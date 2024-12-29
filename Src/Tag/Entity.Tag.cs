#if !FFS_ECS_DISABLE_TAGS
using System;
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
    public abstract partial class Ecs<WorldID> {
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public partial struct Entity {

            [MethodImpl(AggressiveInlining)]
            public int TagsCount() => ModuleTags.TagsCount(this);

            #region BY_TYPE
            #region HAS
            [MethodImpl(AggressiveInlining)]
            public bool HasAllOfTags<C>() where C : struct, ITag {
                return Tags<C>.Value.Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public bool HasAllOfTags<C1, C2>()
                where C1 : struct, ITag
                where C2 : struct, ITag {
                return Tags<C1>.Value.Has(this) && Tags<C2>.Value.Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public bool HasAllOfTags<C1, C2, C3>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag {
                return Tags<C1>.Value.Has(this) && Tags<C2>.Value.Has(this) && Tags<C3>.Value.Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public bool HasAnyOfTags<C1, C2>()
                where C1 : struct, ITag
                where C2 : struct, ITag {
                return Tags<C1>.Value.Has(this) || Tags<C2>.Value.Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public bool HasAnyOfTags<C1, C2, C3>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag {
                return Tags<C1>.Value.Has(this) || Tags<C2>.Value.Has(this) || Tags<C3>.Value.Has(this);
            }
            #endregion

            #region ADD
            [MethodImpl(AggressiveInlining)]
            public void AddTag<C>()
                where C : struct, ITag {
                Tags<C>.Value.Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public void AddTag<C1, C2>()
                where C1 : struct, ITag
                where C2 : struct, ITag {
                Tags<C1>.Value.Add(this);
                Tags<C2>.Value.Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public void AddTag<C1, C2, C3>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag {
                Tags<C1>.Value.Add(this);
                Tags<C2>.Value.Add(this);
                Tags<C3>.Value.Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public void AddTag<C1, C2, C3, C4>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag
                where C4 : struct, ITag {
                Tags<C1>.Value.Add(this);
                Tags<C2>.Value.Add(this);
                Tags<C3>.Value.Add(this);
                Tags<C4>.Value.Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public void AddTag<C1, C2, C3, C4, C5>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag
                where C4 : struct, ITag
                where C5 : struct, ITag {
                Tags<C1>.Value.Add(this);
                Tags<C2>.Value.Add(this);
                Tags<C3>.Value.Add(this);
                Tags<C4>.Value.Add(this);
                Tags<C5>.Value.Add(this);
            }
            
            [MethodImpl(AggressiveInlining)]
            public void TryAddTag<C>()
                where C : struct, ITag {
                Tags<C>.Value.TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public void TryAddTag<C1, C2>()
                where C1 : struct, ITag
                where C2 : struct, ITag {
                Tags<C1>.Value.TryAdd(this);
                Tags<C2>.Value.TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public void TryAddTag<C1, C2, C3>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag {
                Tags<C1>.Value.TryAdd(this);
                Tags<C2>.Value.TryAdd(this);
                Tags<C3>.Value.TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public void TryAddTag<C1, C2, C3, C4>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag
                where C4 : struct, ITag {
                Tags<C1>.Value.TryAdd(this);
                Tags<C2>.Value.TryAdd(this);
                Tags<C3>.Value.TryAdd(this);
                Tags<C4>.Value.TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public void TryAddTag<C1, C2, C3, C4, C5>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag
                where C4 : struct, ITag
                where C5 : struct, ITag {
                Tags<C1>.Value.TryAdd(this);
                Tags<C2>.Value.TryAdd(this);
                Tags<C3>.Value.TryAdd(this);
                Tags<C4>.Value.TryAdd(this);
                Tags<C5>.Value.TryAdd(this);
            }
            
            [MethodImpl(AggressiveInlining)]
            public void TryAddTag<C>(out bool added)
                where C : struct, ITag {
                Tags<C>.Value.TryAdd(this, out added);
            }

            [MethodImpl(AggressiveInlining)]
            public void TryAddTag<C1, C2>(out bool added)
                where C1 : struct, ITag
                where C2 : struct, ITag {
                Tags<C1>.Value.TryAdd(this, out var added1);
                Tags<C2>.Value.TryAdd(this, out var added2);
                added = added1 || added2;
            }

            [MethodImpl(AggressiveInlining)]
            public void TryAddTag<C1, C2, C3>(out bool added)
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag {
                Tags<C1>.Value.TryAdd(this, out var added1);
                Tags<C2>.Value.TryAdd(this, out var added2);
                Tags<C3>.Value.TryAdd(this, out var added3);
                added = added1 || added2 || added3;
            }

            [MethodImpl(AggressiveInlining)]
            public void TryAddTag<C1, C2, C3, C4>(out bool added)
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag
                where C4 : struct, ITag {
                Tags<C1>.Value.TryAdd(this, out var added1);
                Tags<C2>.Value.TryAdd(this, out var added2);
                Tags<C3>.Value.TryAdd(this, out var added3);
                Tags<C4>.Value.TryAdd(this, out var added4);
                added = added1 || added2 || added3 || added4;
            }
            
            [MethodImpl(AggressiveInlining)]
            public void TryAddTag<C1, C2, C3, C4, C5>(out bool added)
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag
                where C4 : struct, ITag
                where C5 : struct, ITag {
                Tags<C1>.Value.TryAdd(this, out var added1);
                Tags<C2>.Value.TryAdd(this, out var added2);
                Tags<C3>.Value.TryAdd(this, out var added3);
                Tags<C4>.Value.TryAdd(this, out var added4);
                Tags<C5>.Value.TryAdd(this, out var added5);
                added = added1 || added2 || added3 || added4 || added5;
            }
            #endregion

            #region DELETE
            [MethodImpl(AggressiveInlining)]
            public bool DeleteTag<C>() where C : struct, ITag {
                return Tags<C>.Value.Delete(this);
            }

            [MethodImpl(AggressiveInlining)]
            public bool DeleteTag<C1, C2>()
                where C1 : struct, ITag
                where C2 : struct, ITag {
                var delC1 = Tags<C1>.Value.Delete(this);
                var delC2 = Tags<C2>.Value.Delete(this);
                return delC1 && delC2;
            }

            [MethodImpl(AggressiveInlining)]
            public bool DeleteTag<C1, C2, C3>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag {
                var delC1 = Tags<C1>.Value.Delete(this);
                var delC2 = Tags<C2>.Value.Delete(this);
                var delC3 = Tags<C3>.Value.Delete(this);

                return delC1 && delC2 && delC3;
            }

            [MethodImpl(AggressiveInlining)]
            public bool DeleteTag<C1, C2, C3, C4>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag
                where C4 : struct, ITag {
                var delC1 = Tags<C1>.Value.Delete(this);
                var delC2 = Tags<C2>.Value.Delete(this);
                var delC3 = Tags<C3>.Value.Delete(this);
                var delC4 = Tags<C4>.Value.Delete(this);

                return delC1 && delC2 && delC3 && delC4;
            }

            [MethodImpl(AggressiveInlining)]
            public bool DeleteTag<C1, C2, C3, C4, C5>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag
                where C4 : struct, ITag
                where C5 : struct, ITag {
                var delC1 = Tags<C1>.Value.Delete(this);
                var delC2 = Tags<C2>.Value.Delete(this);
                var delC3 = Tags<C3>.Value.Delete(this);
                var delC4 = Tags<C4>.Value.Delete(this);
                var delC5 = Tags<C5>.Value.Delete(this);

                return delC1 && delC2 && delC3 && delC4 && delC5;
            }
            #endregion
            
            #region MOVE
            [MethodImpl(AggressiveInlining)]
            public void MoveTagsTo<C1>(Entity target)
                where C1 : struct, ITag {
                Tags<C1>.Value.Move(this, target);
            }
            
            [MethodImpl(AggressiveInlining)]
            public void MoveTagsTo<C1, C2>(Entity target)
                where C1 : struct, ITag
                where C2 : struct, ITag {
                Tags<C1>.Value.Move(this, target);
                Tags<C2>.Value.Move(this, target);
            }
            
            [MethodImpl(AggressiveInlining)]
            public void MoveTagsTo<C1, C2, C3>(Entity target)
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag {
                Tags<C1>.Value.Move(this, target);
                Tags<C2>.Value.Move(this, target);
                Tags<C3>.Value.Move(this, target);
            }
            
            [MethodImpl(AggressiveInlining)]
            public void MoveTagsTo<C1, C2, C3, C4>(Entity target)
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag
                where C4 : struct, ITag {
                Tags<C1>.Value.Move(this, target);
                Tags<C2>.Value.Move(this, target);
                Tags<C3>.Value.Move(this, target);
                Tags<C4>.Value.Move(this, target);
            }
            
            [MethodImpl(AggressiveInlining)]
            public void MoveTagsTo<C1, C2, C3, C4, C5>(Entity target)
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag
                where C4 : struct, ITag
                where C5 : struct, ITag {
                Tags<C1>.Value.Move(this, target);
                Tags<C2>.Value.Move(this, target);
                Tags<C3>.Value.Move(this, target);
                Tags<C4>.Value.Move(this, target);
                Tags<C5>.Value.Move(this, target);
            }
            #endregion
            #endregion

            #region BY_ID
            #region HAS
            [MethodImpl(AggressiveInlining)]
            public bool HasAllOfTags(TagDynId c) {
                return ModuleTags.GetPool(c).Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public bool HasAllOfTags(TagDynId c1, TagDynId c2) {
                return ModuleTags.GetPool(c1).Has(this) && ModuleTags.GetPool(c2).Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public bool HasAllOfTags(TagDynId c1, TagDynId c2, TagDynId c3) {
                return ModuleTags.GetPool(c1).Has(this) && ModuleTags.GetPool(c2).Has(this) && ModuleTags.GetPool(c3).Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public bool HasAnyOfTags(TagDynId c1, TagDynId c2) {
                return ModuleTags.GetPool(c1).Has(this) || ModuleTags.GetPool(c2).Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public bool HasAnyOfTags(TagDynId c1, TagDynId c2, TagDynId c3) {
                return ModuleTags.GetPool(c1).Has(this) || ModuleTags.GetPool(c2).Has(this) || ModuleTags.GetPool(c3).Has(this);
            }
            #endregion
            
            #region ADD
            [MethodImpl(AggressiveInlining)]
            public void AddTag(TagDynId c) {
                ModuleTags.GetPool(c).Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public void AddTag(TagDynId c1, TagDynId c2) {
                ModuleTags.GetPool(c1).Add(this);
                ModuleTags.GetPool(c2).Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public void AddTag(TagDynId c1, TagDynId c2, TagDynId c3) {
                ModuleTags.GetPool(c1).Add(this);
                ModuleTags.GetPool(c2).Add(this);
                ModuleTags.GetPool(c3).Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public void AddTag(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4) {
                ModuleTags.GetPool(c1).Add(this);
                ModuleTags.GetPool(c2).Add(this);
                ModuleTags.GetPool(c3).Add(this);
                ModuleTags.GetPool(c4).Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public void AddTag(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4, TagDynId c5) {
                ModuleTags.GetPool(c1).Add(this);
                ModuleTags.GetPool(c2).Add(this);
                ModuleTags.GetPool(c3).Add(this);
                ModuleTags.GetPool(c4).Add(this);
                ModuleTags.GetPool(c5).Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public void TryAddTag(TagDynId c) {
                ModuleTags.GetPool(c).TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public void TryAddTag(TagDynId c1, TagDynId c2) {
                ModuleTags.GetPool(c1).TryAdd(this);
                ModuleTags.GetPool(c2).TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public void TryAddTag(TagDynId c1, TagDynId c2, TagDynId c3) {
                ModuleTags.GetPool(c1).TryAdd(this);
                ModuleTags.GetPool(c2).TryAdd(this);
                ModuleTags.GetPool(c3).TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public void TryAddTag(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4) {
                ModuleTags.GetPool(c1).TryAdd(this);
                ModuleTags.GetPool(c2).TryAdd(this);
                ModuleTags.GetPool(c3).TryAdd(this);
                ModuleTags.GetPool(c4).TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public void TryAddTag(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4, TagDynId c5) {
                ModuleTags.GetPool(c1).TryAdd(this);
                ModuleTags.GetPool(c2).TryAdd(this);
                ModuleTags.GetPool(c3).TryAdd(this);
                ModuleTags.GetPool(c4).TryAdd(this);
                ModuleTags.GetPool(c5).TryAdd(this);
            }
            
            [MethodImpl(AggressiveInlining)]
            public void TryAddTag(TagDynId c, out bool added) {
                ModuleTags.GetPool(c).TryAdd(this, out added);
            }

            [MethodImpl(AggressiveInlining)]
            public void TryAddTag(TagDynId c1, TagDynId c2, out bool added) {
                ModuleTags.GetPool(c1).TryAdd(this, out var added1);
                ModuleTags.GetPool(c2).TryAdd(this, out var added2);
                added = added1 || added2;
            }

            [MethodImpl(AggressiveInlining)]
            public void TryAddTag(TagDynId c1, TagDynId c2, TagDynId c3, out bool added) {
                ModuleTags.GetPool(c1).TryAdd(this, out var added1);
                ModuleTags.GetPool(c2).TryAdd(this, out var added2);
                ModuleTags.GetPool(c3).TryAdd(this, out var added3);
                added = added1 || added2 || added3;
            }

            [MethodImpl(AggressiveInlining)]
            public void TryAddTag(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4, out bool added) {
                ModuleTags.GetPool(c1).TryAdd(this, out var added1);
                ModuleTags.GetPool(c2).TryAdd(this, out var added2);
                ModuleTags.GetPool(c3).TryAdd(this, out var added3);
                ModuleTags.GetPool(c4).TryAdd(this, out var added4);
                added = added1 || added2 || added3 || added4;
            }

            [MethodImpl(AggressiveInlining)]
            public void TryAddTag(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4, TagDynId c5, out bool added) {
                ModuleTags.GetPool(c1).TryAdd(this, out var added1);
                ModuleTags.GetPool(c2).TryAdd(this, out var added2);
                ModuleTags.GetPool(c3).TryAdd(this, out var added3);
                ModuleTags.GetPool(c4).TryAdd(this, out var added4);
                ModuleTags.GetPool(c5).TryAdd(this, out var added5);
                added = added1 || added2 || added3 || added4 || added5;
            }
            #endregion
            
            #region DELETE
            [MethodImpl(AggressiveInlining)]
            public bool DeleteTag(TagDynId c) {
                return ModuleTags.GetPool(c).Del(this);
            }

            [MethodImpl(AggressiveInlining)]
            public bool DeleteTag(TagDynId c1, TagDynId c2) {
                var delC1 = ModuleTags.GetPool(c1).Del(this);
                var delC2 = ModuleTags.GetPool(c2).Del(this);

                return delC1 && delC2;
            }

            [MethodImpl(AggressiveInlining)]
            public bool DeleteTag(TagDynId c1, TagDynId c2, TagDynId c3) {
                var delC1 = ModuleTags.GetPool(c1).Del(this);
                var delC2 = ModuleTags.GetPool(c2).Del(this);
                var delC3 = ModuleTags.GetPool(c3).Del(this);

                return delC1 && delC2 && delC3;
            }

            [MethodImpl(AggressiveInlining)]
            public bool DeleteTag(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4) {
                var delC1 = ModuleTags.GetPool(c1).Del(this);
                var delC2 = ModuleTags.GetPool(c2).Del(this);
                var delC3 = ModuleTags.GetPool(c3).Del(this);
                var delC4 = ModuleTags.GetPool(c4).Del(this);

                return delC1 && delC2 && delC3 && delC4;
            }

            [MethodImpl(AggressiveInlining)]
            public bool DeleteTag(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4, TagDynId c5) {
                var delC1 = ModuleTags.GetPool(c1).Del(this);
                var delC2 = ModuleTags.GetPool(c2).Del(this);
                var delC3 = ModuleTags.GetPool(c3).Del(this);
                var delC4 = ModuleTags.GetPool(c4).Del(this);
                var delC5 = ModuleTags.GetPool(c5).Del(this);

                return delC1 && delC2 && delC3 && delC4 && delC5;
            }
            #endregion
            
            #region MOVE
            [MethodImpl(AggressiveInlining)]
            public void MoveTagsTo(TagDynId c, Entity target) {
                ModuleTags.GetPool(c).Move(this, target);
            }

            [MethodImpl(AggressiveInlining)]
            public void MoveTagsTo(TagDynId c1, TagDynId c2, Entity target) {
                ModuleTags.GetPool(c1).Move(this, target);
                ModuleTags.GetPool(c2).Move(this, target);
            }

            [MethodImpl(AggressiveInlining)]
            public void MoveTagsTo(TagDynId c1, TagDynId c2, TagDynId c3, Entity target) {
                ModuleTags.GetPool(c1).Move(this, target);
                ModuleTags.GetPool(c2).Move(this, target);
                ModuleTags.GetPool(c3).Move(this, target);
            }

            [MethodImpl(AggressiveInlining)]
            public void MoveTagsTo(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4, Entity target) {
                ModuleTags.GetPool(c1).Move(this, target);
                ModuleTags.GetPool(c2).Move(this, target);
                ModuleTags.GetPool(c3).Move(this, target);
                ModuleTags.GetPool(c4).Move(this, target);
            }

            [MethodImpl(AggressiveInlining)]
            public void MoveTagsTo(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4, TagDynId c5, Entity target) {
                ModuleTags.GetPool(c1).Move(this, target);
                ModuleTags.GetPool(c2).Move(this, target);
                ModuleTags.GetPool(c3).Move(this, target);
                ModuleTags.GetPool(c4).Move(this, target);
                ModuleTags.GetPool(c5).Move(this, target);
            }
            #endregion
            #endregion
            
            #region BY_RAW_TYPE
            [MethodImpl(AggressiveInlining)]
            public bool HasAllOfTags(Type tagType) {
                return ModuleTags.GetPool(tagType).Has(this);
            }
            
            [MethodImpl(AggressiveInlining)]
            public void AddTag(Type tagType) {
                ModuleTags.GetPool(tagType).Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public void TryAddTag(Type tagType) {
                ModuleTags.GetPool(tagType).TryAdd(this);
            }
            
            [MethodImpl(AggressiveInlining)]
            public void TryAddTag(Type tagType, out bool added) {
                ModuleTags.GetPool(tagType).TryAdd(this, out added);
            }
            
            [MethodImpl(AggressiveInlining)]
            public bool DeleteTag(Type tagType) {
                return ModuleTags.GetPool(tagType).Del(this);
            }
            
            [MethodImpl(AggressiveInlining)]
            public void MoveTagsTo(Type tagType, Entity target) {
                ModuleTags.GetPool(tagType).Move(this, target);
            }
            #endregion
        }
    }
    
    public partial interface IEntity {
        public int TagsCount();

        public bool HasAllOfTags<C>() where C : struct, ITag;

        public void AddTag<C>() where C : struct, ITag;

        public bool DeleteTag<C>() where C : struct, ITag;

        public bool HasAllOfTags(Type tagType);

        public void AddTag(Type tagType);

        public void TryAddTag(Type tagType);

        public void TryAddTag(Type tagType, out bool added);

        public bool DeleteTag(Type tagType);

    }
}
#endif