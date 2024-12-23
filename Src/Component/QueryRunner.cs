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
    public delegate void DelegateQueryFunction<WorldID, C1>(Ecs<WorldID>.Entity entity, ref C1 c1)
        where C1 : struct, IComponent
        where WorldID : struct, IWorldId;

    public delegate void DelegateQueryFunction<WorldID, C1, C2>(Ecs<WorldID>.Entity entity, ref C1 c1, ref C2 c2)
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where WorldID : struct, IWorldId;

    public delegate void DelegateQueryFunction<WorldID, C1, C2, C3>(Ecs<WorldID>.Entity entity, ref C1 c1, ref C2 c2, ref C3 c3)
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where WorldID : struct, IWorldId;

    public delegate void DelegateQueryFunction<WorldID, C1, C2, C3, C4>(Ecs<WorldID>.Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4)
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where WorldID : struct, IWorldId;

    public delegate void DelegateQueryFunction<WorldID, C1, C2, C3, C4, C5>(Ecs<WorldID>.Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5)
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where WorldID : struct, IWorldId;

    public delegate void DelegateQueryFunction<WorldID, C1, C2, C3, C4, C5, C6>(Ecs<WorldID>.Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6)
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where C6 : struct, IComponent
        where WorldID : struct, IWorldId;

    public delegate void DelegateQueryFunction<WorldID, C1, C2, C3, C4, C5, C6, C7>(Ecs<WorldID>.Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7)
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where C6 : struct, IComponent
        where C7 : struct, IComponent
        where WorldID : struct, IWorldId;

    public delegate void DelegateQueryFunction<WorldID, C1, C2, C3, C4, C5, C6, C7, C8>(
        Ecs<WorldID>.Entity entity, ref C1 c1, ref C2 c2, ref C3 c3, ref C4 c4, ref C5 c5, ref C6 c6, ref C7 c7, ref C8 c8
    )
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where C6 : struct, IComponent
        where C7 : struct, IComponent
        where C8 : struct, IComponent
        where WorldID : struct, IWorldId;
    #endregion

    #region QUERY_FUNCTION_RUNNER
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly ref struct QueryFunctionRunner<WorldID, C1, P>
        where P : struct, IQueryMethod
        where C1 : struct, IComponent
        where WorldID : struct, IWorldId {
        [MethodImpl(AggressiveInlining)]
        public void Run<R>(ref R runner, P with) where R : struct, Ecs<WorldID>.IQueryFunction<C1> {
            var count = Init(out var entities, ref with, out var dataC1);
            while (count > 0) {
                count--;
                var entity = entities[count];
                if (with.CheckEntity(entity._id)) {
                    runner.Run(entity, ref dataC1[count]);
                }
            }

            with.Dispose<WorldID>();
        }

        [MethodImpl(AggressiveInlining)]
        public void Run(DelegateQueryFunction<WorldID, C1> runner, P with) {
            var count = Init(out var entities, ref with, out var dataC1);
            while (count > 0) {
                count--;
                var entity = entities[count];
                if (with.CheckEntity(entity._id)) {
                    runner(entity, ref dataC1[count]);
                }
            }

            with.Dispose<WorldID>();
        }

        [MethodImpl(AggressiveInlining)]
        private static int Init(out Ecs<WorldID>.Entity[] entities, ref P with, out C1[] dataC1) {
            var count = Ecs<WorldID>.Components<C1>.Count();
            entities = Ecs<WorldID>.Components<C1>.EntitiesData();
            with.SetData(ref count, ref entities);

            dataC1 = Ecs<WorldID>.Components<C1>.Data();
            return count;
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public static class QueryFunctionRunner<WorldID, C1, C2, P>
        where P : struct, IQueryMethod
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where WorldID : struct, IWorldId {
        [MethodImpl(AggressiveInlining)]
        public static void Run<R>(ref R runner, P with) where R : struct, Ecs<WorldID>.IQueryFunction<C1, C2> {
            var all = default(Double<C1, C2>);
            var count = Ecs<WorldID>.Components<C1>.Count();
            var entities = Ecs<WorldID>.Components<C1>.EntitiesData();
            all.SetData(ref count, ref entities);
            with.SetData(ref count, ref entities);

            var di1 = Ecs<WorldID>.Components<C1>.GetDataIdxByEntityId();
            var di2 = Ecs<WorldID>.Components<C2>.GetDataIdxByEntityId();

            var data1 = Ecs<WorldID>.Components<C1>.Data();
            var data2 = Ecs<WorldID>.Components<C2>.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var id = entity._id;
                if (all.CheckEntity(id) && with.CheckEntity(id)) {
                    runner.Run(entity,
                               ref data1[di1[id] - 1],
                               ref data2[di2[id] - 1]
                    );
                }
            }

            all.Dispose<WorldID>();
            with.Dispose<WorldID>();
        }

        [MethodImpl(AggressiveInlining)]
        public static void Run(DelegateQueryFunction<WorldID, C1, C2> runner, P with) {
            var all = default(Double<C1, C2>);
            var count = Ecs<WorldID>.Components<C1>.Count();
            var entities = Ecs<WorldID>.Components<C1>.EntitiesData();
            all.SetData(ref count, ref entities);
            with.SetData(ref count, ref entities);

            var di1 = Ecs<WorldID>.Components<C1>.GetDataIdxByEntityId();
            var di2 = Ecs<WorldID>.Components<C2>.GetDataIdxByEntityId();

            var data1 = Ecs<WorldID>.Components<C1>.Data();
            var data2 = Ecs<WorldID>.Components<C2>.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var id = entity._id;
                if (all.CheckEntity(id) && with.CheckEntity(id)) {
                    runner(entity,
                           ref data1[di1[id] - 1],
                           ref data2[di2[id] - 1]
                    );
                }
            }

            all.Dispose<WorldID>();
            with.Dispose<WorldID>();
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public static class QueryFunctionRunner<WorldID, C1, C2, C3, P>
        where P : struct, IQueryMethod
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where WorldID : struct, IWorldId {
        [MethodImpl(AggressiveInlining)]
        public static void Run<R>(ref R runner, P with) where R : struct, Ecs<WorldID>.IQueryFunction<C1, C2, C3> {
            var all = default(All<Types<C1, C2, C3>>);
            var count = Ecs<WorldID>.Components<C1>.Count();
            var entities = Ecs<WorldID>.Components<C1>.EntitiesData();
            all.SetData(ref count, ref entities);
            with.SetData(ref count, ref entities);

            var di1 = Ecs<WorldID>.Components<C1>.GetDataIdxByEntityId();
            var di2 = Ecs<WorldID>.Components<C2>.GetDataIdxByEntityId();
            var di3 = Ecs<WorldID>.Components<C3>.GetDataIdxByEntityId();

            var data1 = Ecs<WorldID>.Components<C1>.Data();
            var data2 = Ecs<WorldID>.Components<C2>.Data();
            var data3 = Ecs<WorldID>.Components<C3>.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var id = entity._id;
                if (all.CheckEntity(id) && with.CheckEntity(id)) {
                    runner.Run(entity,
                               ref data1[di1[id] - 1],
                               ref data2[di2[id] - 1],
                               ref data3[di3[id] - 1]
                    );
                }
            }

            all.Dispose<WorldID>();
            with.Dispose<WorldID>();
        }

        [MethodImpl(AggressiveInlining)]
        public static void Run(DelegateQueryFunction<WorldID, C1, C2, C3> runner, P with) {
            var all = default(All<Types<C1, C2, C3>>);
            var count = Ecs<WorldID>.Components<C1>.Count();
            var entities = Ecs<WorldID>.Components<C1>.EntitiesData();
            all.SetData(ref count, ref entities);
            with.SetData(ref count, ref entities);

            var di1 = Ecs<WorldID>.Components<C1>.GetDataIdxByEntityId();
            var di2 = Ecs<WorldID>.Components<C2>.GetDataIdxByEntityId();
            var di3 = Ecs<WorldID>.Components<C3>.GetDataIdxByEntityId();

            var data1 = Ecs<WorldID>.Components<C1>.Data();
            var data2 = Ecs<WorldID>.Components<C2>.Data();
            var data3 = Ecs<WorldID>.Components<C3>.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var id = entity._id;
                if (all.CheckEntity(id) && with.CheckEntity(id)) {
                    runner(entity,
                           ref data1[di1[id] - 1],
                           ref data2[di2[id] - 1],
                           ref data3[di3[id] - 1]
                    );
                }
            }

            all.Dispose<WorldID>();
            with.Dispose<WorldID>();
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public static class QueryFunctionRunner<WorldID, C1, C2, C3, C4, P>
        where P : struct, IQueryMethod
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where WorldID : struct, IWorldId {
        [MethodImpl(AggressiveInlining)]
        public static void Run<R>(ref R runner, P with) where R : struct, Ecs<WorldID>.IQueryFunction<C1, C2, C3, C4> {
            var all = default(All<Types<C1, C2, C3, C4>>);
            var count = Ecs<WorldID>.Components<C1>.Count();
            var entities = Ecs<WorldID>.Components<C1>.EntitiesData();
            all.SetData(ref count, ref entities);
            with.SetData(ref count, ref entities);

            var di1 = Ecs<WorldID>.Components<C1>.GetDataIdxByEntityId();
            var di2 = Ecs<WorldID>.Components<C2>.GetDataIdxByEntityId();
            var di3 = Ecs<WorldID>.Components<C3>.GetDataIdxByEntityId();
            var di4 = Ecs<WorldID>.Components<C4>.GetDataIdxByEntityId();

            var data1 = Ecs<WorldID>.Components<C1>.Data();
            var data2 = Ecs<WorldID>.Components<C2>.Data();
            var data3 = Ecs<WorldID>.Components<C3>.Data();
            var data4 = Ecs<WorldID>.Components<C4>.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var id = entity._id;
                if (all.CheckEntity(id) && with.CheckEntity(id)) {
                    runner.Run(entity,
                               ref data1[di1[id] - 1],
                               ref data2[di2[id] - 1],
                               ref data3[di3[id] - 1],
                               ref data4[di4[id] - 1]
                    );
                }
            }

            all.Dispose<WorldID>();
            with.Dispose<WorldID>();
        }

        [MethodImpl(AggressiveInlining)]
        public static void Run(DelegateQueryFunction<WorldID, C1, C2, C3, C4> runner, P with) {
            var all = default(All<Types<C1, C2, C3, C4>>);
            var count = Ecs<WorldID>.Components<C1>.Count();
            var entities = Ecs<WorldID>.Components<C1>.EntitiesData();
            all.SetData(ref count, ref entities);
            with.SetData(ref count, ref entities);

            var di1 = Ecs<WorldID>.Components<C1>.GetDataIdxByEntityId();
            var di2 = Ecs<WorldID>.Components<C2>.GetDataIdxByEntityId();
            var di3 = Ecs<WorldID>.Components<C3>.GetDataIdxByEntityId();
            var di4 = Ecs<WorldID>.Components<C4>.GetDataIdxByEntityId();

            var data1 = Ecs<WorldID>.Components<C1>.Data();
            var data2 = Ecs<WorldID>.Components<C2>.Data();
            var data3 = Ecs<WorldID>.Components<C3>.Data();
            var data4 = Ecs<WorldID>.Components<C4>.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var id = entity._id;
                if (all.CheckEntity(id) && with.CheckEntity(id)) {
                    runner(entity,
                           ref data1[di1[id] - 1],
                           ref data2[di2[id] - 1],
                           ref data3[di3[id] - 1],
                           ref data4[di4[id] - 1]
                    );
                }
            }

            all.Dispose<WorldID>();
            with.Dispose<WorldID>();
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public static class QueryFunctionRunner<WorldID, C1, C2, C3, C4, C5, P>
        where P : struct, IQueryMethod
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where WorldID : struct, IWorldId {
        [MethodImpl(AggressiveInlining)]
        public static void Run<R>(ref R runner, P with) where R : struct, Ecs<WorldID>.IQueryFunction<C1, C2, C3, C4, C5> {
            var all = default(All<Types<C1, C2, C3, C4, C5>>);
            var count = Ecs<WorldID>.Components<C1>.Count();
            var entities = Ecs<WorldID>.Components<C1>.EntitiesData();
            all.SetData(ref count, ref entities);
            with.SetData(ref count, ref entities);

            var di1 = Ecs<WorldID>.Components<C1>.GetDataIdxByEntityId();
            var di2 = Ecs<WorldID>.Components<C2>.GetDataIdxByEntityId();
            var di3 = Ecs<WorldID>.Components<C3>.GetDataIdxByEntityId();
            var di4 = Ecs<WorldID>.Components<C4>.GetDataIdxByEntityId();
            var di5 = Ecs<WorldID>.Components<C5>.GetDataIdxByEntityId();

            var data1 = Ecs<WorldID>.Components<C1>.Data();
            var data2 = Ecs<WorldID>.Components<C2>.Data();
            var data3 = Ecs<WorldID>.Components<C3>.Data();
            var data4 = Ecs<WorldID>.Components<C4>.Data();
            var data5 = Ecs<WorldID>.Components<C5>.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var id = entity._id;
                if (all.CheckEntity(id) && with.CheckEntity(id)) {
                    runner.Run(entity,
                               ref data1[di1[id] - 1],
                               ref data2[di2[id] - 1],
                               ref data3[di3[id] - 1],
                               ref data4[di4[id] - 1],
                               ref data5[di5[id] - 1]
                    );
                }
            }

            all.Dispose<WorldID>();
            with.Dispose<WorldID>();
        }

        [MethodImpl(AggressiveInlining)]
        public static void Run(DelegateQueryFunction<WorldID, C1, C2, C3, C4, C5> runner, P with) {
            var all = default(All<Types<C1, C2, C3, C4, C5>>);
            var count = Ecs<WorldID>.Components<C1>.Count();
            var entities = Ecs<WorldID>.Components<C1>.EntitiesData();
            all.SetData(ref count, ref entities);
            with.SetData(ref count, ref entities);

            var di1 = Ecs<WorldID>.Components<C1>.GetDataIdxByEntityId();
            var di2 = Ecs<WorldID>.Components<C2>.GetDataIdxByEntityId();
            var di3 = Ecs<WorldID>.Components<C3>.GetDataIdxByEntityId();
            var di4 = Ecs<WorldID>.Components<C4>.GetDataIdxByEntityId();
            var di5 = Ecs<WorldID>.Components<C5>.GetDataIdxByEntityId();

            var data1 = Ecs<WorldID>.Components<C1>.Data();
            var data2 = Ecs<WorldID>.Components<C2>.Data();
            var data3 = Ecs<WorldID>.Components<C3>.Data();
            var data4 = Ecs<WorldID>.Components<C4>.Data();
            var data5 = Ecs<WorldID>.Components<C5>.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var id = entity._id;
                if (all.CheckEntity(id) && with.CheckEntity(id)) {
                    runner(entity,
                           ref data1[di1[id] - 1],
                           ref data2[di2[id] - 1],
                           ref data3[di3[id] - 1],
                           ref data4[di4[id] - 1],
                           ref data5[di5[id] - 1]
                    );
                }
            }

            all.Dispose<WorldID>();
            with.Dispose<WorldID>();
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public static class QueryFunctionRunner<WorldID, C1, C2, C3, C4, C5, C6, P>
        where P : struct, IQueryMethod
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where C6 : struct, IComponent
        where WorldID : struct, IWorldId {
        [MethodImpl(AggressiveInlining)]
        public static void Run<R>(ref R runner, P with) where R : struct, Ecs<WorldID>.IQueryFunction<C1, C2, C3, C4, C5, C6> {
            var all = default(All<Types<C1, C2, C3, C4, C5, C6>>);
            var count = Ecs<WorldID>.Components<C1>.Count();
            var entities = Ecs<WorldID>.Components<C1>.EntitiesData();
            all.SetData(ref count, ref entities);
            with.SetData(ref count, ref entities);

            var di1 = Ecs<WorldID>.Components<C1>.GetDataIdxByEntityId();
            var di2 = Ecs<WorldID>.Components<C2>.GetDataIdxByEntityId();
            var di3 = Ecs<WorldID>.Components<C3>.GetDataIdxByEntityId();
            var di4 = Ecs<WorldID>.Components<C4>.GetDataIdxByEntityId();
            var di5 = Ecs<WorldID>.Components<C5>.GetDataIdxByEntityId();
            var di6 = Ecs<WorldID>.Components<C6>.GetDataIdxByEntityId();

            var data1 = Ecs<WorldID>.Components<C1>.Data();
            var data2 = Ecs<WorldID>.Components<C2>.Data();
            var data3 = Ecs<WorldID>.Components<C3>.Data();
            var data4 = Ecs<WorldID>.Components<C4>.Data();
            var data5 = Ecs<WorldID>.Components<C5>.Data();
            var data6 = Ecs<WorldID>.Components<C6>.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var id = entity._id;
                if (all.CheckEntity(id) && with.CheckEntity(id)) {
                    runner.Run(entity,
                               ref data1[di1[id] - 1],
                               ref data2[di2[id] - 1],
                               ref data3[di3[id] - 1],
                               ref data4[di4[id] - 1],
                               ref data5[di5[id] - 1],
                               ref data6[di6[id] - 1]
                    );
                }
            }

            all.Dispose<WorldID>();
            with.Dispose<WorldID>();
        }

        [MethodImpl(AggressiveInlining)]
        public static void Run(DelegateQueryFunction<WorldID, C1, C2, C3, C4, C5, C6> runner, P with) {
            var all = default(All<Types<C1, C2, C3, C4, C5, C6>>);
            var count = Ecs<WorldID>.Components<C1>.Count();
            var entities = Ecs<WorldID>.Components<C1>.EntitiesData();
            all.SetData(ref count, ref entities);
            with.SetData(ref count, ref entities);

            var di1 = Ecs<WorldID>.Components<C1>.GetDataIdxByEntityId();
            var di2 = Ecs<WorldID>.Components<C2>.GetDataIdxByEntityId();
            var di3 = Ecs<WorldID>.Components<C3>.GetDataIdxByEntityId();
            var di4 = Ecs<WorldID>.Components<C4>.GetDataIdxByEntityId();
            var di5 = Ecs<WorldID>.Components<C5>.GetDataIdxByEntityId();
            var di6 = Ecs<WorldID>.Components<C6>.GetDataIdxByEntityId();

            var data1 = Ecs<WorldID>.Components<C1>.Data();
            var data2 = Ecs<WorldID>.Components<C2>.Data();
            var data3 = Ecs<WorldID>.Components<C3>.Data();
            var data4 = Ecs<WorldID>.Components<C4>.Data();
            var data5 = Ecs<WorldID>.Components<C5>.Data();
            var data6 = Ecs<WorldID>.Components<C6>.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var id = entity._id;
                if (all.CheckEntity(id) && with.CheckEntity(id)) {
                    runner(entity,
                           ref data1[di1[id] - 1],
                           ref data2[di2[id] - 1],
                           ref data3[di3[id] - 1],
                           ref data4[di4[id] - 1],
                           ref data5[di5[id] - 1],
                           ref data6[di6[id] - 1]
                    );
                }
            }

            all.Dispose<WorldID>();
            with.Dispose<WorldID>();
        }
    }


    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public static class QueryFunctionRunner<WorldID, C1, C2, C3, C4, C5, C6, C7, P>
        where P : struct, IQueryMethod
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where C6 : struct, IComponent
        where C7 : struct, IComponent
        where WorldID : struct, IWorldId {
        [MethodImpl(AggressiveInlining)]
        public static void Run<R>(ref R runner, P with) where R : struct, Ecs<WorldID>.IQueryFunction<C1, C2, C3, C4, C5, C6, C7> {
            var all = default(All<Types<C1, C2, C3, C4, C5, C6, C7>>);
            var count = Ecs<WorldID>.Components<C1>.Count();
            var entities = Ecs<WorldID>.Components<C1>.EntitiesData();
            all.SetData(ref count, ref entities);
            with.SetData(ref count, ref entities);

            var di1 = Ecs<WorldID>.Components<C1>.GetDataIdxByEntityId();
            var di2 = Ecs<WorldID>.Components<C2>.GetDataIdxByEntityId();
            var di3 = Ecs<WorldID>.Components<C3>.GetDataIdxByEntityId();
            var di4 = Ecs<WorldID>.Components<C4>.GetDataIdxByEntityId();
            var di5 = Ecs<WorldID>.Components<C5>.GetDataIdxByEntityId();
            var di6 = Ecs<WorldID>.Components<C6>.GetDataIdxByEntityId();
            var di7 = Ecs<WorldID>.Components<C7>.GetDataIdxByEntityId();

            var data1 = Ecs<WorldID>.Components<C1>.Data();
            var data2 = Ecs<WorldID>.Components<C2>.Data();
            var data3 = Ecs<WorldID>.Components<C3>.Data();
            var data4 = Ecs<WorldID>.Components<C4>.Data();
            var data5 = Ecs<WorldID>.Components<C5>.Data();
            var data6 = Ecs<WorldID>.Components<C6>.Data();
            var data7 = Ecs<WorldID>.Components<C7>.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var id = entity._id;
                if (all.CheckEntity(id) && with.CheckEntity(id)) {
                    runner.Run(entity,
                               ref data1[di1[id] - 1],
                               ref data2[di2[id] - 1],
                               ref data3[di3[id] - 1],
                               ref data4[di4[id] - 1],
                               ref data5[di5[id] - 1],
                               ref data6[di6[id] - 1],
                               ref data7[di7[id] - 1]
                    );
                }
            }

            all.Dispose<WorldID>();
            with.Dispose<WorldID>();
        }

        [MethodImpl(AggressiveInlining)]
        public static void Run(DelegateQueryFunction<WorldID, C1, C2, C3, C4, C5, C6, C7> runner, P with) {
            var all = default(All<Types<C1, C2, C3, C4, C5, C6, C7>>);
            var count = Ecs<WorldID>.Components<C1>.Count();
            var entities = Ecs<WorldID>.Components<C1>.EntitiesData();
            all.SetData(ref count, ref entities);
            with.SetData(ref count, ref entities);

            var di1 = Ecs<WorldID>.Components<C1>.GetDataIdxByEntityId();
            var di2 = Ecs<WorldID>.Components<C2>.GetDataIdxByEntityId();
            var di3 = Ecs<WorldID>.Components<C3>.GetDataIdxByEntityId();
            var di4 = Ecs<WorldID>.Components<C4>.GetDataIdxByEntityId();
            var di5 = Ecs<WorldID>.Components<C5>.GetDataIdxByEntityId();
            var di6 = Ecs<WorldID>.Components<C6>.GetDataIdxByEntityId();
            var di7 = Ecs<WorldID>.Components<C7>.GetDataIdxByEntityId();

            var data1 = Ecs<WorldID>.Components<C1>.Data();
            var data2 = Ecs<WorldID>.Components<C2>.Data();
            var data3 = Ecs<WorldID>.Components<C3>.Data();
            var data4 = Ecs<WorldID>.Components<C4>.Data();
            var data5 = Ecs<WorldID>.Components<C5>.Data();
            var data6 = Ecs<WorldID>.Components<C6>.Data();
            var data7 = Ecs<WorldID>.Components<C7>.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var id = entity._id;
                if (all.CheckEntity(id) && with.CheckEntity(id)) {
                    runner(entity,
                           ref data1[di1[id] - 1],
                           ref data2[di2[id] - 1],
                           ref data3[di3[id] - 1],
                           ref data4[di4[id] - 1],
                           ref data5[di5[id] - 1],
                           ref data6[di6[id] - 1],
                           ref data7[di7[id] - 1]
                    );
                }
            }

            all.Dispose<WorldID>();
            with.Dispose<WorldID>();
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public static class QueryFunctionRunner<WorldID, C1, C2, C3, C4, C5, C6, C7, C8, P>
        where P : struct, IQueryMethod
        where C1 : struct, IComponent
        where C2 : struct, IComponent
        where C3 : struct, IComponent
        where C4 : struct, IComponent
        where C5 : struct, IComponent
        where C6 : struct, IComponent
        where C7 : struct, IComponent
        where C8 : struct, IComponent
        where WorldID : struct, IWorldId {
        [MethodImpl(AggressiveInlining)]
        public static void Run<R>(ref R runner, P with) where R : struct, Ecs<WorldID>.IQueryFunction<C1, C2, C3, C4, C5, C6, C7, C8> {
            var all = default(All<Types<C1, C2, C3, C4, C5, C6, C7, C8>>);
            var count = Ecs<WorldID>.Components<C1>.Count();
            var entities = Ecs<WorldID>.Components<C1>.EntitiesData();
            all.SetData(ref count, ref entities);
            with.SetData(ref count, ref entities);

            var di1 = Ecs<WorldID>.Components<C1>.GetDataIdxByEntityId();
            var di2 = Ecs<WorldID>.Components<C2>.GetDataIdxByEntityId();
            var di3 = Ecs<WorldID>.Components<C3>.GetDataIdxByEntityId();
            var di4 = Ecs<WorldID>.Components<C4>.GetDataIdxByEntityId();
            var di5 = Ecs<WorldID>.Components<C5>.GetDataIdxByEntityId();
            var di6 = Ecs<WorldID>.Components<C6>.GetDataIdxByEntityId();
            var di7 = Ecs<WorldID>.Components<C7>.GetDataIdxByEntityId();
            var di8 = Ecs<WorldID>.Components<C8>.GetDataIdxByEntityId();

            var data1 = Ecs<WorldID>.Components<C1>.Data();
            var data2 = Ecs<WorldID>.Components<C2>.Data();
            var data3 = Ecs<WorldID>.Components<C3>.Data();
            var data4 = Ecs<WorldID>.Components<C4>.Data();
            var data5 = Ecs<WorldID>.Components<C5>.Data();
            var data6 = Ecs<WorldID>.Components<C6>.Data();
            var data7 = Ecs<WorldID>.Components<C7>.Data();
            var data8 = Ecs<WorldID>.Components<C8>.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var id = entity._id;
                if (all.CheckEntity(id) && with.CheckEntity(id)) {
                    runner.Run(entity,
                               ref data1[di1[id] - 1],
                               ref data2[di2[id] - 1],
                               ref data3[di3[id] - 1],
                               ref data4[di4[id] - 1],
                               ref data5[di5[id] - 1],
                               ref data6[di6[id] - 1],
                               ref data7[di7[id] - 1],
                               ref data8[di8[id] - 1]
                    );
                }
            }

            all.Dispose<WorldID>();
            with.Dispose<WorldID>();
        }

        [MethodImpl(AggressiveInlining)]
        public static void Run(DelegateQueryFunction<WorldID, C1, C2, C3, C4, C5, C6, C7, C8> runner, P with) {
            var all = default(All<Types<C1, C2, C3, C4, C5, C6, C7, C8>>);
            var count = Ecs<WorldID>.Components<C1>.Count();
            var entities = Ecs<WorldID>.Components<C1>.EntitiesData();
            all.SetData(ref count, ref entities);
            with.SetData(ref count, ref entities);

            var di1 = Ecs<WorldID>.Components<C1>.GetDataIdxByEntityId();
            var di2 = Ecs<WorldID>.Components<C2>.GetDataIdxByEntityId();
            var di3 = Ecs<WorldID>.Components<C3>.GetDataIdxByEntityId();
            var di4 = Ecs<WorldID>.Components<C4>.GetDataIdxByEntityId();
            var di5 = Ecs<WorldID>.Components<C5>.GetDataIdxByEntityId();
            var di6 = Ecs<WorldID>.Components<C6>.GetDataIdxByEntityId();
            var di7 = Ecs<WorldID>.Components<C7>.GetDataIdxByEntityId();
            var di8 = Ecs<WorldID>.Components<C8>.GetDataIdxByEntityId();

            var data1 = Ecs<WorldID>.Components<C1>.Data();
            var data2 = Ecs<WorldID>.Components<C2>.Data();
            var data3 = Ecs<WorldID>.Components<C3>.Data();
            var data4 = Ecs<WorldID>.Components<C4>.Data();
            var data5 = Ecs<WorldID>.Components<C5>.Data();
            var data6 = Ecs<WorldID>.Components<C6>.Data();
            var data7 = Ecs<WorldID>.Components<C7>.Data();
            var data8 = Ecs<WorldID>.Components<C8>.Data();

            while (count > 0) {
                count--;
                var entity = entities[count];
                var id = entity._id;
                if (all.CheckEntity(id) && with.CheckEntity(id)) {
                    runner(entity,
                           ref data1[di1[id] - 1],
                           ref data2[di2[id] - 1],
                           ref data3[di3[id] - 1],
                           ref data4[di4[id] - 1],
                           ref data5[di5[id] - 1],
                           ref data6[di6[id] - 1],
                           ref data7[di7[id] - 1],
                           ref data8[di8[id] - 1]
                    );
                }
            }

            all.Dispose<WorldID>();
            with.Dispose<WorldID>();
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    internal static class QueryFunctionRunner { }
    #endregion
}