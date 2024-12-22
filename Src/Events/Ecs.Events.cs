#if !FFS_ECS_DISABLE_EVENTS
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
        [Il2CppEagerStaticClassConstruction]
        #endif
        public abstract partial class Events {
            private static Action[] _poolDestroyMethods;
            private static Func<bool>[] _poolTryAddMethods;
            private static ushort _poolCount;

            #region PUBLIC
            [MethodImpl(AggressiveInlining)]
            public static void Send<E>(E value = default) where E : struct, IEvent {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"[ Ecs<{typeof(World)}>.Events.Send<{typeof(E)}> ] Ecs not initialized");
                #endif
                if (Pool<E>.Initialized) {
                    Pool<E>.Add(value);
                }
                #if DEBUG
                else {
                    EcsDebugLogger.Warn($"[ Ecs<{typeof(World)}>.Events.Send<{typeof(E)}> ] The event will not be sent. No receiver is registered.");
                }
                #endif
            }
            
            [MethodImpl(AggressiveInlining)]
            public static void SendDefault(EventDynId value) {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"[ Ecs<{typeof(World)}>.Events.Send ] Ecs not initialized");
                #endif
                if (!_poolTryAddMethods[value.Val]()) {
                    #if DEBUG
                    EcsDebugLogger.Warn($"[ Ecs<{typeof(World)}>.Events.Send ] The event will not be sent. No receiver is registered.");
                    #endif
                }
            }
            
            [MethodImpl(AggressiveInlining)]
            public static EventReceiver<WorldID, E> RegisterEventReceiver<E>() where E : struct, IEvent {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"[ Ecs<{typeof(World)}>.Events.RegisterEventReceiver<{typeof(E)}> ] Ecs not initialized");
                #endif
                if (!Pool<E>.Initialized) {
                    RegisterEventPool<E>();
                }
                return Pool<E>.CreateReceiver();
            }
            
            [MethodImpl(AggressiveInlining)]
            public static void DeleteEventReceiver<E>(ref EventReceiver<WorldID, E> receiver) where E : struct, IEvent {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"[ Ecs<{typeof(World)}>.Events.DeleteEventReceiver<{typeof(E)}> ] Ecs not initialized");
                #endif
                if (Pool<E>.Initialized) {
                    Pool<E>.DeleteReceiver(ref receiver);
                }
            }
            
            [MethodImpl(AggressiveInlining)]
            public static EventDynId DynamicId<E>() where E : struct, IEvent {
                #if DEBUG
                if (!World.IsInitialized()) throw new Exception($"[ Ecs<{typeof(World)}>.Events.Send<{typeof(E)}> ] Ecs not initialized");
                #endif
                if (Pool<E>.Initialized) {
                    return new EventDynId(Pool<E>.Id);
                }
                throw new Exception($"[ Ecs<{typeof(World)}>.Events.DynamicId<{typeof(E)}> ] Pool not initialized");
            }
            #endregion

            #region INTERNAL
            [MethodImpl(AggressiveInlining)]
            internal static void Create() {
                _poolDestroyMethods = new Action[32];
                _poolTryAddMethods = new Func<bool>[32];
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static void RegisterEventPool<T>() where T : struct {
                Pool<T>.Create(_poolCount);

                if (_poolCount == _poolDestroyMethods.Length) {
                    Array.Resize(ref _poolDestroyMethods, _poolCount << 1);
                    Array.Resize(ref _poolTryAddMethods, _poolCount << 1);
                }

                _poolDestroyMethods[_poolCount] = static () => Pool<T>.Destroy();
                _poolTryAddMethods[_poolCount] = static () => {
                    if (Pool<T>.Initialized) {
                        Pool<T>.Add();
                        return true;
                    }

                    return false;
                };
                _poolCount++;
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static void Destroy() {
                for (var i = 0; i < _poolCount; i++) {
                    _poolDestroyMethods[i]();
                }

                _poolCount = default;
                _poolDestroyMethods = default;
                _poolTryAddMethods = default;
            }
            #endregion
        }
    }
}
#endif