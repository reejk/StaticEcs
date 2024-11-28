#if !FFS_ECS_DISABLE_TAGS
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
        public abstract partial class Tags {
            public interface IPoolWrapper {
                public ushort Id();

                public void Add(Entity entity);

                public void TryAdd(Entity entity);
                
                public void TryAdd(Entity entity, out bool added);

                public bool Has(Entity entity);

                public bool Del(Entity entity);

                public void Copy(Entity srcEntity, Entity dstEntity);

                public int Count();

                public Entity[] EntitiesData();
                
                public string ToStringComponent(Entity entity);

                public bool Is<C>() where C : struct, ITag;

                public bool TryCast<C>(out PoolWrapper<C> wrapper) where C : struct, ITag;

                internal bool Has(Entity entity, out int internalId);

                internal void SetDataIfCountLess(ref int count, ref Entity[] entities);

                internal void Resize(int cap);

                internal void Destroy();
                
                #if DEBUG
                internal void AddBlocker(int val);
                #endif
                
                internal void Clear();
            }

            #if ENABLE_IL2CPP
            [Il2CppSetOption(Option.NullChecks, false)]
            [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
            #endif
            public readonly struct PoolWrapper<T> : IPoolWrapper, Stateless where T : struct, ITag {
                [MethodImpl(AggressiveInlining)]
                public ushort Id() => Pool<T>.Id();

                [MethodImpl(AggressiveInlining)]
                public void Add(Entity entity) => Pool<T>.Add(entity);

                [MethodImpl(AggressiveInlining)]
                public void TryAdd(Entity entity) => Pool<T>.TryAdd(entity);

                [MethodImpl(AggressiveInlining)]
                public void TryAdd(Entity entity, out bool added) => Pool<T>.TryAdd(entity, out added);

                [MethodImpl(AggressiveInlining)]
                public bool Has(Entity entity) => Pool<T>.Has(entity);

                [MethodImpl(AggressiveInlining)]
                public bool Del(Entity entity) => Pool<T>.Del(entity);

                [MethodImpl(AggressiveInlining)]
                public void Copy(Entity srcEntity, Entity dstEntity) => Pool<T>.Copy(srcEntity, dstEntity);

                [MethodImpl(AggressiveInlining)]
                public int Count() => Pool<T>.Count();

                [MethodImpl(AggressiveInlining)]
                public Entity[] EntitiesData() => Pool<T>.EntitiesData();
                
                [MethodImpl(AggressiveInlining)]
                public string ToStringComponent(Entity entity) => Pool<T>.ToStringComponent(entity);

                [MethodImpl(AggressiveInlining)]
                public bool Is<C>() where C : struct, ITag {
                    return Pool<C>.id == Pool<T>.id;
                }

                [MethodImpl(AggressiveInlining)]
                public bool TryCast<C>(out PoolWrapper<C> wrapper) where C : struct, ITag {
                    return Pool<C>.id == Pool<T>.id;
                }

                [MethodImpl(AggressiveInlining)]
                bool IPoolWrapper.Has(Entity entity, out int internalId) => Pool<T>.Has(entity, out internalId);

                [MethodImpl(AggressiveInlining)]
                void IPoolWrapper.SetDataIfCountLess(ref int count, ref Entity[] entities) {
                    Pool<T>.SetDataIfCountLess(ref count, ref entities);
                }

                [MethodImpl(AggressiveInlining)]
                void IPoolWrapper.Resize(int cap) => Pool<T>.Resize(cap);

                [MethodImpl(AggressiveInlining)]
                void IPoolWrapper.Destroy() => Pool<T>.Destroy();
                
                #if DEBUG
                void IPoolWrapper.AddBlocker(int val) {
                    Pool<T>.AddBlocker(val);
                }
                #endif

                [MethodImpl(AggressiveInlining)]
                void IPoolWrapper.Clear() => Pool<T>.Clear();
            }
        }
    }
}
#endif