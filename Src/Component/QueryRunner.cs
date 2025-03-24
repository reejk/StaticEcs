﻿using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

namespace FFS.Libraries.StaticEcs {
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public abstract partial class Ecs<WorldType> {
        #region ABSTRACT_QUERY_FUNCTION
        public interface IQueryFunction<C1>
            where C1 : struct, IComponent {
            public void Run(Entity entity, ref C1 c1);
        }

        public interface IQueryFunction<C1, C2>
            where C1 : struct, IComponent
            where C2 : struct, IComponent {
            public void Run(Entity entity, ref C1 c1, ref C2 c2);
        }

        public interface IQueryFunction<C1, C2, C3>
            where C1 : struct, IComponent
            where C2 : struct, IComponent
            where C3 : struct, IComponent {
            public void Run(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3);
        }

        public interface IQueryFunction<C1, C2, C3, C4>
            where C1 : struct, IComponent
            where C2 : struct, IComponent
            where C3 : struct, IComponent
            where C4 : struct, IComponent {
            public void Run(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4);
        }

        public interface IQueryFunction<C1, C2, C3, C4, C5>
            where C1 : struct, IComponent
            where C2 : struct, IComponent
            where C3 : struct, IComponent
            where C4 : struct, IComponent
            where C5 : struct, IComponent {
            public void Run(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5);
        }

        public interface IQueryFunction<C1, C2, C3, C4, C5, C6>
            where C1 : struct, IComponent
            where C2 : struct, IComponent
            where C3 : struct, IComponent
            where C4 : struct, IComponent
            where C5 : struct, IComponent
            where C6 : struct, IComponent {
            public void Run(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6);
        }

        public interface IQueryFunction<C1, C2, C3, C4, C5, C6, C7>
            where C1 : struct, IComponent
            where C2 : struct, IComponent
            where C3 : struct, IComponent
            where C4 : struct, IComponent
            where C5 : struct, IComponent
            where C6 : struct, IComponent
            where C7 : struct, IComponent {
            public void Run(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7);
        }

        public interface IQueryFunction<C1, C2, C3, C4, C5, C6, C7, C8>
            where C1 : struct, IComponent
            where C2 : struct, IComponent
            where C3 : struct, IComponent
            where C4 : struct, IComponent
            where C5 : struct, IComponent
            where C6 : struct, IComponent
            where C7 : struct, IComponent
            where C8 : struct, IComponent {
            public void Run(Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8);
        }
        #endregion
    }

    #region DELEFATE_QUERY_FUNCTION
    public delegate void DelegateQueryFunction<WorldType, C1>(Ecs<WorldType>.Entity entity, ref C1 c1)
        where C1 : struct, IComponent
        where WorldType : struct, IWorldType;

    public delegate void DelegateQueryFunction<WorldType, C1, C2>(Ecs<WorldType>.Entity entity, ref C1 c1, ref C2 c2)
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where WorldType : struct, IWorldType;

    public delegate void DelegateQueryFunction<WorldType, C1, C2, C3>(Ecs<WorldType>.Entity entity, ref C1 c1, ref C2 c2, ref C3 c3)
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where WorldType : struct, IWorldType;

    public delegate void DelegateQueryFunction<WorldType, C1, C2, C3, C4>(Ecs<WorldType>.Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4)
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where WorldType : struct, IWorldType;

    public delegate void DelegateQueryFunction<WorldType, C1, C2, C3, C4, C5>(Ecs<WorldType>.Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5)
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where WorldType : struct, IWorldType;

    public delegate void DelegateQueryFunction<WorldType, C1, C2, C3, C4, C5, C6>(Ecs<WorldType>.Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6)
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where C6 : struct, IComponent
        where WorldType : struct, IWorldType;

    public delegate void DelegateQueryFunction<WorldType, C1, C2, C3, C4, C5, C6, C7>(Ecs<WorldType>.Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7)
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where C6 : struct, IComponent
        where C7 : struct, IComponent
        where WorldType : struct, IWorldType;

    public delegate void DelegateQueryFunction<WorldType, C1, C2, C3, C4, C5, C6, C7, C8>(
        Ecs<WorldType>.Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8
    )
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where C6 : struct, IComponent
        where C7 : struct, IComponent
        where C8 : struct, IComponent
        where WorldType : struct, IWorldType;
    #endregion

