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
        public interface IMasksWrapper {
            public ushort Id();

            public void Set(Entity entity);

            public bool Has(Entity entity);

            public void Del(Entity entity);

            public void Copy(Entity srcEntity, Entity dstEntity);

            public int Count();

            public string ToStringComponent(Entity entity);

            public bool Is<C>() where C : struct, IMask;

            public bool TryCast<C>(out MasksWrapper<C> wrapper) where C : struct, IMask;

            internal void Clear();
            
            internal void SetBitMask(BitMask bitMask);
        }

        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public readonly struct MasksWrapper<T> : IMasksWrapper, Stateless where T : struct, IMask {
            [MethodImpl(AggressiveInlining)]
            public ushort Id() => Masks<T>.Value.Id();

            [MethodImpl(AggressiveInlining)]
            public void Set(Entity entity) => Masks<T>.Value.Set(entity);

            [MethodImpl(AggressiveInlining)]
            public bool Has(Entity entity) => Masks<T>.Value.Has(entity);

            [MethodImpl(AggressiveInlining)]
            public void Del(Entity entity) => Masks<T>.Value.Delete(entity);

            [MethodImpl(AggressiveInlining)]
            public void Copy(Entity srcEntity, Entity dstEntity) => ModuleMasks.CopyEntity(srcEntity, dstEntity);

            [MethodImpl(AggressiveInlining)]
            public int Count() => Masks<T>.Value.Count();

            [MethodImpl(AggressiveInlining)]
            public string ToStringComponent(Entity entity) => Masks<T>.Value.ToStringComponent(entity);

            [MethodImpl(AggressiveInlining)]
            public bool Is<C>() where C : struct, IMask {
                return Masks<C>.Value.id == Masks<T>.Value.id;
            }

            [MethodImpl(AggressiveInlining)]
            public bool TryCast<C>(out MasksWrapper<C> wrapper) where C : struct, IMask {
                return Masks<C>.Value.id == Masks<T>.Value.id;
            }

            [MethodImpl(AggressiveInlining)]
            void IMasksWrapper.Clear() => Masks<T>.Value.Clear();

            [MethodImpl(AggressiveInlining)]
            void IMasksWrapper.SetBitMask(BitMask bitMask) => Masks<T>.Value.SetBitMask(bitMask);
        }
    }
}
#endif