using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

namespace FFS.Libraries.StaticEcs {
    public interface IComponentTypes {
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] _entities) where WorldID : struct, IWorldId;

        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId;

        #if DEBUG
        public void Dispose<WorldID>() where WorldID : struct, IWorldId;
        #endif
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public static class ComponentTypesExtensions {
        [MethodImpl(AggressiveInlining)]
        public static TypesBox Box<T>(this T types) where T : struct, IComponentTypes {
            return new TypesBox(types);
        }
        
        [MethodImpl(AggressiveInlining)]
        public static All<T> All<T>(this T types) where T : struct, IComponentTypes {
            return new All<T>(types);
        }
        
        [MethodImpl(AggressiveInlining)]
        public static AllAndNone<T, W> AllAndNone<T, W>(this T types, W without = default) where T : struct, IComponentTypes 
                                                                                           where W : struct, IComponentTypes {
            return new AllAndNone<T, W>(types, without);
        }
        
        [MethodImpl(AggressiveInlining)]
        public static None<T> None<T>(this T types) where T : struct, IComponentTypes {
            return new None<T>(types);
        }
        
        [MethodImpl(AggressiveInlining)]
        public static Any<T> Any<T>(this T types) where T : struct, IComponentTypes {
            return new Any<T>(types);
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Types<C1> : IComponentTypes, Stateless
        where C1 : struct, IComponent {
        
        [MethodImpl(AggressiveInlining)]
        public static Single<C1> Single() => default;
        
        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components<C1>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockComponents<WorldID>(1);
            #endif
            
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId,  Ecs<WorldID>.Components<C1>.id);
        }
       
        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockComponents<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockComponents<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components<C1>.AddBlocker(val);
        }
        #endif
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Types<C1, C2> : IComponentTypes, Stateless
        where C1 : struct, IComponent
        where C2 : struct, IComponent {
        
        [MethodImpl(AggressiveInlining)]
        public static Double<C1, C2> Double() => default;
        
       
        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C2>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockComponents<WorldID>(1);
            #endif

            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Ecs<WorldID>.Components<C1>.id, Ecs<WorldID>.Components<C2>.id);
        }
       
        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockComponents<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockComponents<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components<C1>.AddBlocker(val);
            Ecs<WorldID>.Components<C2>.AddBlocker(val);
        }
        #endif
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
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C3>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockComponents<WorldID>(1);
            #endif

            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId,
                                                          Ecs<WorldID>.Components<C1>.id,
                                                          Ecs<WorldID>.Components<C2>.id,
                                                          Ecs<WorldID>.Components<C3>.id);
        }
       
        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockComponents<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockComponents<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components<C1>.AddBlocker(val);
            Ecs<WorldID>.Components<C2>.AddBlocker(val);
            Ecs<WorldID>.Components<C3>.AddBlocker(val);
        }
        #endif
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
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C4>.SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockComponents<WorldID>(1);
            #endif

            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId,
                                                          Ecs<WorldID>.Components<C1>.id,
                                                          Ecs<WorldID>.Components<C2>.id,
                                                          Ecs<WorldID>.Components<C3>.id,
                                                          Ecs<WorldID>.Components<C4>.id);
        }
       
        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockComponents<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockComponents<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components<C1>.AddBlocker(val);
            Ecs<WorldID>.Components<C2>.AddBlocker(val);
            Ecs<WorldID>.Components<C3>.AddBlocker(val);
            Ecs<WorldID>.Components<C4>.AddBlocker(val);
        }
        #endif
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
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C4>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C5>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockComponents<WorldID>(1);
            #endif

            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId,
                                                          Ecs<WorldID>.Components<C1>.id,
                                                          Ecs<WorldID>.Components<C2>.id,
                                                          Ecs<WorldID>.Components<C3>.id,
                                                          Ecs<WorldID>.Components<C4>.id,
                                                          Ecs<WorldID>.Components<C5>.id);
        }
       
        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockComponents<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockComponents<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components<C1>.AddBlocker(val);
            Ecs<WorldID>.Components<C2>.AddBlocker(val);
            Ecs<WorldID>.Components<C3>.AddBlocker(val);
            Ecs<WorldID>.Components<C4>.AddBlocker(val);
            Ecs<WorldID>.Components<C5>.AddBlocker(val);
        }
        #endif
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
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C4>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C5>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C6>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockComponents<WorldID>(1);
            #endif

            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId,
                                                          Ecs<WorldID>.Components<C1>.id,
                                                          Ecs<WorldID>.Components<C2>.id,
                                                          Ecs<WorldID>.Components<C3>.id,
                                                          Ecs<WorldID>.Components<C4>.id,
                                                          Ecs<WorldID>.Components<C5>.id,
                                                          Ecs<WorldID>.Components<C6>.id);
        }
       
        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockComponents<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockComponents<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components<C1>.AddBlocker(val);
            Ecs<WorldID>.Components<C2>.AddBlocker(val);
            Ecs<WorldID>.Components<C3>.AddBlocker(val);
            Ecs<WorldID>.Components<C4>.AddBlocker(val);
            Ecs<WorldID>.Components<C5>.AddBlocker(val);
            Ecs<WorldID>.Components<C6>.AddBlocker(val);
        }
        #endif
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
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C4>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C5>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C6>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C7>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockComponents<WorldID>(1);
            #endif

            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId,
                                                          Ecs<WorldID>.Components<C1>.id,
                                                          Ecs<WorldID>.Components<C2>.id,
                                                          Ecs<WorldID>.Components<C3>.id,
                                                          Ecs<WorldID>.Components<C4>.id,
                                                          Ecs<WorldID>.Components<C5>.id,
                                                          Ecs<WorldID>.Components<C6>.id,
                                                          Ecs<WorldID>.Components<C7>.id);
        }
       
        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockComponents<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockComponents<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components<C1>.AddBlocker(val);
            Ecs<WorldID>.Components<C2>.AddBlocker(val);
            Ecs<WorldID>.Components<C3>.AddBlocker(val);
            Ecs<WorldID>.Components<C4>.AddBlocker(val);
            Ecs<WorldID>.Components<C5>.AddBlocker(val);
            Ecs<WorldID>.Components<C6>.AddBlocker(val);
            Ecs<WorldID>.Components<C7>.AddBlocker(val);
        }
        #endif
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
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C4>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C5>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C6>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C7>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<C8>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockComponents<WorldID>(1);
            #endif

            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId,
                                                          Ecs<WorldID>.Components<C1>.id,
                                                          Ecs<WorldID>.Components<C2>.id,
                                                          Ecs<WorldID>.Components<C3>.id,
                                                          Ecs<WorldID>.Components<C4>.id,
                                                          Ecs<WorldID>.Components<C5>.id,
                                                          Ecs<WorldID>.Components<C6>.id,
                                                          Ecs<WorldID>.Components<C7>.id,
                                                          Ecs<WorldID>.Components<C8>.id);
        }
       
        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockComponents<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockComponents<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Components<C1>.AddBlocker(val);
            Ecs<WorldID>.Components<C2>.AddBlocker(val);
            Ecs<WorldID>.Components<C3>.AddBlocker(val);
            Ecs<WorldID>.Components<C4>.AddBlocker(val);
            Ecs<WorldID>.Components<C5>.AddBlocker(val);
            Ecs<WorldID>.Components<C6>.AddBlocker(val);
            Ecs<WorldID>.Components<C7>.AddBlocker(val);
            Ecs<WorldID>.Components<C8>.AddBlocker(val);
        }
        #endif
    }
}