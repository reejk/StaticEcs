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
        public abstract partial class World {
            #if ENABLE_IL2CPP
            [Il2CppSetOption(Option.NullChecks, false)]
            [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
            #endif
            public abstract partial class QueryEntities {
                [MethodImpl(AggressiveInlining)]
                public static QueryEntitiesIterator<WorldID, W> With<W>(W with = default)
                    where W : struct, IQueryWith {
                    return new QueryEntitiesIterator<WorldID, W>(with);
                }
                
                [MethodImpl(AggressiveInlining)]
                public static QueryEntitiesIterator<WorldID, With<Single<C1>>> All<C1>()
                    where C1 : struct, IComponent {
                    return new QueryEntitiesIterator<WorldID, With<Single<C1>>>(default);
                }
                
                [MethodImpl(AggressiveInlining)]
                public static QueryEntitiesIterator<WorldID, With<Double<C1, C2>>> All<C1, C2>()
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent {
                    return new QueryEntitiesIterator<WorldID, With<Double<C1, C2>>>(default);
                }
                
                [MethodImpl(AggressiveInlining)]
                public static QueryEntitiesIterator<WorldID, With<All<Types<C1, C2, C3>>>> All<C1, C2, C3>()
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent {
                    return new QueryEntitiesIterator<WorldID, With<All<Types<C1, C2, C3>>>>(default);
                }
                
                [MethodImpl(AggressiveInlining)]
                public static QueryEntitiesIterator<WorldID, With<All<Types<C1, C2, C3, C4>>>> All<C1, C2, C3, C4>()
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent {
                    return new QueryEntitiesIterator<WorldID, With<All<Types<C1, C2, C3, C4>>>>(default);
                }
                
                [MethodImpl(AggressiveInlining)]
                public static QueryEntitiesIterator<WorldID, With<All<Types<C1, C2, C3, C4, C5>>>> All<C1, C2, C3, C4, C5>()
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent
                    where C5 : struct, IComponent {
                    return new QueryEntitiesIterator<WorldID, With<All<Types<C1, C2, C3, C4, C5>>>>(default);
                }
                
                [MethodImpl(AggressiveInlining)]
                public static QueryEntitiesIterator<WorldID, With<All<Types<C1, C2, C3, C4, C5, C6>>>> All<C1, C2, C3, C4, C5, C6>()
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent
                    where C5 : struct, IComponent
                    where C6 : struct, IComponent {
                    return new QueryEntitiesIterator<WorldID, With<All<Types<C1, C2, C3, C4, C5, C6>>>>(default);
                }
                
                [MethodImpl(AggressiveInlining)]
                public static QueryEntitiesIterator<WorldID, With<All<Types<C1, C2, C3, C4, C5, C6, C7>>>> All<C1, C2, C3, C4, C5, C6, C7>()
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent
                    where C5 : struct, IComponent
                    where C6 : struct, IComponent
                    where C7 : struct, IComponent {
                    return new QueryEntitiesIterator<WorldID, With<All<Types<C1, C2, C3, C4, C5, C6, C7>>>>(default);
                }
                
                [MethodImpl(AggressiveInlining)]
                public static QueryEntitiesIterator<WorldID, With<All<Types<C1, C2, C3, C4, C5, C6, C7, C8>>>> All<C1, C2, C3, C4, C5, C6, C7, C8>()
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent
                    where C5 : struct, IComponent
                    where C6 : struct, IComponent
                    where C7 : struct, IComponent
                    where C8 : struct, IComponent {
                    return new QueryEntitiesIterator<WorldID, With<All<Types<C1, C2, C3, C4, C5, C6, C7, C8>>>>(default);
                }

                [MethodImpl(AggressiveInlining)]
                public static QueryEntitiesIterator<WorldID, With<QM1>> For<QM1>(QM1 qm1 = default)
                    where QM1 : struct, IQueryMethod, IPrimaryQueryMethod {
                    return new QueryEntitiesIterator<WorldID, With<QM1>>(new With<QM1>(qm1));
                }

                [MethodImpl(AggressiveInlining)]
                public static QueryEntitiesIterator<WorldID, With<QM1, QM2>> For<QM1, QM2>(QM1 qm1 = default, QM2 qm2 = default)
                    where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
                    where QM2 : struct, IQueryMethod {
                    return new QueryEntitiesIterator<WorldID, With<QM1, QM2>>(new With<QM1, QM2>(qm1, qm2));
                }

                [MethodImpl(AggressiveInlining)]
                public static QueryEntitiesIterator<WorldID, With<QM1, QM2, QM3>> For<QM1, QM2, QM3>(
                    QM1 qm1 = default, QM2 qm2 = default, QM3 qm3 = default
                )
                    where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
                    where QM2 : struct, IQueryMethod
                    where QM3 : struct, IQueryMethod {
                    return new QueryEntitiesIterator<WorldID, With<QM1, QM2, QM3>>(new With<QM1, QM2, QM3>(qm1, qm2, qm3));
                }

                [MethodImpl(AggressiveInlining)]
                public static QueryEntitiesIterator<WorldID, With<QM1, QM2, QM3, QM4>> For<QM1, QM2, QM3, QM4>(
                    QM1 qm1 = default, QM2 qm2 = default, QM3 qm3 = default, QM4 qm4 = default
                )
                    where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
                    where QM2 : struct, IQueryMethod
                    where QM3 : struct, IQueryMethod
                    where QM4 : struct, IQueryMethod {
                    return new QueryEntitiesIterator<WorldID, With<QM1, QM2, QM3, QM4>>(new With<QM1, QM2, QM3, QM4>(qm1, qm2, qm3, qm4));
                }

                [MethodImpl(AggressiveInlining)]
                public static QueryEntitiesIterator<WorldID, With<QM1, QM2, QM3, QM4, QM5>> For<QM1, QM2, QM3, QM4, QM5>(
                    QM1 qm1 = default, QM2 qm2 = default, QM3 qm3 = default, QM4 qm4 = default, QM5 qm5 = default
                )
                    where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
                    where QM2 : struct, IQueryMethod
                    where QM3 : struct, IQueryMethod
                    where QM4 : struct, IQueryMethod
                    where QM5 : struct, IQueryMethod {
                    return new QueryEntitiesIterator<WorldID, With<QM1, QM2, QM3, QM4, QM5>>(new With<QM1, QM2, QM3, QM4, QM5>(qm1, qm2, qm3, qm4, qm5));
                }

                [MethodImpl(AggressiveInlining)]
                public static QueryEntitiesIterator<WorldID, With<QM1, QM2, QM3, QM4, QM5, QM6>> For<QM1, QM2, QM3, QM4, QM5, QM6>(
                    QM1 qm1 = default, QM2 qm2 = default, QM3 qm3 = default, QM4 qm4 = default, QM5 qm5 = default, QM6 qm6 = default
                )
                    where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
                    where QM2 : struct, IQueryMethod
                    where QM3 : struct, IQueryMethod
                    where QM4 : struct, IQueryMethod
                    where QM5 : struct, IQueryMethod
                    where QM6 : struct, IQueryMethod {
                    return new QueryEntitiesIterator<WorldID, With<QM1, QM2, QM3, QM4, QM5, QM6>>(
                        new With<QM1, QM2, QM3, QM4, QM5, QM6>(qm1, qm2, qm3, qm4, qm5, qm6));
                }

                [MethodImpl(AggressiveInlining)]
                public static QueryEntitiesIterator<WorldID, With<QM1, QM2, QM3, QM4, QM5, QM6, QM7>> For<QM1, QM2, QM3, QM4, QM5, QM6, QM7>(
                    QM1 qm1 = default, QM2 qm2 = default, QM3 qm3 = default, QM4 qm4 = default, QM5 qm5 = default, QM6 qm6 = default, QM7 qm7 = default
                )
                    where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
                    where QM2 : struct, IQueryMethod
                    where QM3 : struct, IQueryMethod
                    where QM4 : struct, IQueryMethod
                    where QM5 : struct, IQueryMethod
                    where QM6 : struct, IQueryMethod
                    where QM7 : struct, IQueryMethod {
                    return new QueryEntitiesIterator<WorldID, With<QM1, QM2, QM3, QM4, QM5, QM6, QM7>>(
                        new With<QM1, QM2, QM3, QM4, QM5, QM6, QM7>(qm1, qm2, qm3, qm4, qm5, qm6, qm7));
                }

                [MethodImpl(AggressiveInlining)]
                public static QueryEntitiesIterator<WorldID, With<QM1, QM2, QM3, QM4, QM5, QM6, QM7, QM8>> For<QM1, QM2, QM3, QM4, QM5, QM6, QM7, QM8>(
                        QM1 qm1 = default, QM2 qm2 = default, QM3 qm3 = default, QM4 qm4 = default, QM5 qm5 = default, QM6 qm6 = default, QM7 qm7 = default, QM8 qm8 = default
                    )
                    where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
                    where QM2 : struct, IQueryMethod
                    where QM3 : struct, IQueryMethod
                    where QM4 : struct, IQueryMethod
                    where QM5 : struct, IQueryMethod
                    where QM6 : struct, IQueryMethod
                    where QM7 : struct, IQueryMethod
                    where QM8 : struct, IQueryMethod {
                    return new QueryEntitiesIterator<WorldID, With<QM1, QM2, QM3, QM4, QM5, QM6, QM7, QM8>>(
                        new With<QM1, QM2, QM3, QM4, QM5, QM6, QM7, QM8>(qm1, qm2, qm3, qm4, qm5, qm6, qm7, qm8));
                }
            }
        }
    }
}