    #region QUERY_FUNCTION_RUNNER
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly ref struct QueryFunctionRunner<WorldType, C1, P>
        where P : struct, IQueryMethod
        where C1 : struct, IComponent
        where WorldType : struct, IWorldType {
        [MethodImpl(AggressiveInlining)]
        public void Run<R>(ref R runner, P with) where R : struct, Ecs<WorldType>.IQueryFunction<C1> {
            var count = Ecs<WorldType>.Components<C1>.Value.Count();
            var entities = Ecs<WorldType>.Components<C1>.Value.EntitiesData();
            #if DEBUG || FFS_ECS_ENABLE_DEBUG
            Ecs<WorldType>.Components<C1>.Value.AddBlocker(1);
            #endif
            with.SetData<WorldType>(ref count, ref entities);

            var di1 = Ecs<WorldType>.Components<C1>.Value.GetDataIdxByEntityId();
            var dataC1 = Ecs<WorldType>.Components<C1>.Value.Data();
            while (count > 0) {
                count--;
                var entity = entities[count];
                var i1 = di1[entity];
                if (i1 != Utils.EmptyComponent && with.CheckEntity(entity)) {
                    runner.Run(new Ecs<WorldType>.Entity(entity), ref dataC1[i1]);
                }
            }

            with.Dispose<WorldType>();
            #if DEBUG || FFS_ECS_ENABLE_DEBUG
            Ecs<WorldType>.Components<C1>.Value.AddBlocker(-1);
            #endif
        }

        [MethodImpl(AggressiveInlining)]
        public void Run(DelegateQueryFunction<WorldType, C1> runner, P with) {
            var count = Ecs<WorldType>.Components<C1>.Value.Count();
            var entities = Ecs<WorldType>.Components<C1>.Value.EntitiesData();
            #if DEBUG || FFS_ECS_ENABLE_DEBUG
            Ecs<WorldType>.Components<C1>.Value.AddBlocker(1);
            #endif
            with.SetData<WorldType>(ref count, ref entities);
            
            var di1 = Ecs<WorldType>.Components<C1>.Value.GetDataIdxByEntityId();
            var dataC1 = Ecs<WorldType>.Components<C1>.Value.Data();
            while (count > 0) {
                count--;
                var entity = entities[count];
                var i1 = di1[entity];
                if (i1 != Utils.EmptyComponent && with.CheckEntity(entity)) {
                    runner(new Ecs<WorldType>.Entity(entity), ref dataC1[i1]);
                }
            }

            with.Dispose<WorldType>();
            #if DEBUG || FFS_ECS_ENABLE_DEBUG
            Ecs<WorldType>.Components<C1>.Value.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly ref struct QueryFunctionRunner<WorldType, C1, C2, P>
        where P : struct, IQueryMethod
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where WorldType : struct, IWorldType {
        [MethodImpl(AggressiveInlining)]
        public static void Run<R>(ref R runner, P with) where R : struct, Ecs<WorldType>.IQueryFunction<C1, C2> {
            #if DEBUG || FFS_ECS_ENABLE_DEBUG
            Ecs<WorldType>.Components<C1>.Value.AddBlocker(1);
            Ecs<WorldType>.Components<C2>.Value.AddBlocker(1);
            #endif
            var count = Ecs<WorldType>.Components<C1>.Value.Count();
            var entities = Ecs<WorldType>.Components<C1>.Value.EntitiesData();
            Ecs<WorldType>.Components<C2>.Value.SetDataIfCountLess(ref count, ref entities, out var _);
            with.SetData<WorldType>(ref count, ref entities);

            var di1 = Ecs<WorldType>.Components<C1>.Value.GetDataIdxByEntityId();
            var di2 = Ecs<WorldType>.Components<C2>.Value.GetDataIdxByEntityId();

            var data1 = Ecs<WorldType>.Components<C1>.Value.Data();
            var data2 = Ecs<WorldType>.Components<C2>.Value.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var i1 = di1[entity];
                var i2 = di2[entity];
                if (i1 != Utils.EmptyComponent && i2 != Utils.EmptyComponent && with.CheckEntity(entity)) {
                    runner.Run(new Ecs<WorldType>.Entity(entity),
                               ref data1[i1],
                               ref data2[i2]
                    );
                }
            }

            with.Dispose<WorldType>();
            #if DEBUG || FFS_ECS_ENABLE_DEBUG
            Ecs<WorldType>.Components<C1>.Value.AddBlocker(-1);
            Ecs<WorldType>.Components<C2>.Value.AddBlocker(-1);
            #endif
        }

        [MethodImpl(AggressiveInlining)]
        public static void Run(DelegateQueryFunction<WorldType, C1, C2> runner, P with) {
            #if DEBUG || FFS_ECS_ENABLE_DEBUG
            Ecs<WorldType>.Components<C1>.Value.AddBlocker(1);
            Ecs<WorldType>.Components<C2>.Value.AddBlocker(1);
            #endif
            var count = Ecs<WorldType>.Components<C1>.Value.Count();
            var entities = Ecs<WorldType>.Components<C1>.Value.EntitiesData();
            Ecs<WorldType>.Components<C2>.Value.SetDataIfCountLess(ref count, ref entities, out var _);
            with.SetData<WorldType>(ref count, ref entities);

            var di1 = Ecs<WorldType>.Components<C1>.Value.GetDataIdxByEntityId();
            var di2 = Ecs<WorldType>.Components<C2>.Value.GetDataIdxByEntityId();

            var data1 = Ecs<WorldType>.Components<C1>.Value.Data();
            var data2 = Ecs<WorldType>.Components<C2>.Value.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var i1 = di1[entity];
                var i2 = di2[entity];
                if (i1 != Utils.EmptyComponent && i2 != Utils.EmptyComponent && with.CheckEntity(entity)) {
                    runner(new Ecs<WorldType>.Entity(entity),
                               ref data1[i1],
                               ref data2[i2]
                    );
                }
            }

            with.Dispose<WorldType>();
            #if DEBUG || FFS_ECS_ENABLE_DEBUG
            Ecs<WorldType>.Components<C1>.Value.AddBlocker(-1);
            Ecs<WorldType>.Components<C2>.Value.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly ref struct QueryFunctionRunner<WorldType, C1, C2, C3, P>
        where P : struct, IQueryMethod
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where WorldType : struct, IWorldType {
        [MethodImpl(AggressiveInlining)]
        public static void Run<R>(ref R runner, P with) where R : struct, Ecs<WorldType>.IQueryFunction<C1, C2, C3> {
            #if DEBUG || FFS_ECS_ENABLE_DEBUG
            Ecs<WorldType>.Components<C1>.Value.AddBlocker(1);
            Ecs<WorldType>.Components<C2>.Value.AddBlocker(1);
            Ecs<WorldType>.Components<C3>.Value.AddBlocker(1);
            #endif
            var count = Ecs<WorldType>.Components<C1>.Value.Count();
            var entities = Ecs<WorldType>.Components<C1>.Value.EntitiesData();
            Ecs<WorldType>.Components<C2>.Value.SetDataIfCountLess(ref count, ref entities, out var _);
            Ecs<WorldType>.Components<C3>.Value.SetDataIfCountLess(ref count, ref entities, out var _);
            with.SetData<WorldType>(ref count, ref entities);

            var di1 = Ecs<WorldType>.Components<C1>.Value.GetDataIdxByEntityId();
            var di2 = Ecs<WorldType>.Components<C2>.Value.GetDataIdxByEntityId();
            var di3 = Ecs<WorldType>.Components<C3>.Value.GetDataIdxByEntityId();

            var data1 = Ecs<WorldType>.Components<C1>.Value.Data();
            var data2 = Ecs<WorldType>.Components<C2>.Value.Data();
            var data3 = Ecs<WorldType>.Components<C3>.Value.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var i1 = di1[entity];
                var i2 = di2[entity];
                var i3 = di3[entity];
                if (i1 != Utils.EmptyComponent && i2 != Utils.EmptyComponent && i3 != Utils.EmptyComponent && with.CheckEntity(entity)) {
                    runner.Run(new Ecs<WorldType>.Entity(entity),
                               ref data1[i1],
                               ref data2[i2],
                               ref data3[i3]
                    );
                }
            }

            with.Dispose<WorldType>();
            #if DEBUG || FFS_ECS_ENABLE_DEBUG
            Ecs<WorldType>.Components<C1>.Value.AddBlocker(-1);
            Ecs<WorldType>.Components<C2>.Value.AddBlocker(-1);
            Ecs<WorldType>.Components<C3>.Value.AddBlocker(-1);
            #endif
        }

        [MethodImpl(AggressiveInlining)]
        public static void Run(DelegateQueryFunction<WorldType, C1, C2, C3> runner, P with) {
            #if DEBUG || FFS_ECS_ENABLE_DEBUG
            Ecs<WorldType>.Components<C1>.Value.AddBlocker(1);
            Ecs<WorldType>.Components<C2>.Value.AddBlocker(1);
            Ecs<WorldType>.Components<C3>.Value.AddBlocker(1);
            #endif
            var count = Ecs<WorldType>.Components<C1>.Value.Count();
            var entities = Ecs<WorldType>.Components<C1>.Value.EntitiesData();
            Ecs<WorldType>.Components<C2>.Value.SetDataIfCountLess(ref count, ref entities, out var _);
            Ecs<WorldType>.Components<C3>.Value.SetDataIfCountLess(ref count, ref entities, out var _);
            with.SetData<WorldType>(ref count, ref entities);

            var di1 = Ecs<WorldType>.Components<C1>.Value.GetDataIdxByEntityId();
            var di2 = Ecs<WorldType>.Components<C2>.Value.GetDataIdxByEntityId();
            var di3 = Ecs<WorldType>.Components<C3>.Value.GetDataIdxByEntityId();

            var data1 = Ecs<WorldType>.Components<C1>.Value.Data();
            var data2 = Ecs<WorldType>.Components<C2>.Value.Data();
            var data3 = Ecs<WorldType>.Components<C3>.Value.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var i1 = di1[entity];
                var i2 = di2[entity];
                var i3 = di3[entity];
                if (i1 != Utils.EmptyComponent && i2 != Utils.EmptyComponent && i3 != Utils.EmptyComponent && with.CheckEntity(entity)) {
                    runner(new Ecs<WorldType>.Entity(entity),
                               ref data1[i1],
                               ref data2[i2],
                               ref data3[i3]
                    );
                }
            }

            with.Dispose<WorldType>();
            #if DEBUG || FFS_ECS_ENABLE_DEBUG
            Ecs<WorldType>.Components<C1>.Value.AddBlocker(-1);
            Ecs<WorldType>.Components<C2>.Value.AddBlocker(-1);
            Ecs<WorldType>.Components<C3>.Value.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly ref struct QueryFunctionRunner<WorldType, C1, C2, C3, C4, P>
        where P : struct, IQueryMethod
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where WorldType : struct, IWorldType {
        [MethodImpl(AggressiveInlining)]
        public static void Run<R>(ref R runner, P with) where R : struct, Ecs<WorldType>.IQueryFunction<C1, C2, C3, C4> {
            #if DEBUG || FFS_ECS_ENABLE_DEBUG
            Ecs<WorldType>.Components<C1>.Value.AddBlocker(1);
            Ecs<WorldType>.Components<C2>.Value.AddBlocker(1);
            Ecs<WorldType>.Components<C3>.Value.AddBlocker(1);
            Ecs<WorldType>.Components<C4>.Value.AddBlocker(1);
            #endif
            var count = Ecs<WorldType>.Components<C1>.Value.Count();
            var entities = Ecs<WorldType>.Components<C1>.Value.EntitiesData();
            Ecs<WorldType>.Components<C2>.Value.SetDataIfCountLess(ref count, ref entities, out var _);
            Ecs<WorldType>.Components<C3>.Value.SetDataIfCountLess(ref count, ref entities, out var _);
            Ecs<WorldType>.Components<C4>.Value.SetDataIfCountLess(ref count, ref entities, out var _);
            with.SetData<WorldType>(ref count, ref entities);

            var di1 = Ecs<WorldType>.Components<C1>.Value.GetDataIdxByEntityId();
            var di2 = Ecs<WorldType>.Components<C2>.Value.GetDataIdxByEntityId();
            var di3 = Ecs<WorldType>.Components<C3>.Value.GetDataIdxByEntityId();
            var di4 = Ecs<WorldType>.Components<C4>.Value.GetDataIdxByEntityId();

            var data1 = Ecs<WorldType>.Components<C1>.Value.Data();
            var data2 = Ecs<WorldType>.Components<C2>.Value.Data();
            var data3 = Ecs<WorldType>.Components<C3>.Value.Data();
            var data4 = Ecs<WorldType>.Components<C4>.Value.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var i1 = di1[entity];
                var i2 = di2[entity];
                var i3 = di3[entity];
                var i4 = di4[entity];
                if (i1 != Utils.EmptyComponent && i2 != Utils.EmptyComponent && i3 != Utils.EmptyComponent && i4 != Utils.EmptyComponent && with.CheckEntity(entity)) {
                    runner.Run(new Ecs<WorldType>.Entity(entity),
                               ref data1[i1],
                               ref data2[i2],
                               ref data3[i3],
                               ref data4[i4]
                    );
                }
            }

            with.Dispose<WorldType>();
            #if DEBUG || FFS_ECS_ENABLE_DEBUG
            Ecs<WorldType>.Components<C1>.Value.AddBlocker(-1);
            Ecs<WorldType>.Components<C2>.Value.AddBlocker(-1);
            Ecs<WorldType>.Components<C3>.Value.AddBlocker(-1);
            Ecs<WorldType>.Components<C4>.Value.AddBlocker(-1);
            #endif
        }

        [MethodImpl(AggressiveInlining)]
        public static void Run(DelegateQueryFunction<WorldType, C1, C2, C3, C4> runner, P with) {
           #if DEBUG || FFS_ECS_ENABLE_DEBUG
            Ecs<WorldType>.Components<C1>.Value.AddBlocker(1);
            Ecs<WorldType>.Components<C2>.Value.AddBlocker(1);
            Ecs<WorldType>.Components<C3>.Value.AddBlocker(1);
            Ecs<WorldType>.Components<C4>.Value.AddBlocker(1);
            #endif
            var count = Ecs<WorldType>.Components<C1>.Value.Count();
            var entities = Ecs<WorldType>.Components<C1>.Value.EntitiesData();
            Ecs<WorldType>.Components<C2>.Value.SetDataIfCountLess(ref count, ref entities, out var _);
            Ecs<WorldType>.Components<C3>.Value.SetDataIfCountLess(ref count, ref entities, out var _);
            Ecs<WorldType>.Components<C4>.Value.SetDataIfCountLess(ref count, ref entities, out var _);
            with.SetData<WorldType>(ref count, ref entities);

            var di1 = Ecs<WorldType>.Components<C1>.Value.GetDataIdxByEntityId();
            var di2 = Ecs<WorldType>.Components<C2>.Value.GetDataIdxByEntityId();
            var di3 = Ecs<WorldType>.Components<C3>.Value.GetDataIdxByEntityId();
            var di4 = Ecs<WorldType>.Components<C4>.Value.GetDataIdxByEntityId();

            var data1 = Ecs<WorldType>.Components<C1>.Value.Data();
            var data2 = Ecs<WorldType>.Components<C2>.Value.Data();
            var data3 = Ecs<WorldType>.Components<C3>.Value.Data();
            var data4 = Ecs<WorldType>.Components<C4>.Value.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var i1 = di1[entity];
                var i2 = di2[entity];
                var i3 = di3[entity];
                var i4 = di4[entity];
                if (i1 != Utils.EmptyComponent && i2 != Utils.EmptyComponent && i3 != Utils.EmptyComponent && i4 != Utils.EmptyComponent && with.CheckEntity(entity)) {
                    runner(new Ecs<WorldType>.Entity(entity),
                               ref data1[i1],
                               ref data2[i2],
                               ref data3[i3],
                               ref data4[i4]
                    );
                }
            }

            with.Dispose<WorldType>();
            #if DEBUG || FFS_ECS_ENABLE_DEBUG
            Ecs<WorldType>.Components<C1>.Value.AddBlocker(-1);
            Ecs<WorldType>.Components<C2>.Value.AddBlocker(-1);
            Ecs<WorldType>.Components<C3>.Value.AddBlocker(-1);
            Ecs<WorldType>.Components<C4>.Value.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly ref struct QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, P>
        where P : struct, IQueryMethod
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where WorldType : struct, IWorldType {
        [MethodImpl(AggressiveInlining)]
        public static void Run<R>(ref R runner, P with) where R : struct, Ecs<WorldType>.IQueryFunction<C1, C2, C3, C4, C5> {
            var all = default(All<C1, C2, C3, C4, C5>);
            var count = Ecs<WorldType>.Components<C1>.Value.Count();
            var entities = Ecs<WorldType>.Components<C1>.Value.EntitiesData();
            all.SetData<WorldType>(ref count, ref entities);
            with.SetData<WorldType>(ref count, ref entities);

            var di1 = Ecs<WorldType>.Components<C1>.Value.GetDataIdxByEntityId();
            var di2 = Ecs<WorldType>.Components<C2>.Value.GetDataIdxByEntityId();
            var di3 = Ecs<WorldType>.Components<C3>.Value.GetDataIdxByEntityId();
            var di4 = Ecs<WorldType>.Components<C4>.Value.GetDataIdxByEntityId();
            var di5 = Ecs<WorldType>.Components<C5>.Value.GetDataIdxByEntityId();

            var data1 = Ecs<WorldType>.Components<C1>.Value.Data();
            var data2 = Ecs<WorldType>.Components<C2>.Value.Data();
            var data3 = Ecs<WorldType>.Components<C3>.Value.Data();
            var data4 = Ecs<WorldType>.Components<C4>.Value.Data();
            var data5 = Ecs<WorldType>.Components<C5>.Value.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                if (all.CheckEntity(entity) && with.CheckEntity(entity)) {
                    runner.Run(new Ecs<WorldType>.Entity(entity),
                               ref data1[di1[entity]],
                               ref data2[di2[entity]],
                               ref data3[di3[entity]],
                               ref data4[di4[entity]],
                               ref data5[di5[entity]]
                    );
                }
            }

            all.Dispose<WorldType>();
            with.Dispose<WorldType>();
        }

        [MethodImpl(AggressiveInlining)]
        public static void Run(DelegateQueryFunction<WorldType, C1, C2, C3, C4, C5> runner, P with) {
            var all = default(All<C1, C2, C3, C4, C5>);
            var count = Ecs<WorldType>.Components<C1>.Value.Count();
            var entities = Ecs<WorldType>.Components<C1>.Value.EntitiesData();
            all.SetData<WorldType>(ref count, ref entities);
            with.SetData<WorldType>(ref count, ref entities);

            var di1 = Ecs<WorldType>.Components<C1>.Value.GetDataIdxByEntityId();
            var di2 = Ecs<WorldType>.Components<C2>.Value.GetDataIdxByEntityId();
            var di3 = Ecs<WorldType>.Components<C3>.Value.GetDataIdxByEntityId();
            var di4 = Ecs<WorldType>.Components<C4>.Value.GetDataIdxByEntityId();
            var di5 = Ecs<WorldType>.Components<C5>.Value.GetDataIdxByEntityId();

            var data1 = Ecs<WorldType>.Components<C1>.Value.Data();
            var data2 = Ecs<WorldType>.Components<C2>.Value.Data();
            var data3 = Ecs<WorldType>.Components<C3>.Value.Data();
            var data4 = Ecs<WorldType>.Components<C4>.Value.Data();
            var data5 = Ecs<WorldType>.Components<C5>.Value.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                if (all.CheckEntity(entity) && with.CheckEntity(entity)) {
                    runner(new Ecs<WorldType>.Entity(entity),
                           ref data1[di1[entity]],
                           ref data2[di2[entity]],
                           ref data3[di3[entity]],
                           ref data4[di4[entity]],
                           ref data5[di5[entity]]
                    );
                }
            }

            all.Dispose<WorldType>();
            with.Dispose<WorldType>();
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly ref struct QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, P>
        where P : struct, IQueryMethod
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where C6 : struct, IComponent
        where WorldType : struct, IWorldType {
        [MethodImpl(AggressiveInlining)]
        public static void Run<R>(ref R runner, P with) where R : struct, Ecs<WorldType>.IQueryFunction<C1, C2, C3, C4, C5, C6> {
            var all = default(All<C1, C2, C3, C4, C5, C6>);
            var count = Ecs<WorldType>.Components<C1>.Value.Count();
            var entities = Ecs<WorldType>.Components<C1>.Value.EntitiesData();
            all.SetData<WorldType>(ref count, ref entities);
            with.SetData<WorldType>(ref count, ref entities);

            var di1 = Ecs<WorldType>.Components<C1>.Value.GetDataIdxByEntityId();
            var di2 = Ecs<WorldType>.Components<C2>.Value.GetDataIdxByEntityId();
            var di3 = Ecs<WorldType>.Components<C3>.Value.GetDataIdxByEntityId();
            var di4 = Ecs<WorldType>.Components<C4>.Value.GetDataIdxByEntityId();
            var di5 = Ecs<WorldType>.Components<C5>.Value.GetDataIdxByEntityId();
            var di6 = Ecs<WorldType>.Components<C6>.Value.GetDataIdxByEntityId();

            var data1 = Ecs<WorldType>.Components<C1>.Value.Data();
            var data2 = Ecs<WorldType>.Components<C2>.Value.Data();
            var data3 = Ecs<WorldType>.Components<C3>.Value.Data();
            var data4 = Ecs<WorldType>.Components<C4>.Value.Data();
            var data5 = Ecs<WorldType>.Components<C5>.Value.Data();
            var data6 = Ecs<WorldType>.Components<C6>.Value.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                if (all.CheckEntity(entity) && with.CheckEntity(entity)) {
                    runner.Run(new Ecs<WorldType>.Entity(entity),
                               ref data1[di1[entity]],
                               ref data2[di2[entity]],
                               ref data3[di3[entity]],
                               ref data4[di4[entity]],
                               ref data5[di5[entity]],
                               ref data6[di6[entity]]
                    );
                }
            }

            all.Dispose<WorldType>();
            with.Dispose<WorldType>();
        }

        [MethodImpl(AggressiveInlining)]
        public static void Run(DelegateQueryFunction<WorldType, C1, C2, C3, C4, C5, C6> runner, P with) {
            var all = default(All<C1, C2, C3, C4, C5, C6>);
            var count = Ecs<WorldType>.Components<C1>.Value.Count();
            var entities = Ecs<WorldType>.Components<C1>.Value.EntitiesData();
            all.SetData<WorldType>(ref count, ref entities);
            with.SetData<WorldType>(ref count, ref entities);

            var di1 = Ecs<WorldType>.Components<C1>.Value.GetDataIdxByEntityId();
            var di2 = Ecs<WorldType>.Components<C2>.Value.GetDataIdxByEntityId();
            var di3 = Ecs<WorldType>.Components<C3>.Value.GetDataIdxByEntityId();
            var di4 = Ecs<WorldType>.Components<C4>.Value.GetDataIdxByEntityId();
            var di5 = Ecs<WorldType>.Components<C5>.Value.GetDataIdxByEntityId();
            var di6 = Ecs<WorldType>.Components<C6>.Value.GetDataIdxByEntityId();

            var data1 = Ecs<WorldType>.Components<C1>.Value.Data();
            var data2 = Ecs<WorldType>.Components<C2>.Value.Data();
            var data3 = Ecs<WorldType>.Components<C3>.Value.Data();
            var data4 = Ecs<WorldType>.Components<C4>.Value.Data();
            var data5 = Ecs<WorldType>.Components<C5>.Value.Data();
            var data6 = Ecs<WorldType>.Components<C6>.Value.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                if (all.CheckEntity(entity) && with.CheckEntity(entity)) {
                    runner(new Ecs<WorldType>.Entity(entity),
                           ref data1[di1[entity]],
                           ref data2[di2[entity]],
                           ref data3[di3[entity]],
                           ref data4[di4[entity]],
                           ref data5[di5[entity]],
                           ref data6[di6[entity]]
                    );
                }
            }

            all.Dispose<WorldType>();
            with.Dispose<WorldType>();
        }
    }


    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly ref struct QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, C7, P>
        where P : struct, IQueryMethod
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where C6 : struct, IComponent
        where C7 : struct, IComponent
        where WorldType : struct, IWorldType {
        [MethodImpl(AggressiveInlining)]
        public static void Run<R>(ref R runner, P with) where R : struct, Ecs<WorldType>.IQueryFunction<C1, C2, C3, C4, C5, C6, C7> {
            var all = default(All<C1, C2, C3, C4, C5, C6, C7>);
            var count = Ecs<WorldType>.Components<C1>.Value.Count();
            var entities = Ecs<WorldType>.Components<C1>.Value.EntitiesData();
            all.SetData<WorldType>(ref count, ref entities);
            with.SetData<WorldType>(ref count, ref entities);

            var di1 = Ecs<WorldType>.Components<C1>.Value.GetDataIdxByEntityId();
            var di2 = Ecs<WorldType>.Components<C2>.Value.GetDataIdxByEntityId();
            var di3 = Ecs<WorldType>.Components<C3>.Value.GetDataIdxByEntityId();
            var di4 = Ecs<WorldType>.Components<C4>.Value.GetDataIdxByEntityId();
            var di5 = Ecs<WorldType>.Components<C5>.Value.GetDataIdxByEntityId();
            var di6 = Ecs<WorldType>.Components<C6>.Value.GetDataIdxByEntityId();
            var di7 = Ecs<WorldType>.Components<C7>.Value.GetDataIdxByEntityId();

            var data1 = Ecs<WorldType>.Components<C1>.Value.Data();
            var data2 = Ecs<WorldType>.Components<C2>.Value.Data();
            var data3 = Ecs<WorldType>.Components<C3>.Value.Data();
            var data4 = Ecs<WorldType>.Components<C4>.Value.Data();
            var data5 = Ecs<WorldType>.Components<C5>.Value.Data();
            var data6 = Ecs<WorldType>.Components<C6>.Value.Data();
            var data7 = Ecs<WorldType>.Components<C7>.Value.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                if (all.CheckEntity(entity) && with.CheckEntity(entity)) {
                    runner.Run(new Ecs<WorldType>.Entity(entity),
                               ref data1[di1[entity]],
                               ref data2[di2[entity]],
                               ref data3[di3[entity]],
                               ref data4[di4[entity]],
                               ref data5[di5[entity]],
                               ref data6[di6[entity]],
                               ref data7[di7[entity]]
                    );
                }
            }

            all.Dispose<WorldType>();
            with.Dispose<WorldType>();
        }

