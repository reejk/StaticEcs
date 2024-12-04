#if !FFS_ECS_DISABLE_TAGS
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
        public interface ITagsWrapper {
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

            public bool TryCast<C>(out TagsWrapper<C> wrapper) where C : struct, ITag;

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
        public readonly struct TagsWrapper<T> : ITagsWrapper, Stateless where T : struct, ITag {
            [MethodImpl(AggressiveInlining)]
            public ushort Id() => Tags<T>.Id();

            [MethodImpl(AggressiveInlining)]
            public void Add(Entity entity) => Tags<T>.Add(entity);

            [MethodImpl(AggressiveInlining)]
            public void TryAdd(Entity entity) => Tags<T>.TryAdd(entity);

            [MethodImpl(AggressiveInlining)]
            public void TryAdd(Entity entity, out bool added) => Tags<T>.TryAdd(entity, out added);

            [MethodImpl(AggressiveInlining)]
            public bool Has(Entity entity) => Tags<T>.Has(entity);

            [MethodImpl(AggressiveInlining)]
            public bool Del(Entity entity) => Tags<T>.Del(entity);

            [MethodImpl(AggressiveInlining)]
            public void Copy(Entity srcEntity, Entity dstEntity) => Tags<T>.Copy(srcEntity, dstEntity);

            [MethodImpl(AggressiveInlining)]
            public int Count() => Tags<T>.Count();

            [MethodImpl(AggressiveInlining)]
            public Entity[] EntitiesData() => Tags<T>.EntitiesData();

            [MethodImpl(AggressiveInlining)]
            public string ToStringComponent(Entity entity) => Tags<T>.ToStringComponent(entity);

            [MethodImpl(AggressiveInlining)]
            public bool Is<C>() where C : struct, ITag {
                return Tags<C>.id == Tags<T>.id;
            }

            [MethodImpl(AggressiveInlining)]
            public bool TryCast<C>(out TagsWrapper<C> wrapper) where C : struct, ITag {
                return Tags<C>.id == Tags<T>.id;
            }

            [MethodImpl(AggressiveInlining)]
            bool ITagsWrapper.Has(Entity entity, out int internalId) => Tags<T>.Has(entity, out internalId);

            [MethodImpl(AggressiveInlining)]
            void ITagsWrapper.SetDataIfCountLess(ref int count, ref Entity[] entities) {
                Tags<T>.SetDataIfCountLess(ref count, ref entities);
            }

            [MethodImpl(AggressiveInlining)]
            void ITagsWrapper.Resize(int cap) => Tags<T>.Resize(cap);

            [MethodImpl(AggressiveInlining)]
            void ITagsWrapper.Destroy() => Tags<T>.Destroy();

            #if DEBUG
            void ITagsWrapper.AddBlocker(int val) {
                Tags<T>.AddBlocker(val);
            }
            #endif

            [MethodImpl(AggressiveInlining)]
            void ITagsWrapper.Clear() => Tags<T>.Clear();
        }
    }
}
#endif