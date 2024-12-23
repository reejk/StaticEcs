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
            private const int Empty = -1;
            private static BitMask _bitMask;
            private static int[] _entities;
            private static int[] _dataIdxByEntityId;
            private static int _tagCount;
            internal static ushort id;

            #if DEBUG
            private static int _blockers;
            #endif

            static Tags() {
                ModuleTags.RegisterTag<T>();
            }

            internal static void Create(ushort tagId, BitMask bitMask, uint baseCapacity = 128) {
                _bitMask = bitMask;
                id = tagId;
                _entities = new int[baseCapacity];
                _tagCount = 0;
                _dataIdxByEntityId = new int[World.EntitiesCapacity()];
                for (var i = 0; i < _dataIdxByEntityId.Length; i++) {
                    _dataIdxByEntityId[i] = Empty;
                }
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

                var eid = entity._id;
                _entities[_tagCount] = eid;
                _dataIdxByEntityId[eid] = _tagCount;
                _bitMask.Set(eid, id);
                _tagCount++;
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
                return _dataIdxByEntityId[entity._id] >= 0;
            }

            [MethodImpl(AggressiveInlining)]
            public static bool Delete(Entity entity) {
                #if DEBUG
                if (World.EntityVersion(entity) < 0) throw new Exception($"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: DelInternal, cannot access ID - {id} from deleted entity");
                if (!IsNotBlocked())
                    throw new Exception($"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: DelInternal,  component pool cannot be changed, it is in read-only mode due to multiple accesses");
                #endif

                ref var idxRef = ref _dataIdxByEntityId[entity._id];
                if (idxRef >= 0) {
                    _tagCount--;

                    if (idxRef < _tagCount) {
                        var e = _entities[_tagCount];
                        _entities[idxRef] = e;
                        _dataIdxByEntityId[e] = idxRef;
                    }

                    _bitMask.Del(entity._id, id);
                    idxRef = 0;
                    return true;
                }

                return false;
            }

            [MethodImpl(AggressiveInlining)]
            internal static void Resize(int cap) {
                var lastLength = _dataIdxByEntityId.Length;
                Array.Resize(ref _dataIdxByEntityId, cap);
                for (var i = lastLength; i < cap; i++) {
                    _dataIdxByEntityId[i] = Empty;
                }
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
            public static void Move(Entity src, Entity dst) {
                Copy(src, dst);
                Delete(src);
            }

            [MethodImpl(AggressiveInlining)]
            public static int Count() => _tagCount;

            [MethodImpl(AggressiveInlining)]
            public static int[] EntitiesData() => _entities;

            [MethodImpl(AggressiveInlining)]
            public static string ToStringComponent(Entity entity) {
                return $" - [{id}] {typeof(T).Name}\n";
            }

            [MethodImpl(AggressiveInlining)]
            internal static void SetDataIfCountLess(ref int count, ref int[] entities) {
                if (_tagCount < count || count == 0) {
                    count = _tagCount;
                    entities = _entities;
                }
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static int[] GetDataIdxByEntityId() {
                return _dataIdxByEntityId;
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
                for (var i = 0; i < _dataIdxByEntityId.Length; i++) {
                    _dataIdxByEntityId[i] = Empty;
                }
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