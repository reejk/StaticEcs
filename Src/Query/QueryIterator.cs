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
        private readonly int[] _entities; //8
        private int _current;             //4
        private int _count;               //4
        private QM _queryMethod;          //???

        [MethodImpl(AggressiveInlining)]
        public QueryEntitiesIterator(QM queryMethod) {
            _queryMethod = queryMethod;
            _current = default;
            _entities = default;
            _count = int.MaxValue;
            _queryMethod.SetData<WorldID>(ref _count, ref _entities);
        }

        public readonly Ecs<WorldID>.Entity Current {
            [MethodImpl(AggressiveInlining)] get => new (_current);
        }

        [MethodImpl(AggressiveInlining)]
        public bool MoveNext() {
            while (true) {
                if (_count == 0) {
                    return false;
                }

                _count--;
                _current = _entities[_count];
                if (_queryMethod.CheckEntity(_current)) {
                    return true;
                }
            }
        }

        [MethodImpl(AggressiveInlining)]
        public readonly QueryEntitiesIterator<WorldID, QM> GetEnumerator() => this;

        [MethodImpl(AggressiveInlining)]
        public void Dispose() => _queryMethod.Dispose<WorldID>();
        
        [MethodImpl(AggressiveInlining)]
        public void DestroyAllEntities() {
            while (MoveNext()) {
                new Ecs<WorldID>.Entity(_current).Destroy();
            }
            Dispose();
        }

        [MethodImpl(AggressiveInlining)]
        public bool First(out Ecs<WorldID>.Entity entity) {
            var moveNext = MoveNext();
            entity = new Ecs<WorldID>.Entity(_current);
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
        public void AddForAll<T1>() where T1 : struct, IComponent {
            ref var components = ref Ecs<WorldID>.Components<T1>.Value;
            while (MoveNext()) {
                components.Add(new Ecs<WorldID>.Entity(_current));
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void AddForAll<T1, T2>() 
            where T1 : struct, IComponent
            where T2 : struct, IComponent{
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            ref var components2 = ref Ecs<WorldID>.Components<T2>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Add(entity);
                components2.Add(entity);
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void AddForAll<T1, T2, T3>() 
            where T1 : struct, IComponent
            where T2 : struct, IComponent
            where T3 : struct, IComponent {
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            ref var components2 = ref Ecs<WorldID>.Components<T2>.Value;
            ref var components3 = ref Ecs<WorldID>.Components<T3>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Add(entity);
                components2.Add(entity);
                components3.Add(entity);
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void AddForAll<T1, T2, T3, T4>() 
            where T1 : struct, IComponent
            where T2 : struct, IComponent
            where T3 : struct, IComponent
            where T4 : struct, IComponent {
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            ref var components2 = ref Ecs<WorldID>.Components<T2>.Value;
            ref var components3 = ref Ecs<WorldID>.Components<T3>.Value;
            ref var components4 = ref Ecs<WorldID>.Components<T4>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Add(entity);
                components2.Add(entity);
                components3.Add(entity);
                components4.Add(entity);
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void AddForAll<T1, T2, T3, T4, T5>() 
            where T1 : struct, IComponent
            where T2 : struct, IComponent
            where T3 : struct, IComponent
            where T4 : struct, IComponent
            where T5 : struct, IComponent {
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            ref var components2 = ref Ecs<WorldID>.Components<T2>.Value;
            ref var components3 = ref Ecs<WorldID>.Components<T3>.Value;
            ref var components4 = ref Ecs<WorldID>.Components<T4>.Value;
            ref var components5 = ref Ecs<WorldID>.Components<T5>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Add(entity);
                components2.Add(entity);
                components3.Add(entity);
                components4.Add(entity);
                components5.Add(entity);
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void AddForAll<T1>(T1 t1) 
            where T1 : struct, IComponent {
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Add(entity) = t1;
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void AddForAll<T1, T2>(T1 t1, T2 t2) 
            where T1 : struct, IComponent
            where T2 : struct, IComponent {
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            ref var components2 = ref Ecs<WorldID>.Components<T2>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Add(entity) = t1;
                components2.Add(entity) = t2;
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void AddForAll<T1, T2, T3>(T1 t1, T2 t2, T3 t3) 
            where T1 : struct, IComponent
            where T2 : struct, IComponent
            where T3 : struct, IComponent {
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            ref var components2 = ref Ecs<WorldID>.Components<T2>.Value;
            ref var components3 = ref Ecs<WorldID>.Components<T3>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Add(entity) = t1;
                components2.Add(entity) = t2;
                components3.Add(entity) = t3;
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void AddForAll<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4) 
            where T1 : struct, IComponent
            where T2 : struct, IComponent
            where T3 : struct, IComponent
            where T4 : struct, IComponent {
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            ref var components2 = ref Ecs<WorldID>.Components<T2>.Value;
            ref var components3 = ref Ecs<WorldID>.Components<T3>.Value;
            ref var components4 = ref Ecs<WorldID>.Components<T4>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Add(entity) = t1;
                components2.Add(entity) = t2;
                components3.Add(entity) = t3;
                components4.Add(entity) = t4;
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void AddForAll<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) 
            where T1 : struct, IComponent
            where T2 : struct, IComponent
            where T3 : struct, IComponent
            where T4 : struct, IComponent
            where T5 : struct, IComponent {
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            ref var components2 = ref Ecs<WorldID>.Components<T2>.Value;
            ref var components3 = ref Ecs<WorldID>.Components<T3>.Value;
            ref var components4 = ref Ecs<WorldID>.Components<T4>.Value;
            ref var components5 = ref Ecs<WorldID>.Components<T5>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Add(entity) = t1;
                components2.Add(entity) = t2;
                components3.Add(entity) = t3;
                components4.Add(entity) = t4;
                components5.Add(entity) = t5;
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void PutForAll<T1>(T1 t1) 
            where T1 : struct, IComponent {
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Put(entity, t1);
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void PutForAll<T1, T2>(T1 t1, T2 t2) 
            where T1 : struct, IComponent
            where T2 : struct, IComponent {
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            ref var components2 = ref Ecs<WorldID>.Components<T2>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Put(entity, t1);
                components2.Put(entity, t2);
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void PutForAll<T1, T2, T3>(T1 t1, T2 t2, T3 t3) 
            where T1 : struct, IComponent
            where T2 : struct, IComponent
            where T3 : struct, IComponent {
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            ref var components2 = ref Ecs<WorldID>.Components<T2>.Value;
            ref var components3 = ref Ecs<WorldID>.Components<T3>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Put(entity, t1);
                components2.Put(entity, t2);
                components3.Put(entity, t3);
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void PutForAll<T1, T2, T3, T4>(T1 t1, T2 t2, T3 t3, T4 t4) 
            where T1 : struct, IComponent
            where T2 : struct, IComponent
            where T3 : struct, IComponent
            where T4 : struct, IComponent {
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            ref var components2 = ref Ecs<WorldID>.Components<T2>.Value;
            ref var components3 = ref Ecs<WorldID>.Components<T3>.Value;
            ref var components4 = ref Ecs<WorldID>.Components<T4>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Put(entity, t1);
                components2.Put(entity, t2);
                components3.Put(entity, t3);
                components4.Put(entity, t4);
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void PutForAll<T1, T2, T3, T4, T5>(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) 
            where T1 : struct, IComponent
            where T2 : struct, IComponent
            where T3 : struct, IComponent
            where T4 : struct, IComponent
            where T5 : struct, IComponent {
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            ref var components2 = ref Ecs<WorldID>.Components<T2>.Value;
            ref var components3 = ref Ecs<WorldID>.Components<T3>.Value;
            ref var components4 = ref Ecs<WorldID>.Components<T4>.Value;
            ref var components5 = ref Ecs<WorldID>.Components<T5>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Put(entity, t1);
                components2.Put(entity, t2);
                components3.Put(entity, t3);
                components4.Put(entity, t4);
                components5.Put(entity, t5);
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void DeleteForAll<T1>() 
            where T1 : struct, IComponent {
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Delete(entity);
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void DeleteForAll<T1, T2>() 
            where T1 : struct, IComponent
            where T2 : struct, IComponent {
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            ref var components2 = ref Ecs<WorldID>.Components<T2>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Delete(entity);
                components2.Delete(entity);
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void DeleteForAll<T1, T2, T3>() 
            where T1 : struct, IComponent
            where T2 : struct, IComponent
            where T3 : struct, IComponent {
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            ref var components2 = ref Ecs<WorldID>.Components<T2>.Value;
            ref var components3 = ref Ecs<WorldID>.Components<T3>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Delete(entity);
                components2.Delete(entity);
                components3.Delete(entity);
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void DeleteForAll<T1, T2, T3, T4>() 
            where T1 : struct, IComponent
            where T2 : struct, IComponent
            where T3 : struct, IComponent
            where T4 : struct, IComponent {
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            ref var components2 = ref Ecs<WorldID>.Components<T2>.Value;
            ref var components3 = ref Ecs<WorldID>.Components<T3>.Value;
            ref var components4 = ref Ecs<WorldID>.Components<T4>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Delete(entity);
                components2.Delete(entity);
                components3.Delete(entity);
                components4.Delete(entity);
            }
            Dispose();
        }
        
        [MethodImpl(AggressiveInlining)]
        public void DeleteForAll<T1, T2, T3, T4, T5>() 
            where T1 : struct, IComponent
            where T2 : struct, IComponent
            where T3 : struct, IComponent
            where T4 : struct, IComponent
            where T5 : struct, IComponent {
            ref var components1 = ref Ecs<WorldID>.Components<T1>.Value;
            ref var components2 = ref Ecs<WorldID>.Components<T2>.Value;
            ref var components3 = ref Ecs<WorldID>.Components<T3>.Value;
            ref var components4 = ref Ecs<WorldID>.Components<T4>.Value;
            ref var components5 = ref Ecs<WorldID>.Components<T5>.Value;
            while (MoveNext()) {
                var entity = new Ecs<WorldID>.Entity(_current);
                components1.Delete(entity);
                components2.Delete(entity);
                components3.Delete(entity);
                components4.Delete(entity);
                components5.Delete(entity);
            }
            Dispose();
        }
    }
}