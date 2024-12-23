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
    public ref struct QueryComponentsIterator<WorldID, C> where C : struct, IComponent where WorldID : struct, IWorldId {
        private readonly C[] _data; //8
        private int _count;         //4

        [MethodImpl(AggressiveInlining)]
        public QueryComponentsIterator(byte cs9fake) {
            _data = Ecs<WorldID>.Components<C>.Data();
            _count = Ecs<WorldID>.Components<C>.Count();
            #if DEBUG
                Ecs<WorldID>.Components<C>.AddBlocker(1);
            #endif
        }

        public readonly ref C Current {
            [MethodImpl(AggressiveInlining)] get => ref _data[_count];
        }

        [MethodImpl(AggressiveInlining)]
        public bool MoveNext() {
            _count--;
            return _count >= 0;
        }

        [MethodImpl(AggressiveInlining)]
        public QueryComponentsIterator<WorldID, C> GetEnumerator() => this;

        #if DEBUG
            [MethodImpl(AggressiveInlining)]
            public void Dispose() {
                Ecs<WorldID>.Components<C>.AddBlocker(-1);
            }
        #endif
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public ref struct QueryComponentsIterator<WorldID, C, QW>
        where C : struct, IComponent
        where QW : struct, IQueryMethod
        where WorldID : struct, IWorldId {
        private readonly C[] _data;                               //8
        private readonly Ecs<WorldID>.Entity[] _entities; //8
        private int _count;                                       //4
        private QW _with;                                         //???

        [MethodImpl(AggressiveInlining)]
        public QueryComponentsIterator(QW with) {
            _with = with;
            _data = Ecs<WorldID>.Components<C>.Data();
            _count = Ecs<WorldID>.Components<C>.Count();
            _entities = Ecs<WorldID>.Components<C>.EntitiesData();
            var count = int.MaxValue;
            Ecs<WorldID>.Entity[] entities = null;
            with.SetData(ref count, ref entities);
            #if DEBUG
            Ecs<WorldID>.Components<C>.AddBlocker(1);
            #endif
        }

        public readonly ref C Current {
            [MethodImpl(AggressiveInlining)] get => ref _data[_count];
        }

        [MethodImpl(AggressiveInlining)]
        public bool MoveNext() {
            while (true) {
                if (_count <= 0) {
                    return false;
                }

                _count--;

                if (_with.CheckEntity(_entities[_count]._id)) {
                    return true;
                }
            }
        }

        [MethodImpl(AggressiveInlining)]
        public QueryComponentsIterator<WorldID, C, QW> GetEnumerator() => this;

        [MethodImpl(AggressiveInlining)]
        public void Dispose() {
            #if DEBUG
            Ecs<WorldID>.Components<C>.AddBlocker(-1);
            #endif
            _with.Dispose<WorldID>();
        }
    }
}