        [MethodImpl(AggressiveInlining)]
        public static void Run(DelegateQueryFunction<WorldType, C1, C2, C3, C4, C5, C6, C7> runner, P with) {
            var all = default(All<C1, C2, C3, C4, C5, C6, C7>);
            var count = Ecs<WorldType>.Components<C1>.Value.Count();
            var entities = Ecs<WorldType>.Components<C1>.Value.EntitiesData();
            all.SetData<WorldType>(ref count, ref entities);
            with.SetData<WorldType>(ref count, ref entities);

            var di1 = Ecs<WorldType>.Components<C1>.Value.GetDataIdxByEntityId();
            var di2 = Ecs<WorldType>.Components<C2>.Value.GetDataIdxByEntityId();
            var di3 = Ecs<WorldType>.Components<C3>.Value.GetDataIdxByEntityId();
            var di4 = Ecs<WorldType>.Components<C4>.Value.GetDataIdxByEntityId();
            var di5 = Ecs<WorldType>.Components<C5>.Value.GetDataIdxByEntityId();
            var di6 = Ecs<WorldType>.Components<C6>.Value.GetDataIdxByEntityId();
            var di7 = Ecs<WorldType>.Components<C7>.Value.GetDataIdxByEntityId();

            var data1 = Ecs<WorldType>.Components<C1>.Value.Data();
            var data2 = Ecs<WorldType>.Components<C2>.Value.Data();
            var data3 = Ecs<WorldType>.Components<C3>.Value.Data();
            var data4 = Ecs<WorldType>.Components<C4>.Value.Data();
            var data5 = Ecs<WorldType>.Components<C5>.Value.Data();
            var data6 = Ecs<WorldType>.Components<C6>.Value.Data();
            var data7 = Ecs<WorldType>.Components<C7>.Value.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                if (all.CheckEntity(entity) && with.CheckEntity(entity)) {
                    runner(new Ecs<WorldType>.Entity(entity),
                           ref data1[di1[entity]],
                           ref data2[di2[entity]],
                           ref data3[di3[entity]],
                           ref data4[di4[entity]],
                           ref data5[di5[entity]],
                           ref data6[di6[entity]],
                           ref data7[di7[entity]]
                    );
                }
            }

