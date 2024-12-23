#if !FFS_ECS_DISABLE_TAGS
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

namespace FFS.Libraries.StaticEcs {
    public interface IComponentTags {
        public void SetData<WorldID>(ref int minCount, ref int[] _entities) where WorldID : struct, IWorldId;

        public void SetMask<WorldID>(byte bufId) where WorldID : struct, IWorldId;

        #if DEBUG
        public void Dispose<WorldID>() where WorldID : struct, IWorldId;
        #endif
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
                
        [MethodImpl(AggressiveInlining)]
        public static TagAll<T> All<T>(this T types) where T : struct, IComponentTags {
            return new TagAll<T>(types);
        }
        
        [MethodImpl(AggressiveInlining)]
        public static TagAllAndNone<T, W> AllAndNone<T, W>(this T types, W without = default) where T : struct, IComponentTags 
                                                                                              where W : struct, IComponentTags {
            return new TagAllAndNone<T, W>(types, without);
        }
        
        [MethodImpl(AggressiveInlining)]
        public static TagNone<T> None<T>(this T types) where T : struct, IComponentTags {
            return new TagNone<T>(types);
        }
        
        [MethodImpl(AggressiveInlining)]
        public static TagAny<T> Any<T>(this T types) where T : struct, IComponentTags {
            return new TagAny<T>(types);
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Tag<C1> : IComponentTags, Stateless
        where C1 : struct, ITag {
        
        [MethodImpl(AggressiveInlining)]
        public static TagSingle<C1> Single() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAll<Tag<C1>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagNone<Tag<C1>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAllAndNone<Tag<C1>, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAny<Tag<C1>> Any() => default;
        
        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref int[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags<C1>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockTags<WorldID>(1);
            #endif

            Ecs<WorldID>.ModuleTags.BitMask.SetInBuffer(bufId, Ecs<WorldID>.Tags<C1>.id);
        }

        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockTags<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockTags<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags<C1>.AddBlocker(val);
        }
        #endif
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Tag<C1, C2> : IComponentTags, Stateless
        where C1 : struct, ITag
        where C2 : struct, ITag {
        
        [MethodImpl(AggressiveInlining)]
        public static TagDouble<C1, C2> Double() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAll<Tag<C1, C2>> All() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagNone<Tag<C1, C2>> None() => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAllAndNone<Tag<C1, C2>, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => default;
        
        [MethodImpl(AggressiveInlining)]
        public static TagAny<Tag<C1, C2>> Any() => default;
        
       
        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref int[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C2>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockTags<WorldID>(1);
            #endif

            Ecs<WorldID>.ModuleTags.BitMask.SetInBuffer(bufId, 
                                                    Ecs<WorldID>.Tags<C1>.id,
                                                    Ecs<WorldID>.Tags<C2>.id);
        }


        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockTags<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockTags<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags<C1>.AddBlocker(val);
            Ecs<WorldID>.Tags<C2>.AddBlocker(val);
        }
        #endif
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
        public void SetData<WorldID>(ref int minCount, ref int[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C3>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockTags<WorldID>(1);
            #endif

            Ecs<WorldID>.ModuleTags.BitMask.SetInBuffer(bufId, 
                                                    Ecs<WorldID>.Tags<C1>.id,
                                                    Ecs<WorldID>.Tags<C2>.id,
                                                    Ecs<WorldID>.Tags<C3>.id);
        }

        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockTags<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockTags<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags<C1>.AddBlocker(val);
            Ecs<WorldID>.Tags<C2>.AddBlocker(val);
            Ecs<WorldID>.Tags<C3>.AddBlocker(val);
        }
        #endif
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
        public void SetData<WorldID>(ref int minCount, ref int[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C4>.SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockTags<WorldID>(1);
            #endif

            Ecs<WorldID>.ModuleTags.BitMask.SetInBuffer(bufId, 
                                                    Ecs<WorldID>.Tags<C1>.id,
                                                    Ecs<WorldID>.Tags<C2>.id,
                                                    Ecs<WorldID>.Tags<C3>.id,
                                                    Ecs<WorldID>.Tags<C4>.id);
        }

        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockTags<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockTags<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags<C1>.AddBlocker(val);
            Ecs<WorldID>.Tags<C2>.AddBlocker(val);
            Ecs<WorldID>.Tags<C3>.AddBlocker(val);
            Ecs<WorldID>.Tags<C4>.AddBlocker(val);
        }
        #endif
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
        public void SetData<WorldID>(ref int minCount, ref int[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C4>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C5>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockTags<WorldID>(1);
            #endif

            Ecs<WorldID>.ModuleTags.BitMask.SetInBuffer(bufId, 
                                                    Ecs<WorldID>.Tags<C1>.id,
                                                    Ecs<WorldID>.Tags<C2>.id,
                                                    Ecs<WorldID>.Tags<C3>.id,
                                                    Ecs<WorldID>.Tags<C4>.id,
                                                    Ecs<WorldID>.Tags<C5>.id);
        }
       
        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockTags<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockTags<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags<C1>.AddBlocker(val);
            Ecs<WorldID>.Tags<C2>.AddBlocker(val);
            Ecs<WorldID>.Tags<C3>.AddBlocker(val);
            Ecs<WorldID>.Tags<C4>.AddBlocker(val);
            Ecs<WorldID>.Tags<C5>.AddBlocker(val);
        }
        #endif
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
        public void SetData<WorldID>(ref int minCount, ref int[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C4>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C5>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C6>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockTags<WorldID>(1);
            #endif

            Ecs<WorldID>.ModuleTags.BitMask.SetInBuffer(bufId, 
                                                    Ecs<WorldID>.Tags<C1>.id,
                                                    Ecs<WorldID>.Tags<C2>.id,
                                                    Ecs<WorldID>.Tags<C3>.id,
                                                    Ecs<WorldID>.Tags<C4>.id,
                                                    Ecs<WorldID>.Tags<C5>.id,
                                                    Ecs<WorldID>.Tags<C6>.id);
        }
       
        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockTags<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockTags<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags<C1>.AddBlocker(val);
            Ecs<WorldID>.Tags<C2>.AddBlocker(val);
            Ecs<WorldID>.Tags<C3>.AddBlocker(val);
            Ecs<WorldID>.Tags<C4>.AddBlocker(val);
            Ecs<WorldID>.Tags<C5>.AddBlocker(val);
            Ecs<WorldID>.Tags<C6>.AddBlocker(val);
        }
        #endif
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
        public void SetData<WorldID>(ref int minCount, ref int[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C4>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C5>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C6>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C7>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockTags<WorldID>(1);
            #endif

            Ecs<WorldID>.ModuleTags.BitMask.SetInBuffer(bufId, 
                                                    Ecs<WorldID>.Tags<C1>.id,
                                                    Ecs<WorldID>.Tags<C2>.id,
                                                    Ecs<WorldID>.Tags<C3>.id,
                                                    Ecs<WorldID>.Tags<C4>.id,
                                                    Ecs<WorldID>.Tags<C5>.id,
                                                    Ecs<WorldID>.Tags<C6>.id,
                                                    Ecs<WorldID>.Tags<C7>.id);
        }
       
        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockTags<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockTags<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags<C1>.AddBlocker(val);
            Ecs<WorldID>.Tags<C2>.AddBlocker(val);
            Ecs<WorldID>.Tags<C3>.AddBlocker(val);
            Ecs<WorldID>.Tags<C4>.AddBlocker(val);
            Ecs<WorldID>.Tags<C5>.AddBlocker(val);
            Ecs<WorldID>.Tags<C6>.AddBlocker(val);
            Ecs<WorldID>.Tags<C7>.AddBlocker(val);
        }
        #endif
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
        public void SetData<WorldID>(ref int minCount, ref int[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags<C1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C2>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C3>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C4>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C5>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C6>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C7>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<C8>.SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockTags<WorldID>(1);
            #endif

            Ecs<WorldID>.ModuleTags.BitMask.SetInBuffer(bufId, 
                                                    Ecs<WorldID>.Tags<C1>.id,
                                                    Ecs<WorldID>.Tags<C2>.id,
                                                    Ecs<WorldID>.Tags<C3>.id,
                                                    Ecs<WorldID>.Tags<C4>.id,
                                                    Ecs<WorldID>.Tags<C5>.id,
                                                    Ecs<WorldID>.Tags<C6>.id,
                                                    Ecs<WorldID>.Tags<C7>.id,
                                                    Ecs<WorldID>.Tags<C8>.id);
        }
        
        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockTags<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockTags<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.Tags<C1>.AddBlocker(val);
            Ecs<WorldID>.Tags<C2>.AddBlocker(val);
            Ecs<WorldID>.Tags<C3>.AddBlocker(val);
            Ecs<WorldID>.Tags<C4>.AddBlocker(val);
            Ecs<WorldID>.Tags<C5>.AddBlocker(val);
            Ecs<WorldID>.Tags<C6>.AddBlocker(val);
            Ecs<WorldID>.Tags<C7>.AddBlocker(val);
            Ecs<WorldID>.Tags<C8>.AddBlocker(val);
        }
        #endif
    }
}
#endif