using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

namespace FFS.Libraries.StaticEcs {
    public interface IWorldId { }

    public readonly struct Default : IWorldId { }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public abstract partial class Ecs<WorldID> {
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public abstract partial class World {
            internal static short[] _entityVersions;
            internal static Entity[] _deletedEntities;
            internal static int _entityVersionsCount;
            internal static int _deletedEntitiesCount;
            public static WorldStatus Status { get; private set; }

            internal static void Create(EcsConfig cfg) {
                _entityVersions = new short[cfg.BaseEntitiesCount];
                _deletedEntities = new Entity[cfg.BaseDeletedEntitiesCount];
                Components.SetBasePoolCapacity(cfg.BaseComponentPoolCount);
                Components.Create(cfg.BaseComponentTypesCount);
                #if !FFS_ECS_DISABLE_TAGS
                Tags.SetBasePoolCapacity(cfg.BaseTagPoolCount);
                Tags.Create(cfg.BaseTagTypesCount);
                #endif
                #if !FFS_ECS_DISABLE_MASKS
                Masks.Create(cfg.BaseMaskTypesCount);
                #endif
                Status = WorldStatus.Created;
            }

            internal static void Initialize() {
                Components.Initialize();
                #if !FFS_ECS_DISABLE_TAGS
                Tags.Initialize();
                #endif
                #if !FFS_ECS_DISABLE_MASKS
                Masks.Initialize();
                #endif
                Status = WorldStatus.Initialized;
            }

            [MethodImpl(AggressiveInlining)]
            public static ComponentDynId RegisterComponent<C>(uint basePoolCapacity = 128) where C : struct, IComponent {
                Components.SetBasePoolCapacity<C>(basePoolCapacity);
                return Components.RegisterComponent<C>();
            }

            #if !FFS_ECS_DISABLE_TAGS
            [MethodImpl(AggressiveInlining)]
            public static TagDynId RegisterTag<T>(uint basePoolCapacity = 128) where T : struct, ITag {
                Tags.SetBasePoolCapacity<T>(basePoolCapacity);
                return Tags.RegisterTag<T>();
            }
            #endif

            #if !FFS_ECS_DISABLE_MASKS
            [MethodImpl(AggressiveInlining)]
            public static MaskDynId RegisterMask<M>() where M : struct, IMask {
                return Masks.RegisterMask<M>();
            }
            #endif

            [MethodImpl(AggressiveInlining)]
            public static bool IsInitialized() => Status == WorldStatus.Initialized;

            [MethodImpl(AggressiveInlining)]
            internal static Entity CreateEntityInternal() {
                Assert.Check(IsInitialized(), $"World<{typeof(WorldID)}>, Method: NewEntity, World not initialized");
                Entity entity;
                if (_deletedEntitiesCount > 0) {
                    entity = _deletedEntities[--_deletedEntitiesCount];
                    _entityVersions[entity._id] *= -1;
                } else {
                    entity._id = _entityVersionsCount;
                    
                    if (_entityVersionsCount == _entityVersions.Length) {
                        Array.Resize(ref _entityVersions, _entityVersionsCount << 1);
                        Components.Resize(_entityVersionsCount << 1);
                        #if !FFS_ECS_DISABLE_TAGS
                        Tags.Resize(_entityVersionsCount << 1);
                        #endif
                        #if !FFS_ECS_DISABLE_MASKS
                        Masks.Resize(_entityVersionsCount << 1);
                        #endif
                    }
                    
                    _entityVersions[_entityVersionsCount++] = 1;
                }

                return entity;
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static void CreateEntitiesInternal<C>(int count, C onCreateEntity, Action<Entity> additional = null) where C : struct, IOnCreateEntityFunction<WorldID> {
                var newEntitiesCount = count - (_entityVersions.Length - _entityVersionsCount + _deletedEntitiesCount);
                if (newEntitiesCount >= 0) {
                    ResizeFor(newEntitiesCount);
                }

                while (count > 0) {
                    count--;
                    Entity entity;
                    if (_deletedEntitiesCount > 0) {
                        entity = _deletedEntities[--_deletedEntitiesCount];
                        _entityVersions[entity._id] *= -1;
                    } else {
                        entity._id = _entityVersionsCount;
                        _entityVersions[_entityVersionsCount++] = 1;
                    }
                    onCreateEntity.OnCreate(entity);
                    additional?.Invoke(entity);
                }
            }

            [MethodImpl(AggressiveInlining)]
            private static void ResizeFor(int count) {
                var newSize = Utils.CalculateSize(_entityVersionsCount + count);
                Array.Resize(ref _entityVersions, newSize);
                Components.Resize(newSize);
                #if !FFS_ECS_DISABLE_TAGS
                Tags.Resize(newSize);
                #endif
                #if !FFS_ECS_DISABLE_MASKS
                Masks.Resize(newSize);
                #endif
            }

            [MethodImpl(AggressiveInlining)]
            public static void DestroyEntity(Entity entity) {
                Assert.Check(IsInitialized(), $"World<{typeof(WorldID)}>, Method: DelEntity, World not initialized");

                ref var version = ref _entityVersions[entity._id];
                if (version < 0) {
                    return;
                }

                #if !FFS_ECS_DISABLE_TAGS
                Tags.DestroyEntity(entity);
                #endif
                #if !FFS_ECS_DISABLE_MASKS
                Masks.DestroyEntity(entity);
                #endif
                Components.DestroyEntity(entity);
                version = version == short.MaxValue ? (short) -1 : (short) -(version + 1);
                if (_deletedEntitiesCount == _deletedEntities.Length) {
                    Array.Resize(ref _deletedEntities, _deletedEntitiesCount << 1);
                }

                _deletedEntities[_deletedEntitiesCount++] = entity;
            }

            [MethodImpl(AggressiveInlining)]
            public static void CopyEntityData(Entity srcEntity, Entity dstEntity) {
                Assert.Check(IsInitialized(), $"World<{typeof(WorldID)}>, Method: CopyEntity, World not initialized");

                Components.CopyEntity(srcEntity, dstEntity);
                #if !FFS_ECS_DISABLE_TAGS
                Tags.CopyEntity(srcEntity, dstEntity);
                #endif
                #if !FFS_ECS_DISABLE_MASKS
                Masks.CopyEntity(srcEntity, dstEntity);
                #endif
            }

            [MethodImpl(AggressiveInlining)]
            public static Entity CloneEntity(Entity srcEntity) {
                Assert.Check(IsInitialized(), $"World<{typeof(WorldID)}>, Method: CopyEntity, World not initialized");

                var dstEntity = CreateEntityInternal();
                CopyEntityData(srcEntity, dstEntity);

                return dstEntity;
            }
            
            [MethodImpl(AggressiveInlining)]
            public static string ToPrettyStringEntity(Entity entity) {
                var result = $"Entity ID: {entity._id}, Version: {EntityVersion(entity)}\n";
                result += Components.ToPrettyStringEntity(entity);
                #if !FFS_ECS_DISABLE_TAGS
                result += Tags.ToPrettyStringEntity(entity);
                #endif
                #if !FFS_ECS_DISABLE_MASKS
                result += Masks.ToPrettyStringEntity(entity);
                #endif
                return result;
            }

            [MethodImpl(AggressiveInlining)]
            public static int EntitiesCount() {
                Assert.Check(IsInitialized(), $"World<{typeof(WorldID)}>, Method: GetEntitiesCount, World not initialized");
                return _entityVersionsCount - _deletedEntitiesCount;
            }

            [MethodImpl(AggressiveInlining)]
            public static int EntitiesCapacity() {
                Assert.Check(Status is > WorldStatus.NotCreated, $"World<{typeof(WorldID)}>, Method: GetEntitiesCapacity, World not initialized");
                return _entityVersions.Length;
            }

            [MethodImpl(AggressiveInlining)]
            public static short EntityVersion(Entity entity) {
                Assert.Check(IsInitialized(), $"World<{typeof(WorldID)}>, Method: EntityVersion, World not initialized");
                return _entityVersions[entity._id];
            }

            [MethodImpl(AggressiveInlining)]
            public static void AllEntities(List<Entity> result) {
                result.Clear();
                for (int i = 0, iMax = _entityVersionsCount; i < iMax; i++) {
                    if (_entityVersions[i] > 0) {
                        result.Add(Entity.FromIdx(i));
                    }
                }
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static void Clear() {
                Assert.Check(IsInitialized(), $"World<{typeof(WorldID)}>, Method: Clear, World not initialized");

                Components.Clear();
                #if !FFS_ECS_DISABLE_TAGS
                Tags.Clear();
                #endif
                #if !FFS_ECS_DISABLE_MASKS
                Masks.Clear();
                #endif

                Array.Clear(_entityVersions, 0, _entityVersions.Length);
                Array.Clear(_deletedEntities, 0, _deletedEntities.Length);
                _entityVersionsCount = 0;
                _deletedEntitiesCount = 0;
            }

            [MethodImpl(AggressiveInlining)]
            internal static void Destroy() {
                Assert.Check(IsInitialized(), $"World<{typeof(WorldID)}>, Method: Destroy, World not initialized");

                for (var i = _entityVersionsCount - 1; i >= 0; i--) {
                    if (_entityVersions[i] > 0) {
                        DestroyEntity(Entity.FromIdx(i));
                    }
                }

                Components.Destroy();
                #if !FFS_ECS_DISABLE_TAGS
                Tags.Destroy();
                #endif
                #if !FFS_ECS_DISABLE_MASKS
                Masks.Destroy();
                #endif

                _entityVersions = null;
                _deletedEntities = null;
                _entityVersionsCount = 0;
                _deletedEntitiesCount = 0;
                Status = WorldStatus.NotCreated;
            }
        }
    }

    public enum WorldStatus {
        NotCreated,
        Created,
        Initialized
    }
}