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
    public readonly struct TypesBox : IComponentTypes {
        public readonly IComponentTypes Types;

        [MethodImpl(AggressiveInlining)]
        public TypesBox(IComponentTypes types) {
            Types = types;
        }

        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Types.SetData(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            Types.SetBitMask<WorldID>(bufId);
        }

        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            Types.Dispose<WorldID>();
        }
        #endif
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Types1 : IComponentTypes {
        public readonly ComponentDynId C1;

        [MethodImpl(AggressiveInlining)]
        public Types1(ComponentDynId c1) {
            C1 = c1;
        }

        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockComponents<WorldID>(1);
            #endif

            Ecs<WorldID>.ModuleComponents.BitMask.SetInBuffer(bufId, C1.Val);
        }

        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockComponents<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockComponents<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(val);
        }
        #endif
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Types2 : IComponentTypes {
        public readonly ComponentDynId C1;
        public readonly ComponentDynId C2;

        [MethodImpl(AggressiveInlining)]
        public Types2(ComponentDynId c1, ComponentDynId c2) {
            C1 = c1;
            C2 = c2;
        }

        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockComponents<WorldID>(1);
            #endif
            
            Ecs<WorldID>.ModuleComponents.BitMask.SetInBuffer(bufId, C1.Val, C2.Val);
        }


        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockComponents<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockComponents<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(val);
        }
        #endif
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Types3 : IComponentTypes {
        public readonly ComponentDynId C1;
        public readonly ComponentDynId C2;
        public readonly ComponentDynId C3;

        [MethodImpl(AggressiveInlining)]
        public Types3(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3) {
            C1 = c1;
            C2 = c2;
            C3 = c3;
        }

        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockComponents<WorldID>(1);
            #endif
            
            Ecs<WorldID>.ModuleComponents.BitMask.SetInBuffer(bufId, C1.Val, C2.Val, C3.Val);
        }


        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockComponents<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockComponents<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).AddBlocker(val);
        }
        #endif
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Types4 : IComponentTypes {
        public readonly ComponentDynId C1;
        public readonly ComponentDynId C2;
        public readonly ComponentDynId C3;
        public readonly ComponentDynId C4;

        [MethodImpl(AggressiveInlining)]
        public Types4(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3, ComponentDynId c4) {
            C1 = c1;
            C2 = c2;
            C3 = c3;
            C4 = c4;
        }

        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockComponents<WorldID>(1);
            #endif

            Ecs<WorldID>.ModuleComponents.BitMask.SetInBuffer(bufId, C1.Val, C2.Val, C3.Val, C4.Val);
        }


        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockComponents<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockComponents<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).AddBlocker(val);
        }
        #endif
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Types5 : IComponentTypes {
        public readonly ComponentDynId C1;
        public readonly ComponentDynId C2;
        public readonly ComponentDynId C3;
        public readonly ComponentDynId C4;
        public readonly ComponentDynId C5;

        [MethodImpl(AggressiveInlining)]
        public Types5(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3, ComponentDynId c4, ComponentDynId c5) {
            C1 = c1;
            C2 = c2;
            C3 = c3;
            C4 = c4;
            C5 = c5;
        }

        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockComponents<WorldID>(1);
            #endif
            
            Ecs<WorldID>.ModuleComponents.BitMask.SetInBuffer(bufId, C1.Val, C2.Val, C3.Val, C4.Val, C5.Val);
        }


        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockComponents<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockComponents<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).AddBlocker(val);
        }
        #endif
    }


    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Types6 : IComponentTypes {
        public readonly ComponentDynId C1;
        public readonly ComponentDynId C2;
        public readonly ComponentDynId C3;
        public readonly ComponentDynId C4;
        public readonly ComponentDynId C5;
        public readonly ComponentDynId C6;

        [MethodImpl(AggressiveInlining)]
        public Types6(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3, ComponentDynId c4, ComponentDynId c5, ComponentDynId c6) {
            C1 = c1;
            C2 = c2;
            C3 = c3;
            C4 = c4;
            C5 = c5;
            C6 = c6;
        }

        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C6).SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockComponents<WorldID>(1);
            #endif
            
            Ecs<WorldID>.ModuleComponents.BitMask.SetInBuffer(bufId, C1.Val, C2.Val, C3.Val, C4.Val, C5.Val, C6.Val);
        }


        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockComponents<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockComponents<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C6).AddBlocker(val);
        }
        #endif
    }


    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Types7 : IComponentTypes {
        public readonly ComponentDynId C1;
        public readonly ComponentDynId C2;
        public readonly ComponentDynId C3;
        public readonly ComponentDynId C4;
        public readonly ComponentDynId C5;
        public readonly ComponentDynId C6;
        public readonly ComponentDynId C7;

        [MethodImpl(AggressiveInlining)]
        public Types7(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3, ComponentDynId c4, ComponentDynId c5, ComponentDynId c6, ComponentDynId c7) {
            C1 = c1;
            C2 = c2;
            C3 = c3;
            C4 = c4;
            C5 = c5;
            C6 = c6;
            C7 = c7;
        }

        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C6).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C7).SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockComponents<WorldID>(1);
            #endif
            
            Ecs<WorldID>.ModuleComponents.BitMask.SetInBuffer(bufId, C1.Val, C2.Val, C3.Val, C4.Val, C5.Val, C6.Val, C7.Val);
        }


        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockComponents<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockComponents<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C6).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C7).AddBlocker(val);
        }
        #endif
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Types8 : IComponentTypes {
        public readonly ComponentDynId C1;
        public readonly ComponentDynId C2;
        public readonly ComponentDynId C3;
        public readonly ComponentDynId C4;
        public readonly ComponentDynId C5;
        public readonly ComponentDynId C6;
        public readonly ComponentDynId C7;
        public readonly ComponentDynId C8;

        [MethodImpl(AggressiveInlining)]
        public Types8(ComponentDynId c1, ComponentDynId c2, ComponentDynId c3, ComponentDynId c4, ComponentDynId c5, ComponentDynId c6, ComponentDynId c7, ComponentDynId c8) {
            C1 = c1;
            C2 = c2;
            C3 = c3;
            C4 = c4;
            C5 = c5;
            C6 = c6;
            C7 = c7;
            C8 = c8;
        }

        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C6).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C7).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C8).SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            BlockComponents<WorldID>(1);
            #endif

            Ecs<WorldID>.ModuleComponents.BitMask.SetInBuffer(bufId, C1.Val, C2.Val, C3.Val, C4.Val, C5.Val, C6.Val, C7.Val, C8.Val);
        }

        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BlockComponents<WorldID>(-1);
        }

        [MethodImpl(AggressiveInlining)]
        public void BlockComponents<WorldID>(int val) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C6).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C7).AddBlocker(val);
            Ecs<WorldID>.ModuleComponents.GetPool(C8).AddBlocker(val);
        }
        #endif
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct TypesArray : IComponentTypes {
        public readonly ComponentDynId[] Types;

        [MethodImpl(AggressiveInlining)]
        public TypesArray(params ComponentDynId[] types) {
            Types = types;
        }

        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            foreach (var type in Types) {
                Ecs<WorldID>.ModuleComponents.GetPool(type).SetDataIfCountLess(ref minCount, ref entities);
            }
        }

        [MethodImpl(AggressiveInlining)]
        public void SetBitMask<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            foreach (var type in Types) {
                Ecs<WorldID>.ModuleComponents.BitMask.SetInBuffer(bufId, type.Val);
                #if DEBUG
                Ecs<WorldID>.ModuleComponents.GetPool(type).AddBlocker(1);
                #endif
            }
        }

        #if DEBUG
        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            foreach (var type in Types) {
                Ecs<WorldID>.ModuleComponents.GetPool(type).AddBlocker(-1);
            }
        }
        #endif
    }
}