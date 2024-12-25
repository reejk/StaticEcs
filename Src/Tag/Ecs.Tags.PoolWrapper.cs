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
            
            public void Move(Entity entity, Entity target);

            public int Count();

            public string ToStringComponent(Entity entity);

            public bool Is<C>() where C : struct, ITag;

            public bool TryCast<C>(out TagsWrapper<C> wrapper) where C : struct, ITag;

            internal int[] EntitiesData();

            internal void SetDataIfCountLess(ref int count, ref int[] entities);

            internal void SetDataIfCountMore(ref int count, ref int[] entities);

            internal void Resize(int cap);
            
            internal void SetBitMask(BitMask bitMask);

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
            public ushort Id() => Tags<T>.Value.Id();

            [MethodImpl(AggressiveInlining)]
            public void Add(Entity entity) => Tags<T>.Value.Add(entity);

            [MethodImpl(AggressiveInlining)]
            public void TryAdd(Entity entity) => Tags<T>.Value.TryAdd(entity);

            [MethodImpl(AggressiveInlining)]
            public void TryAdd(Entity entity, out bool added) => Tags<T>.Value.TryAdd(entity, out added);

            [MethodImpl(AggressiveInlining)]
            public bool Has(Entity entity) => Tags<T>.Value.Has(entity);

            [MethodImpl(AggressiveInlining)]
            public bool Del(Entity entity) => Tags<T>.Value.Delete(entity);

            [MethodImpl(AggressiveInlining)]
            public void Copy(Entity srcEntity, Entity dstEntity) => Tags<T>.Value.Copy(srcEntity, dstEntity);

            [MethodImpl(AggressiveInlining)]
            public void Move(Entity srcEntity, Entity dstEntity) => Tags<T>.Value.Move(srcEntity, dstEntity);

            [MethodImpl(AggressiveInlining)]
            public int Count() => Tags<T>.Value.Count();

            [MethodImpl(AggressiveInlining)]
            public string ToStringComponent(Entity entity) => Tags<T>.Value.ToStringComponent(entity);

            [MethodImpl(AggressiveInlining)]
            public bool Is<C>() where C : struct, ITag {
                return Tags<C>.Value.id == Tags<T>.Value.id;
            }

            [MethodImpl(AggressiveInlining)]
            public bool TryCast<C>(out TagsWrapper<C> wrapper) where C : struct, ITag {
                return Tags<C>.Value.id == Tags<T>.Value.id;
            }

            [MethodImpl(AggressiveInlining)]
            int[] ITagsWrapper.EntitiesData() => Tags<T>.Value.EntitiesData();

            [MethodImpl(AggressiveInlining)]
            void ITagsWrapper.SetDataIfCountLess(ref int count, ref int[] entities) {
                Tags<T>.Value.SetDataIfCountLess(ref count, ref entities);
            }

            [MethodImpl(AggressiveInlining)]
            void ITagsWrapper.SetDataIfCountMore(ref int count, ref int[] entities) {
                Tags<T>.Value.SetDataIfCountMore(ref count, ref entities);
            }

            [MethodImpl(AggressiveInlining)]
            void ITagsWrapper.Resize(int cap) => Tags<T>.Value.Resize(cap);

            [MethodImpl(AggressiveInlining)]
            void ITagsWrapper.Destroy() => Tags<T>.Value.Destroy();

            #if DEBUG
            void ITagsWrapper.AddBlocker(int val) {
                Tags<T>.Value.AddBlocker(val);
            }
            #endif

            [MethodImpl(AggressiveInlining)]
            void ITagsWrapper.Clear() => Tags<T>.Value.Clear();

            [MethodImpl(AggressiveInlining)]
            void ITagsWrapper.SetBitMask(BitMask bitMask) => Tags<T>.Value.SetBitMask(bitMask);
        }
    }
}
#endif