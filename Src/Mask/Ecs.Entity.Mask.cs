#if !FFS_ECS_DISABLE_MASKS
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
            public readonly int MasksCount() => ModuleMasks.MasksCount(this);

            #region BY_TYPE
            #region HAS
            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAllOfMasks<C>() where C : struct, IMask {
                return Masks<C>.Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAllOfMasks<C1, C2>()
                where C1 : struct, IMask
                where C2 : struct, IMask {
                return Masks<C1>.Has(this) && Masks<C2>.Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAllOfMasks<C1, C2, C3>()
                where C1 : struct, IMask
                where C2 : struct, IMask
                where C3 : struct, IMask {
                return Masks<C1>.Has(this) && Masks<C2>.Has(this) && Masks<C3>.Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAnyOfMasks<C1, C2>()
                where C1 : struct, IMask
                where C2 : struct, IMask {
                return Masks<C1>.Has(this) || Masks<C2>.Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAnyOfMasks<C1, C2, C3>()
                where C1 : struct, IMask
                where C2 : struct, IMask
                where C3 : struct, IMask {
                return Masks<C1>.Has(this) || Masks<C2>.Has(this) || Masks<C3>.Has(this);
            }
            #endregion

            #region SET
            [MethodImpl(AggressiveInlining)]
            public readonly void SetMask<C>()
                where C : struct, IMask {
                Masks<C>.Set(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void SetMask<C1, C2>()
                where C1 : struct, IMask
                where C2 : struct, IMask {
                Masks<C1>.Set(this);
                Masks<C2>.Set(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void SetMask<C1, C2, C3>()
                where C1 : struct, IMask
                where C2 : struct, IMask
                where C3 : struct, IMask {
                Masks<C1>.Set(this);
                Masks<C2>.Set(this);
                Masks<C3>.Set(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void SetMask<C1, C2, C3, C4>()
                where C1 : struct, IMask
                where C2 : struct, IMask
                where C3 : struct, IMask
                where C4 : struct, IMask {
                Masks<C1>.Set(this);
                Masks<C2>.Set(this);
                Masks<C3>.Set(this);
                Masks<C4>.Set(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void SetMask<C1, C2, C3, C4, C5>()
                where C1 : struct, IMask
                where C2 : struct, IMask
                where C3 : struct, IMask
                where C4 : struct, IMask
                where C5 : struct, IMask {
                Masks<C1>.Set(this);
                Masks<C2>.Set(this);
                Masks<C3>.Set(this);
                Masks<C4>.Set(this);
                Masks<C5>.Set(this);
            }
            #endregion

            #region DELETE
            [MethodImpl(AggressiveInlining)]
            public readonly void DeleteMask<C>() where C : struct, IMask {
                Masks<C>.Del(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void DeleteMask<C1, C2>()
                where C1 : struct, IMask
                where C2 : struct, IMask {
                Masks<C1>.Del(this);
                Masks<C2>.Del(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void DeleteMask<C1, C2, C3>()
                where C1 : struct, IMask
                where C2 : struct, IMask
                where C3 : struct, IMask {
                Masks<C1>.Del(this);
                Masks<C2>.Del(this);
                Masks<C3>.Del(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void DeleteMask<C1, C2, C3, C4>()
                where C1 : struct, IMask
                where C2 : struct, IMask
                where C3 : struct, IMask
                where C4 : struct, IMask {
                Masks<C1>.Del(this);
                Masks<C2>.Del(this);
                Masks<C3>.Del(this);
                Masks<C4>.Del(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void DeleteMask<C1, C2, C3, C4, C5>()
                where C1 : struct, IMask
                where C2 : struct, IMask
                where C3 : struct, IMask
                where C4 : struct, IMask
                where C5 : struct, IMask {
                Masks<C1>.Del(this);
                Masks<C2>.Del(this);
                Masks<C3>.Del(this);
                Masks<C4>.Del(this);
                Masks<C5>.Del(this);
            }
            #endregion
            #endregion

            #region BY_ID
            #region HAS
            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAllOfMasks(MaskDynId c) {
                return ModuleMasks.GetPool(c).Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAllOfMasks(MaskDynId c1, MaskDynId c2) {
                return ModuleMasks.GetPool(c1).Has(this) && ModuleMasks.GetPool(c2).Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAllOfMasks(MaskDynId c1, MaskDynId c2, MaskDynId c3) {
                return ModuleMasks.GetPool(c1).Has(this) && ModuleMasks.GetPool(c2).Has(this) && ModuleMasks.GetPool(c3).Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAnyOfMasks(MaskDynId c1, MaskDynId c2) {
                return ModuleMasks.GetPool(c1).Has(this) || ModuleMasks.GetPool(c2).Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAnyOfMasks(MaskDynId c1, MaskDynId c2, MaskDynId c3) {
                return ModuleMasks.GetPool(c1).Has(this) || ModuleMasks.GetPool(c2).Has(this) || ModuleMasks.GetPool(c3).Has(this);
            }
            #endregion
            
            #region ADD
            [MethodImpl(AggressiveInlining)]
            public readonly void SetMask(MaskDynId c) {
                ModuleMasks.GetPool(c).Set(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void SetMask(MaskDynId c1, MaskDynId c2) {
                ModuleMasks.GetPool(c1).Set(this);
                ModuleMasks.GetPool(c2).Set(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void SetMask(MaskDynId c1, MaskDynId c2, MaskDynId c3) {
                ModuleMasks.GetPool(c1).Set(this);
                ModuleMasks.GetPool(c2).Set(this);
                ModuleMasks.GetPool(c3).Set(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void SetMask(MaskDynId c1, MaskDynId c2, MaskDynId c3, MaskDynId c4) {
                ModuleMasks.GetPool(c1).Set(this);
                ModuleMasks.GetPool(c2).Set(this);
                ModuleMasks.GetPool(c3).Set(this);
                ModuleMasks.GetPool(c4).Set(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void SetMask(MaskDynId c1, MaskDynId c2, MaskDynId c3, MaskDynId c4, MaskDynId c5) {
                ModuleMasks.GetPool(c1).Set(this);
                ModuleMasks.GetPool(c2).Set(this);
                ModuleMasks.GetPool(c3).Set(this);
                ModuleMasks.GetPool(c4).Set(this);
                ModuleMasks.GetPool(c5).Set(this);
            }
            #endregion
            
            #region DELETE
            [MethodImpl(AggressiveInlining)]
            public readonly void DeleteMask(MaskDynId c) {
                ModuleMasks.GetPool(c).Del(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void DeleteMask(MaskDynId c1, MaskDynId c2) {
                ModuleMasks.GetPool(c1).Del(this);
                ModuleMasks.GetPool(c2).Del(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void DeleteMask(MaskDynId c1, MaskDynId c2, MaskDynId c3) {
                ModuleMasks.GetPool(c1).Del(this);
                ModuleMasks.GetPool(c2).Del(this);
                ModuleMasks.GetPool(c3).Del(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void DeleteMask(MaskDynId c1, MaskDynId c2, MaskDynId c3, MaskDynId c4) {
                ModuleMasks.GetPool(c1).Del(this);
                ModuleMasks.GetPool(c2).Del(this);
                ModuleMasks.GetPool(c3).Del(this);
                ModuleMasks.GetPool(c4).Del(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void DeleteMask(MaskDynId c1, MaskDynId c2, MaskDynId c3, MaskDynId c4, MaskDynId c5) {
                ModuleMasks.GetPool(c1).Del(this);
                ModuleMasks.GetPool(c2).Del(this);
                ModuleMasks.GetPool(c3).Del(this);
                ModuleMasks.GetPool(c4).Del(this);
                ModuleMasks.GetPool(c5).Del(this);
            }
            #endregion
            #endregion
        }
    }
}
#endif