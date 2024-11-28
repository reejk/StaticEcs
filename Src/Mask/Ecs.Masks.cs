#if !FFS_ECS_DISABLE_MASKS
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using static System.Runtime.CompilerServices.MethodImplOptions;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

namespace FFS.Libraries.StaticEcs {
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public abstract partial class Ecs<WorldID> {
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public abstract partial class Masks {
            internal static ulong[] _bitMap;
            private static IPoolWrapper[] _pools;
            private static Action[] _resetActions;
            private static Action[] _reInitActions;
            private static ushort _actionsCount;
            private static ushort _poolsCount;

            internal static ushort BitMapLen;

            [MethodImpl(AggressiveInlining)]
            internal static void Create(uint baseComponentsCapacity) {
                _pools = new IPoolWrapper[baseComponentsCapacity];
                _reInitActions ??= new Action[baseComponentsCapacity];
                _resetActions ??= new Action[baseComponentsCapacity];
            }

            [MethodImpl(AggressiveInlining)]
            internal static void Initialize() {
                var count = _actionsCount;
                _actionsCount = 0;
                for (var i = 0; i < count; i++) {
                    _reInitActions[i]();
                }

                BitMapLen = Utils.CalculateMaskLen(_poolsCount);
                _bitMap = new ulong[World.EntitiesCapacity() * BitMapLen];
                BitMaskUtils<WorldID, IMask>.Create(_bitMap, 32, BitMapLen);
            }

            [MethodImpl(AggressiveInlining)]
            internal static void ReInitialize() {
                var newEntityComponentBitMapLen = Utils.CalculateMaskLen(_poolsCount);

                Array.Resize(ref _bitMap, World.EntitiesCapacity() * newEntityComponentBitMapLen);
                for (var i = World._entityVersionsCount - 1; i > 0; i--) {
                    for (var j = BitMapLen - 1; j >= 0; j--) {
                        var idx = i * BitMapLen + j;
                        ref var bits = ref _bitMap[idx];
                        _bitMap[idx + i] = bits;
                        bits = 0UL;
                    }
                }

                BitMapLen = newEntityComponentBitMapLen;
                BitMaskUtils<WorldID, IMask>.SetNewBitMap(_bitMap);
                BitMaskUtils<WorldID, IMask>.ResizeBuffer(BitMapLen);
            }

            [MethodImpl(AggressiveInlining)]
            internal static MaskDynId RegisterMask<T>() where T : struct, IMask {
                #if DEBUG
                if (World.Status == WorldStatus.NotCreated) throw new Exception($"World<{typeof(WorldID)}>, Method: RegisterMask, World not created");
                #endif
                if (MaskInfo<T>.Has()) {
                    return GetDynamicId<T>();
                }

                MaskInfo<T>.Register();
                Pool<T>.Create(MaskInfo<T>.Id);
                if (_poolsCount == _pools.Length) {
                    Array.Resize(ref _pools, _poolsCount << 1);
                }

                _pools[_poolsCount++] = new PoolWrapper<T>();

                if (_actionsCount == _reInitActions.Length) {
                    Array.Resize(ref _reInitActions, _actionsCount << 1);
                    Array.Resize(ref _resetActions, _actionsCount << 1);
                }

                _reInitActions[MaskInfo<T>.Id] = static () => RegisterMask<T>();
                _resetActions[MaskInfo<T>.Id] = static () => MaskInfo<T>.Reset();
                _actionsCount++;

                if (World.IsInitialized() && _poolsCount % 64 == 0) {
                    ReInitialize();
                }

                return GetDynamicId<T>();
            }

            [MethodImpl(AggressiveInlining)]
            public static MaskDynId GetDynamicId<T>() where T : struct, IMask {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: GetMaskDynamicId, World not initialized");
                #endif
                return new MaskDynId(Pool<T>.Id());
            }

            [MethodImpl(AggressiveInlining)]
            public static ushort MasksCount(Entity entity) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: MasksCount, World not initialized");
                #endif
                return BitMaskUtils<WorldID, IMask>.Len(entity._id);
            }

            [MethodImpl(AggressiveInlining)]
            public static bool HasAllMasks(Entity entity, byte allBufId) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: HasAllMasks, World not initialized");
                #endif
                return BitMaskUtils<WorldID, IMask>.HasAll(entity._id, allBufId);
            }

