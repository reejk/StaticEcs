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
            public readonly int ComponentsCount() => Components.ComponentsCount(this);

            #region BY_TYPE
            #region REF
            [MethodImpl(AggressiveInlining)]
            public readonly ref C RefMut<C>()
                where C : struct, IComponent {
                return ref Components.Pool<C>.RefMut(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly ref readonly C Ref<C>()
                where C : struct, IComponent {
                return ref Components.Pool<C>.Ref(this);
            }
            #endregion

            #region HAS
            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAllOf<C>() where C : struct, IComponent {
                return Components.Pool<C>.Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAllOf<C1, C2>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent {
                return Components.Pool<C1>.Has(this) && Components.Pool<C2>.Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAllOf<C1, C2, C3>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent {
                return Components.Pool<C1>.Has(this) && Components.Pool<C2>.Has(this) && Components.Pool<C3>.Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAnyOf<C1, C2>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent {
                return Components.Pool<C1>.Has(this) || Components.Pool<C2>.Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAnyOf<C1, C2, C3>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent {
                return Components.Pool<C1>.Has(this) || Components.Pool<C2>.Has(this) || Components.Pool<C3>.Has(this);
            }


            #endregion

            #region ADD
            [MethodImpl(AggressiveInlining)]
            public readonly ref C Add<C>()
                where C : struct, IComponent {
                return ref Components.Pool<C>.Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void Add<C1, C2>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent {
                Components.Pool<C1>.Add(this);
                Components.Pool<C2>.Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void Add<C1, C2, C3>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent {
                Components.Pool<C1>.Add(this);
                Components.Pool<C2>.Add(this);
                Components.Pool<C3>.Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void Add<C1, C2, C3, C4>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent {
                Components.Pool<C1>.Add(this);
                Components.Pool<C2>.Add(this);
                Components.Pool<C3>.Add(this);
                Components.Pool<C4>.Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void Add<C1, C2, C3, C4, C5>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent {
                Components.Pool<C1>.Add(this);
                Components.Pool<C2>.Add(this);
                Components.Pool<C3>.Add(this);
                Components.Pool<C4>.Add(this);
                Components.Pool<C5>.Add(this);
            }
            
            [MethodImpl(AggressiveInlining)]
            public readonly void Add<C1>(C1 c1)
                where C1 : struct, IComponent {
                Components.Pool<C1>.Add(this) = c1;
            }
            
            [MethodImpl(AggressiveInlining)]
            public readonly void Add<C1, C2>(C1 c1, C2 c2)
                where C1 : struct, IComponent
                where C2 : struct, IComponent {
                Components.Pool<C1>.Add(this) = c1;
                Components.Pool<C2>.Add(this) = c2;
            }
            
            [MethodImpl(AggressiveInlining)]
            public readonly void Add<C1, C2, C3>(C1 c1, C2 c2, C3 c3)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent {
                Components.Pool<C1>.Add(this) = c1;
                Components.Pool<C2>.Add(this) = c2;
                Components.Pool<C3>.Add(this) = c3;
            }
            
            [MethodImpl(AggressiveInlining)]
            public readonly void Add<C1, C2, C3, C4>(C1 c1, C2 c2, C3 c3, C4 c4)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent {
                Components.Pool<C1>.Add(this) = c1;
                Components.Pool<C2>.Add(this) = c2;
                Components.Pool<C3>.Add(this) = c3;
                Components.Pool<C4>.Add(this) = c4;
            }
            
            [MethodImpl(AggressiveInlining)]
            public readonly void Add<C1, C2, C3, C4, C5>(C1 c1, C2 c2, C3 c3, C4 c4, C5 c5)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent {
                Components.Pool<C1>.Add(this) = c1;
                Components.Pool<C2>.Add(this) = c2;
                Components.Pool<C3>.Add(this) = c3;
                Components.Pool<C4>.Add(this) = c4;
                Components.Pool<C5>.Add(this) = c5;
            }
            
            [MethodImpl(AggressiveInlining)]
            public readonly ref C TryAdd<C>()
                where C : struct, IComponent {
                return ref Components.Pool<C>.TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAdd<C1, C2>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent {
                Components.Pool<C1>.TryAdd(this);
                Components.Pool<C2>.TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAdd<C1, C2, C3>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent {
                Components.Pool<C1>.TryAdd(this);
                Components.Pool<C2>.TryAdd(this);
                Components.Pool<C3>.TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAdd<C1, C2, C3, C4>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent {
                Components.Pool<C1>.TryAdd(this);
                Components.Pool<C2>.TryAdd(this);
                Components.Pool<C3>.TryAdd(this);
                Components.Pool<C4>.TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAdd<C1, C2, C3, C4, C5>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent {
                Components.Pool<C1>.TryAdd(this);
                Components.Pool<C2>.TryAdd(this);
                Components.Pool<C3>.TryAdd(this);
                Components.Pool<C4>.TryAdd(this);
                Components.Pool<C5>.TryAdd(this);
            }
            
            [MethodImpl(AggressiveInlining)]
            public readonly ref C TryAdd<C>(out bool added)
                where C : struct, IComponent {
                return ref Components.Pool<C>.TryAdd(this, out added);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAdd<C1, C2>(out bool added)
                where C1 : struct, IComponent
                where C2 : struct, IComponent {
                Components.Pool<C1>.TryAdd(this, out var added1);
                Components.Pool<C2>.TryAdd(this, out var added2);
                added = added1 || added2;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAdd<C1, C2, C3>(out bool added)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent {
                Components.Pool<C1>.TryAdd(this, out var added1);
                Components.Pool<C2>.TryAdd(this, out var added2);
                Components.Pool<C3>.TryAdd(this, out var added3);
                added = added1 || added2 || added3;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAdd<C1, C2, C3, C4>(out bool added)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent {
                Components.Pool<C1>.TryAdd(this, out var added1);
                Components.Pool<C2>.TryAdd(this, out var added2);
                Components.Pool<C3>.TryAdd(this, out var added3);
                Components.Pool<C4>.TryAdd(this, out var added4);
                added = added1 || added2 || added3 || added4;
            }
            
            [MethodImpl(AggressiveInlining)]
            public readonly void TryAdd<C1, C2, C3, C4, C5>(out bool added)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent {
                Components.Pool<C1>.TryAdd(this, out var added1);
                Components.Pool<C2>.TryAdd(this, out var added2);
                Components.Pool<C3>.TryAdd(this, out var added3);
                Components.Pool<C4>.TryAdd(this, out var added4);
                Components.Pool<C5>.TryAdd(this, out var added5);
                added = added1 || added2 || added3 || added4 || added5;
            }
            #endregion

            #region PUT
            [MethodImpl(AggressiveInlining)]
            public readonly void Put<C>(C comp)
                where C : struct, IComponent {
                Components.Pool<C>.Put(this, comp);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void Put<C1, C2>(C1 comp1, C2 comp2)
                where C1 : struct, IComponent
                where C2 : struct, IComponent {
                Components.Pool<C1>.Put(this, comp1);
                Components.Pool<C2>.Put(this, comp2);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void Put<C1, C2, C3>(C1 comp1, C2 comp2, C3 comp3)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent {
                Components.Pool<C1>.Put(this, comp1);
                Components.Pool<C2>.Put(this, comp2);
                Components.Pool<C3>.Put(this, comp3);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void Put<C1, C2, C3, C4>(C1 comp1, C2 comp2, C3 comp3, C4 comp4)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent {
                Components.Pool<C1>.Put(this, comp1);
                Components.Pool<C2>.Put(this, comp2);
                Components.Pool<C3>.Put(this, comp3);
                Components.Pool<C4>.Put(this, comp4);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void Put<C1, C2, C3, C4, C5>(C1 comp1, C2 comp2, C3 comp3, C4 comp4, C5 comp5)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent {
                Components.Pool<C1>.Put(this, comp1);
                Components.Pool<C2>.Put(this, comp2);
                Components.Pool<C3>.Put(this, comp3);
                Components.Pool<C4>.Put(this, comp4);
                Components.Pool<C5>.Put(this, comp5);
            }
            #endregion

            #region DELETE
            [MethodImpl(AggressiveInlining)]
            public readonly bool Delete<C>() where C : struct, IComponent {
                return Components.Pool<C>.Del(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool Delete<C1, C2>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent {
                var delC1 = Components.Pool<C1>.Del(this);
                var delC2 = Components.Pool<C2>.Del(this);
                return delC1 && delC2;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool Delete<C1, C2, C3>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent {
                var delC1 = Components.Pool<C1>.Del(this);
                var delC2 = Components.Pool<C2>.Del(this);
                var delC3 = Components.Pool<C3>.Del(this);

                return delC1 && delC2 && delC3;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool Delete<C1, C2, C3, C4>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent {
                var delC1 = Components.Pool<C1>.Del(this);
                var delC2 = Components.Pool<C2>.Del(this);
                var delC3 = Components.Pool<C3>.Del(this);
                var delC4 = Components.Pool<C4>.Del(this);

                return delC1 && delC2 && delC3 && delC4;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool Delete<C1, C2, C3, C4, C5>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent {
                var delC1 = Components.Pool<C1>.Del(this);
                var delC2 = Components.Pool<C2>.Del(this);
                var delC3 = Components.Pool<C3>.Del(this);
                var delC4 = Components.Pool<C4>.Del(this);
                var delC5 = Components.Pool<C5>.Del(this);

                return delC1 && delC2 && delC3 && delC4 && delC5;
            }
            #endregion

            #region COPY
            [MethodImpl(AggressiveInlining)]
            public readonly void CopyComponentsTo<C1>(Entity target)
                where C1 : struct, IComponent {
                Components.Pool<C1>.Copy(this, target);
            }
            
            [MethodImpl(AggressiveInlining)]
            public readonly void CopyComponentsTo<C1, C2>(Entity target)
                where C1 : struct, IComponent
                where C2 : struct, IComponent {
                Components.Pool<C1>.Copy(this, target);
                Components.Pool<C2>.Copy(this, target);
            }
            
            [MethodImpl(AggressiveInlining)]
            public readonly void CopyComponentsTo<C1, C2, C3>(Entity target)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent {
                Components.Pool<C1>.Copy(this, target);
                Components.Pool<C2>.Copy(this, target);
                Components.Pool<C3>.Copy(this, target);
            }
            
            [MethodImpl(AggressiveInlining)]
            public readonly void CopyComponentsTo<C1, C2, C3, C4>(Entity target)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent {
                Components.Pool<C1>.Copy(this, target);
                Components.Pool<C2>.Copy(this, target);
                Components.Pool<C3>.Copy(this, target);
                Components.Pool<C4>.Copy(this, target);
            }
            
            [MethodImpl(AggressiveInlining)]
            public readonly void CopyComponentsTo<C1, C2, C3, C4, C5>(Entity target)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent {
                Components.Pool<C1>.Copy(this, target);
                Components.Pool<C2>.Copy(this, target);
                Components.Pool<C3>.Copy(this, target);
                Components.Pool<C4>.Copy(this, target);
                Components.Pool<C5>.Copy(this, target);
            }
            #endregion
            #endregion

            #region BY_ID
            #region HAS
            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAllOf(ComponentDynId c) {
                return Components.GetPool(c).Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAllOf(ComponentDynId c1, ComponentDynId c2) {
                return Components.GetPool(c1).Has(this) && Components.GetPool(c2).Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAllOf(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3) {
                return Components.GetPool(c1).Has(this) && Components.GetPool(c2).Has(this) && Components.GetPool(c3).Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAnyOf(ComponentDynId c1, ComponentDynId c2) {
                return Components.GetPool(c1).Has(this) || Components.GetPool(c2).Has(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool HasAnyOf(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3) {
                return Components.GetPool(c1).Has(this) || Components.GetPool(c2).Has(this) || Components.GetPool(c3).Has(this);
            }
            #endregion
            
            #region ADD
            [MethodImpl(AggressiveInlining)]
            public readonly void Add(ComponentDynId c) {
                Components.GetPool(c).Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void Add(ComponentDynId c1, ComponentDynId c2) {
                Components.GetPool(c1).Add(this);
                Components.GetPool(c2).Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void Add(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3) {
                Components.GetPool(c1).Add(this);
                Components.GetPool(c2).Add(this);
                Components.GetPool(c3).Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void Add(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3, ComponentDynId c4) {
                Components.GetPool(c1).Add(this);
                Components.GetPool(c2).Add(this);
                Components.GetPool(c3).Add(this);
                Components.GetPool(c4).Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void Add(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3, ComponentDynId c4, ComponentDynId c5) {
                Components.GetPool(c1).Add(this);
                Components.GetPool(c2).Add(this);
                Components.GetPool(c3).Add(this);
                Components.GetPool(c4).Add(this);
                Components.GetPool(c5).Add(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAdd(ComponentDynId c) {
                Components.GetPool(c).TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAdd(ComponentDynId c1, ComponentDynId c2) {
                Components.GetPool(c1).TryAdd(this);
                Components.GetPool(c2).TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAdd(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3) {
                Components.GetPool(c1).TryAdd(this);
                Components.GetPool(c2).TryAdd(this);
                Components.GetPool(c3).TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAdd(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3, ComponentDynId c4) {
                Components.GetPool(c1).TryAdd(this);
                Components.GetPool(c2).TryAdd(this);
                Components.GetPool(c3).TryAdd(this);
                Components.GetPool(c4).TryAdd(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAdd(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3, ComponentDynId c4, ComponentDynId c5) {
                Components.GetPool(c1).TryAdd(this);
                Components.GetPool(c2).TryAdd(this);
                Components.GetPool(c3).TryAdd(this);
                Components.GetPool(c4).TryAdd(this);
                Components.GetPool(c5).TryAdd(this);
            }
            
            [MethodImpl(AggressiveInlining)]
            public readonly void TryAdd(ComponentDynId c, out bool added) {
                Components.GetPool(c).TryAdd(this, out added);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAdd(ComponentDynId c1, ComponentDynId c2, out bool added) {
                Components.GetPool(c1).TryAdd(this, out var added1);
                Components.GetPool(c2).TryAdd(this, out var added2);
                added = added1 || added2;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAdd(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3, out bool added) {
                Components.GetPool(c1).TryAdd(this, out var added1);
                Components.GetPool(c2).TryAdd(this, out var added2);
                Components.GetPool(c3).TryAdd(this, out var added3);
                added = added1 || added2 || added3;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAdd(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3, ComponentDynId c4, out bool added) {
                Components.GetPool(c1).TryAdd(this, out var added1);
                Components.GetPool(c2).TryAdd(this, out var added2);
                Components.GetPool(c3).TryAdd(this, out var added3);
                Components.GetPool(c4).TryAdd(this, out var added4);
                added = added1 || added2 || added3 || added4;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void TryAdd(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3, ComponentDynId c4, ComponentDynId c5, out bool added) {
                Components.GetPool(c1).TryAdd(this, out var added1);
                Components.GetPool(c2).TryAdd(this, out var added2);
                Components.GetPool(c3).TryAdd(this, out var added3);
                Components.GetPool(c4).TryAdd(this, out var added4);
                Components.GetPool(c5).TryAdd(this, out var added5);
                added = added1 || added2 || added3 || added4 || added5;
            }
            #endregion
            
            #region DELETE
            [MethodImpl(AggressiveInlining)]
            public readonly bool Delete(ComponentDynId c) {
                return Components.GetPool(c).Del(this);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool Delete(ComponentDynId c1, ComponentDynId c2) {
                var delC1 = Components.GetPool(c1).Del(this);
                var delC2 = Components.GetPool(c2).Del(this);

                return delC1 && delC2;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool Delete(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3) {
                var delC1 = Components.GetPool(c1).Del(this);
                var delC2 = Components.GetPool(c2).Del(this);
                var delC3 = Components.GetPool(c3).Del(this);

                return delC1 && delC2 && delC3;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool Delete(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3, ComponentDynId c4) {
                var delC1 = Components.GetPool(c1).Del(this);
                var delC2 = Components.GetPool(c2).Del(this);
                var delC3 = Components.GetPool(c3).Del(this);
                var delC4 = Components.GetPool(c4).Del(this);

                return delC1 && delC2 && delC3 && delC4;
            }

            [MethodImpl(AggressiveInlining)]
            public readonly bool Delete(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3, ComponentDynId c4, ComponentDynId c5) {
                var delC1 = Components.GetPool(c1).Del(this);
                var delC2 = Components.GetPool(c2).Del(this);
                var delC3 = Components.GetPool(c3).Del(this);
                var delC4 = Components.GetPool(c4).Del(this);
                var delC5 = Components.GetPool(c5).Del(this);

                return delC1 && delC2 && delC3 && delC4 && delC5;
            }
            #endregion
            
            #region COPY
            [MethodImpl(AggressiveInlining)]
            public readonly void CopyComponentsTo(ComponentDynId c, Entity target) {
                Components.GetPool(c).Copy(this, target);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void CopyComponentsTo(ComponentDynId c1, ComponentDynId c2, Entity target) {
                Components.GetPool(c1).Copy(this, target);
                Components.GetPool(c2).Copy(this, target);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void CopyComponentsTo(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3, Entity target) {
                Components.GetPool(c1).Copy(this, target);
                Components.GetPool(c2).Copy(this, target);
                Components.GetPool(c3).Copy(this, target);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void CopyComponentsTo(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3, ComponentDynId c4, Entity target) {
                Components.GetPool(c1).Copy(this, target);
                Components.GetPool(c2).Copy(this, target);
                Components.GetPool(c3).Copy(this, target);
                Components.GetPool(c4).Copy(this, target);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly void CopyComponentsTo(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3, ComponentDynId c4, ComponentDynId c5, Entity target) {
                Components.GetPool(c1).Copy(this, target);
                Components.GetPool(c2).Copy(this, target);
                Components.GetPool(c3).Copy(this, target);
                Components.GetPool(c4).Copy(this, target);
                Components.GetPool(c5).Copy(this, target);
            }
            #endregion
            #endregion
        }
    }
}