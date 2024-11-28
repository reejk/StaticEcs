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
        public abstract class Context {
            [MethodImpl(AggressiveInlining)]
            public static bool Has<T>() => Context<T>.Has();
            
            [MethodImpl(AggressiveInlining)]
            public static ref T Get<T>() => ref Context<T>.Get();

            [MethodImpl(AggressiveInlining)]
            public static void Set<T>(T value) => Context<T>.Set(value);
            
            [MethodImpl(AggressiveInlining)]
            public static void Replace<T>(T value) => Context<T>.Replace(value);
        }

        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        [Il2CppEagerStaticClassConstruction]
        #endif
        public abstract partial class Context<T> {
            private static T _value;
            private static bool _has;

            [MethodImpl(AggressiveInlining)]
            public static void Set(T value) {
                if (value == null) {
                    throw new Exception($"{typeof(T).Name} is null, Context<{typeof(WorldID)}>");
                }

                if (_has) {
                    throw new Exception($"{typeof(T).Name} already exist in container Context<{typeof(WorldID)}>");
                }

                _has = true;
                _value = value;
            }
            
            [MethodImpl(AggressiveInlining)]
            public static void Replace(T value) {
                _has = true;
                _value = value;
            }

            [MethodImpl(AggressiveInlining)]
            public static bool Has() {
                return _has;
            }

            [MethodImpl(AggressiveInlining)]
            public static ref T Get() {
                return ref _value;
            }

            [MethodImpl(AggressiveInlining)]
            public static void Remove() {
                _value = default;
            }
        }
    }
}