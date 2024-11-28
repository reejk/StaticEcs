using System;
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
        public abstract partial class Components {
            #if ENABLE_IL2CPP
            [Il2CppSetOption(Option.NullChecks, false)]
            [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
            #endif
            public abstract class Pool<T> where T : struct, IComponent {
                internal static ushort id;
                private static Entity[] _entities;
                private static int _componentsCount;
                private static T[] _data;
                private static int[] _dataIdxByEntityId;

                #if DEBUG
                private static int _blockers;
                #endif

                static Pool() {
                   RegisterComponent<T>();
                }

                internal static void Create(ushort componentId, uint baseCapacity = 128) {
                    id = componentId;
                    _entities = new Entity[baseCapacity];
                    _data = new T[baseCapacity];
                    _componentsCount = 0;
                    _dataIdxByEntityId = new int[World.EntitiesCapacity()];
                }

                [MethodImpl(AggressiveInlining)]
                public static ushort Id() => id;

                [MethodImpl(AggressiveInlining)]
                public static PoolWrapper<T> Wrap() => default;

                [MethodImpl(AggressiveInlining)]
                public static ref T RefMut(Entity entity) {
                    #if DEBUG
                    if (World.EntityVersion(entity) < 0) throw new Exception($"ComponentPool<{typeof(WorldID)}, {typeof(T)}>, Method: RefMut, cannot access ID - {id} from deleted entity");
                    if (!Has(entity)) throw new Exception($"ComponentPool<{typeof(WorldID)}, {typeof(T)}>, Method: RefMut, ID - {entity._id} is missing on an entity");
                    #endif
                    return ref _data[_dataIdxByEntityId[entity._id] - 1];
                }
                
                [MethodImpl(AggressiveInlining)]
                public static ref readonly T Ref(Entity entity) {
                    #if DEBUG
                    if (World.EntityVersion(entity) < 0) throw new Exception($"ComponentPool<{typeof(WorldID)}, {typeof(T)}>, Method: Ref, cannot access ID - {id} from deleted entity");
                    if (!Has(entity)) throw new Exception($"ComponentPool<{typeof(WorldID)}, {typeof(T)}>, Method: Ref, ID - {entity._id} is missing on an entity");
                    #endif
                    return ref _data[_dataIdxByEntityId[entity._id] - 1];
                }

                [MethodImpl(AggressiveInlining)]
                public static ref T Add(Entity entity) {
                    #if DEBUG
                    if (World.EntityVersion(entity) < 0) throw new Exception($"ComponentPool<{typeof(WorldID)}, {typeof(T)}>, Method: Add, cannot access ID - {id} from deleted entity");
                    if (!Has(entity)) throw new Exception($"ComponentPool<{typeof(WorldID)}, {typeof(T)}>, Method: Add, ID - {entity._id} is missing on an entity");
                    #endif

                    if (_entities.Length == _componentsCount) {
                        ResizeData(_componentsCount << 1);
                    }

                    var idx = _componentsCount;
                    _componentsCount++;
                    _entities[idx] = entity;
                    _dataIdxByEntityId[entity._id] = _componentsCount;

                    SetComponentBit(entity, id);

                    ref var data = ref _data[idx];
                    if (AutoHandlers<T>.Init != null) {
                        AutoHandlers<T>.Init(ref data);
                    }

                    return ref data;
                }
                
                [MethodImpl(AggressiveInlining)]
                public static void Put(Entity entity, T component) {
                    #if DEBUG
                    if (!IsNotBlocked()) throw new Exception($"ComponentPool<{typeof(WorldID)}, {typeof(T)}>, Method: Add,  component pool cannot be changed, it is in read-only mode due to multiple accesses");
                    #endif
                    if (Has(entity)) {
                        RefMut(entity) = component;
                        return;
                    }
                    
                    if (_entities.Length == _componentsCount) {
                        ResizeData(_componentsCount << 1);
                    }

                    var idx = _componentsCount;
                    _componentsCount++;
                    _entities[idx] = entity;
                    _dataIdxByEntityId[entity._id] = _componentsCount;

                    SetComponentBit(entity, id);

                    _data[idx] = component;
                }

                [MethodImpl(AggressiveInlining)]
                public static ref T TryAdd(Entity entity) {
                    return ref Has(entity)
                        ? ref RefMut(entity)
                        : ref Add(entity);
                }
                
                [MethodImpl(AggressiveInlining)]
                public static ref T TryAdd(Entity entity, out bool added) {
                    added = !Has(entity);
                    return ref added
                        ? ref Add(entity)
                        : ref RefMut(entity);
                }

                [MethodImpl(AggressiveInlining)]
                public static bool Has(Entity entity) {
                    #if DEBUG
                    if (World.EntityVersion(entity) < 0) throw new Exception($"ComponentPool<{typeof(WorldID)}, {typeof(T)}>, Method: Has, cannot access ID - {id} from deleted entity");
                    #endif
                    return _dataIdxByEntityId[entity._id] > 0;
                }

                [MethodImpl(AggressiveInlining)]
                internal static bool Has(Entity entity, out int internalId) {
                    #if DEBUG
                    if (World.EntityVersion(entity) < 0) throw new Exception($"ComponentPool<{typeof(WorldID)}, {typeof(T)}>, Method: Has, cannot access ID - {id} from deleted entity");
                    #endif
                    internalId = _dataIdxByEntityId[entity._id] - 1;
                    return internalId >= 0;
                }

                [MethodImpl(AggressiveInlining)]
                public static bool Del(Entity entity) {
                    return DelInternal(entity, false);
                }

                [MethodImpl(AggressiveInlining)]
                public static bool DelFromWorld(Entity entity) {
                    return DelInternal(entity, true);
                }

                [MethodImpl(AggressiveInlining)]
                private static bool DelInternal(Entity entity, bool fromWorld) {
                    #if DEBUG
                    if (World.EntityVersion(entity) < 0) throw new Exception($"ComponentPool<{typeof(WorldID)}, {typeof(T)}>, Method: DelInternal, cannot access ID - {id} from deleted entity");
                    if (!IsNotBlocked()) throw new Exception($"ComponentPool<{typeof(WorldID)}, {typeof(T)}>, Method: DelInternal,  component pool cannot be changed, it is in read-only mode due to multiple accesses");
                    #endif

                    ref var idxRef = ref _dataIdxByEntityId[entity._id];
                    var idx = idxRef - 1;
                    if (idx >= 0) {
                        idxRef = 0;
                        _componentsCount--;

                        ResetComponent(idx);

                        if (idx < _componentsCount) {
                            var e = _entities[_componentsCount];
                            _entities[idx] = e;
                            _dataIdxByEntityId[e._id] = idx + 1;
                            (_data[idx], _data[_componentsCount]) = (_data[_componentsCount], _data[idx]);
                        }

                        UnsetComponentBit(entity, id, fromWorld);
                        return true;
                    }

                    return false;
                }

                private static void ResetComponent(int idx) {
                    if (AutoHandlers<T>.Reset != null) {
                        AutoHandlers<T>.Reset(ref _data[idx]);
                    } else {
                        _data[idx] = default;
                    }
                }

                [MethodImpl(AggressiveInlining)]
                internal static void Resize(int cap) {
                    Array.Resize(ref _dataIdxByEntityId, cap);
                }

                [MethodImpl(AggressiveInlining)]
                public static void Copy(Entity src, Entity dst) {
                    #if DEBUG
                    if (World.EntityVersion(src) < 0) throw new Exception($"ComponentPool<{typeof(WorldID)}, {typeof(T)}>, Method: Copy, cannot access ID - {id} from deleted entity");
                    if (World.EntityVersion(dst) < 0) throw new Exception($"ComponentPool<{typeof(WorldID)}, {typeof(T)}>, Method: Copy, cannot access ID - {id} from deleted entity");
                    if (!IsNotBlocked()) throw new Exception($"ComponentPool<{typeof(WorldID)}, {typeof(T)}>, Method: Copy,  component pool cannot be changed, it is in read-only mode due to multiple accesses");
                    #endif

                    if (Has(src)) {
                        ref var srcData = ref RefMut(src);
                        if (!Has(dst)) {
                            Add(dst);
                        }

                        if (AutoHandlers<T>.Copy != null) {
                            AutoHandlers<T>.Copy(ref srcData, ref RefMut(dst));
                        } else {
                            RefMut(dst) = srcData;
                        }
                    }
                }

                [MethodImpl(AggressiveInlining)]
                public static int Count() => _componentsCount;

                [MethodImpl(AggressiveInlining)]
                internal static void SetDataIfCountLess(ref int count, ref Entity[] entities) {
                    if (_componentsCount < count || count == 0) {
                        count = _componentsCount;
                        entities = _entities;
                    }
                }

                [MethodImpl(AggressiveInlining)]
                public static Entity[] EntitiesData() => _entities;
                
                [MethodImpl(AggressiveInlining)]
                public static string ToStringComponent(Entity entity) {
                    return $" - [{id}] {typeof(T).Name} ( {RefMut(entity)} )\n";
                }

                [MethodImpl(AggressiveInlining)]
                public static T[] Data() => _data;

                [MethodImpl(AggressiveInlining)]
                internal static void Destroy() {
                    AutoHandlers<T>.Destroy();
                    _entities = null;
                    _data = null;
                    _dataIdxByEntityId = null;
                    _componentsCount = 0;
                    id = 0;
                }

                #if DEBUG
                [MethodImpl(AggressiveInlining)]
                internal static void AddBlocker(int amount) {
                    _blockers += amount;
                    #if DEBUG
                    if (_blockers < 0) throw new Exception($"ComponentPool<{typeof(WorldID)}, {typeof(T)}>, Method: AddBlocker, incorrect pool user balance when attempting to release");
                    #endif
                }
                #endif

                [MethodImpl(AggressiveInlining)]
                internal static bool IsNotBlocked() {
                    #if DEBUG
                    return _blockers <= 1;
                    #endif
                    return true;
                }
                
                [MethodImpl(AggressiveInlining)]
                internal static void EnsureSize(int size) {
                    if  (_componentsCount + size >= _entities.Length) {
                        ResizeData(Utils.CalculateSize(_componentsCount + size));
                    }
                }

                [MethodImpl(NoInlining)]
                private static void ResizeData(int newSize) {
                    Array.Resize(ref _entities, newSize);
                    Array.Resize(ref _data, newSize);
                }

                [MethodImpl(AggressiveInlining)]
                public static void Clear() {
                    Array.Clear(_entities, 0, _entities.Length);
                    Array.Clear(_data, 0, _data.Length);
                    Array.Clear(_dataIdxByEntityId, 0, _dataIdxByEntityId.Length);
                    _componentsCount = 0;
                }
            }
            
            #if ENABLE_IL2CPP
            [Il2CppEagerStaticClassConstruction]
            #endif
            public static class AutoHandlers<T> where T : struct, IComponent {
                internal static AutoInitHandler<T> Init;
                internal static AutoResetHandler<T> Reset;
                internal static AutoCopyHandler<T> Copy;

                [MethodImpl(AggressiveInlining)]
                public static void SetAutoInit(AutoInitHandler<T> handler) {
                    #if DEBUG
                    if (handler == null) throw new Exception($"Components.AutoHandlers<{typeof(WorldID)}, {typeof(T)}>, Method: SetAutoInit, handler is null");
                    if (World.Status != WorldStatus.Created) throw new Exception($"Components.AutoHandlers<{typeof(WorldID)}, {typeof(T)}>, Method: SetAutoInit, world status not `Created`");
                    #endif
                    Init = handler;
                }

                [MethodImpl(AggressiveInlining)]
                public static void SetAutoReset(AutoResetHandler<T> handler) {
                    #if DEBUG
                    if (handler == null) throw new Exception($"Components.AutoHandlers<{typeof(WorldID)}, {typeof(T)}>, Method: SetAutoReset, handler is null");
                    if (World.Status != WorldStatus.Created) throw new Exception($"Components.AutoHandlers<{typeof(WorldID)}, {typeof(T)}>, Method: SetAutoReset, world status not `Created`");
                    #endif
                    Reset = handler;
                }

                [MethodImpl(AggressiveInlining)]
                public static void SetAutoCopy(AutoCopyHandler<T> handler) {
                    #if DEBUG
                    if (handler == null) throw new Exception($"Components.AutoHandlers<{typeof(WorldID)}, {typeof(T)}>, Method: SetAutoCopy, handler is null");
                    if (World.Status != WorldStatus.Created) throw new Exception($"Components.AutoHandlers<{typeof(WorldID)}, {typeof(T)}>, Method: SetAutoCopy, world status not `Created`");
                    #endif
                    Copy = handler;
                }

                [MethodImpl(AggressiveInlining)]
                internal static void Destroy() {
                    Init = null;
                    Reset = null;
                    Copy = null;
                }
            }
        }
    }

    public delegate void AutoInitHandler<T> (ref T component) where T : struct;
    public delegate void AutoResetHandler<T> (ref T component) where T : struct;
    public delegate void AutoCopyHandler<T> (ref T src, ref T dst) where T : struct;

}