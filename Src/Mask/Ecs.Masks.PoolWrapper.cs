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
        public abstract partial class Masks {
            public interface IPoolWrapper {
                public ushort Id();

                public void Set(Entity entity);

                public bool Has(Entity entity);

                public void Del(Entity entity);

                public void Copy(Entity srcEntity, Entity dstEntity);

                public int Count();
                
                public string ToStringComponent(Entity entity);

                public bool Is<C>() where C : struct, IMask;

                public bool TryCast<C>(out PoolWrapper<C> wrapper) where C : struct, IMask;
                
                internal void Clear();
            }

            #if ENABLE_IL2CPP
            [Il2CppSetOption(Option.NullChecks, false)]
            [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
            #endif
            public readonly struct PoolWrapper<T> : IPoolWrapper, Stateless where T : struct, IMask {
                [MethodImpl(AggressiveInlining)]
                public ushort Id() => Pool<T>.Id();

                [MethodImpl(AggressiveInlining)]
                public void Set(Entity entity) => Pool<T>.Set(entity);

                [MethodImpl(AggressiveInlining)]
                public bool Has(Entity entity) => Pool<T>.Has(entity);

                [MethodImpl(AggressiveInlining)]
                public void Del(Entity entity) => Pool<T>.Del(entity);

                [MethodImpl(AggressiveInlining)]
                public void Copy(Entity srcEntity, Entity dstEntity) => CopyEntity(srcEntity, dstEntity);

                [MethodImpl(AggressiveInlining)]
                public int Count() => Pool<T>.Count();
                
                [MethodImpl(AggressiveInlining)]
                public string ToStringComponent(Entity entity) => Pool<T>.ToStringComponent(entity);

                [MethodImpl(AggressiveInlining)]
                public bool Is<C>() where C : struct, IMask {
                    return Pool<C>.id == Pool<T>.id;
                }

                [MethodImpl(AggressiveInlining)]
                public bool TryCast<C>(out PoolWrapper<C> wrapper) where C : struct, IMask {
                    return Pool<C>.id == Pool<T>.id;
                }

                [MethodImpl(AggressiveInlining)]
                void IPoolWrapper.Clear() => Pool<T>.Clear();
            }
        }
    }
}
#endif