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
        
        public override bool Equals(object obj) => throw new Exception("MaskDynId` Equals object` not allowed!");

        [MethodImpl(AggressiveInlining)]
        public override int GetHashCode() => Val;

        [MethodImpl(AggressiveInlining)]
        public override string ToString() => $"MaskDynamicId ID: {Val}";
                
        [MethodImpl(AggressiveInlining)]
        public static bool operator ==(MaskDynId left, MaskDynId right) => left.Equals(right);

        [MethodImpl(AggressiveInlining)]
        public static bool operator !=(MaskDynId left, MaskDynId right) => !left.Equals(right);
    }
}
#endif

namespace FFS.Libraries.StaticEcs {
    public interface IMask { }
}