            [MethodImpl(AggressiveInlining)]
            public static bool HasAnyMasks(Entity entity, byte anyBufId) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: HasAnyMasks, World not initialized");
                #endif
                return BitMaskUtils<WorldID, IMask>.HasAny(entity._id, anyBufId);
            }

            [MethodImpl(AggressiveInlining)]
            public static bool HasAllAndExcMasks(Entity entity, byte allBufId, byte excBufId) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: HasAllAndExcMasks, World not initialized");
                #endif
                return BitMaskUtils<WorldID, IMask>.HasAllAndExc(entity._id, allBufId, excBufId);
            }

            [MethodImpl(AggressiveInlining)]
            public static bool NotHasAnyMasks(Entity entity, byte excBufId) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: NotHasAnyMasks, World not initialized");
                #endif
                return BitMaskUtils<WorldID, IMask>.NotHasAny(entity._id, excBufId);
            }

            [MethodImpl(AggressiveInlining)]
            public static IPoolWrapper GetPool(MaskDynId id) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: GetMasksPool, World not initialized");
                #endif
                return _pools[id.Val];
            }

            [MethodImpl(AggressiveInlining)]
            public static PoolWrapper<T> GetPool<T>() where T : struct, IMask {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: GetMasksPool, World not initialized");
                #endif
                return default;
            }

            [MethodImpl(AggressiveInlining)]
            internal static void Resize(int cap) {
                Array.Resize(ref _bitMap, cap * BitMapLen);
                BitMaskUtils<WorldID, IMask>.SetNewBitMap(_bitMap);
            }

            [MethodImpl(AggressiveInlining)]
            internal static void DestroyEntity(Entity entity) {
                BitMaskUtils<WorldID, IMask>.ClearAll(entity._id);
            }
            
            [MethodImpl(AggressiveInlining)]
            public static string ToPrettyStringEntity(Entity entity) {
                var str = "Masks:\n";
                var bufId = BitMaskUtils<WorldID, IMask>.BorrowBuf();
                Array.Copy(_bitMap, entity._id * BitMapLen, BitMaskUtils<WorldID, IMask>._buffer, bufId * BitMaskUtils<WorldID, IMask>._len, BitMapLen);
                var id = BitMaskUtils<WorldID, IMask>.GetMinIndexBuffer(bufId);
                while (id >= 0) {
                    str += _pools[id].ToStringComponent(entity);
                    BitMaskUtils<WorldID, IMask>.DelInBuffer(bufId, (ushort) id);
                    id = BitMaskUtils<WorldID, IMask>.GetMinIndexBuffer(bufId);
                }
                BitMaskUtils<WorldID, IMask>.DropBuf(bufId);
                return str;
            }

            [MethodImpl(AggressiveInlining)]
            internal static void CopyEntity(Entity srcEntity, Entity dstEntity) {
                Array.Copy(_bitMap, srcEntity._id * BitMapLen, _bitMap, dstEntity._id * BitMapLen, BitMapLen);
            }

            [MethodImpl(AggressiveInlining)]
            internal static void SetMaskBit(Entity entity, ushort index) {
                BitMaskUtils<WorldID, IMask>.Set(entity._id, index);
            }

            [MethodImpl(AggressiveInlining)]
            internal static void UnsetMaskBit(Entity entity, ushort index) {
                BitMaskUtils<WorldID, IMask>.Del(entity._id, index);
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static void Clear() {
                for (var i = 0; i < _poolsCount; i++) {
                    _pools[i].Clear();
                }

                Array.Clear(_bitMap, 0, _bitMap.Length);
            }

            internal static void Destroy() {
                for (var i = 0; i < _actionsCount; i++) {
                    _resetActions[i]();
                }

                BitMaskUtils<WorldID, IMask>.Destroy();
                _pools = null;
                _poolsCount = 0;
                _bitMap = null;
                BitMapLen = 0;
                MaskCounter.Value = -1;
            }

            #if ENABLE_IL2CPP
            [Il2CppEagerStaticClassConstruction]
            #endif
            private static class MaskCounter {
                public static int Value = -1;
            }

            #if ENABLE_IL2CPP
            [Il2CppEagerStaticClassConstruction]
            #endif
            private static class MaskInfo<T> where T : struct, IMask {
                public static ushort Id = ushort.MaxValue;
                public static Type Type;

                public static void Register() {
                    Id = (ushort) Interlocked.Increment(ref MaskCounter.Value);
                    Type = typeof(T);
                }

                public static void Reset() {
                    Id = ushort.MaxValue;
                }

                public static bool Has() => Id < ushort.MaxValue;
            }
        }
    }
}
#endif