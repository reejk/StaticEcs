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
        public abstract class Components<T> where T : struct, IComponent {
            private static Entity[] _entities;
            private static T[] _data;
            private static int[] _dataIdxByEntityId;
            private static BitMask _bitMask;
            private static int _componentsCount;
            internal static ushort id;

            #if DEBUG
            private static int _blockers;
            #endif

            #region PUBLIC
            static Components() {
                #if DEBUG
                if (World.Status == WorldStatus.NotCreated) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}>, Method: `Components static constructor`, World not created");
                #endif
                ModuleComponents.RegisterComponent<T>();
            }
            
            [MethodImpl(AggressiveInlining)]
            public static ComponentDynId DynamicId() {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}>, Method: DynamicId, World not initialized");
                #endif
                return new ComponentDynId(id);
            }
            
            [MethodImpl(AggressiveInlining)]
            public static ComponentsWrapper<T> Wrap() {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}> Method: Wrap, World not initialized");
                #endif
                return default;
            }

            [MethodImpl(AggressiveInlining)]
            public static ref T RefMut(Entity entity) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}> Method: RefMut, World not initialized");
                if (!entity.IsActual()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}>, Method: RefMut, cannot access Entity ID - {id} from deleted entity");
                if (!Has(entity)) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}>, Method: RefMut, ID - {entity._id} is missing on an entity");
                #endif
                return ref _data[_dataIdxByEntityId[entity._id] - 1];
            }

            [MethodImpl(AggressiveInlining)]
            public static ref readonly T Ref(Entity entity) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}> Method: Ref, World not initialized");
                if (!entity.IsActual()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}>, Method: Ref, cannot access Entity ID - {id} from deleted entity");
                if (!Has(entity)) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}>, Method: Ref, ID - {entity._id} is missing on an entity");
                #endif
                return ref _data[_dataIdxByEntityId[entity._id] - 1];
            }

            [MethodImpl(AggressiveInlining)]
            public static ref T Add(Entity entity) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}> Method: Add, World not initialized");
                if (!entity.IsActual()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}>, Method: Add, cannot access Entity ID - {id} from deleted entity");
                if (Has(entity)) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}>, Method: Add, ID - {entity._id} is already on an entity");
                if (IsBlocked()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}>, Method: Add, component pool cannot be changed, it is in read-only mode due to multiple accesses");
                #endif

                if (_entities.Length == _componentsCount) {
                    ResizeData(_componentsCount << 1);
                }

                var idx = _componentsCount;
                _componentsCount++;
                _entities[idx] = entity;
                _dataIdxByEntityId[entity._id] = _componentsCount;

                _bitMask.Set(entity._id, id);
                
                ref var data = ref _data[idx];
                if (AutoHandlers<T>.Init != null) {
                    AutoHandlers<T>.Init(ref data);
                }

                return ref data;
            }

            [MethodImpl(AggressiveInlining)]
            public static void Put(Entity entity, T component) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}> Method: Put, World not initialized");
                if (!entity.IsActual()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}>, Method: Put, cannot access ID - {id} from deleted entity");
                if (IsBlocked()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}>, Method: Put, component pool cannot be changed, it is in read-only mode due to multiple accesses");
                #endif
                ref var dataId = ref _dataIdxByEntityId[entity._id];
                if (dataId > 0) {
                    _data[dataId - 1] = component;
                    return;
                }

                if (_entities.Length == _componentsCount) {
                    ResizeData(_componentsCount << 1);
                }

                var idx = _componentsCount;
                _componentsCount++;
                _entities[idx] = entity;
                dataId = _componentsCount;

                _bitMask.Set(entity._id, id);

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
                if (!World.IsInitialized()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}> Method: Has, World not initialized");
                if (!entity.IsActual()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}>, Method: Has, cannot access ID - {id} from deleted entity");
                #endif
                return _dataIdxByEntityId[entity._id] > 0;
            }

            [MethodImpl(AggressiveInlining)]
            public static bool Delete(Entity entity) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}> Method: Delete, World not initialized");
                if (!entity.IsActual()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}>, Method: Delete, cannot access ID - {id} from deleted entity");
                if (IsBlocked()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}>, Method: Delete,  component pool cannot be changed, it is in read-only mode due to multiple accesses");
                #endif
                return DelInternal(entity, false);
            }
            
            [MethodImpl(AggressiveInlining)]
            public static void Copy(Entity src, Entity dst) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}> Method: Copy, World not initialized");
                if (!src.IsActual()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}>, Method: Copy, cannot access ID - {id} from deleted entity");
                if (!dst.IsActual()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}>, Method: Copy, cannot access ID - {id} from deleted entity");
                if (IsBlocked()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}>, Method: Copy,  component pool cannot be changed, it is in read-only mode due to multiple accesses");
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
            public static void Move(Entity src, Entity dst) {
                Copy(src, dst);
                Delete(src);
            }

            [MethodImpl(AggressiveInlining)]
            public static int Count() {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}> Method: Count, World not initialized");
                #endif
                return _componentsCount;
            }

            [MethodImpl(AggressiveInlining)]
            public static Entity[] EntitiesData() {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}> Method: EntitiesData, World not initialized");
                #endif
                return _entities;
            }
            
            [MethodImpl(AggressiveInlining)]
            public static T[] Data() {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}> Method: Data, World not initialized");
                #endif
                return _data;
            }
            #endregion

            #region INTERNAL
            internal static void Create(ushort componentId, BitMask bitMask, uint baseCapacity = 128) {
                _bitMask = bitMask;
                id = componentId;
                _entities = new Entity[baseCapacity];
                _data = new T[baseCapacity];
                _componentsCount = 0;
                _dataIdxByEntityId = new int[World.EntitiesCapacity()];
            }

            [MethodImpl(AggressiveInlining)]
            internal static bool DeleteFromWorld(Entity entity) {
                return DelInternal(entity, true);
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static int[] GetDataIdxByEntityId() {
                return _dataIdxByEntityId;
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static void Resize(int cap) {
                Array.Resize(ref _dataIdxByEntityId, cap);
            }

            [MethodImpl(AggressiveInlining)]
            private static bool DelInternal(Entity entity, bool fromWorld) {
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

                    _bitMask.Del(entity._id, id);
                    if (!fromWorld && _bitMask.IsEmpty(entity._id)) {
                        World.DestroyEntity(entity);
                    }
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
            internal static void SetDataIfCountLess(ref int count, ref Entity[] entities) {
                if (_componentsCount < count || count == 0) {
                    count = _componentsCount;
                    entities = _entities;
                }
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static string ToStringComponent(Entity entity) {
                return $" - [{id}] {typeof(T).Name} ( {RefMut(entity)} )\n";
            }

            [MethodImpl(AggressiveInlining)]
            internal static void Destroy() {
                AutoHandlers<T>.Destroy();
                _entities = null;
                _data = null;
                _dataIdxByEntityId = null;
                _bitMask = null;
                _componentsCount = 0;
                id = 0;
            }

            [MethodImpl(AggressiveInlining)]
            internal static void EnsureSize(int size) {
                if (_componentsCount + size >= _entities.Length) {
                    ResizeData(Utils.CalculateSize(_componentsCount + size));
                }
            }

            [MethodImpl(NoInlining)]
            private static void ResizeData(int newSize) {
                Array.Resize(ref _entities, newSize);
                Array.Resize(ref _data, newSize);
            }

            [MethodImpl(AggressiveInlining)]
            internal static void Clear() {
                Array.Clear(_entities, 0, _entities.Length);
                Array.Clear(_data, 0, _data.Length);
                Array.Clear(_dataIdxByEntityId, 0, _dataIdxByEntityId.Length);
                _componentsCount = 0;
            }
            
            #if DEBUG
            [MethodImpl(AggressiveInlining)]
            internal static void AddBlocker(int amount) {
                _blockers += amount;
                if (_blockers < 0) {
                    throw new Exception($"Ecs<{typeof(WorldID)}>.Components<{typeof(T)}>, Method: AddBlocker, incorrect pool user balance when attempting to release");
                }
            }

            [MethodImpl(AggressiveInlining)]
            internal static bool IsBlocked() {
                return _blockers > 1;
            }
            #endif
            #endregion
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

    public delegate void AutoInitHandler<T>(ref T component) where T : struct;

    public delegate void AutoResetHandler<T>(ref T component) where T : struct;

    public delegate void AutoCopyHandler<T>(ref T src, ref T dst) where T : struct;
}