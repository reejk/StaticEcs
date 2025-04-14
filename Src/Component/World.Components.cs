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
    public abstract partial class World<WorldType> {
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppEagerStaticClassConstruction]
        #endif
        internal partial struct ModuleComponents {
            public static ModuleComponents Value;
            
            #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
            internal List<IComponentsDebugEventListener> _debugEventListeners;
            #endif
            
            internal BitMask BitMask;
            private IComponentsWrapper[] _pools;
            private Dictionary<Type, int> _poolIdxByType;
            private ushort _poolsCount;

            [MethodImpl(AggressiveInlining)]
            internal void Create(uint baseComponentsCapacity) {
                _pools = new IComponentsWrapper[baseComponentsCapacity];
                _poolIdxByType = new Dictionary<Type, int>();
                BitMask = new BitMask();
                #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
                _debugEventListeners ??= new List<IComponentsDebugEventListener>();
                #endif
            }

            [MethodImpl(AggressiveInlining)]
            internal void Initialize() {
                BitMask.Create(EntitiesCapacity(), 32, Utils.CalculateMaskLen(_poolsCount), true);
            }

            [MethodImpl(AggressiveInlining)]
            internal ushort RegisterComponentType<T>(uint capacity, AutoInitHandler<T> autoInit = null, AutoResetHandler<T> autoReset = null, AutoCopyHandler<T> autoCopy = null, AutoInitHandler<T> autoPutInit = null) where T : struct, IComponent {
                if (Components<T>.Value.IsRegistered()) {
                    return Components<T>.Value.DynamicId();
                }

                if (_poolsCount == _pools.Length) {
                    Array.Resize(ref _pools, _poolsCount << 1);
                }

                _pools[_poolsCount] = new ComponentsWrapper<T>();
                _poolIdxByType[typeof(T)] = _poolsCount;
                Components<T>.Value.Create(_poolsCount, BitMask, EntitiesCapacity(), autoInit, autoReset, autoCopy, autoPutInit, capacity);
                #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
                Components<T>.Value.debugEventListeners = _debugEventListeners;
                #endif
                _poolsCount++;
                
                return Components<T>.Value.DynamicId();
            }
            
            [MethodImpl(AggressiveInlining)]
            internal List<IRawPool> GetAllRawsPools() {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!IsWorldInitialized()) throw new Exception($"World<{typeof(WorldType)}>, Method: GetAllRawsPools, World not initialized");
                #endif
                var pools = new List<IRawPool>();
                for (int i = 0; i < _poolsCount; i++) {
                    pools.Add(_pools[i]);
                }
                return pools;
            }
            
            [MethodImpl(AggressiveInlining)]
            internal IComponentsWrapper GetPool(ushort id) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!IsWorldInitialized()) throw new Exception($"World<{typeof(WorldType)}>, Method: GetPool, World not initialized");
                if (id >= _poolsCount) throw new Exception($"World<{typeof(WorldType)}>, Method: GetPool, Component type for dyn id {id} not registered");
                #endif
                return _pools[id];
            }
            
            [MethodImpl(AggressiveInlining)]
            internal IComponentsWrapper GetPool(Type componentType) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!IsWorldInitialized()) throw new Exception($"World<{typeof(WorldType)}>, Method: GetPool, World not initialized");
                if (!_poolIdxByType.ContainsKey(componentType)) throw new Exception($"World<{typeof(WorldType)}>, Method: GetPool, Component type {componentType} not registered");
                #endif
                return _pools[_poolIdxByType[componentType]];
            }

            [MethodImpl(AggressiveInlining)]
            internal ComponentsWrapper<T> GetPool<T>() where T : struct, IComponent {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!IsWorldInitialized()) throw new Exception($"World<{typeof(WorldType)}>, Method: GetPool<{typeof(T)}>, World not initialized");
                if (!Components<T>.Value.IsRegistered()) throw new Exception($"World<{typeof(WorldType)}>, Method: GetPool<{typeof(T)}>, Component type not registered");
                #endif
                return default;
            }
            
            [MethodImpl(AggressiveInlining)]
            internal bool TryGetPool(ushort id, out IComponentsWrapper pool) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!IsWorldInitialized()) throw new Exception($"World<{typeof(WorldType)}>, Method: GetPool, World not initialized");
                #endif
                if (id >= _poolsCount) {
                    pool = default;
                    return false;
                }
                
                pool = _pools[id];
                return true;
            }
            
            [MethodImpl(AggressiveInlining)]
            internal bool TryGetPool(Type componentType, out IComponentsWrapper pool) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!IsWorldInitialized()) throw new Exception($"World<{typeof(WorldType)}>, Method: GetPool, World not initialized");
                #endif
                if (!_poolIdxByType.TryGetValue(componentType, out var idx)) {
                    pool = default;
                    return false;
                }
                
                pool = _pools[idx];
                return true;
            }

            [MethodImpl(AggressiveInlining)]
            internal bool TryGetPool<T>(out ComponentsWrapper<T> pool) where T : struct, IComponent {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!IsWorldInitialized()) throw new Exception($"World<{typeof(WorldType)}>, Method: GetPool<{typeof(T)}>, World not initialized");
                #endif
                pool = default;
                return Components<T>.Value.IsRegistered();
            }

            [MethodImpl(AggressiveInlining)]
            internal ushort ComponentsCount(Entity entity, bool withDisabled) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!IsWorldInitialized()) throw new Exception($"World<{typeof(WorldType)}>, Method: ComponentsCount, World not initialized");
                #endif
                return withDisabled ? BitMask.LenWithDisabled(entity._id) : BitMask.Len(entity._id);
            }
            
            [MethodImpl(AggressiveInlining)]
            internal string ToPrettyStringEntity(Entity entity, bool withDisabled) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!IsWorldInitialized()) throw new Exception($"World<{typeof(WorldType)}>, Method: ToPrettyStringEntity, World not initialized");
                #endif
                var str = "Components:\n";
                var bufId = BitMask.BorrowBuf();
                if (withDisabled) {
                    BitMask.CopyWithDisabledToBuffer(entity._id, bufId);
                } else {
                    BitMask.CopyToBuffer(entity._id, bufId);
                }
                while (BitMask.GetMinIndexBuffer(bufId, out var id)) {
                    str += _pools[id].ToStringComponent(entity);
                    BitMask.DelInBuffer(bufId, (ushort) id);
                }
                BitMask.DropBuf();
                return str;
            }
            
            [MethodImpl(AggressiveInlining)]
            internal void GetAllComponents(Entity entity, List<IComponent> result, bool withDisabled) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!IsWorldInitialized()) throw new Exception($"World<{typeof(WorldType)}>, Method: GetComponents, World not initialized");
                #endif
                result.Clear();
                var bufId = BitMask.BorrowBuf();
                if (withDisabled) {
                    BitMask.CopyWithDisabledToBuffer(entity._id, bufId);
                } else {
                    BitMask.CopyToBuffer(entity._id, bufId);
                }
                while (BitMask.GetMinIndexBuffer(bufId, out var id)) {
                    result.Add(_pools[id].GetRaw(entity));
                    BitMask.DelInBuffer(bufId, (ushort) id);
                }
                BitMask.DropBuf();
            }
            
            [MethodImpl(AggressiveInlining)]
            internal void DestroyEntity(Entity entity) {
                while (BitMask.GetMinIndexWithDisabled(entity._id, out var id)) {
                    _pools[id].DeleteInternal(entity);
                }
            }
            
            [MethodImpl(AggressiveInlining)]
            internal void CopyEntity(Entity srcEntity, Entity dstEntity, bool withDisabled) {
                var bufId = BitMask.BorrowBuf();
                if (withDisabled) {
                    BitMask.CopyWithDisabledToBuffer(srcEntity._id, bufId);
                } else {
                    BitMask.CopyToBuffer(srcEntity._id, bufId);
                }
                while (BitMask.GetMinIndexBuffer(bufId, out var id)) {
                    _pools[id].Copy(srcEntity, dstEntity);
                    BitMask.DelInBuffer(bufId, (ushort) id);
                }
                BitMask.DropBuf();
            }
            
            [MethodImpl(AggressiveInlining)]
            internal void Resize(uint size) {
                for (uint i = 0, iMax = _poolsCount; i < iMax; i++) {
                    _pools[i].Resize(size);
                }
                BitMask.ResizeBitMap(size);
            }

            [MethodImpl(AggressiveInlining)]
            internal void Clear() {
                for (var i = 0; i < _poolsCount; i++) {
                    _pools[i].Clear();
                }
                BitMask.Clear();
            }

            [MethodImpl(AggressiveInlining)]
            internal void Destroy() {
                for (var i = 0; i < _poolsCount; i++) {
                    _pools[i].Destroy();
                }

                BitMask.Destroy();
                BitMask = default;
                _pools = default;
                _poolIdxByType = default;
                _poolsCount = default;
                #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
                _debugEventListeners = null;
                #endif
            }
            
            #if ENABLE_IL2CPP
            [Il2CppSetOption(Option.NullChecks, false)]
            [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
            #endif
            internal struct MaskCache<M> where M : struct, IComponentMasks {
                internal static MaskCache<M> Cache;
            
                internal uint BufId;
                private ushort Version;
                internal byte Count;

                [MethodImpl(AggressiveInlining)]
                public void This(out uint bufId, out ushort count) {
                    if (Version != runtimeVersion) {
                        SetMask();
                    }

                    count = Count;
                    bufId = BufId;
                }
                
                [MethodImpl(AggressiveInlining)]
                public void This(M types, out uint bufId, out ushort count) {
                    if (Version != runtimeVersion) {
                        SetMask(types);
                    }

                    count = Count;
                    bufId = BufId;
                }

                private void SetMask(M types = default) {
                    #if DEBUG || FFS_ECS_ENABLE_DEBUG
                    if (Status != WorldStatus.Initialized) throw new Exception($"World<{typeof(WorldType)}>>, World not initialized");
                    #endif
                    var buf = Value.BitMask.BorrowBuf();
                    types.SetBitMask<WorldType>(buf);
                    var buffer = Value.BitMask.AddIndexedBuffer(buf);
                    Value.BitMask.DropBuf();
                    BufId = buffer.index;
                    Count = buffer.count;
                    Version = runtimeVersion;
                }
            }
        }
        
        #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
        public interface IComponentsDebugEventListener {
            void OnComponentRef<T>(Entity entity, ref T component) where T : struct, IComponent;
            void OnComponentRefMut<T>(Entity entity, ref T component) where T : struct, IComponent;
            void OnComponentAdd<T>(Entity entity, ref T component) where T : struct, IComponent;
            void OnComponentPut<T>(Entity entity, ref T component) where T : struct, IComponent;
            void OnComponentDelete<T>(Entity entity, ref T component) where T : struct, IComponent;
        }
        #endif
    }
    
    public struct DeleteComponentsSystem<WorldType, T> : IUpdateSystem where T : struct, IComponent where WorldType : struct, IWorldType {
        [MethodImpl(AggressiveInlining)]
        public void Update() {
            World<WorldType>.QueryEntities.For<All<T>>().DeleteForAll<T>();
        }
    }
}