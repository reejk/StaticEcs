#if !FFS_ECS_DISABLE_MASKS
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

namespace FFS.Libraries.StaticEcs {
    
    public interface IComponentMasks {
        public void SetMask<WorldID>(byte bufId) where WorldID : struct, IWorldId;
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public static class ComponentMasksExtensions {
        
        [MethodImpl(AggressiveInlining)]
        public static MaskBox Box<T>(this T types) where T : IComponentMasks {
            return new MaskBox(types);
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Mask<C1> : IComponentMasks, Stateless
        where C1 : struct, IMask {
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAll<Mask<C1>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskSingle<C1> Single() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskNone<Mask<C1>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAllAndNone<Mask<C1>, T> AllAndNone<T>(T without = default) where T : struct, IComponentMasks => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAny<Mask<C1>> Any() => default;
        
        [MethodImpl(AggressiveInlining)]
        public void SetMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            BitMaskUtils<WorldID, IMask>.SetInBuffer(0, Ecs<WorldID>.Masks.Pool<C1>.id);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Mask<C1, C2> : IComponentMasks, Stateless
        where C1 : struct, IMask
        where C2 : struct, IMask {
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAll<Mask<C1, C2>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskDouble<C1, C2> Double() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAllAndNone<Mask<C1, C2>, T> AllAndNone<T>(T without = default) where T : struct, IComponentMasks => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskNone<Mask<C1, C2>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAny<Mask<C1, C2>> Any() => default;
        
        [MethodImpl(AggressiveInlining)]
        public void SetMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C1>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C2>.id);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Mask<C1, C2, C3> : IComponentMasks, Stateless
        where C1 : struct, IMask
        where C2 : struct, IMask
        where C3 : struct, IMask {
        
       [MethodImpl(AggressiveInlining)]
       public static MaskAll<Mask<C1, C2, C3>> All() => default;
        
       [MethodImpl(AggressiveInlining)]
       public static MaskAllAndNone<Mask<C1, C2, C3>, T> AllAndNone<T>(T without = default) where T : struct, IComponentMasks => default;
        
       [MethodImpl(AggressiveInlining)]
       public static MaskNone<Mask<C1, C2, C3>> None() => default;
        
       [MethodImpl(AggressiveInlining)]
       public static MaskAny<Mask<C1, C2, C3>> Any() => default;
        
        [MethodImpl(AggressiveInlining)]
        public void SetMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C1>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C2>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C3>.id);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Mask<C1, C2, C3, C4> : IComponentMasks, Stateless
        where C1 : struct, IMask
        where C2 : struct, IMask
        where C3 : struct, IMask
        where C4 : struct, IMask {
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAll<Mask<C1, C2, C3, C4>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAllAndNone<Mask<C1, C2, C3, C4>, T> AllAndNone<T>(T without = default) where T : struct, IComponentMasks => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskNone<Mask<C1, C2, C3, C4>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAny<Mask<C1, C2, C3, C4>> Any() => default;
        
        public void SetMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C1>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C2>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C3>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C4>.id);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Mask<C1, C2, C3, C4, C5> : IComponentMasks, Stateless
        where C1 : struct, IMask
        where C2 : struct, IMask
        where C3 : struct, IMask
        where C4 : struct, IMask
        where C5 : struct, IMask {
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAll<Mask<C1, C2, C3, C4, C5>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAllAndNone<Mask<C1, C2, C3, C4, C5>, T> AllAndNone<T>(T without = default) where T : struct, IComponentMasks => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskNone<Mask<C1, C2, C3, C4, C5>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAny<Mask<C1, C2, C3, C4, C5>> Any() => default;
        
        public void SetMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C1>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C2>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C3>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C4>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C5>.id);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Mask<C1, C2, C3, C4, C5, C6> : IComponentMasks, Stateless
        where C1 : struct, IMask
        where C2 : struct, IMask
        where C3 : struct, IMask
        where C4 : struct, IMask
        where C5 : struct, IMask
        where C6 : struct, IMask {
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAll<Mask<C1, C2, C3, C4, C5, C6>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAllAndNone<Mask<C1, C2, C3, C4, C5, C6>, T> AllAndNone<T>(T without = default) where T : struct, IComponentMasks => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskNone<Mask<C1, C2, C3, C4, C5, C6>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAny<Mask<C1, C2, C3, C4, C5, C6>> Any() => default;
        
        public void SetMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C1>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C2>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C3>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C4>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C5>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C6>.id);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Mask<C1, C2, C3, C4, C5, C6, C7> : IComponentMasks, Stateless
        where C1 : struct, IMask
        where C2 : struct, IMask
        where C3 : struct, IMask
        where C4 : struct, IMask
        where C5 : struct, IMask
        where C6 : struct, IMask
        where C7 : struct, IMask {
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAll<Mask<C1, C2, C3, C4, C5, C6, C7>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAllAndNone<Mask<C1, C2, C3, C4, C5, C6, C7>, T> AllAndNone<T>(T without = default) where T : struct, IComponentMasks => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskNone<Mask<C1, C2, C3, C4, C5, C6, C7>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAny<Mask<C1, C2, C3, C4, C5, C6, C7>> Any() => default;
        
        public void SetMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C1>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C2>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C3>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C4>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C5>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C6>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C7>.id);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Mask<C1, C2, C3, C4, C5, C6, C7, C8> : IComponentMasks, Stateless
        where C1 : struct, IMask
        where C2 : struct, IMask
        where C3 : struct, IMask
        where C4 : struct, IMask
        where C5 : struct, IMask
        where C6 : struct, IMask
        where C7 : struct, IMask
        where C8 : struct, IMask {
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAll<Mask<C1, C2, C3, C4, C5, C6, C7, C8>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAllAndNone<Mask<C1, C2, C3, C4, C5, C6, C7, C8>, T> AllAndNone<T>(T without = default) where T : struct, IComponentMasks => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskNone<Mask<C1, C2, C3, C4, C5, C6, C7, C8>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static MaskAny<Mask<C1, C2, C3, C4, C5, C6, C7, C8>> Any() => default;
        
        public void SetMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C1>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C2>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C3>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C4>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C5>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C6>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C7>.id);
            BitMaskUtils<WorldID, IMask>.SetInBuffer(bufId, Ecs<WorldID>.Masks.Pool<C8>.id);
        }
    }
}
#endif