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
        public abstract class ModuleComponents {
            private static ulong[] _bitMap;
            internal static BitMask BitMask;
            private static IComponentsWrapper[] _pools;
            private static Action[] _resetActions;
            private static Action[] _reInitActions;
            private static ushort _actionsCount;
            private static ushort _poolsCount;
            private static ushort _bitMapLen;
            
            #region PUBLIC
            [MethodImpl(AggressiveInlining)]
            public static IComponentsWrapper GetPool(ComponentDynId id) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: GetPool, World not initialized");
                #endif
                return _pools[id.Val];
            }

            [MethodImpl(AggressiveInlining)]
            public static ComponentsWrapper<T> GetPool<T>() where T : struct, IComponent {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: GetPool<>, World not initialized");
                #endif
                return default;
            }

            [MethodImpl(AggressiveInlining)]
            public static ushort ComponentsCount(Entity entity) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: ComponentsCount, World not initialized");
                #endif
                return BitMask.Len(entity._id);
            }

            [MethodImpl(AggressiveInlining)]
            public static bool HasAllComponents(Entity entity, byte allBufId) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: HasAllComponents, World not initialized");
                #endif
                return BitMask.HasAll(entity._id, allBufId);
            }

            [MethodImpl(AggressiveInlining)]
            public static bool HasAnyComponents(Entity entity, byte allBufId) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: HasAnyComponents, World not initialized");
                #endif
                return BitMask.HasAny(entity._id, allBufId);
            }

            [MethodImpl(AggressiveInlining)]
            public static bool HasAllAndExcComponents(Entity entity, byte allBufId, byte excBufId) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: HasAllAndExcComponents, World not initialized");
                #endif
                return BitMask.HasAllAndExc(entity._id, allBufId, excBufId);
            }

            [MethodImpl(AggressiveInlining)]
            public static bool NotHasAnyComponents(Entity entity, byte anyBufId) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: NotHasAnyComponents, World not initialized");
                #endif
                return BitMask.NotHasAny(entity._id, anyBufId);
            }
            
            [MethodImpl(AggressiveInlining)]
            public static string ToPrettyStringEntity(Entity entity) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: ToPrettyStringEntity, World not initialized");
                #endif
                var str = "Components:\n";
                var bufId = BitMask.BorrowBuf();
                Array.Copy(_bitMap, entity._id * _bitMapLen, BitMask._buffer, bufId * BitMask._len, _bitMapLen);
                var id = BitMask.GetMinIndexBuffer(bufId);
                while (id >= 0) {
                    str += _pools[id].ToStringComponent(entity);
                    BitMask.DelInBuffer(bufId, (ushort) id);
                    id = BitMask.GetMinIndexBuffer(bufId);
                }
                BitMask.DropBuf(bufId);
                return str;
            }
            #endregion

            #region INTERNAL
            [MethodImpl(AggressiveInlining)]
            internal static void Create(uint baseComponentsCapacity) {
                _pools = new IComponentsWrapper[baseComponentsCapacity];
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

                _bitMapLen = Utils.CalculateMaskLen(_poolsCount);
                _bitMap = new ulong[World.EntitiesCapacity() * _bitMapLen];
                BitMask = new BitMask();
                BitMask.Create(_bitMap, 32, _bitMapLen);
            }

            [MethodImpl(AggressiveInlining)]
            internal static void ReInitialize() {
                var newEntityComponentBitMapLen = Utils.CalculateMaskLen(_poolsCount);

                Array.Resize(ref _bitMap, World.EntitiesCapacity() * newEntityComponentBitMapLen);
                for (var i = World._entityVersionsCount - 1; i > 0; i--) {
                    for (var j = _bitMapLen - 1; j >= 0; j--) {
                        var idx = i * _bitMapLen + j;
                        ref var bits = ref _bitMap[idx];
                        _bitMap[idx + i] = bits;
                        bits = 0UL;
                    }
                }

                _bitMapLen = newEntityComponentBitMapLen;
                BitMask.SetNewBitMap(_bitMap);
                BitMask.ResizeBuffer(_bitMapLen);
            }

            [MethodImpl(AggressiveInlining)]
            internal static ComponentDynId RegisterComponent<C>() where C : struct, IComponent {
                if (ComponentInfo<C>.Has()) {
                    return Components<C>.DynamicId();
                }

                if (_poolsCount == _pools.Length) {
                    Array.Resize(ref _pools, _poolsCount << 1);
                }

                _pools[_poolsCount++] = new ComponentsWrapper<C>();

                ComponentInfo<C>.Register();
                Components<C>.Create(ComponentInfo<C>.Id, BitMask, ComponentInfo<C>.BaseCapacity ?? ComponentInfo.BaseCapacity);

                if (_actionsCount == _reInitActions.Length) {
                    Array.Resize(ref _reInitActions, _actionsCount << 1);
                    Array.Resize(ref _resetActions, _actionsCount << 1);
                }

                _reInitActions[ComponentInfo<C>.Id] = static () => RegisterComponent<C>();
                _resetActions[ComponentInfo<C>.Id] = static () => ComponentInfo<C>.Reset();
                _actionsCount++;

                if (World.IsInitialized() && _poolsCount % 64 == 0) {
                    ReInitialize();
                }

                return Components<C>.DynamicId();
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static void DestroyEntity(Entity entity) {
                var id = BitMask.GetMinIndex(entity._id);
                while (id >= 0) {
                    _pools[id].DeleteFromWorld(entity);
                    id = BitMask.GetMinIndex(entity._id);
                }
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static void CopyEntity(Entity srcEntity, Entity dstEntity) {
                var bufId = BitMask.BorrowBuf();
                Array.Copy(_bitMap, srcEntity._id * _bitMapLen, BitMask._buffer, bufId * BitMask._len, _bitMapLen);
                var id = BitMask.GetMinIndexBuffer(bufId);
                while (id >= 0) {
                    _pools[id].Copy(srcEntity, dstEntity);
                    BitMask.DelInBuffer(bufId, (ushort) id);
                    id = BitMask.GetMinIndexBuffer(bufId);
                }

                BitMask.DropBuf(bufId);
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static void Resize(int cap) {
                for (int i = 0, iMax = _poolsCount; i < iMax; i++) {
                    _pools[i].Resize(cap);
                }
                Array.Resize(ref _bitMap, cap * _bitMapLen);
                BitMask.SetNewBitMap(_bitMap);
            }

            [MethodImpl(AggressiveInlining)]
            internal static void Clear() {
                for (var i = 0; i < _poolsCount; i++) {
                    _pools[i].Clear();
                }

                Array.Clear(_bitMap, 0, _bitMap.Length);
            }

            [MethodImpl(AggressiveInlining)]
            internal static void Destroy() {
                for (var i = 0; i < _poolsCount; i++) {
                    _pools[i].Destroy();
                    _resetActions[i]();
                }

                BitMask.Destroy();
                BitMask = null;
                _pools = null;
                _poolsCount = 0;
                _bitMap = null;
                _bitMapLen = 0;
                ComponentsCounter.Value = -1;
            }

            internal static void SetBasePoolCapacity<T>(uint capacity) where T : struct, IComponent {
                ComponentInfo<T>.BaseCapacity = capacity;
            }

            internal static void SetBasePoolCapacity(uint capacity) {
                ComponentInfo.BaseCapacity = capacity;
            }
            #endregion

            #if ENABLE_IL2CPP
            [Il2CppEagerStaticClassConstruction]
            #endif
            private static class ComponentsCounter {
                public static int Value = -1;
            }

            #if ENABLE_IL2CPP
            [Il2CppEagerStaticClassConstruction]
            #endif
            private static class ComponentInfo {
                public static uint BaseCapacity = 128;
            }

            #if ENABLE_IL2CPP
            [Il2CppEagerStaticClassConstruction]
            #endif
            private static class ComponentInfo<T> where T : struct, IComponent {
                public static ushort Id = ushort.MaxValue;
                public static uint? BaseCapacity;
                public static Type Type;

                public static void Register() {
                    Id = (ushort) Interlocked.Increment(ref ComponentsCounter.Value);
                    Type = typeof(T);
                }

                public static void Reset() {
                    Id = ushort.MaxValue;
                }

                public static bool Has() => Id < ushort.MaxValue;
            }
        }
    }
    
    public struct DeleteComponentsSystem<WorldId, T> : IUpdateSystem where T : struct, IComponent where WorldId : struct, IWorldId {
        [MethodImpl(AggressiveInlining)]
        public void Update() {
            foreach (var entity in Ecs<WorldId>.World.QueryEntities.All<T>()) {
                entity.Delete<T>();
            }
        }
    }
}