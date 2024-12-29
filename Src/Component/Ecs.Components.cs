using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
        internal abstract class ModuleComponents {
            #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
            internal static List<IComponentsDebugEventListener> _debugEventListeners;
            #endif
            
            internal static BitMask BitMask;

            private static ulong[] _bitMap;
            private static IComponentsWrapper[] _pools;
            private static Dictionary<Type, int> _poolsByType;
            private static Action[] _resetActions;
            private static Action[] _reInitActions;
            private static ushort _actionsCount;
            private static ushort _poolsCount;
            private static ushort _bitMapLen;

            [MethodImpl(AggressiveInlining)]
            internal static void Create(uint baseComponentsCapacity) {
                _pools = new IComponentsWrapper[baseComponentsCapacity];
                _poolsByType = new Dictionary<Type, int>();
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
                BitMask ??= new BitMask();
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
                    return Components<C>.Value.DynamicId();
                }

                if (_poolsCount == _pools.Length) {
                    Array.Resize(ref _pools, _poolsCount << 1);
                }

                _pools[_poolsCount] = new ComponentsWrapper<C>();
                _poolsByType[typeof(C)] = _poolsCount;
                ComponentInfo<C>.Register(_poolsCount++);
                BitMask ??= new BitMask();
                Components<C>.Value.Create(ComponentInfo<C>.Id, BitMask, ComponentInfo<C>.BaseCapacity ?? ComponentInfo.BaseCapacity);

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

                return Components<C>.Value.DynamicId();
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static IComponentsWrapper GetPool(ComponentDynId id) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: GetPool, World not initialized");
                #endif
                return _pools[id.Value];
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static IComponentsWrapper GetPool(Type componentType) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: GetPool, World not initialized");
                #endif
                return _pools[_poolsByType[componentType]];
            }

            [MethodImpl(AggressiveInlining)]
            internal static ComponentsWrapper<T> GetPool<T>() where T : struct, IComponent {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: GetPool<>, World not initialized");
                #endif
                return default;
            }

            [MethodImpl(AggressiveInlining)]
            internal static ushort ComponentsCount(Entity entity) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: ComponentsCount, World not initialized");
                #endif
                return BitMask.Len(entity._id);
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static string ToPrettyStringEntity(Entity entity) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
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
            
            [MethodImpl(AggressiveInlining)]
            internal static void GetAllComponents(Entity entity, List<IComponent> result) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: GetComponents, World not initialized");
                #endif
                result.Clear();
                var bufId = BitMask.BorrowBuf();
                Array.Copy(_bitMap, entity._id * _bitMapLen, BitMask._buffer, bufId * BitMask._len, _bitMapLen);
                var id = BitMask.GetMinIndexBuffer(bufId);
                while (id >= 0) {
                    result.Add(_pools[id].GetRaw(entity));
                    BitMask.DelInBuffer(bufId, (ushort) id);
                    id = BitMask.GetMinIndexBuffer(bufId);
                }
                BitMask.DropBuf(bufId);
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
                BitMask = default;
                _pools = default;
                _poolsByType = default;
                _poolsCount = default;
                _bitMap = default;
                _bitMapLen = default;
                #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
                _debugEventListeners = null;
                #endif
            }

            internal static void SetBasePoolCapacity<T>(uint capacity) where T : struct, IComponent {
                ComponentInfo<T>.BaseCapacity = capacity;
            }

            internal static void SetBasePoolCapacity(uint capacity) {
                ComponentInfo.BaseCapacity = capacity;
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

                public static void Register(ushort val) {
                    Id = val;
                }

                public static void Reset() {
                    Id = ushort.MaxValue;
                }

                public static bool Has() => Id < ushort.MaxValue;
            }
        }
        
        #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
        public interface IComponentsDebugEventListener {
            void OnComponentAdd<T>(Entity entity, ref T component) where T : struct, IComponent;
            void OnComponentPut<T>(Entity entity, ref T component) where T : struct, IComponent;
            void OnComponentDelete<T>(Entity entity, ref T component) where T : struct, IComponent;
        }
        #endif
    }
    
    public struct DeleteComponentsSystem<WorldId, T> : IUpdateSystem where T : struct, IComponent where WorldId : struct, IWorldId {
        [MethodImpl(AggressiveInlining)]
        public void Update() {
            Ecs<WorldId>.World.QueryEntities.For<All<T>>().DeleteForAll<T>();
        }
    }
}