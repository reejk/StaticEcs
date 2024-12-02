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
        public partial struct Entity : IEquatable<Entity> {
            internal int _id;

            [MethodImpl(AggressiveInlining)]
            public static Entity FromIdx(int idx) => new() { _id = idx };

            [MethodImpl(AggressiveInlining)]
            public readonly short Version() => World.EntityVersion(this);

            [MethodImpl(AggressiveInlining)]
            public readonly bool IsActual() => World.EntityVersion(this) > 0;

            [MethodImpl(AggressiveInlining)]
            public readonly Entity Clone() => World.CloneEntity(this);

            [MethodImpl(AggressiveInlining)]
            public readonly void CopyTo(Entity dstEntity) => World.CopyEntityData(this, dstEntity);

            [MethodImpl(AggressiveInlining)]
            public readonly void MoveTo(Entity dstEntity) {
                World.CopyEntityData(this, dstEntity);
                this.Destroy();
            }

            [MethodImpl(AggressiveInlining)]
            public static bool operator ==(Entity left, Entity right) {
                return left.Equals(right);
            }

            [MethodImpl(AggressiveInlining)]
            public static bool operator !=(Entity left, Entity right) {
                return !left.Equals(right);
            }

            [MethodImpl(AggressiveInlining)]
            public readonly PackedEntity Pack() => new() { _entity = _id, _version = World.EntityVersion(this) };

            [MethodImpl(AggressiveInlining)]
            public readonly void Destroy() => World.DestroyEntity(this);

            #region NEW_BY_TYPE_SINGLE

            #if DEBUG || FFS_ECS_EMPTY_ENTITY
            [MethodImpl(AggressiveInlining)]
            public static Entity New() {
                return World.CreateEntityInternal();
            }
            #endif
            
            [MethodImpl(AggressiveInlining)]
            public static Entity New<C1>() where C1 : struct, IComponent {
                var entity = World.CreateEntityInternal();
                entity.Add<C1>();
                return entity;
            }

            [MethodImpl(AggressiveInlining)]
            public static Entity New<C1, C2>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent {
                var entity = World.CreateEntityInternal();
                entity.Add<C1, C2>();
                return entity;
            }

            [MethodImpl(AggressiveInlining)]
            public static Entity New<C1, C2, C3>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent {
                var entity = World.CreateEntityInternal();
                entity.Add<C1, C2, C3>();
                return entity;
            }

            [MethodImpl(AggressiveInlining)]
            public static Entity New<C1, C2, C3, C4>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent {
                var entity = World.CreateEntityInternal();
                entity.Add<C1, C2, C3, C4>();
                return entity;
            }

            [MethodImpl(AggressiveInlining)]
            public static Entity New<C1, C2, C3, C4, C5>()
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent {
                var entity = World.CreateEntityInternal();
                entity.Add<C1, C2, C3, C4, C5>();
                return entity;
            }
            #endregion
            
            #region NEW_BY_VALUE_SINGLE
            [MethodImpl(AggressiveInlining)]
            public static Entity New<C1>(C1 component) where C1 : struct, IComponent {
                var entity = World.CreateEntityInternal();
                entity.Put(component);
                return entity;
            }

            [MethodImpl(AggressiveInlining)]
            public static Entity New<C1, C2>(C1 comp1, C2 comp2)
                where C1 : struct, IComponent
                where C2 : struct, IComponent {
                var entity = World.CreateEntityInternal();
                entity.Put(comp1, comp2);
                return entity;
            }

            [MethodImpl(AggressiveInlining)]
            public static Entity New<C1, C2, C3>(C1 comp1, C2 comp2, C3 comp3)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent {
                var entity = World.CreateEntityInternal();
                entity.Put(comp1, comp2, comp3);
                return entity;
            }

            [MethodImpl(AggressiveInlining)]
            public static Entity New<C1, C2, C3, C4>(C1 comp1, C2 comp2, C3 comp3, C4 comp4)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent {
                var entity = World.CreateEntityInternal();
                entity.Put(comp1, comp2, comp3, comp4);
                return entity;
            }

            [MethodImpl(AggressiveInlining)]
            public static Entity New<C1, C2, C3, C4, C5>(C1 comp1, C2 comp2, C3 comp3, C4 comp4, C5 comp5)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent {
                var entity = World.CreateEntityInternal();
                entity.Put(comp1, comp2, comp3, comp4, comp5);
                return entity;
            }
            #endregion
            
            #region NEW_BY_DYN_ID_SINGLE
            [MethodImpl(AggressiveInlining)]
            public static Entity New(ComponentDynId component) {
                var entity = World.CreateEntityInternal();
                entity.Add(component);
                return entity;
            }

            [MethodImpl(AggressiveInlining)]
            public static Entity New(ComponentDynId comp1, ComponentDynId comp2) {
                var entity = World.CreateEntityInternal();
                entity.Add(comp1, comp2);
                return entity;
            }

            [MethodImpl(AggressiveInlining)]
            public static Entity New(ComponentDynId comp1, ComponentDynId comp2, ComponentDynId comp3) {
                var entity = World.CreateEntityInternal();
                entity.Add(comp1, comp2, comp3);
                return entity;
            }

            [MethodImpl(AggressiveInlining)]
            public static Entity New(ComponentDynId comp1, ComponentDynId comp2, ComponentDynId comp3, ComponentDynId comp4) {
                var entity = World.CreateEntityInternal();
                entity.Add(comp1, comp2, comp3, comp4);
                return entity;
            }

            [MethodImpl(AggressiveInlining)]
            public static Entity New(ComponentDynId comp1, ComponentDynId comp2, ComponentDynId comp3, ComponentDynId comp4, ComponentDynId comp5) {
                var entity = World.CreateEntityInternal();
                entity.Add(comp1, comp2, comp3, comp4, comp5);
                return entity;
            }
            #endregion

            #region NEW_BY_TYPE_BATCH
            [MethodImpl(AggressiveInlining)]
            public static void NewOnes<C1>(int count, Action<Entity> onCreate = null) where C1 : struct, IComponent {
                Components.Pool<C1>.EnsureSize(count);
                World.CreateEntitiesInternal(
                    count,
                    new AddComponentFunction<WorldID, C1>(),
                    onCreate
                );
            }

            [MethodImpl(AggressiveInlining)]
            public static void NewOnes<C1, C2>(int count, Action<Entity> onCreate = null)
                where C1 : struct, IComponent
                where C2 : struct, IComponent {
                Components.Pool<C1>.EnsureSize(count);
                Components.Pool<C2>.EnsureSize(count);
                World.CreateEntitiesInternal(
                    count,
                    new AddComponentFunction<WorldID, C1, C2>(),
                    onCreate
                );
            }

            [MethodImpl(AggressiveInlining)]
            public static void NewOnes<C1, C2, C3>(int count, Action<Entity> onCreate = null)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent {
                Components.Pool<C1>.EnsureSize(count);
                Components.Pool<C2>.EnsureSize(count);
                Components.Pool<C3>.EnsureSize(count);
                World.CreateEntitiesInternal(
                    count,
                    new AddComponentFunction<WorldID, C1, C2, C3>(),
                    onCreate
                );
            }

            [MethodImpl(AggressiveInlining)]
            public static void NewOnes<C1, C2, C3, C4>(int count, Action<Entity> onCreate = null)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent {
                Components.Pool<C1>.EnsureSize(count);
                Components.Pool<C2>.EnsureSize(count);
                Components.Pool<C3>.EnsureSize(count);
                Components.Pool<C4>.EnsureSize(count);
                World.CreateEntitiesInternal(
                    count,
                    new AddComponentFunction<WorldID, C1, C2, C3, C4>(),
                    onCreate
                );
            }

            [MethodImpl(AggressiveInlining)]
            public static void NewOnes<C1, C2, C3, C4, C5>(int count, Action<Entity> onCreate = null)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent {
                Components.Pool<C1>.EnsureSize(count);
                Components.Pool<C2>.EnsureSize(count);
                Components.Pool<C3>.EnsureSize(count);
                Components.Pool<C4>.EnsureSize(count);
                Components.Pool<C5>.EnsureSize(count);
                World.CreateEntitiesInternal(
                    count,
                    new AddComponentFunction<WorldID, C1, C2, C3, C4, C5>(),
                    onCreate
                );
            }

            [MethodImpl(AggressiveInlining)]
            public static void NewOnes<C1>(int count, C1 c1, Action<Entity> onCreate = null) where C1 : struct, IComponent {
                Components.Pool<C1>.EnsureSize(count);
                World.CreateEntitiesInternal(
                    count,
                    new PutComponentFunction<WorldID, C1>(c1),
                    onCreate
                );
            }

            [MethodImpl(AggressiveInlining)]
            public static void NewOnes<C1, C2>(int count, C1 c1, C2 c2, Action<Entity> onCreate = null)
                where C1 : struct, IComponent
                where C2 : struct, IComponent {
                Components.Pool<C1>.EnsureSize(count);
                Components.Pool<C2>.EnsureSize(count);
                World.CreateEntitiesInternal(
                    count,
                    new PutComponentFunction<WorldID, C1, C2>(c1, c2),
                    onCreate
                );
            }

            [MethodImpl(AggressiveInlining)]
            public static void NewOnes<C1, C2, C3>(int count, C1 c1, C2 c2, C3 c3, Action<Entity> onCreate = null)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent {
                Components.Pool<C1>.EnsureSize(count);
                Components.Pool<C2>.EnsureSize(count);
                Components.Pool<C3>.EnsureSize(count);
                World.CreateEntitiesInternal(
                    count,
                    new PutComponentFunction<WorldID, C1, C2, C3>(c1, c2, c3),
                    onCreate
                );
            }

            [MethodImpl(AggressiveInlining)]
            public static void NewOnes<C1, C2, C3, C4>(int count, C1 c1, C2 c2, C3 c3, C4 c4, Action<Entity> onCreate = null)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent {
                Components.Pool<C1>.EnsureSize(count);
                Components.Pool<C2>.EnsureSize(count);
                Components.Pool<C3>.EnsureSize(count);
                Components.Pool<C4>.EnsureSize(count);
                World.CreateEntitiesInternal(
                    count,
                    new PutComponentFunction<WorldID, C1, C2, C3, C4>(c1, c2, c3, c4),
                    onCreate
                );
            }

            [MethodImpl(AggressiveInlining)]
            public static void NewOnes<C1, C2, C3, C4, C5>(int count, C1 c1, C2 c2, C3 c3, C4 c4, C5 c5, Action<Entity> onCreate = null)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent {
                Components.Pool<C1>.EnsureSize(count);
                Components.Pool<C2>.EnsureSize(count);
                Components.Pool<C3>.EnsureSize(count);
                Components.Pool<C4>.EnsureSize(count);
                Components.Pool<C5>.EnsureSize(count);
                World.CreateEntitiesInternal(
                    count,
                    new PutComponentFunction<WorldID, C1, C2, C3, C4, C5>(c1, c2, c3, c4, c5),
                    onCreate
                );
            }
            #endregion
            
            #region NEW_BY_DYN_ID_BATCH
            [MethodImpl(AggressiveInlining)]
            public static void NewOnes(int count, ComponentDynId component, Action<Entity> onCreate = null) {
                Components.GetPool(component).EnsureSize(count);
                World.CreateEntitiesInternal(
                    count,
                    new AddComponentOnCreateEntity1<WorldID>(component),
                    onCreate
                );
            }

            [MethodImpl(AggressiveInlining)]
            public static void NewOnes(int count, ComponentDynId comp1, ComponentDynId comp2, Action<Entity> onCreate = null) {
                Components.GetPool(comp1).EnsureSize(count);
                Components.GetPool(comp2).EnsureSize(count);
                World.CreateEntitiesInternal(
                    count,
                    new AddComponentOnCreateEntity2<WorldID>(comp1, comp2),
                    onCreate
                );
            }

            [MethodImpl(AggressiveInlining)]
            public static void NewOnes(int count, ComponentDynId comp1, ComponentDynId comp2, ComponentDynId comp3, Action<Entity> onCreate = null) {
                Components.GetPool(comp1).EnsureSize(count);
                Components.GetPool(comp2).EnsureSize(count);
                Components.GetPool(comp3).EnsureSize(count);
                World.CreateEntitiesInternal(
                    count,
                    new AddComponentOnCreateEntity3<WorldID>(comp1, comp2, comp3),
                    onCreate
                );
            }

            [MethodImpl(AggressiveInlining)]
            public static void NewOnes(int count, ComponentDynId comp1, ComponentDynId comp2, ComponentDynId comp3, ComponentDynId comp4, Action<Entity> onCreate = null) {
                Components.GetPool(comp1).EnsureSize(count);
                Components.GetPool(comp2).EnsureSize(count);
                Components.GetPool(comp3).EnsureSize(count);
                Components.GetPool(comp4).EnsureSize(count);
                World.CreateEntitiesInternal(
                    count,
                    new AddComponentOnCreateEntity4<WorldID>(comp1, comp2, comp3, comp4),
                    onCreate
                );
            }

            [MethodImpl(AggressiveInlining)]
            public static void NewOnes(int count, ComponentDynId comp1, ComponentDynId comp2, ComponentDynId comp3, ComponentDynId comp4, ComponentDynId comp5, Action<Entity> onCreate = null) {
                Components.GetPool(comp1).EnsureSize(count);
                Components.GetPool(comp2).EnsureSize(count);
                Components.GetPool(comp3).EnsureSize(count);
                Components.GetPool(comp4).EnsureSize(count);
                Components.GetPool(comp5).EnsureSize(count);
                World.CreateEntitiesInternal(
                    count,
                    new AddComponentOnCreateEntity5<WorldID>(comp1, comp2, comp3, comp4, comp5),
                    onCreate
                );
            }
            #endregion

            [MethodImpl(AggressiveInlining)]
            public bool Equals(Entity entity) {
                return _id == entity._id;
            }

            [MethodImpl(AggressiveInlining)]
            public override bool Equals(object obj) {
                return obj is Entity other && Equals(other);
            }

            [MethodImpl(AggressiveInlining)]
            public override int GetHashCode() {
                return _id;
            }

            [MethodImpl(AggressiveInlining)]
            public string ToPrettyStringEntity() => World.ToPrettyStringEntity(this);
            
            #if DEBUG
            [MethodImpl(AggressiveInlining)]
            public override string ToString() => World.ToPrettyStringEntity(this);
            #else
            [MethodImpl(AggressiveInlining)]
            public override string ToString() => $"Entity ID: {_id}";
            #endif
        }
    }
    
    public struct PackedEntity : IEquatable<PackedEntity> {
        internal int _entity;
        internal short _version;

        [MethodImpl(AggressiveInlining)]
        public readonly bool TryUnpack<WorldID>(out Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            entity = Ecs<WorldID>.Entity.FromIdx(_entity);
            return Ecs<WorldID>.World.EntityVersion(entity) == _version;
        }

        [MethodImpl(AggressiveInlining)]
        public bool Equals(PackedEntity entity) {
            return _entity.Equals(entity._entity) && _version == entity._version;
        }

        [MethodImpl(AggressiveInlining)]
        public override bool Equals(object obj) => throw new Exception("PackEntity `Equals object` not allowed!!");

        [MethodImpl(AggressiveInlining)]
        public override int GetHashCode() => throw new Exception("PackEntity `GetHashCode` not allowed!");

        [MethodImpl(AggressiveInlining)]
        public override string ToString() => $"PackEntity ID: {_entity}, Version: {_version}";
    }
}