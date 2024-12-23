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
        public abstract partial class Masks<T> where T : struct, IMask {
            private static BitMask _bitMask;
            internal static ushort id;
            internal static int count;

            static Masks() {
                ModuleMasks.RegisterMask<T>();
            }

            internal static void Create(ushort componentId, BitMask bitMask) {
                _bitMask = bitMask;
                id = componentId;
            }

            [MethodImpl(AggressiveInlining)]
            public static ushort Id() => id;

            [MethodImpl(AggressiveInlining)]
            public static int Count() => count;

            [MethodImpl(AggressiveInlining)]
            public static void Set(Entity entity) {
                _bitMask.Set(entity._id, id);
                count++;
            }

            [MethodImpl(AggressiveInlining)]
            public static bool Has(Entity entity) {
                return _bitMask.Has(entity._id, id);
            }

            [MethodImpl(AggressiveInlining)]
            public static void Delete(Entity entity) {
                _bitMask.Del(entity._id, id);
                count--;
            }

            [MethodImpl(AggressiveInlining)]
            public static string ToStringComponent(Entity entity) {
                return $" - [{id}] {typeof(T).Name}\n";
            }

            [MethodImpl(AggressiveInlining)]
            public static void Clear() {
                count = 0;
            }
        }
    }
}
#endif