            all.Dispose<WorldType>();
            with.Dispose<WorldType>();
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly ref struct QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, C7, C8, P>
        where P : struct, IQueryMethod
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where C6 : struct, IComponent
        where C7 : struct, IComponent
        where C8 : struct, IComponent
        where WorldType : struct, IWorldType {

        [MethodImpl(AggressiveInlining)]
        public static void Run<R>(ref R runner, P with) where R : struct, Ecs<WorldType>.IQueryFunction<C1, C2, C3, C4, C5, C6, C7, C8> {
            var all = default(All<C1, C2, C3, C4, C5, C6, C7, C8>);
            var count = Ecs<WorldType>.Components<C1>.Value.Count();
            var entities = Ecs<WorldType>.Components<C1>.Value.EntitiesData();
            all.SetData<WorldType>(ref count, ref entities);
            with.SetData<WorldType>(ref count, ref entities);

            var di1 = Ecs<WorldType>.Components<C1>.Value.GetDataIdxByEntityId();
            var di2 = Ecs<WorldType>.Components<C2>.Value.GetDataIdxByEntityId();
            var di3 = Ecs<WorldType>.Components<C3>.Value.GetDataIdxByEntityId();
            var di4 = Ecs<WorldType>.Components<C4>.Value.GetDataIdxByEntityId();
            var di5 = Ecs<WorldType>.Components<C5>.Value.GetDataIdxByEntityId();
            var di6 = Ecs<WorldType>.Components<C6>.Value.GetDataIdxByEntityId();
            var di7 = Ecs<WorldType>.Components<C7>.Value.GetDataIdxByEntityId();
            var di8 = Ecs<WorldType>.Components<C8>.Value.GetDataIdxByEntityId();

            var data1 = Ecs<WorldType>.Components<C1>.Value.Data();
            var data2 = Ecs<WorldType>.Components<C2>.Value.Data();
            var data3 = Ecs<WorldType>.Components<C3>.Value.Data();
            var data4 = Ecs<WorldType>.Components<C4>.Value.Data();
            var data5 = Ecs<WorldType>.Components<C5>.Value.Data();
            var data6 = Ecs<WorldType>.Components<C6>.Value.Data();
            var data7 = Ecs<WorldType>.Components<C7>.Value.Data();
            var data8 = Ecs<WorldType>.Components<C8>.Value.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                if (all.CheckEntity(entity) && with.CheckEntity(entity)) {
                    runner.Run(new Ecs<WorldType>.Entity(entity),
                               ref data1[di1[entity]],
                               ref data2[di2[entity]],
                               ref data3[di3[entity]],
                               ref data4[di4[entity]],
                               ref data5[di5[entity]],
                               ref data6[di6[entity]],
                               ref data7[di7[entity]],
                               ref data8[di8[entity]]
                    );
                }
            }

            all.Dispose<WorldType>();
            with.Dispose<WorldType>();
        }

