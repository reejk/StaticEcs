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
        public struct Tags<T> where T : struct, ITag {
            public static Tags<T> Value;
            private const int Empty = -1;
            private BitMask _bitMask;
            private int[] _entities;
            private int[] _dataIdxByEntityId;
            private int _tagCount;
            internal ushort id;

            #if DEBUG
            private int _blockers;
            #endif

            static Tags() {
                ModuleTags.RegisterTag<T>();
            }

            internal void Create(ushort tagId, BitMask bitMask, uint baseCapacity = 128) {
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
            public TagDynId DynamicId() => new(id);

            [MethodImpl(AggressiveInlining)]
            public void Add(Entity entity) {
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
            public void TryAdd(Entity entity) {
                if (!Has(entity)) {
                    Add(entity);
                }
            }

            [MethodImpl(AggressiveInlining)]
            public void TryAdd(Entity entity, out bool added) {
                added = !Has(entity);
                if (!added) {
                    Add(entity);
                }
            }

            [MethodImpl(AggressiveInlining)]
            public bool Has(Entity entity) {
                #if DEBUG
                if (World.EntityVersion(entity) < 0) throw new Exception($"TagPool<{typeof(WorldID)}, {typeof(T)}>, Method: Has, cannot access ID - {id} from deleted entity");
                #endif
                return _dataIdxByEntityId[entity._id] >= 0;
            }

            [MethodImpl(AggressiveInlining)]
            public bool Delete(Entity entity) {
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
            internal void Resize(int cap) {
                var lastLength = _dataIdxByEntityId.Length;
                Array.Resize(ref _dataIdxByEntityId, cap);
                for (var i = lastLength; i < cap; i++) {
                    _dataIdxByEntityId[i] = Empty;
                }
            }

            [MethodImpl(AggressiveInlining)]
            public void Copy(Entity src, Entity dst) {
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
            public void Move(Entity src, Entity dst) {
                Copy(src, dst);
                Delete(src);
            }

            [MethodImpl(AggressiveInlining)]
            public int Count() => _tagCount;

            [MethodImpl(AggressiveInlining)]
            public int[] EntitiesData() => _entities;

            [MethodImpl(AggressiveInlining)]
            public string ToStringComponent(Entity entity) {
                return $" - [{id}] {typeof(T).Name}\n";
            }

            [MethodImpl(AggressiveInlining)]
            internal void SetDataIfCountLess(ref int count, ref int[] entities) {
                if (_tagCount < count || count == 0) {
                    count = _tagCount;
                    entities = _entities;
                }
            }

            [MethodImpl(AggressiveInlining)]
            internal void SetDataIfCountMore(ref int count, ref int[] entities) {
                if (_tagCount > count || count == 0) {
                    count = _tagCount;
                    entities = _entities;
                }
            }
            
            [MethodImpl(AggressiveInlining)]
            internal int[] GetDataIdxByEntityId() {
                return _dataIdxByEntityId;
            }

            [MethodImpl(AggressiveInlining)]
            internal void Destroy() {
                _entities = null;
                _dataIdxByEntityId = null;
                _tagCount = 0;
                id = 0;
            }

            [MethodImpl(AggressiveInlining)]
            public void Clear() {
                Array.Clear(_entities, 0, _entities.Length);
                for (var i = 0; i < _dataIdxByEntityId.Length; i++) {
                    _dataIdxByEntityId[i] = Empty;
                }
                _tagCount = 0;
            }

            #if DEBUG
            [MethodImpl(AggressiveInlining)]
            internal void AddBlocker(int amount) {
                _blockers += amount;
                #if DEBUG
                if (_blockers < 0) throw new Exception($"TagsPool<{typeof(WorldID)}, {typeof(T)}>, Method: AddBlocker, incorrect pool user balance when attempting to release");
                #endif
            }
            #endif

            [MethodImpl(AggressiveInlining)]
            internal bool IsNotBlocked() {
                #if DEBUG
                return _blockers <= 1;
                #endif
                return true;
            }
        }
    }
}
#endif