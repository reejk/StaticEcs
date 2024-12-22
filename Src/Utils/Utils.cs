using System;
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

[assembly: InternalsVisibleTo("Tests")]

namespace FFS.Libraries.StaticEcs {
    #if ENABLE_IL2CPP
    [Il2CppSetOption (Option.NullChecks, false)]
    [Il2CppSetOption (Option.ArrayBoundsChecks, false)]
    #endif
    public static class Utils {
        internal static ushort CalculateMaskLen(ushort count) {
            var len = (ushort) (count >> 6);
            if (count - (len << 6) != 0) {
                len++;
            }

            return (ushort) (len == 0 ? 1 : len);
        }
        
        
        [MethodImpl(AggressiveInlining)]
        public static int CalculateSize(int value) {
            var u = (uint) value;
            if (u == 0) {
                return 0;
            }
        
            u--;
            u |= u >> 1;
            u |= u >> 2;
            u |= u >> 4;
            u |= u >> 8;
            u |= u >> 16;
            u++;
        
            return (int) u;
        }

        internal static string GetGenericName(this Type type) {
            if (!type.IsGenericType) {
                return type.Name;
            }

            var genericArguments = type.GetGenericArguments();
            var typeName = type.FullName.Substring(0, type.FullName.IndexOf('`')); // Убираем суффикс `1, `2 и т.д.
            var genericArgs = string.Join(", ", Array.ConvertAll(genericArguments, GetGenericName));

            return $"{typeName}<{genericArgs}>";
        }
    }

    public interface Stateless { }
}

#if ENABLE_IL2CPP
namespace Unity.IL2CPP.CompilerServices {
    using System;

    internal enum Option {
        NullChecks = 1,
        ArrayBoundsChecks = 2,
        DivideByZeroChecks = 3
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Property, AllowMultiple = true)]
    internal class Il2CppSetOptionAttribute : Attribute {
        public Option Option { get; }
        public object Value { get; }

        public Il2CppSetOptionAttribute(Option option, object value) {
            Option = option;
            Value = value;
        }
    }

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, Inherited = false)]
    internal class Il2CppEagerStaticClassConstructionAttribute : Attribute { }
}
#endif