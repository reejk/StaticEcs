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
        public abstract partial class Tags<T> where T : struct, ITag {
            internal static ushort id;
            private static Entity[] _entities;
            private static int[] _dataIdxByEntityId;
            private static int _tagCount;

            #if DEBUG
            private static int _blockers;
            #endif

            static Tags() {
                ModuleTags.RegisterTag<T>();
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
                #if DEBUG
                if (World.EntityVersion(entity) < 0) throw new Exception($"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: Add, cannot access ID - {id} from deleted entity");
                if (Has(entity)) throw new Exception($"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: Add, ID - {entity._id} is missing on an entity");
                #endif

                if (_entities.Length == _tagCount) {
                    Array.Resize(ref _entities, _tagCount << 1);
                }

                var idx = _tagCount;
                _tagCount++;
                _entities[idx] = entity;
                _dataIdxByEntityId[entity._id] = _tagCount;

                ModuleTags.SetTagBit(entity, id);
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
                #if DEBUG
                if (World.EntityVersion(entity) < 0) throw new Exception($"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: Has, cannot access ID - {id} from deleted entity");
                #endif
                return _dataIdxByEntityId[entity._id] > 0;
            }

            [MethodImpl(AggressiveInlining)]
            internal static bool Has(Entity entity, out int internalId) {
                #if DEBUG
                if (World.EntityVersion(entity) < 0) throw new Exception($"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: Has, cannot access ID - {id} from deleted entity");
                #endif
                internalId = _dataIdxByEntityId[entity._id] - 1;
                return internalId >= 0;
            }

            [MethodImpl(AggressiveInlining)]
            public static bool Del(Entity entity) {
                #if DEBUG
                if (World.EntityVersion(entity) < 0) throw new Exception($"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: DelInternal, cannot access ID - {id} from deleted entity");
                if (!IsNotBlocked())
                    throw new Exception($"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: DelInternal,  component pool cannot be changed, it is in read-only mode due to multiple accesses");
                #endif

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

                    ModuleTags.UnsetTagBit(entity, id);
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
                #if DEBUG
                if (World.EntityVersion(src) < 0) throw new Exception($"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: Copy, cannot access ID - {id} from deleted entity");
                if (World.EntityVersion(dst) < 0) throw new Exception($"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: Copy, cannot access ID - {id} from deleted entity");
                if (!IsNotBlocked()) throw new Exception($"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: Copy,  component pool cannot be changed, it is in read-only mode due to multiple accesses");
                #endif

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
                #if DEBUG
                if (_blockers < 0) throw new Exception($"TagsPool<{typeof(WorldID)}, {typeof(T)}>, Method: AddBlocker, incorrect pool user balance when attempting to release");
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
        }
    }
}
#endif