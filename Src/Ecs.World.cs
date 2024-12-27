﻿using System;
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
            #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
            internal static List<IWorldDebugEventListener> _debugEventListeners;
            #endif
            internal static short[] _entityVersions;
            internal static Entity[] _deletedEntities;
            internal static int _entityVersionsCount;
            internal static int _deletedEntitiesCount;
            public static WorldStatus Status { get; private set; }

            internal static void Create() {
                _entityVersions = new short[cfg.BaseEntitiesCount];
                _deletedEntities = new Entity[cfg.BaseDeletedEntitiesCount];
                ModuleComponents.SetBasePoolCapacity(cfg.BaseComponentPoolCount);
                ModuleComponents.Create(cfg.BaseComponentTypesCount);
                #if !FFS_ECS_DISABLE_TAGS
                ModuleTags.SetBasePoolCapacity(cfg.BaseTagPoolCount);
                ModuleTags.Create(cfg.BaseTagTypesCount);
                #endif
                #if !FFS_ECS_DISABLE_MASKS
                ModuleMasks.Create(cfg.BaseMaskTypesCount);
                #endif
                Status = WorldStatus.Created;
            }

            internal static void Initialize() {
                ModuleComponents.Initialize();
                #if !FFS_ECS_DISABLE_TAGS
                ModuleTags.Initialize();
                #endif
                #if !FFS_ECS_DISABLE_MASKS
                ModuleMasks.Initialize();
                #endif
                Status = WorldStatus.Initialized;
                #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
                if (_debugEventListeners != null) {
                    foreach (var listener in _debugEventListeners) {
                        listener.OnWorldInitialized();
                    }
                }
                #endif
            }
            
            #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
            [MethodImpl(AggressiveInlining)]
            public static void AddWorldDebugEventListener(IWorldDebugEventListener listener) {
                _debugEventListeners ??= new List<IWorldDebugEventListener>();
                _debugEventListeners.Add(listener);
            }
            
            [MethodImpl(AggressiveInlining)]
            public static void AddComponentsDebugEventListener(IComponentsDebugEventListener listener) {
                ModuleComponents._debugEventListeners ??= new List<IComponentsDebugEventListener>();
                ModuleComponents._debugEventListeners.Add(listener);
            }
            #endif

            [MethodImpl(AggressiveInlining)]
            public static ComponentDynId RegisterComponent<C>(uint basePoolCapacity = 128) where C : struct, IComponent {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (Status == WorldStatus.NotCreated) throw new Exception($"World<{typeof(WorldID)}>, Method: RegisterComponent, World not created");
                #endif
                ModuleComponents.SetBasePoolCapacity<C>(basePoolCapacity);
                return ModuleComponents.RegisterComponent<C>();
            }
            
            [MethodImpl(AggressiveInlining)]
            public static ComponentDynId GetComponentDynId<T>() where T : struct, IComponent {
                return Components<T>.Value.DynamicId();
            }
            
            [MethodImpl(AggressiveInlining)]
            public static IComponentsWrapper GetComponentsPool(ComponentDynId id) {
                return ModuleComponents.GetPool(id);
            }

            [MethodImpl(AggressiveInlining)]
            public static ComponentsWrapper<T> GetComponentsPool<T>() where T : struct, IComponent {
                return ModuleComponents.GetPool<T>();
            }

            #if !FFS_ECS_DISABLE_TAGS
            [MethodImpl(AggressiveInlining)]
            public static TagDynId RegisterTag<T>(uint basePoolCapacity = 128) where T : struct, ITag {
                ModuleTags.SetBasePoolCapacity<T>(basePoolCapacity);
                return ModuleTags.RegisterTag<T>();
            }
                        
            [MethodImpl(AggressiveInlining)]
            public static TagDynId GetTagDynId<T>() where T : struct, ITag {
                return Tags<T>.Value.DynamicId();
            }
            
            [MethodImpl(AggressiveInlining)]
            public static ITagsWrapper GetTagsPool(TagDynId id) {
                return ModuleTags.GetPool(id);
            }

            [MethodImpl(AggressiveInlining)]
            public static TagsWrapper<T> GetTagsPool<T>() where T : struct, ITag {
                return ModuleTags.GetPool<T>();
            }
            
            #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
            [MethodImpl(AggressiveInlining)]
            public static void AddTagDebugEventListener(ITagDebugEventListener listener) {
                ModuleTags._debugEventListeners ??= new List<ITagDebugEventListener>();
                ModuleTags._debugEventListeners.Add(listener);
            }
            #endif
            #endif

            #if !FFS_ECS_DISABLE_MASKS
            [MethodImpl(AggressiveInlining)]
            public static MaskDynId RegisterMask<M>() where M : struct, IMask {
                return ModuleMasks.RegisterMask<M>();
            }
            
            [MethodImpl(AggressiveInlining)]
            public static MaskDynId GetMaskDynId<T>() where T : struct, IMask {
                return Masks<T>.Value.DynamicId();
            }
            
            [MethodImpl(AggressiveInlining)]
            public static IMasksWrapper GetMasksPool(MaskDynId id) {
                return ModuleMasks.GetPool(id);
            }

            [MethodImpl(AggressiveInlining)]
            public static MasksWrapper<T> GetMasksPool<T>() where T : struct, IMask {
                return ModuleMasks.GetPool<T>();
            }
            
            #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
            [MethodImpl(AggressiveInlining)]
            public static void AddMaskDebugEventListener(IMaskDebugEventListener listener) {
                ModuleMasks._debugEventListeners ??= new List<IMaskDebugEventListener>();
                ModuleMasks._debugEventListeners.Add(listener);
            }
            #endif
            #endif

            [MethodImpl(AggressiveInlining)]
            public static bool IsInitialized() => Status == WorldStatus.Initialized;

            [MethodImpl(AggressiveInlining)]
            internal static Entity CreateEntityInternal() {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if(!IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: CreateEntityInternal, World not initialized");
                #endif
                Entity entity;
                if (_deletedEntitiesCount > 0) {
                    entity = _deletedEntities[--_deletedEntitiesCount];
                    _entityVersions[entity._id] *= -1;
                } else {
                    entity._id = _entityVersionsCount;
                    
                    if (_entityVersionsCount == _entityVersions.Length) {
                        Array.Resize(ref _entityVersions, _entityVersionsCount << 1);
                        ModuleComponents.Resize(_entityVersionsCount << 1);
                        #if !FFS_ECS_DISABLE_TAGS
                        ModuleTags.Resize(_entityVersionsCount << 1);
                        #endif
                        #if !FFS_ECS_DISABLE_MASKS
                        ModuleMasks.Resize(_entityVersionsCount << 1);
                        #endif
                    }
                    
                    _entityVersions[_entityVersionsCount++] = 1;
                }

                #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
                if (_debugEventListeners != null) {
                    foreach (var listener in _debugEventListeners) {
                        listener.OnEntityCreated(entity);
                    }
                }
                #endif
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
                    #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
                    if (_debugEventListeners != null) {
                        foreach (var listener in _debugEventListeners) {
                            listener.OnEntityCreated(entity);
                        }
                    }
                    #endif
                    onCreateEntity.OnCreate(entity);
                    additional?.Invoke(entity);
                }
            }

            [MethodImpl(AggressiveInlining)]
            private static void ResizeFor(int count) {
                var newSize = Utils.CalculateSize(_entityVersionsCount + count);
                Array.Resize(ref _entityVersions, newSize);
                ModuleComponents.Resize(newSize);
                #if !FFS_ECS_DISABLE_TAGS
                ModuleTags.Resize(newSize);
                #endif
                #if !FFS_ECS_DISABLE_MASKS
                ModuleMasks.Resize(newSize);
                #endif
            }

            [MethodImpl(AggressiveInlining)]
            public static void DestroyEntity(Entity entity) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if(!IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: DestroyEntity, World not initialized");
                #endif
                ref var version = ref _entityVersions[entity._id];
                if (version < 0) {
                    return;
                }

                #if !FFS_ECS_DISABLE_TAGS
                ModuleTags.DestroyEntity(entity);
                #endif
                #if !FFS_ECS_DISABLE_MASKS
                ModuleMasks.DestroyEntity(entity);
                #endif
                ModuleComponents.DestroyEntity(entity);
                version = version == short.MaxValue ? (short) -1 : (short) -(version + 1);
                if (_deletedEntitiesCount == _deletedEntities.Length) {
                    Array.Resize(ref _deletedEntities, _deletedEntitiesCount << 1);
                }

                _deletedEntities[_deletedEntitiesCount++] = entity;
                #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
                if (_debugEventListeners != null) {
                    foreach (var listener in _debugEventListeners) {
                        listener.OnEntityDestroyed(entity);
                    }
                }
                #endif
            }

            [MethodImpl(AggressiveInlining)]
            public static void CopyEntityData(Entity srcEntity, Entity dstEntity) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if(!IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: CopyEntityData, World not initialized");
                #endif
                
                ModuleComponents.CopyEntity(srcEntity, dstEntity);
                #if !FFS_ECS_DISABLE_TAGS
                ModuleTags.CopyEntity(srcEntity, dstEntity);
                #endif
                #if !FFS_ECS_DISABLE_MASKS
                ModuleMasks.CopyEntity(srcEntity, dstEntity);
                #endif
            }

            [MethodImpl(AggressiveInlining)]
            public static Entity CloneEntity(Entity srcEntity) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if(!IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: CloneEntity, World not initialized");
                #endif
                
                var dstEntity = CreateEntityInternal();
                CopyEntityData(srcEntity, dstEntity);

                return dstEntity;
            }
            
            [MethodImpl(AggressiveInlining)]
            public static string ToPrettyStringEntity(Entity entity) {
                var result = $"Entity ID: {entity._id}, Version: {EntityVersion(entity)}\n";
                result += ModuleComponents.ToPrettyStringEntity(entity);
                #if !FFS_ECS_DISABLE_TAGS
                result += ModuleTags.ToPrettyStringEntity(entity);
                #endif
                #if !FFS_ECS_DISABLE_MASKS
                result += ModuleMasks.ToPrettyStringEntity(entity);
                #endif
                return result;
            }

            [MethodImpl(AggressiveInlining)]
            public static int EntitiesCount() {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if(!IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: EntitiesCount, World not initialized");
                #endif
                return _entityVersionsCount - _deletedEntitiesCount;
            }

            [MethodImpl(AggressiveInlining)]
            public static int EntitiesCapacity() {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if(Status == WorldStatus.NotCreated) throw new Exception($"World<{typeof(WorldID)}>, Method: GetEntitiesCapacity, World not initialized");
                #endif
                return _entityVersions.Length;
            }

            [MethodImpl(AggressiveInlining)]
            public static short EntityVersion(Entity entity) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if(!IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: EntityVersion, World not initialized");
                #endif
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
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if(!IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: Clear, World not initialized");
                #endif

                ModuleComponents.Clear();
                #if !FFS_ECS_DISABLE_TAGS
                ModuleTags.Clear();
                #endif
                #if !FFS_ECS_DISABLE_MASKS
                ModuleMasks.Clear();
                #endif

                Array.Clear(_entityVersions, 0, _entityVersions.Length);
                Array.Clear(_deletedEntities, 0, _deletedEntities.Length);
                _entityVersionsCount = 0;
                _deletedEntitiesCount = 0;
            }

            [MethodImpl(AggressiveInlining)]
            internal static void Destroy() {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if(!IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: Destroy, World not initialized");
                #endif
                
                for (var i = _entityVersionsCount - 1; i >= 0; i--) {
                    if (_entityVersions[i] > 0) {
                        DestroyEntity(Entity.FromIdx(i));
                    }
                }

                ModuleComponents.Destroy();
                #if !FFS_ECS_DISABLE_TAGS
                ModuleTags.Destroy();
                #endif
                #if !FFS_ECS_DISABLE_MASKS
                ModuleMasks.Destroy();
                #endif

                _entityVersions = null;
                _deletedEntities = null;
                _entityVersionsCount = 0;
                _deletedEntitiesCount = 0;
                Status = WorldStatus.NotCreated;
                #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
                if (_debugEventListeners != null) {
                    foreach (var listener in _debugEventListeners) {
                        listener.OnWorldDestroyed();
                    }
                }

                _debugEventListeners = null;
                #endif
            }
        }
        
        #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
        public interface IWorldDebugEventListener {
            void OnEntityCreated(Entity entity);
            void OnEntityDestroyed(Entity entity);
            void OnWorldInitialized();
            void OnWorldDestroyed();
        }
        #endif
    }

    public enum WorldStatus {
        NotCreated,
        Created,
        Initialized
    }
}