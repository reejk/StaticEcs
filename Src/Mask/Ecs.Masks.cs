#if !FFS_ECS_DISABLE_MASKS
using System;
using System.Collections.Generic;
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
        internal abstract class ModuleMasks {
            #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
            internal static List<IMaskDebugEventListener> _debugEventListeners;
            #endif

            internal static BitMask BitMask;
            
            private static ulong[] _bitMap;
            private static IMasksWrapper[] _pools;
            private static Action[] _resetActions;
            private static Action[] _reInitActions;
            private static ushort _actionsCount;
            private static ushort _poolsCount;
            private static ushort BitMapLen;

            [MethodImpl(AggressiveInlining)]
            internal static void Create(uint baseComponentsCapacity) {
                _pools = new IMasksWrapper[baseComponentsCapacity];
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
                BitMask ??= new BitMask();
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
                BitMask.SetNewBitMap(_bitMap);
                BitMask.ResizeBuffer(BitMapLen);
            }

            [MethodImpl(AggressiveInlining)]
            internal static MaskDynId RegisterMask<T>() where T : struct, IMask {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (World.Status == WorldStatus.NotCreated) throw new Exception($"World<{typeof(WorldID)}>, Method: RegisterMask, World not created");
                #endif
                if (MaskInfo<T>.Has()) {
                    return Masks<T>.Value.DynamicId();
                }
                
                BitMask ??= new BitMask();
                
                if (_poolsCount == _pools.Length) {
                    Array.Resize(ref _pools, _poolsCount << 1);
                }
                _pools[_poolsCount] = new MasksWrapper<T>();
                
                MaskInfo<T>.Register(_poolsCount);
                Masks<T>.Value.Create(MaskInfo<T>.Id, BitMask);

                if (_actionsCount == _reInitActions.Length) {
                    Array.Resize(ref _reInitActions, _actionsCount << 1);
                    Array.Resize(ref _resetActions, _actionsCount << 1);
                }

                _reInitActions[_poolsCount] = static () => RegisterMask<T>();
                _resetActions[_poolsCount] = static () => MaskInfo<T>.Reset();
                
                _actionsCount++;
                _poolsCount++;
                
                if (World.IsInitialized() && _poolsCount % 64 == 0) {
                    ReInitialize();
                }

                return Masks<T>.Value.DynamicId();
            }

            [MethodImpl(AggressiveInlining)]
            internal static ushort MasksCount(Entity entity) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: MasksCount, World not initialized");
                #endif
                return BitMask.Len(entity._id);
            }

            [MethodImpl(AggressiveInlining)]
            internal static IMasksWrapper GetPool(MaskDynId id) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: GetMasksPool, World not initialized");
                #endif
                return _pools[id.Val];
            }

            [MethodImpl(AggressiveInlining)]
            internal static MasksWrapper<T> GetPool<T>() where T : struct, IMask {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: GetMasksPool, World not initialized");
                #endif
                return default;
            }

            [MethodImpl(AggressiveInlining)]
            internal static void Resize(int cap) {
                Array.Resize(ref _bitMap, cap * BitMapLen);
                BitMask.SetNewBitMap(_bitMap);
            }

            [MethodImpl(AggressiveInlining)]
            internal static void DestroyEntity(Entity entity) {
                BitMask.ClearAll(entity._id);
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static string ToPrettyStringEntity(Entity entity) {
                var str = "Masks:\n";
                var bufId = BitMask.BorrowBuf();
                Array.Copy(_bitMap, entity._id * BitMapLen, BitMask._buffer, bufId * BitMask._len, BitMapLen);
                var id = BitMask.GetMinIndexBuffer(bufId);
                while (id >= 0) {
                    str += _pools[id].ToStringComponent(entity);
                    BitMask.DelInBuffer(bufId, (ushort) id);
                    id = BitMask.GetMinIndexBuffer(bufId);
                }
                BitMask.DropBuf(bufId);
                return str;
            }

            [MethodImpl(AggressiveInlining)]
            internal static void CopyEntity(Entity srcEntity, Entity dstEntity) {
                Array.Copy(_bitMap, srcEntity._id * BitMapLen, _bitMap, dstEntity._id * BitMapLen, BitMapLen);
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

                BitMask.Destroy();
                BitMask = null;
                _pools = null;
                _poolsCount = 0;
                _bitMap = null;
                BitMapLen = 0;
                #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
                _debugEventListeners = null;
                #endif
            }

            #if ENABLE_IL2CPP
            [Il2CppEagerStaticClassConstruction]
            #endif
            private static class MaskInfo<T> where T : struct, IMask {
                public static ushort Id = ushort.MaxValue;

                [MethodImpl(AggressiveInlining)]
                public static void Register(ushort val) {
                    Id = val;
                }

                [MethodImpl(AggressiveInlining)]
                public static void Reset() {
                    Id = ushort.MaxValue;
                }

                [MethodImpl(AggressiveInlining)]
                public static bool Has() => Id < ushort.MaxValue;
            }
        }
        
        #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
        public interface IMaskDebugEventListener {
            void OnMaskSet<T>(Entity entity) where T : struct, IMask;
            void OnMaskDelete<T>(Entity entity) where T : struct, IMask;
        }
        #endif

    }
}
#endif