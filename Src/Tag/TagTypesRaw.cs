#if !FFS_ECS_DISABLE_TAGS
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
    public readonly struct TagBox : IComponentTags {
        public readonly IComponentTags Tags;
        
        [MethodImpl(AggressiveInlining)]
        public TagBox(IComponentTags tags) {
            Tags = tags;
        }

        [MethodImpl(AggressiveInlining)]
        public TagAll<TagBox> All() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagNone<TagBox> None() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagAllAndNone<TagBox, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => new(this, without);
        
        [MethodImpl(AggressiveInlining)]
        public TagAny<TagBox> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Tags.FillMinData(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            Tags.SetMaskBuffer<WorldID>(bufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            Tags.DisposeMask<WorldID>();
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Tag1 : IComponentTags {
        public readonly TagDynId C1;
        
        [MethodImpl(AggressiveInlining)]
        public Tag1(TagDynId c1) {
            C1 = c1;
        }
        
        [MethodImpl(AggressiveInlining)]
        public TagAll<Tag1> All() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagNone<Tag1> None() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagAllAndNone<Tag1, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => new(this, without);
        
        [MethodImpl(AggressiveInlining)]
        public TagAny<Tag1> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleTags.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleTags.GetPool(C1).AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId,  C1.Val);
        }

        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleTags.GetPool(C1).AddBlocker(-1);
            #endif
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Tag2 : IComponentTags {
        public readonly TagDynId C1;
        public readonly TagDynId C2;

        [MethodImpl(AggressiveInlining)]
        public Tag2(TagDynId c1, TagDynId c2) {
            C1 = c1;
            C2 = c2;
        }
        
        [MethodImpl(AggressiveInlining)]
        public TagAll<Tag2> All() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagNone<Tag2> None() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagAllAndNone<Tag2, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => new(this, without);
        
        [MethodImpl(AggressiveInlining)]
        public TagAny<Tag2> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleTags.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG            
            Ecs<WorldID>.ModuleTags.GetPool(C1).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C2).AddBlocker(1);
            #endif
            
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C1.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C2.Val);
        }
       
        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleTags.GetPool(C1).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C2).AddBlocker(-1);
            #endif
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Tag3 : IComponentTags {
        public readonly TagDynId C1;
        public readonly TagDynId C2;
        public readonly TagDynId C3;

        [MethodImpl(AggressiveInlining)]
        public Tag3(TagDynId c1, TagDynId c2, TagDynId c3) {
            C1 = c1;
            C2 = c2;
            C3 = c3;
        }
        
        [MethodImpl(AggressiveInlining)]
        public TagAll<Tag3> All() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagNone<Tag3> None() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagAllAndNone<Tag3, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => new(this, without);
        
        [MethodImpl(AggressiveInlining)]
        public TagAny<Tag3> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleTags.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C3).SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG            
            Ecs<WorldID>.ModuleTags.GetPool(C1).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C2).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C3).AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C1.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C2.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C3.Val);
        }
       
        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleTags.GetPool(C1).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C2).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C3).AddBlocker(-1);
            #endif
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Tag4 : IComponentTags {
        public readonly TagDynId C1;
        public readonly TagDynId C2;
        public readonly TagDynId C3;
        public readonly TagDynId C4;

        [MethodImpl(AggressiveInlining)]
        public Tag4(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4) {
            C1 = c1;
            C2 = c2;
            C3 = c3;
            C4 = c4;
        }
        
        [MethodImpl(AggressiveInlining)]
        public TagAll<Tag4> All() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagNone<Tag4> None() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagAllAndNone<Tag4, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => new(this, without);
        
        [MethodImpl(AggressiveInlining)]
        public TagAny<Tag4> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleTags.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C3).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C4).SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG            
            Ecs<WorldID>.ModuleTags.GetPool(C1).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C2).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C3).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C4).AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C1.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C2.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C3.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C4.Val);
        }

       
        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleTags.GetPool(C1).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C2).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C3).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C4).AddBlocker(-1);
            #endif
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Tag5 : IComponentTags {
        public readonly TagDynId C1;
        public readonly TagDynId C2;
        public readonly TagDynId C3;
        public readonly TagDynId C4;
        public readonly TagDynId C5;

        [MethodImpl(AggressiveInlining)]
        public Tag5(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4, TagDynId c5) {
            C1 = c1;
            C2 = c2;
            C3 = c3;
            C4 = c4;
            C5 = c5;
        }
        
        [MethodImpl(AggressiveInlining)]
        public TagAll<Tag5> All() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagNone<Tag5> None() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagAllAndNone<Tag5, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => new(this, without);
        
        [MethodImpl(AggressiveInlining)]
        public TagAny<Tag5> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleTags.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C3).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C4).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C5).SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG            
            Ecs<WorldID>.ModuleTags.GetPool(C1).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C2).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C3).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C4).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C5).AddBlocker(1);
            #endif
            
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C1.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C2.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C3.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C4.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C5.Val);
        }
       
        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleTags.GetPool(C1).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C2).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C3).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C4).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C5).AddBlocker(-1);
            #endif
        }
    }

    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Tag6 : IComponentTags {
        public readonly TagDynId C1;
        public readonly TagDynId C2;
        public readonly TagDynId C3;
        public readonly TagDynId C4;
        public readonly TagDynId C5;
        public readonly TagDynId C6;

        [MethodImpl(AggressiveInlining)]
        public Tag6(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4, TagDynId c5, TagDynId c6) {
            C1 = c1;
            C2 = c2;
            C3 = c3;
            C4 = c4;
            C5 = c5;
            C6 = c6;
        }
        
        [MethodImpl(AggressiveInlining)]
        public TagAll<Tag6> All() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagNone<Tag6> None() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagAllAndNone<Tag6, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => new(this, without);
        
        [MethodImpl(AggressiveInlining)]
        public TagAny<Tag6> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleTags.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C3).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C4).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C5).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C6).SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG            
            Ecs<WorldID>.ModuleTags.GetPool(C1).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C2).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C3).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C4).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C5).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C6).AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C1.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C2.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C3.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C4.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C5.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C6.Val);
        }
       
        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleTags.GetPool(C1).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C2).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C3).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C4).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C5).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C6).AddBlocker(-1);
            #endif
        }
    }
    
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Tag7 : IComponentTags {
        public readonly TagDynId C1;
        public readonly TagDynId C2;
        public readonly TagDynId C3;
        public readonly TagDynId C4;
        public readonly TagDynId C5;
        public readonly TagDynId C6;
        public readonly TagDynId C7;

        [MethodImpl(AggressiveInlining)]
        public Tag7(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4, TagDynId c5, TagDynId c6, TagDynId c7) {
            C1 = c1;
            C2 = c2;
            C3 = c3;
            C4 = c4;
            C5 = c5;
            C6 = c6;
            C7 = c7;
        }
        
        [MethodImpl(AggressiveInlining)]
        public TagAll<Tag7> All() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagNone<Tag7> None() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagAllAndNone<Tag7, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => new(this, without);
        
        [MethodImpl(AggressiveInlining)]
        public TagAny<Tag7> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleTags.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C3).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C4).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C5).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C6).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C7).SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG            
            Ecs<WorldID>.ModuleTags.GetPool(C1).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C2).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C3).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C4).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C5).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C6).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C7).AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C1.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C2.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C3.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C4.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C5.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C6.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C7.Val);
        }
       
        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleTags.GetPool(C1).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C2).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C3).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C4).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C5).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C6).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C7).AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Tag8 : IComponentTags {
        public readonly TagDynId C1;
        public readonly TagDynId C2;
        public readonly TagDynId C3;
        public readonly TagDynId C4;
        public readonly TagDynId C5;
        public readonly TagDynId C6;
        public readonly TagDynId C7;
        public readonly TagDynId C8;

        [MethodImpl(AggressiveInlining)]
        public Tag8(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4, TagDynId c5, TagDynId c6, TagDynId c7, TagDynId c8) {
            C1 = c1;
            C2 = c2;
            C3 = c3;
            C4 = c4;
            C5 = c5;
            C6 = c6;
            C7 = c7;
            C8 = c8;
        }
        
        [MethodImpl(AggressiveInlining)]
        public TagAll<Tag8> All() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagNone<Tag8> None() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagAllAndNone<Tag8, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => new(this, without);
        
        [MethodImpl(AggressiveInlining)]
        public TagAny<Tag8> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleTags.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C3).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C4).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C5).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C6).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C7).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleTags.GetPool(C8).SetDataIfCountLess(ref minCount, ref entities);
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG            
            Ecs<WorldID>.ModuleTags.GetPool(C1).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C2).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C3).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C4).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C5).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C6).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C7).AddBlocker(1);
            Ecs<WorldID>.ModuleTags.GetPool(C8).AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C1.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C2.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C3.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C4.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C5.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C6.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C7.Val);
            BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, C8.Val);
        }
       
        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleTags.GetPool(C1).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C2).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C3).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C4).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C5).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C6).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C7).AddBlocker(-1);
            Ecs<WorldID>.ModuleTags.GetPool(C8).AddBlocker(-1);
            #endif
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct TagArray : IComponentTags {
        public readonly TagDynId[] Tags;
        
        [MethodImpl(AggressiveInlining)]
        public TagArray(params TagDynId[] tags) {
            Tags = tags;
        }

        [MethodImpl(AggressiveInlining)]
        public TagAll<TagArray> All() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagNone<TagArray> None() => new(this);
        
        [MethodImpl(AggressiveInlining)]
        public TagAllAndNone<TagArray, T> AllAndNone<T>(T without = default) where T : struct, IComponentTags => new(this, without);
        
        [MethodImpl(AggressiveInlining)]
        public TagAny<TagArray> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            for (var i = 0; i < Tags.Length; i++) {
                Ecs<WorldID>.ModuleTags.GetPool(Tags[i]).SetDataIfCountLess(ref minCount, ref entities);
            }
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            for (var i = 0; i < Tags.Length; i++) {
                BitMaskUtils<WorldID, ITag>.SetInBuffer(bufId, Tags[i].Val);
                #if DEBUG
                Ecs<WorldID>.ModuleTags.GetPool(Tags[i]).AddBlocker(1);
                #endif
            }
        }
       
        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
             for (var i = 0; i < Tags.Length; i++) {
                var type = Tags[i];
                Ecs<WorldID>.ModuleTags.GetPool(type).AddBlocker(-1);
            }
            #endif
        }
    }
}
#endif