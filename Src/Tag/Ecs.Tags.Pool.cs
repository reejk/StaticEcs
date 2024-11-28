#if !FFS_ECS_DISABLE_TAGS
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
        public abstract partial class Tags {
            public abstract partial class Pool<T> where T : struct, ITag {
                internal static ushort id;
                private static Entity[] _entities;
                private static int[] _dataIdxByEntityId;
                private static int _tagCount;

                #if DEBUG
                private static int _blockers;
                #endif

                static Pool() {
                    RegisterTag<T>();
                }

                internal static void Create(ushort tagId, uint baseCapacity = 128) {
                    id = tagId;
                    _entities = new Entity[baseCapacity];
                    _tagCount = 0;
                    _dataIdxByEntityId = null;
                    _dataIdxByEntityId = new int[World.EntitiesCapacity()];
                }

                [MethodImpl(AggressiveInlining)]
                public static ushort Id() => id;

                [MethodImpl(AggressiveInlining)]
                public static void Add(Entity entity) {
                    Assert.Check(!Has(entity), $"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: Add, can't add a ID - {entity._id}, it already exists");
                    Assert.Check(IsNotBlocked(), $"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: Add,  component pool cannot be changed, it is in read-only mode due to multiple accesses");

                    if (_entities.Length == _tagCount) {
                        Array.Resize(ref _entities, _tagCount << 1);
                    }

                    var idx = _tagCount;
                    _tagCount++;
                    _entities[idx] = entity;
                    _dataIdxByEntityId[entity._id] = _tagCount;

                    SetTagBit(entity, id);
                }

                [MethodImpl(AggressiveInlining)]
                public static void TryAdd(Entity entity) {
                    if (!Has(entity)) {
                        Add(entity);
                    }
                }
                
                [MethodImpl(AggressiveInlining)]
                public static void TryAdd(Entity entity, out bool added) {
                    added = !Has(entity);
                    if (!added) {
                        Add(entity);
                    }
                }

                [MethodImpl(AggressiveInlining)]
                public static bool Has(Entity entity) {
                    Assert.Check(World.EntityVersion(entity) >= 0, $"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: Has, cannot access ID - {entity._id} from deleted entity");
                    return _dataIdxByEntityId[entity._id] > 0;
                }

                [MethodImpl(AggressiveInlining)]
                internal static bool Has(Entity entity, out int internalId) {
                    Assert.Check(World.EntityVersion(entity) >= 0, $"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: Has, cannot access ID - {entity._id} from deleted entity");
                    internalId = _dataIdxByEntityId[entity._id] - 1;
                    return internalId >= 0;
                }

                [MethodImpl(AggressiveInlining)]
                public static bool Del(Entity entity) {
                    Assert.Check(World.EntityVersion(entity) >= 0, $"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: Del, cannot access ID - {entity._id} from deleted entity");
                    Assert.Check(IsNotBlocked(), $"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: Del, component pool cannot be changed, it is in read-only mode due to multiple accesses");


                    ref var idxRef = ref _dataIdxByEntityId[entity._id];
                    var idx = idxRef - 1;
                    if (idx >= 0) {
                        idxRef = 0;
                        _tagCount--;

                        if (idx < _tagCount) {
                            var e = _entities[_tagCount];
                            _entities[idx] = e;
                            _dataIdxByEntityId[e._id] = idx + 1;
                        }

                        UnsetTagBit(entity, id);
                        return true;
                    }

                    return false;
                }

                [MethodImpl(AggressiveInlining)]
                internal static void Resize(int cap) {
                    Array.Resize(ref _dataIdxByEntityId, cap);
                }

                [MethodImpl(AggressiveInlining)]
                public static void Copy(Entity src, Entity dst) {
                    Assert.Check(World.EntityVersion(src) >= 0, $"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: Copy, cannot access ID - {src._id} from deleted original entity");
                    Assert.Check(World.EntityVersion(dst) >= 0, $"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: Copy, cannot access ID - {dst._id} from deleted targeted entity");
                    Assert.Check(IsNotBlocked(), $"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: Copy, component pool cannot be changed, it is in read-only mode due to multiple accesses");

                    if (Has(src) && !Has(dst)) {
                        Add(dst);
                    }
                }

                [MethodImpl(AggressiveInlining)]
                public static int Count() => _tagCount;
                
                [MethodImpl(AggressiveInlining)]
                public static Entity[] EntitiesData() => _entities;
                
                [MethodImpl(AggressiveInlining)]
                public static string ToStringComponent(Entity entity) {
                    return $" - [{id}] {typeof(T).Name}\n";
                }

                [MethodImpl(AggressiveInlining)]
                internal static void SetDataIfCountLess(ref int count, ref Entity[] entities) {
                    if (_tagCount < count || count == 0) {
                        count = _tagCount;
                        entities = _entities;
                    }
                }

                [MethodImpl(AggressiveInlining)]
                internal static void Destroy() {
                    _entities = null;
                    _dataIdxByEntityId = null;
                    _tagCount = 0;
                    id = 0;
                }

                [MethodImpl(AggressiveInlining)]
                public static void Clear() {
                    Array.Clear(_entities, 0, _entities.Length);
                    Array.Clear(_dataIdxByEntityId, 0, _dataIdxByEntityId.Length);
                    _tagCount = 0;
                }

                #if DEBUG
                [MethodImpl(AggressiveInlining)]
                internal static void AddBlocker(int amount) {
                    _blockers += amount;
                    Assert.Check(_blockers >= 0, $"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: AddBlocker, incorrect pool user balance when attempting to release");
                }
                #endif

                [MethodImpl(AggressiveInlining)]
                internal static bool IsNotBlocked() {
                    #if DEBUG
                    return _blockers <= 1;
                    #endif
                    return true;
                }
            }
        }
    }
}
#endif