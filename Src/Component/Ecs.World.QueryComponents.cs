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
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public readonly ref struct WithComponents<W> where W : struct, IQueryMethod {
            private readonly W With;

            [MethodImpl(AggressiveInlining)]
            public WithComponents(W with) {
                With = with;
            }

            #region BY_STRUCT
            [MethodImpl(AggressiveInlining)]
            public void For<C1, R>(R runner = default, bool withDisabled = false)
                where C1 : struct, IComponent
                where R : struct, IQueryFunction<C1> {
                var iterator = default(QueryFunctionRunner<WorldType, C1, W>);
                iterator.Run(ref runner, With, withDisabled);
            }
            
            [MethodImpl(AggressiveInlining)]
            public void For<C1, R>(ref R runner, bool withDisabled = false)
                where C1 : struct, IComponent
                where R : struct, IQueryFunction<C1> {
                var iterator = default(QueryFunctionRunner<WorldType, C1, W>);
                iterator.Run(ref runner, With, withDisabled);
            }

            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, R>(R runner = default, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where R : struct, IQueryFunction<C1, C2> {
                QueryFunctionRunner<WorldType, C1, C2, W>.Run(ref runner, With, withDisabled);
            }
            
            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, R>(ref R runner, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where R : struct, IQueryFunction<C1, C2> {
                QueryFunctionRunner<WorldType, C1, C2, W>.Run(ref runner, With, withDisabled);
            }

            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, C3, R>(R runner = default, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where R : struct, IQueryFunction<C1, C2, C3> {
                QueryFunctionRunner<WorldType, C1, C2, C3, W>.Run(ref runner, With, withDisabled);
            }
            
            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, C3, R>(ref R runner, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where R : struct, IQueryFunction<C1, C2, C3> {
                QueryFunctionRunner<WorldType, C1, C2, C3, W>.Run(ref runner, With, withDisabled);
            }

            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, C3, C4, R>(R runner = default, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where R : struct, IQueryFunction<C1, C2, C3, C4> {
                QueryFunctionRunner<WorldType, C1, C2, C3, C4, W>.Run(ref runner, With, withDisabled);
            }
            
            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, C3, C4, R>(ref R runner, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where R : struct, IQueryFunction<C1, C2, C3, C4> {
                QueryFunctionRunner<WorldType, C1, C2, C3, C4, W>.Run(ref runner, With, withDisabled);
            }

            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, C3, C4, C5, R>(R runner = default, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent
                where R : struct, IQueryFunction<C1, C2, C3, C4, C5> {
                QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, W>.Run(ref runner, With, withDisabled);
            }
            
            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, C3, C4, C5, R>(ref R runner, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent
                where R : struct, IQueryFunction<C1, C2, C3, C4, C5> {
                QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, W>.Run(ref runner, With, withDisabled);
            }

            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, C3, C4, C5, C6, R>(R runner = default, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent
                where C6 : struct, IComponent
                where R : struct, IQueryFunction<C1, C2, C3, C4, C5, C6> {
                QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, W>.Run(ref runner, With, withDisabled);
            }
            
            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, C3, C4, C5, C6, R>(ref R runner, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent
                where C6 : struct, IComponent
                where R : struct, IQueryFunction<C1, C2, C3, C4, C5, C6> {
                QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, W>.Run(ref runner, With, withDisabled);
            }

            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, C3, C4, C5, C6, C7, R>(R runner = default, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent
                where C6 : struct, IComponent
                where C7 : struct, IComponent
                where R : struct, IQueryFunction<C1, C2, C3, C4, C5, C6, C7> {
                QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, C7, W>.Run(ref runner, With, withDisabled);
            }
            
            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, C3, C4, C5, C6, C7, R>(ref R runner, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent
                where C6 : struct, IComponent
                where C7 : struct, IComponent
                where R : struct, IQueryFunction<C1, C2, C3, C4, C5, C6, C7> {
                QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, C7, W>.Run(ref runner, With, withDisabled);
            }

            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, C3, C4, C5, C6, C7, C8, R>(R runner = default, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent
                where C6 : struct, IComponent
                where C7 : struct, IComponent
                where C8 : struct, IComponent
                where R : struct, IQueryFunction<C1, C2, C3, C4, C5, C6, C7, C8> {
                QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, C7, C8, W>.Run(ref runner, With, withDisabled);
            }
            
            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, C3, C4, C5, C6, C7, C8, R>(ref R runner, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent
                where C6 : struct, IComponent
                where C7 : struct, IComponent
                where C8 : struct, IComponent
                where R : struct, IQueryFunction<C1, C2, C3, C4, C5, C6, C7, C8> {
                QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, C7, C8, W>.Run(ref runner, With, withDisabled);
            }
            #endregion

            #region BY_DELEGATE
            [MethodImpl(AggressiveInlining)]
            public void For<C1>(DelegateQueryFunction<WorldType, C1> function, bool withDisabled = false)
                where C1 : struct, IComponent {
                var iterator = default(QueryFunctionRunner<WorldType, C1, W>);
                iterator.Run(function, With, withDisabled);
            }

            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2>(DelegateQueryFunction<WorldType, C1, C2> function, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent {
                QueryFunctionRunner<WorldType, C1, C2, W>.Run(function, With, withDisabled);
            }

            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, C3>(DelegateQueryFunction<WorldType, C1, C2, C3> function, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent {
                QueryFunctionRunner<WorldType, C1, C2, C3, W>.Run(function, With, withDisabled);
            }

            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, C3, C4>(DelegateQueryFunction<WorldType, C1, C2, C3, C4> function, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent {
                QueryFunctionRunner<WorldType, C1, C2, C3, C4, W>.Run(function, With, withDisabled);
            }

            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, C3, C4, C5>(DelegateQueryFunction<WorldType, C1, C2, C3, C4, C5> function, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent {
                QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, W>.Run(function, With, withDisabled);
            }

            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, C3, C4, C5, C6>(DelegateQueryFunction<WorldType, C1, C2, C3, C4, C5, C6> function, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent
                where C6 : struct, IComponent {
                QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, W>.Run(function, With, withDisabled);
            }

            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, C3, C4, C5, C6, C7>(DelegateQueryFunction<WorldType, C1, C2, C3, C4, C5, C6, C7> function, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent
                where C6 : struct, IComponent
                where C7 : struct, IComponent {
                QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, C7, W>.Run(function, With, withDisabled);
            }

            [MethodImpl(AggressiveInlining)]
            public void For<C1, C2, C3, C4, C5, C6, C7, C8>(DelegateQueryFunction<WorldType, C1, C2, C3, C4, C5, C6, C7, C8> function, bool withDisabled = false)
                where C1 : struct, IComponent
                where C2 : struct, IComponent
                where C3 : struct, IComponent
                where C4 : struct, IComponent
                where C5 : struct, IComponent
                where C6 : struct, IComponent
                where C7 : struct, IComponent
                where C8 : struct, IComponent {
                QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, C7, C8, W>.Run(function, With, withDisabled);
            }
            #endregion
        }

        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public abstract partial class World {
            #if ENABLE_IL2CPP
            [Il2CppSetOption(Option.NullChecks, false)]
            [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
            #endif
            public struct QueryComponents {
                public static WithComponents<W> With<W>(W with = default)
                    where W : struct, IQueryMethod {
                    return new WithComponents<W>(with);
                }

                #region BY_RUNNER
                [MethodImpl(AggressiveInlining)]
                public static void For<C1, R>(R runner = default, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where R : struct, IQueryFunction<C1> {
                    var iterator = default(QueryFunctionRunner<WorldType, C1, WithNothing>);
                    iterator.Run(ref runner, default, withDisabled);
                }
                
                [MethodImpl(AggressiveInlining)]
                public static void For<C1, R>(ref R runner, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where R : struct, IQueryFunction<C1> {
                    var iterator = default(QueryFunctionRunner<WorldType, C1, WithNothing>);
                    iterator.Run(ref runner, default, withDisabled);
                }

                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, R>(R runner = default, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where R : struct, IQueryFunction<C1, C2> {
                    QueryFunctionRunner<WorldType, C1, C2, WithNothing>.Run(ref runner, default, withDisabled);
                }
                
                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, R>(ref R runner, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where R : struct, IQueryFunction<C1, C2> {
                    QueryFunctionRunner<WorldType, C1, C2, WithNothing>.Run(ref runner, default, withDisabled);
                }

                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, C3, R>(R runner = default, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where R : struct, IQueryFunction<C1, C2, C3> {
                    QueryFunctionRunner<WorldType, C1, C2, C3, WithNothing>.Run(ref runner, default, withDisabled);
                }
                
                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, C3, R>(ref R runner, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where R : struct, IQueryFunction<C1, C2, C3> {
                    QueryFunctionRunner<WorldType, C1, C2, C3, WithNothing>.Run(ref runner, default, withDisabled);
                }

                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, C3, C4, R>(R runner = default, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent
                    where R : struct, IQueryFunction<C1, C2, C3, C4> {
                    QueryFunctionRunner<WorldType, C1, C2, C3, C4, WithNothing>.Run(ref runner, default, withDisabled);
                }
                
                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, C3, C4, R>(ref R runner, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent
                    where R : struct, IQueryFunction<C1, C2, C3, C4> {
                    QueryFunctionRunner<WorldType, C1, C2, C3, C4, WithNothing>.Run(ref runner, default, withDisabled);
                }

                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, C3, C4, C5, R>(R runner = default, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent
                    where C5 : struct, IComponent
                    where R : struct, IQueryFunction<C1, C2, C3, C4, C5> {
                    QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, WithNothing>.Run(ref runner, default, withDisabled);
                }
                
                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, C3, C4, C5, R>(ref R runner, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent
                    where C5 : struct, IComponent
                    where R : struct, IQueryFunction<C1, C2, C3, C4, C5> {
                    QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, WithNothing>.Run(ref runner, default, withDisabled);
                }

                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, C3, C4, C5, C6, R>(R runner = default, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent
                    where C5 : struct, IComponent
                    where C6 : struct, IComponent
                    where R : struct, IQueryFunction<C1, C2, C3, C4, C5, C6> {
                    QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, WithNothing>.Run(ref runner, default, withDisabled);
                }
                
                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, C3, C4, C5, C6, R>(ref R runner, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent
                    where C5 : struct, IComponent
                    where C6 : struct, IComponent
                    where R : struct, IQueryFunction<C1, C2, C3, C4, C5, C6> {
                    QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, WithNothing>.Run(ref runner, default, withDisabled);
                }

                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, C3, C4, C5, C6, C7, R>(R runner = default, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent
                    where C5 : struct, IComponent
                    where C6 : struct, IComponent
                    where C7 : struct, IComponent
                    where R : struct, IQueryFunction<C1, C2, C3, C4, C5, C6, C7> {
                    QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, C7, WithNothing>.Run(ref runner, default, withDisabled);
                }
                
                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, C3, C4, C5, C6, C7, R>(ref R runner, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent
                    where C5 : struct, IComponent
                    where C6 : struct, IComponent
                    where C7 : struct, IComponent
                    where R : struct, IQueryFunction<C1, C2, C3, C4, C5, C6, C7> {
                    QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, C7, WithNothing>.Run(ref runner, default, withDisabled);
                }

                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, C3, C4, C5, C6, C7, C8, R>(R runner = default, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent
                    where C5 : struct, IComponent
                    where C6 : struct, IComponent
                    where C7 : struct, IComponent
                    where C8 : struct, IComponent
                    where R : struct, IQueryFunction<C1, C2, C3, C4, C5, C6, C7, C8> {
                    QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, C7, C8, WithNothing>.Run(ref runner, default, withDisabled);
                }
                
                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, C3, C4, C5, C6, C7, C8, R>(ref R runner, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent
                    where C5 : struct, IComponent
                    where C6 : struct, IComponent
                    where C7 : struct, IComponent
                    where C8 : struct, IComponent
                    where R : struct, IQueryFunction<C1, C2, C3, C4, C5, C6, C7, C8> {
                    QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, C7, C8, WithNothing>.Run(ref runner, default, withDisabled);
                }
                #endregion

                #region BY_DELEGATE
                [MethodImpl(AggressiveInlining)]
                public static void For<C1>(DelegateQueryFunction<WorldType, C1> function, bool withDisabled = false)
                    where C1 : struct, IComponent {
                    var iterator = default(QueryFunctionRunner<WorldType, C1, WithNothing>);
                    iterator.Run(function, default, withDisabled);
                }

                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2>(DelegateQueryFunction<WorldType, C1, C2> function, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent {
                    QueryFunctionRunner<WorldType, C1, C2, WithNothing>.Run(function, default, withDisabled);
                }

                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, C3>(DelegateQueryFunction<WorldType, C1, C2, C3> function, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent {
                    QueryFunctionRunner<WorldType, C1, C2, C3, WithNothing>.Run(function, default, withDisabled);
                }

                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, C3, C4>(DelegateQueryFunction<WorldType, C1, C2, C3, C4> function, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent {
                    QueryFunctionRunner<WorldType, C1, C2, C3, C4, WithNothing>.Run(function, default, withDisabled);
                }

                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, C3, C4, C5>(DelegateQueryFunction<WorldType, C1, C2, C3, C4, C5> function, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent
                    where C5 : struct, IComponent {
                    QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, WithNothing>.Run(function, default, withDisabled);
                }

                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, C3, C4, C5, C6>(DelegateQueryFunction<WorldType, C1, C2, C3, C4, C5, C6> function, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent
                    where C5 : struct, IComponent
                    where C6 : struct, IComponent {
                    QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, WithNothing>.Run(function, default, withDisabled);
                }

                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, C3, C4, C5, C6, C7>(DelegateQueryFunction<WorldType, C1, C2, C3, C4, C5, C6, C7> function, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent
                    where C5 : struct, IComponent
                    where C6 : struct, IComponent
                    where C7 : struct, IComponent {
                    QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, C7, WithNothing>.Run(function, default, withDisabled);
                }

                [MethodImpl(AggressiveInlining)]
                public static void For<C1, C2, C3, C4, C5, C6, C7, C8>(DelegateQueryFunction<WorldType, C1, C2, C3, C4, C5, C6, C7, C8> function, bool withDisabled = false)
                    where C1 : struct, IComponent
                    where C2 : struct, IComponent
                    where C3 : struct, IComponent
                    where C4 : struct, IComponent
                    where C5 : struct, IComponent
                    where C6 : struct, IComponent
                    where C7 : struct, IComponent
                    where C8 : struct, IComponent {
                    QueryFunctionRunner<WorldType, C1, C2, C3, C4, C5, C6, C7, C8, WithNothing>.Run(function, default, withDisabled);
                }
                #endregion
            }
        }
    }
}