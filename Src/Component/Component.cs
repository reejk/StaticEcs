using System;
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

namespace FFS.Libraries.StaticEcs {
    public interface IComponent { }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct ComponentDynId : IEquatable<ComponentDynId> {
        public readonly ushort Value;
        
        internal ComponentDynId(ushort value) {
            Value = value;
        }

        [MethodImpl(AggressiveInlining)]
        public bool Equals(ComponentDynId other) => Value == other.Value;

        [MethodImpl(AggressiveInlining)]
        public override int GetHashCode() => Value;

        [MethodImpl(AggressiveInlining)]
        public override string ToString() => $"ComponentDynamicId ID: {Value}";
    }
}