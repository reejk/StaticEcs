#if !FFS_ECS_DISABLE_TAGS
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

namespace FFS.Libraries.StaticEcs {
    public interface IComponentTags {
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] _entities) where WorldID : struct, IWorldId;

        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId;

        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId;
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public static class ComponentTagsExtensions {
        
        [MethodImpl(AggressiveInlining)]
        public static TagBox Box<T>(this T types) where T : IComponentTags {
            return new TagBox(types);
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Tag<C1> : IComponentTags, Stateless
        where C1 : struct, ITag {
        
        [MethodImpl(AggressiveInlining)]
        public static TagAll<Tag<C1>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagNone<Tag<C1>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAllAndNone<Tag<C1>, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAny<Tag<C1>> Any() => default;
        
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags.Pool<C1>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags.Pool<C1>.AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C1>.id);
        }

        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags.Pool<C1>.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Tag<C1, C2> : IComponentTags, Stateless
        where C1 : struct, ITag
        where C2 : struct, ITag {
        
        [MethodImpl(AggressiveInlining)]
        public static TagAll<Tag<C1, C2>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagNone<Tag<C1, C2>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAllAndNone<Tag<C1, C2>, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAny<Tag<C1, C2>> Any() => default;
        
       
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags.Pool<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C2>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags.Pool<C1>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C2>.AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C1>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C2>.id);
        }


        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags.Pool<C1>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C2>.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Tag<C1, C2, C3> : IComponentTags, Stateless
        where C1 : struct, ITag
        where C2 : struct, ITag
        where C3 : struct, ITag {
        
       [MethodImpl(AggressiveInlining)]
       public static TagAll<Tag<C1, C2, C3>> All() => default;
        
       [MethodImpl(AggressiveInlining)]
       public static TagNone<Tag<C1, C2, C3>> None() => default;
        
       [MethodImpl(AggressiveInlining)]
       public static TagAllAndNone<Tag<C1, C2, C3>, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => default;
        
       [MethodImpl(AggressiveInlining)]
       public static TagAny<Tag<C1, C2, C3>> Any() => default;
       
       
       [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags.Pool<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C3>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags.Pool<C1>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C2>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C3>.AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C1>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C2>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C3>.id);
        }

        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags.Pool<C1>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C2>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C3>.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Tag<C1, C2, C3, C4> : IComponentTags, Stateless
        where C1 : struct, ITag
        where C2 : struct, ITag
        where C3 : struct, ITag
        where C4 : struct, ITag {
        
        [MethodImpl(AggressiveInlining)]
        public static TagAll<Tag<C1, C2, C3, C4>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagNone<Tag<C1, C2, C3, C4>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAllAndNone<Tag<C1, C2, C3, C4>, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAny<Tag<C1, C2, C3, C4>> Any() => default;
        
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags.Pool<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C4>.SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags.Pool<C1>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C2>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C3>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C4>.AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C1>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C2>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C3>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C4>.id);
        }

        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags.Pool<C1>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C2>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C3>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C4>.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Tag<C1, C2, C3, C4, C5> : IComponentTags, Stateless
        where C1 : struct, ITag
        where C2 : struct, ITag
        where C3 : struct, ITag
        where C4 : struct, ITag
        where C5 : struct, ITag {
        
        [MethodImpl(AggressiveInlining)]
        public static TagAll<Tag<C1, C2, C3, C4, C5>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagNone<Tag<C1, C2, C3, C4, C5>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAllAndNone<Tag<C1, C2, C3, C4, C5>, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAny<Tag<C1, C2, C3, C4, C5>> Any() => default;
       
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags.Pool<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C4>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C5>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags.Pool<C1>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C2>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C3>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C4>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C5>.AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C1>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C2>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C3>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C4>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C5>.id);
        }
       
        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags.Pool<C1>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C2>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C3>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C4>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C5>.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Tag<C1, C2, C3, C4, C5, C6> : IComponentTags, Stateless
        where C1 : struct, ITag
        where C2 : struct, ITag
        where C3 : struct, ITag
        where C4 : struct, ITag
        where C5 : struct, ITag
        where C6 : struct, ITag {
        
        [MethodImpl(AggressiveInlining)]
        public static TagAll<Tag<C1, C2, C3, C4, C5, C6>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagNone<Tag<C1, C2, C3, C4, C5, C6>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAllAndNone<Tag<C1, C2, C3, C4, C5, C6>, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAny<Tag<C1, C2, C3, C4, C5, C6>> Any() => default;
       
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags.Pool<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C4>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C5>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C6>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags.Pool<C1>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C2>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C3>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C4>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C5>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C6>.AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C1>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C2>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C3>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C4>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C5>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C6>.id);
        }
       
        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags.Pool<C1>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C2>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C3>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C4>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C5>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C6>.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Tag<C1, C2, C3, C4, C5, C6, C7> : IComponentTags, Stateless
        where C1 : struct, ITag
        where C2 : struct, ITag
        where C3 : struct, ITag
        where C4 : struct, ITag
        where C5 : struct, ITag
        where C6 : struct, ITag
        where C7 : struct, ITag {
        
        [MethodImpl(AggressiveInlining)]
        public static TagAll<Tag<C1, C2, C3, C4, C5, C6, C7>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagNone<Tag<C1, C2, C3, C4, C5, C6, C7>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAllAndNone<Tag<C1, C2, C3, C4, C5, C6, C7>, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAny<Tag<C1, C2, C3, C4, C5, C6, C7>> Any() => default;
        
       
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags.Pool<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C4>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C5>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C6>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C7>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags.Pool<C1>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C2>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C3>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C4>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C5>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C6>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C7>.AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C1>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C2>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C3>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C4>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C5>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C6>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C7>.id);
        }
       
        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags.Pool<C1>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C2>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C3>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C4>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C5>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C6>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C7>.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Tag<C1, C2, C3, C4, C5, C6, C7, C8> : IComponentTags, Stateless
        where C1 : struct, ITag
        where C2 : struct, ITag
        where C3 : struct, ITag
        where C4 : struct, ITag
        where C5 : struct, ITag
        where C6 : struct, ITag
        where C7 : struct, ITag
        where C8 : struct, ITag {
        
        [MethodImpl(AggressiveInlining)]
        public static TagAll<Tag<C1, C2, C3, C4, C5, C6, C7, C8>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagNone<Tag<C1, C2, C3, C4, C5, C6, C7, C8>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAllAndNone<Tag<C1, C2, C3, C4, C5, C6, C7, C8>, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAny<Tag<C1, C2, C3, C4, C5, C6, C7, C8>> Any() => default;
        
       
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags.Pool<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C4>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C5>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C6>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C7>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags.Pool<C8>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags.Pool<C1>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C2>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C3>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C4>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C5>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C6>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C7>.AddBlocker(1);
            Ecs<WorldID>.Tags.Pool<C8>.AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C1>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C2>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C3>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C4>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C5>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C6>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C7>.id);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Ecs<WorldID>.Tags.Pool<C8>.id);
        }
       
        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags.Pool<C1>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C2>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C3>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C4>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C5>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C6>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C7>.AddBlocker(-1);
            Ecs<WorldID>.Tags.Pool<C8>.AddBlocker(-1);
            #endif
        }
    }
}
#endif