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
    public abstract partial class Ecs<WorldID> {
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public partial struct Entity {

            [MethodImpl(AggressiveInlining)]
            public readonly int TagsCount() => Tags.TagsCount(this);

            #region BY_TYPE
            #region HAS
            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAllOfTags<C>() where C : struct, ITag {
                return Tags.Pool<C>.Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAllOfTags<C1, C2>()
                where C1 : struct, ITag
                where C2 : struct, ITag {
                return Tags.Pool<C1>.Has(this) && Tags.Pool<C2>.Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAllOfTags<C1, C2, C3>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag {
                return Tags.Pool<C1>.Has(this) && Tags.Pool<C2>.Has(this) && Tags.Pool<C3>.Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAnyOfTags<C1, C2>()
                where C1 : struct, ITag
                where C2 : struct, ITag {
                return Tags.Pool<C1>.Has(this) || Tags.Pool<C2>.Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAnyOfTags<C1, C2, C3>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag {
                return Tags.Pool<C1>.Has(this) || Tags.Pool<C2>.Has(this) || Tags.Pool<C3>.Has(this);
            }
            #endregion

            #region ADD
            [MethodImpl(AggressiveInlining)]
            public readonly void AddTag<C>()
                where C : struct, ITag {
                Tags.Pool<C>.Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void AddTag<C1, C2>()
                where C1 : struct, ITag
                where C2 : struct, ITag {
                Tags.Pool<C1>.Add(this);
                Tags.Pool<C2>.Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void AddTag<C1, C2, C3>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag {
                Tags.Pool<C1>.Add(this);
                Tags.Pool<C2>.Add(this);
                Tags.Pool<C3>.Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void AddTag<C1, C2, C3, C4>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag
                where C4 : struct, ITag {
                Tags.Pool<C1>.Add(this);
                Tags.Pool<C2>.Add(this);
                Tags.Pool<C3>.Add(this);
                Tags.Pool<C4>.Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void AddTag<C1, C2, C3, C4, C5>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag
                where C4 : struct, ITag
                where C5 : struct, ITag {
                Tags.Pool<C1>.Add(this);
                Tags.Pool<C2>.Add(this);
                Tags.Pool<C3>.Add(this);
                Tags.Pool<C4>.Add(this);
                Tags.Pool<C5>.Add(this);
            }
            
            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag<C>()
                where C : struct, ITag {
                Tags.Pool<C>.TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag<C1, C2>()
                where C1 : struct, ITag
                where C2 : struct, ITag {
                Tags.Pool<C1>.TryAdd(this);
                Tags.Pool<C2>.TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag<C1, C2, C3>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag {
                Tags.Pool<C1>.TryAdd(this);
                Tags.Pool<C2>.TryAdd(this);
                Tags.Pool<C3>.TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag<C1, C2, C3, C4>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag
                where C4 : struct, ITag {
                Tags.Pool<C1>.TryAdd(this);
                Tags.Pool<C2>.TryAdd(this);
                Tags.Pool<C3>.TryAdd(this);
                Tags.Pool<C4>.TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag<C1, C2, C3, C4, C5>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag
                where C4 : struct, ITag
                where C5 : struct, ITag {
                Tags.Pool<C1>.TryAdd(this);
                Tags.Pool<C2>.TryAdd(this);
                Tags.Pool<C3>.TryAdd(this);
                Tags.Pool<C4>.TryAdd(this);
                Tags.Pool<C5>.TryAdd(this);
            }
            
            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag<C>(out bool added)
                where C : struct, ITag {
                Tags.Pool<C>.TryAdd(this, out added);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag<C1, C2>(out bool added)
                where C1 : struct, ITag
                where C2 : struct, ITag {
                Tags.Pool<C1>.TryAdd(this, out var added1);
                Tags.Pool<C2>.TryAdd(this, out var added2);
                added = added1 || added2;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag<C1, C2, C3>(out bool added)
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag {
                Tags.Pool<C1>.TryAdd(this, out var added1);
                Tags.Pool<C2>.TryAdd(this, out var added2);
                Tags.Pool<C3>.TryAdd(this, out var added3);
                added = added1 || added2 || added3;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag<C1, C2, C3, C4>(out bool added)
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag
                where C4 : struct, ITag {
                Tags.Pool<C1>.TryAdd(this, out var added1);
                Tags.Pool<C2>.TryAdd(this, out var added2);
                Tags.Pool<C3>.TryAdd(this, out var added3);
                Tags.Pool<C4>.TryAdd(this, out var added4);
                added = added1 || added2 || added3 || added4;
            }
            
            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag<C1, C2, C3, C4, C5>(out bool added)
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag
                where C4 : struct, ITag
                where C5 : struct, ITag {
                Tags.Pool<C1>.TryAdd(this, out var added1);
                Tags.Pool<C2>.TryAdd(this, out var added2);
                Tags.Pool<C3>.TryAdd(this, out var added3);
                Tags.Pool<C4>.TryAdd(this, out var added4);
                Tags.Pool<C5>.TryAdd(this, out var added5);
                added = added1 || added2 || added3 || added4 || added5;
            }
            #endregion

            #region DELETE
            [MethodImpl(AggressiveInlining)]
            public readonly bool DeleteTag<C>() where C : struct, ITag {
                return Tags.Pool<C>.Del(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool DeleteTag<C1, C2>()
                where C1 : struct, ITag
                where C2 : struct, ITag {
                var delC1 = Tags.Pool<C1>.Del(this);
                var delC2 = Tags.Pool<C2>.Del(this);
                return delC1 && delC2;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool DeleteTag<C1, C2, C3>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag {
                var delC1 = Tags.Pool<C1>.Del(this);
                var delC2 = Tags.Pool<C2>.Del(this);
                var delC3 = Tags.Pool<C3>.Del(this);

                return delC1 && delC2 && delC3;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool DeleteTag<C1, C2, C3, C4>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag
                where C4 : struct, ITag {
                var delC1 = Tags.Pool<C1>.Del(this);
                var delC2 = Tags.Pool<C2>.Del(this);
                var delC3 = Tags.Pool<C3>.Del(this);
                var delC4 = Tags.Pool<C4>.Del(this);

                return delC1 && delC2 && delC3 && delC4;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool DeleteTag<C1, C2, C3, C4, C5>()
                where C1 : struct, ITag
                where C2 : struct, ITag
                where C3 : struct, ITag
                where C4 : struct, ITag
                where C5 : struct, ITag {
                var delC1 = Tags.Pool<C1>.Del(this);
                var delC2 = Tags.Pool<C2>.Del(this);
                var delC3 = Tags.Pool<C3>.Del(this);
                var delC4 = Tags.Pool<C4>.Del(this);
                var delC5 = Tags.Pool<C5>.Del(this);

                return delC1 && delC2 && delC3 && delC4 && delC5;
            }
            #endregion
            #endregion

            #region BY_ID
            #region HAS
            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAllOfTags(TagDynId c) {
                return Tags.GetPool(c).Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAllOfTags(TagDynId c1, TagDynId c2) {
                return Tags.GetPool(c1).Has(this) && Tags.GetPool(c2).Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAllOfTags(TagDynId c1, TagDynId c2, TagDynId c3) {
                return Tags.GetPool(c1).Has(this) && Tags.GetPool(c2).Has(this) && Tags.GetPool(c3).Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAnyOfTags(TagDynId c1, TagDynId c2) {
                return Tags.GetPool(c1).Has(this) || Tags.GetPool(c2).Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAnyOfTags(TagDynId c1, TagDynId c2, TagDynId c3) {
                return Tags.GetPool(c1).Has(this) || Tags.GetPool(c2).Has(this) || Tags.GetPool(c3).Has(this);
            }
            #endregion
            
            #region ADD
            [MethodImpl(AggressiveInlining)]
            public readonly void AddTag(TagDynId c) {
                Tags.GetPool(c).Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void AddTag(TagDynId c1, TagDynId c2) {
                Tags.GetPool(c1).Add(this);
                Tags.GetPool(c2).Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void AddTag(TagDynId c1, TagDynId c2, TagDynId c3) {
                Tags.GetPool(c1).Add(this);
                Tags.GetPool(c2).Add(this);
                Tags.GetPool(c3).Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void AddTag(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4) {
                Tags.GetPool(c1).Add(this);
                Tags.GetPool(c2).Add(this);
                Tags.GetPool(c3).Add(this);
                Tags.GetPool(c4).Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void AddTag(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4, TagDynId c5) {
                Tags.GetPool(c1).Add(this);
                Tags.GetPool(c2).Add(this);
                Tags.GetPool(c3).Add(this);
                Tags.GetPool(c4).Add(this);
                Tags.GetPool(c5).Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag(TagDynId c) {
                Tags.GetPool(c).TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag(TagDynId c1, TagDynId c2) {
                Tags.GetPool(c1).TryAdd(this);
                Tags.GetPool(c2).TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag(TagDynId c1, TagDynId c2, TagDynId c3) {
                Tags.GetPool(c1).TryAdd(this);
                Tags.GetPool(c2).TryAdd(this);
                Tags.GetPool(c3).TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4) {
                Tags.GetPool(c1).TryAdd(this);
                Tags.GetPool(c2).TryAdd(this);
                Tags.GetPool(c3).TryAdd(this);
                Tags.GetPool(c4).TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4, TagDynId c5) {
                Tags.GetPool(c1).TryAdd(this);
                Tags.GetPool(c2).TryAdd(this);
                Tags.GetPool(c3).TryAdd(this);
                Tags.GetPool(c4).TryAdd(this);
                Tags.GetPool(c5).TryAdd(this);
            }
            
            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag(TagDynId c, out bool added) {
                Tags.GetPool(c).TryAdd(this, out added);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag(TagDynId c1, TagDynId c2, out bool added) {
                Tags.GetPool(c1).TryAdd(this, out var added1);
                Tags.GetPool(c2).TryAdd(this, out var added2);
                added = added1 || added2;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag(TagDynId c1, TagDynId c2, TagDynId c3, out bool added) {
                Tags.GetPool(c1).TryAdd(this, out var added1);
                Tags.GetPool(c2).TryAdd(this, out var added2);
                Tags.GetPool(c3).TryAdd(this, out var added3);
                added = added1 || added2 || added3;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4, out bool added) {
                Tags.GetPool(c1).TryAdd(this, out var added1);
                Tags.GetPool(c2).TryAdd(this, out var added2);
                Tags.GetPool(c3).TryAdd(this, out var added3);
                Tags.GetPool(c4).TryAdd(this, out var added4);
                added = added1 || added2 || added3 || added4;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAddTag(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4, TagDynId c5, out bool added) {
                Tags.GetPool(c1).TryAdd(this, out var added1);
                Tags.GetPool(c2).TryAdd(this, out var added2);
                Tags.GetPool(c3).TryAdd(this, out var added3);
                Tags.GetPool(c4).TryAdd(this, out var added4);
                Tags.GetPool(c5).TryAdd(this, out var added5);
                added = added1 || added2 || added3 || added4 || added5;
            }
            #endregion
            
            #region DELETE
            [MethodImpl(AggressiveInlining)]
            public readonly bool DeleteTag(TagDynId c) {
                return Tags.GetPool(c).Del(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool DeleteTag(TagDynId c1, TagDynId c2) {
                var delC1 = Tags.GetPool(c1).Del(this);
                var delC2 = Tags.GetPool(c2).Del(this);

                return delC1 && delC2;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool DeleteTag(TagDynId c1, TagDynId c2, TagDynId c3) {
                var delC1 = Tags.GetPool(c1).Del(this);
                var delC2 = Tags.GetPool(c2).Del(this);
                var delC3 = Tags.GetPool(c3).Del(this);

                return delC1 && delC2 && delC3;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool DeleteTag(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4) {
                var delC1 = Tags.GetPool(c1).Del(this);
                var delC2 = Tags.GetPool(c2).Del(this);
                var delC3 = Tags.GetPool(c3).Del(this);
                var delC4 = Tags.GetPool(c4).Del(this);

                return delC1 && delC2 && delC3 && delC4;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool DeleteTag(TagDynId c1, TagDynId c2, TagDynId c3, TagDynId c4, TagDynId c5) {
                var delC1 = Tags.GetPool(c1).Del(this);
                var delC2 = Tags.GetPool(c2).Del(this);
                var delC3 = Tags.GetPool(c3).Del(this);
                var delC4 = Tags.GetPool(c4).Del(this);
                var delC5 = Tags.GetPool(c5).Del(this);

                return delC1 && delC2 && delC3 && delC4 && delC5;
            }
            #endregion
            #endregion
        }
    }
}
#endif