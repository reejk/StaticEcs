using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif


namespace FFS.Libraries.StaticEcs {
    public interface IOnCreateEntityFunction<WorldID> where WorldID : struct, IWorldId {
        public void OnCreate(Ecs<WorldID>.Entity entity);
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    internal readonly struct AddComponentFunction<WorldID, T1> : IOnCreateEntityFunction<WorldID> 
        where T1 : struct, IComponent 
        where WorldID : struct, IWorldId {

        [MethodImpl(AggressiveInlining)]
        public void OnCreate(Ecs<WorldID>.Entity entity) {
            entity.Add<T1>();
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    internal readonly struct AddComponentFunction<WorldID, T1, T2> : IOnCreateEntityFunction<WorldID> 
        where T1 : struct, IComponent 
        where T2 : struct, IComponent
        where WorldID : struct, IWorldId {

        [MethodImpl(AggressiveInlining)]
        public void OnCreate(Ecs<WorldID>.Entity entity) {
            entity.Add<T1>();
            entity.Add<T2>();
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    internal readonly struct AddComponentFunction<WorldID, T1, T2, T3> : IOnCreateEntityFunction<WorldID> 
        where T1 : struct, IComponent 
        where T2 : struct, IComponent
        where T3 : struct, IComponent
        where WorldID : struct, IWorldId {

        [MethodImpl(AggressiveInlining)]
        public void OnCreate(Ecs<WorldID>.Entity entity) {
            entity.Add<T1>();
            entity.Add<T2>();
            entity.Add<T3>();
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    internal readonly struct AddComponentFunction<WorldID, T1, T2, T3, T4> : IOnCreateEntityFunction<WorldID> 
        where T1 : struct, IComponent 
        where T2 : struct, IComponent
        where T3 : struct, IComponent
        where T4 : struct, IComponent
        where WorldID : struct, IWorldId {

        [MethodImpl(AggressiveInlining)]
        public void OnCreate(Ecs<WorldID>.Entity entity) {
            entity.Add<T1>();
            entity.Add<T2>();
            entity.Add<T3>();
            entity.Add<T4>();
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    internal readonly struct AddComponentFunction<WorldID, T1, T2, T3, T4, T5> : IOnCreateEntityFunction<WorldID> 
        where T1 : struct, IComponent 
        where T2 : struct, IComponent
        where T3 : struct, IComponent
        where T4 : struct, IComponent
        where T5 : struct, IComponent
        where WorldID : struct, IWorldId {

        [MethodImpl(AggressiveInlining)]
        public void OnCreate(Ecs<WorldID>.Entity entity) {
            entity.Add<T1>();
            entity.Add<T2>();
            entity.Add<T3>();
            entity.Add<T4>();
            entity.Add<T5>();
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    internal readonly struct PutComponentFunction<WorldID, T1> : IOnCreateEntityFunction<WorldID> 
        where T1 : struct, IComponent 
        where WorldID : struct, IWorldId {
        private readonly T1 t1;
        
        [MethodImpl(AggressiveInlining)]
        public PutComponentFunction(T1 t1) {
            this.t1 = t1;
        }

        [MethodImpl(AggressiveInlining)]
        public void OnCreate(Ecs<WorldID>.Entity entity) {
            entity.Put(t1);
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    internal readonly struct PutComponentFunction<WorldID, T1, T2> : IOnCreateEntityFunction<WorldID> 
        where T1 : struct, IComponent 
        where T2 : struct, IComponent
        where WorldID : struct, IWorldId {
        private readonly T1 t1;
        private readonly T2 t2;
        
        [MethodImpl(AggressiveInlining)]
        public PutComponentFunction(T1 t1, T2 t2) {
            this.t1 = t1;
            this.t2 = t2;
        }

        [MethodImpl(AggressiveInlining)]
        public void OnCreate(Ecs<WorldID>.Entity entity) {
            entity.Put(t1);
            entity.Put(t2);
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    internal readonly struct PutComponentFunction<WorldID, T1, T2, T3> : IOnCreateEntityFunction<WorldID> 
        where T1 : struct, IComponent 
        where T2 : struct, IComponent
        where T3 : struct, IComponent
        where WorldID : struct, IWorldId {
        private readonly T1 t1;
        private readonly T2 t2;
        private readonly T3 t3;
        
        [MethodImpl(AggressiveInlining)]
        public PutComponentFunction(T1 t1, T2 t2, T3 t3) {
            this.t1 = t1;
            this.t2 = t2;
            this.t3 = t3;
        }

        [MethodImpl(AggressiveInlining)]
        public void OnCreate(Ecs<WorldID>.Entity entity) {
            entity.Put(t1);
            entity.Put(t2);
            entity.Put(t3);
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    internal readonly struct PutComponentFunction<WorldID, T1, T2, T3, T4> : IOnCreateEntityFunction<WorldID> 
        where T1 : struct, IComponent 
        where T2 : struct, IComponent
        where T3 : struct, IComponent
        where T4 : struct, IComponent
        where WorldID : struct, IWorldId {
        private readonly T1 t1;
        private readonly T2 t2;
        private readonly T3 t3;
        private readonly T4 t4;
        
        [MethodImpl(AggressiveInlining)]
        public PutComponentFunction(T1 t1, T2 t2, T3 t3, T4 t4) {
            this.t1 = t1;
            this.t2 = t2;
            this.t3 = t3;
            this.t4 = t4;
        }

        [MethodImpl(AggressiveInlining)]
        public void OnCreate(Ecs<WorldID>.Entity entity) {
            entity.Put(t1);
            entity.Put(t2);
            entity.Put(t3);
            entity.Put(t4);
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    internal readonly struct PutComponentFunction<WorldID, T1, T2, T3, T4, T5> : IOnCreateEntityFunction<WorldID> 
        where T1 : struct, IComponent 
        where T2 : struct, IComponent
        where T3 : struct, IComponent
        where T4 : struct, IComponent
        where T5 : struct, IComponent
        where WorldID : struct, IWorldId {
        private readonly T1 t1;
        private readonly T2 t2;
        private readonly T3 t3;
        private readonly T4 t4;
        private readonly T5 t5;
        
        [MethodImpl(AggressiveInlining)]
        public PutComponentFunction(T1 t1, T2 t2, T3 t3, T4 t4, T5 t5) {
            this.t1 = t1;
            this.t2 = t2;
            this.t3 = t3;
            this.t4 = t4;
            this.t5 = t5;
        }

        [MethodImpl(AggressiveInlining)]
        public void OnCreate(Ecs<WorldID>.Entity entity) {
            entity.Put(t1);
            entity.Put(t2);
            entity.Put(t3);
            entity.Put(t4);
            entity.Put(t5);
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    internal readonly struct AddComponentOnCreateEntity1<WorldID> : IOnCreateEntityFunction<WorldID> 
        where WorldID : struct, IWorldId {
        private readonly ComponentDynId t1;
        
        [MethodImpl(AggressiveInlining)]
        public AddComponentOnCreateEntity1(ComponentDynId t1) {
            this.t1 = t1;
        }


        [MethodImpl(AggressiveInlining)]
        public void OnCreate(Ecs<WorldID>.Entity entity) {
            entity.Add(t1);
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    internal readonly struct AddComponentOnCreateEntity2<WorldID> : IOnCreateEntityFunction<WorldID> 
        where WorldID : struct, IWorldId {
        private readonly ComponentDynId t1;
        private readonly ComponentDynId t2;
        
        [MethodImpl(AggressiveInlining)]
        public AddComponentOnCreateEntity2(ComponentDynId t1, ComponentDynId t2) {
            this.t1 = t1;
            this.t2 = t2;
        }


        [MethodImpl(AggressiveInlining)]
        public void OnCreate(Ecs<WorldID>.Entity entity) {
            entity.Add(t1);
            entity.Add(t2);
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    internal readonly struct AddComponentOnCreateEntity3<WorldID> : IOnCreateEntityFunction<WorldID> 
        where WorldID : struct, IWorldId {
        private readonly ComponentDynId t1;
        private readonly ComponentDynId t2;
        private readonly ComponentDynId t3;
        
        [MethodImpl(AggressiveInlining)]
        public AddComponentOnCreateEntity3(ComponentDynId t1, ComponentDynId t2, ComponentDynId t3) {
            this.t1 = t1;
            this.t2 = t2;
            this.t3 = t3;
        }


        [MethodImpl(AggressiveInlining)]
        public void OnCreate(Ecs<WorldID>.Entity entity) {
            entity.Add(t1);
            entity.Add(t2);
            entity.Add(t3);
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    internal readonly struct AddComponentOnCreateEntity4<WorldID> : IOnCreateEntityFunction<WorldID> 
        where WorldID : struct, IWorldId {
        private readonly ComponentDynId t1;
        private readonly ComponentDynId t2;
        private readonly ComponentDynId t3;
        private readonly ComponentDynId t4;
        
        [MethodImpl(AggressiveInlining)]
        public AddComponentOnCreateEntity4(ComponentDynId t1, ComponentDynId t2, ComponentDynId t3, ComponentDynId t4) {
            this.t1 = t1;
            this.t2 = t2;
            this.t3 = t3;
            this.t4 = t4;
        }


        [MethodImpl(AggressiveInlining)]
        public void OnCreate(Ecs<WorldID>.Entity entity) {
            entity.Add(t1);
            entity.Add(t2);
            entity.Add(t3);
            entity.Add(t4);
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    internal readonly struct AddComponentOnCreateEntity5<WorldID> : IOnCreateEntityFunction<WorldID> 
        where WorldID : struct, IWorldId {
        private readonly ComponentDynId t1;
        private readonly ComponentDynId t2;
        private readonly ComponentDynId t3;
        private readonly ComponentDynId t4;
        private readonly ComponentDynId t5;
        
        [MethodImpl(AggressiveInlining)]
        public AddComponentOnCreateEntity5(ComponentDynId t1, ComponentDynId t2, ComponentDynId t3, ComponentDynId t4, ComponentDynId t5) {
            this.t1 = t1;
            this.t2 = t2;
            this.t3 = t3;
            this.t4 = t4;
            this.t5 = t5;
        }


        [MethodImpl(AggressiveInlining)]
        public void OnCreate(Ecs<WorldID>.Entity entity) {
            entity.Add(t1);
            entity.Add(t2);
            entity.Add(t3);
            entity.Add(t4);
            entity.Add(t5);
        }
    }
}