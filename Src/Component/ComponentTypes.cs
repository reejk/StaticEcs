using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

namespace FFS.Libraries.StaticEcs {
    public interface IComponentTypes {
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] _entities) where WorldID : struct, IWorldId;

        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId;

        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId;
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public static class ComponentTypesExtensions {
        [MethodImpl(AggressiveInlining)]
        public static TypesBox Box<T>(this T types) where T : IComponentTypes {
            return new TypesBox(types);
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Types<C1> : IComponentTypes, Stateless
        where C1 : struct, IComponent {
        
        [MethodImpl(AggressiveInlining)]
        public static All<Types<C1>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static Single<C1> Single() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static None<Types<C1>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static AllAndNone<Types<C1>, T> AllAndNone<T>(T without = default) where T : struct, IComponentTypes => default;
        
        [MethodImpl(AggressiveInlining)]
        public static Any<Types<C1>> Any() => default;
        
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components.Pool<C1>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components.Pool<C1>.AddBlocker(1);
            #endif
            
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId,  Ecs<WorldID>.Components.Pool<C1>.id);
        }

        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components.Pool<C1>.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Types<C1, C2> : IComponentTypes, Stateless
        where C1 : struct, IComponent
        where C2 : struct, IComponent {
        
        [MethodImpl(AggressiveInlining)]
        public static All<Types<C1, C2>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static Double<C1, C2> Double() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static None<Types<C1, C2>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static AllAndNone<Types<C1, C2>, T> AllAndNone<T>(T without = default) where T : struct, IComponentTypes => default;
        
        [MethodImpl(AggressiveInlining)]
        public static Any<Types<C1, C2>> Any() => default;
        
       
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components.Pool<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C2>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components.Pool<C1>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C2>.AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C1>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C2>.id);
        }


        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components.Pool<C1>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C2>.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Types<C1, C2, C3> : IComponentTypes, Stateless
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent {
       
       [MethodImpl(AggressiveInlining)]
       public static All<Types<C1, C2, C3>> All() => default;
        
       [MethodImpl(AggressiveInlining)]
       public static None<Types<C1, C2, C3>> None() => default;
        
       [MethodImpl(AggressiveInlining)]
       public static AllAndNone<Types<C1, C2, C3>, T> AllAndNone<T>(T without = default) where T : struct, IComponentTypes => default;
        
       [MethodImpl(AggressiveInlining)]
       public static Any<Types<C1, C2, C3>> Any() => default;
       
       
       [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components.Pool<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C3>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components.Pool<C1>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C2>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C3>.AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C1>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C2>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C3>.id);
        }

        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components.Pool<C1>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C2>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C3>.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Types<C1, C2, C3, C4> : IComponentTypes, Stateless
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent {
        
        [MethodImpl(AggressiveInlining)]
        public static All<Types<C1, C2, C3, C4>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static None<Types<C1, C2, C3, C4>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static AllAndNone<Types<C1, C2, C3, C4>, T> AllAndNone<T>(T without = default) where T : struct, IComponentTypes => default;
        
        [MethodImpl(AggressiveInlining)]
        public static Any<Types<C1, C2, C3, C4>> Any() => default;
        
       
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components.Pool<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C4>.SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components.Pool<C1>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C2>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C3>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C4>.AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C1>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C2>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C3>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C4>.id);
        }

        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components.Pool<C1>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C2>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C3>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C4>.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Types<C1, C2, C3, C4, C5> : IComponentTypes, Stateless
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent {
        
        [MethodImpl(AggressiveInlining)]
        public static All<Types<C1, C2, C3, C4, C5>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static None<Types<C1, C2, C3, C4, C5>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static AllAndNone<Types<C1, C2, C3, C4, C5>, T> AllAndNone<T>(T without = default) where T : struct, IComponentTypes => default;
        
        [MethodImpl(AggressiveInlining)]
        public static Any<Types<C1, C2, C3, C4, C5>> Any() => default;
        
       
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components.Pool<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C4>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C5>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components.Pool<C1>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C2>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C3>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C4>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C5>.AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C1>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C2>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C3>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C4>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C5>.id);
        }

       
        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components.Pool<C1>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C2>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C3>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C4>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C5>.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Types<C1, C2, C3, C4, C5, C6> : IComponentTypes, Stateless
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where C6 : struct, IComponent {
        
        [MethodImpl(AggressiveInlining)]
        public static All<Types<C1, C2, C3, C4, C5, C6>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static None<Types<C1, C2, C3, C4, C5, C6>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static AllAndNone<Types<C1, C2, C3, C4, C5, C6>, T> AllAndNone<T>(T without = default) where T : struct, IComponentTypes => default;
        
        [MethodImpl(AggressiveInlining)]
        public static Any<Types<C1, C2, C3, C4, C5, C6>> Any() => default;
        
       
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components.Pool<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C4>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C5>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C6>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components.Pool<C1>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C2>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C3>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C4>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C5>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C6>.AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C1>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C2>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C3>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C4>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C5>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C6>.id);
        }

       
        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components.Pool<C1>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C2>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C3>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C4>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C5>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C6>.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Types<C1, C2, C3, C4, C5, C6, C7> : IComponentTypes, Stateless
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where C6 : struct, IComponent
        where C7 : struct, IComponent {
        
        [MethodImpl(AggressiveInlining)]
        public static All<Types<C1, C2, C3, C4, C5, C6, C7>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static None<Types<C1, C2, C3, C4, C5, C6, C7>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static AllAndNone<Types<C1, C2, C3, C4, C5, C6, C7>, T> AllAndNone<T>(T without = default) where T : struct, IComponentTypes => default;
        
        [MethodImpl(AggressiveInlining)]
        public static Any<Types<C1, C2, C3, C4, C5, C6, C7>> Any() => default;
        
       
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components.Pool<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C4>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C5>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C6>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C7>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components.Pool<C1>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C2>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C3>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C4>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C5>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C6>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C7>.AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C1>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C2>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C3>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C4>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C5>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C6>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C7>.id);
        }

       
        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components.Pool<C1>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C2>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C3>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C4>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C5>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C6>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C7>.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Types<C1, C2, C3, C4, C5, C6, C7, C8> : IComponentTypes, Stateless
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where C6 : struct, IComponent
        where C7 : struct, IComponent
        where C8 : struct, IComponent {
        
        [MethodImpl(AggressiveInlining)]
        public static All<Types<C1, C2, C3, C4, C5, C6, C7, C8>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static None<Types<C1, C2, C3, C4, C5, C6, C7, C8>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static AllAndNone<Types<C1, C2, C3, C4, C5, C6, C7, C8>, T> AllAndNone<T>(T without = default) where T : struct, IComponentTypes => default;
        
        [MethodImpl(AggressiveInlining)]
        public static Any<Types<C1, C2, C3, C4, C5, C6, C7, C8>> Any() => default;
       
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components.Pool<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C4>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C5>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C6>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C7>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components.Pool<C8>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components.Pool<C1>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C2>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C3>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C4>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C5>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C6>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C7>.AddBlocker(1);
            Ecs<WorldID>.Components.Pool<C8>.AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C1>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C2>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C3>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C4>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C5>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C6>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C7>.id);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components.Pool<C8>.id);
        }

       
        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components.Pool<C1>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C2>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C3>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C4>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C5>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C6>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C7>.AddBlocker(-1);
            Ecs<WorldID>.Components.Pool<C8>.AddBlocker(-1);
            #endif
        }
    }
}