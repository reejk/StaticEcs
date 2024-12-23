using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

namespace FFS.Libraries.StaticEcs {
    #if ENABLE_IL2CPP
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
    #endif
    public ref struct QueryEntitiesIterator<WorldID, QM> where QM : struct, IPrimaryQueryMethod where WorldID : struct, IWorldId {
        private readonly Ecs<WorldID>.Entity[] _entities; //8
        private Ecs<WorldID>.Entity _current;             //4
        private int _count;                               //4
        private QM _queryMethod;                          //???

        [MethodImpl(AggressiveInlining)]
        public QueryEntitiesIterator(QM queryMethod) {
            _queryMethod = queryMethod;
            _current = default;
            _entities = default;
            _count = int.MaxValue;
            _queryMethod.SetData(ref _count, ref _entities);
        }

        public readonly Ecs<WorldID>.Entity Current {
            [MethodImpl(AggressiveInlining)] get => _current;
        }
        
        [MethodImpl(AggressiveInlining)]
        public void DestroyAllEntities() {
            while (MoveNext()) {
                _current.Destroy();
            }
            Dispose();
        }

        [MethodImpl(AggressiveInlining)]
        public bool First(out Ecs<WorldID>.Entity entity) {
            var moveNext = MoveNext();
            entity = _current;
            Dispose();
            return moveNext;
        }
        
        [MethodImpl(AggressiveInlining)]
        public int EntitiesCount() {
            var count = 0;
            while (MoveNext()) {
                count++;
            }
            Dispose();
            return count;
        }

        [MethodImpl(AggressiveInlining)]
        public bool MoveNext() {
            while (true) {
                if (_count == 0) {
                    return false;
                }

                _count--;
                _current = _entities[_count];
                if (_queryMethod.CheckEntity(_current._id)) {
                    return true;
                }
            }
        }

        [MethodImpl(AggressiveInlining)]
        public readonly QueryEntitiesIterator<WorldID, QM> GetEnumerator() => this;

        [MethodImpl(AggressiveInlining)]
        public void Dispose() => _queryMethod.Dispose<WorldID>();
    }
}