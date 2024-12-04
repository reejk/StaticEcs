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
        public interface IComponentsWrapper {
            public ushort Id();

            public bool Has(Entity entity);

            public void Add(Entity entity);

            public void TryAdd(Entity entity);

            public void TryAdd(Entity entity, out bool added);

            public bool Del(Entity entity);

            internal bool DelFromWorld(Entity entity);

            public void Copy(Entity srcEntity, Entity dstEntity);

            public int Count();

            public Entity[] EntitiesData();

            public string ToStringComponent(Entity entity);

            public bool Is<C>() where C : struct, IComponent;

            public bool TryCast<C>(out ComponentsWrapper<C> wrapper) where C : struct, IComponent;

            internal void Resize(int cap);

            internal void Destroy();

            internal bool Has(Entity entity, out int internalId);

            internal void SetDataIfCountLess(ref int count, ref Entity[] entities);

            #if DEBUG
            internal void AddBlocker(int val);
            #endif
            internal void Clear();

            internal void EnsureSize(int size);
        }

        #if ENABLE_IL2CPP
            [Il2CppSetOption(Option.NullChecks, false)]
            [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public readonly struct ComponentsWrapper<T> : IComponentsWrapper, Stateless
            where T : struct, IComponent {
            [MethodImpl(AggressiveInlining)]
            public ushort Id() => Components<T>.Id();

            [MethodImpl(AggressiveInlining)]
            internal ref T Get(Entity entity) => ref Components<T>.RefMut(entity);

            [MethodImpl(AggressiveInlining)]
            public void Add(Entity entity) => Components<T>.Add(entity);

            [MethodImpl(AggressiveInlining)]
            public void TryAdd(Entity entity) => Components<T>.TryAdd(entity);

            [MethodImpl(AggressiveInlining)]
            public void TryAdd(Entity entity, out bool added) => Components<T>.TryAdd(entity, out added);

            [MethodImpl(AggressiveInlining)]
            public ref T AddIfAbsent(Entity entity) => ref Components<T>.TryAdd(entity);

            [MethodImpl(AggressiveInlining)]
            public bool Has(Entity entity) => Components<T>.Has(entity);

            [MethodImpl(AggressiveInlining)]
            public bool Del(Entity entity) => Components<T>.Del(entity);

            bool IComponentsWrapper.DelFromWorld(Entity entity) => Components<T>.DelFromWorld(entity);

            [MethodImpl(AggressiveInlining)]
            public void Copy(Entity srcEntity, Entity dstEntity) => Components<T>.Copy(srcEntity, dstEntity);

            [MethodImpl(AggressiveInlining)]
            public int Count() => Components<T>.Count();

            [MethodImpl(AggressiveInlining)]
            public Entity[] EntitiesData() => Components<T>.EntitiesData();

            [MethodImpl(AggressiveInlining)]
            public string ToStringComponent(Entity entity) => Components<T>.ToStringComponent(entity);

            [MethodImpl(AggressiveInlining)]
            public T[] Data() => Components<T>.Data();

            [MethodImpl(AggressiveInlining)]
            public bool Is<C>() where C : struct, IComponent {
                return Components<C>.id == Components<T>.id;
            }

            [MethodImpl(AggressiveInlining)]
            public bool TryCast<C>(out ComponentsWrapper<C> wrapper) where C : struct, IComponent {
                return Components<C>.id == Components<T>.id;
            }

            [MethodImpl(AggressiveInlining)]
            bool IComponentsWrapper.Has(Entity entity, out int internalId) => Components<T>.Has(entity, out internalId);

            [MethodImpl(AggressiveInlining)]
            void IComponentsWrapper.SetDataIfCountLess(ref int count, ref Entity[] entities) {
                Components<T>.SetDataIfCountLess(ref count, ref entities);
            }

            [MethodImpl(AggressiveInlining)]
            void IComponentsWrapper.Resize(int cap) => Components<T>.Resize(cap);

            [MethodImpl(AggressiveInlining)]
            void IComponentsWrapper.Destroy() => Components<T>.Destroy();

            [MethodImpl(AggressiveInlining)]
            void IComponentsWrapper.EnsureSize(int size) => Components<T>.EnsureSize(size);

            [MethodImpl(AggressiveInlining)]
            void IComponentsWrapper.Clear() => Components<T>.Clear();

            #if DEBUG
            [MethodImpl(AggressiveInlining)]
            void IComponentsWrapper.AddBlocker(int val) {
                Components<T>.AddBlocker(val);
            }
            #endif
        }
    }
}