        [MethodImpl(AggressiveInlining)]
        public static void Run(DelegateQueryFunction<WorldType, C1, C2, C3, C4, C5, C6, C7, C8> runner, P with) {
            var all = default(All<C1, C2, C3, C4, C5, C6, C7, C8>);
            var count = Ecs<WorldType>.Components<C1>.Value.Count();
            var entities = Ecs<WorldType>.Components<C1>.Value.EntitiesData();
            all.SetData<WorldType>(ref count, ref entities);
            with.SetData<WorldType>(ref count, ref entities);

            var di1 = Ecs<WorldType>.Components<C1>.Value.GetDataIdxByEntityId();
            var di2 = Ecs<WorldType>.Components<C2>.Value.GetDataIdxByEntityId();
            var di3 = Ecs<WorldType>.Components<C3>.Value.GetDataIdxByEntityId();
            var di4 = Ecs<WorldType>.Components<C4>.Value.GetDataIdxByEntityId();
            var di5 = Ecs<WorldType>.Components<C5>.Value.GetDataIdxByEntityId();
            var di6 = Ecs<WorldType>.Components<C6>.Value.GetDataIdxByEntityId();
            var di7 = Ecs<WorldType>.Components<C7>.Value.GetDataIdxByEntityId();
            var di8 = Ecs<WorldType>.Components<C8>.Value.GetDataIdxByEntityId();

            var data1 = Ecs<WorldType>.Components<C1>.Value.Data();
            var data2 = Ecs<WorldType>.Components<C2>.Value.Data();
            var data3 = Ecs<WorldType>.Components<C3>.Value.Data();
            var data4 = Ecs<WorldType>.Components<C4>.Value.Data();
            var data5 = Ecs<WorldType>.Components<C5>.Value.Data();
            var data6 = Ecs<WorldType>.Components<C6>.Value.Data();
            var data7 = Ecs<WorldType>.Components<C7>.Value.Data();
            var data8 = Ecs<WorldType>.Components<C8>.Value.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                if (all.CheckEntity(entity) && with.CheckEntity(entity)) {
                    runner(new Ecs<WorldType>.Entity(entity),
                           ref data1[di1[entity]],
                           ref data2[di2[entity]],
                           ref data3[di3[entity]],
                           ref data4[di4[entity]],
                           ref data5[di5[entity]],
                           ref data6[di6[entity]],
                           ref data7[di7[entity]],
                           ref data8[di8[entity]]
                    );
                }
            }

            all.Dispose<WorldType>();
            with.Dispose<WorldType>();
        }
    }
    #endregion
}