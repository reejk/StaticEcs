#if !FFS_ECS_DISABLE_MASKS
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
    public readonly struct MaskDynId : IEquatable<MaskDynId> {
        internal readonly ushort Val;
        
        internal MaskDynId(ushort val) {
            Val = val;
        }

        [MethodImpl(AggressiveInlining)]
        public bool Equals(MaskDynId other) => Val == other.Val;

        [MethodImpl(AggressiveInlining)]
        public override int GetHashCode() => Val;

        [MethodImpl(AggressiveInlining)]
        public override string ToString() => $"MaskDynamicId ID: {Val}";
    }
}
#endif

namespace FFS.Libraries.StaticEcs {
    public interface IMask { }
}