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
        internal readonly ushort Val;
        
        internal ComponentDynId(ushort val) {
            Val = val;
        }

        [MethodImpl(AggressiveInlining)]
        public bool Equals(ComponentDynId other) => Val == other.Val;

        [MethodImpl(AggressiveInlining)]
        public override int GetHashCode() => Val;

        [MethodImpl(AggressiveInlining)]
        public override string ToString() => $"ComponentDynamicId ID: {Val}";
    }
}