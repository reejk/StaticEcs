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
        public All<TypesBox> All() => new(this);

        [MethodImpl(AggressiveInlining)]
        public None<TypesBox> None() => new(this);

        [MethodImpl(AggressiveInlining)]
        public AllAndNone<TypesBox, T> AllAndNone<T>(T without = default) where T : struct, IComponentTypes => new(this, without);

        [MethodImpl(AggressiveInlining)]
        public Any<TypesBox> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Types.FillMinData(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            Types.SetMaskBuffer<WorldID>(bufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            Types.DisposeMask<WorldID>();
        }
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
        public All<Types1> All() => new(this);

        [MethodImpl(AggressiveInlining)]
        public None<Types1> None() => new(this);

        [MethodImpl(AggressiveInlining)]
        public AllAndNone<Types1, T> AllAndNone<T>(T without = default) where T : struct, IComponentTypes => new(this, without);

        [MethodImpl(AggressiveInlining)]
        public Any<Types1> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C1.Val);
        }

        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(-1);
            #endif
        }
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
        public All<Types2> All() => new(this);

        [MethodImpl(AggressiveInlining)]
        public None<Types2> None() => new(this);

        [MethodImpl(AggressiveInlining)]
        public AllAndNone<Types2, T> AllAndNone<T>(T without = default) where T : struct, IComponentTypes => new(this, without);

        [MethodImpl(AggressiveInlining)]
        public Any<Types2> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(1);
            #endif
            
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C1.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C2.Val);
        }


        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(-1);
            #endif
        }
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
        public All<Types3> All() => new(this);

        [MethodImpl(AggressiveInlining)]
        public None<Types3> None() => new(this);

        [MethodImpl(AggressiveInlining)]
        public AllAndNone<Types3, T> AllAndNone<T>(T without = default) where T : struct, IComponentTypes => new(this, without);

        [MethodImpl(AggressiveInlining)]
        public Any<Types3> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).AddBlocker(1);
            #endif
            
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C1.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C2.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C3.Val);
        }


        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).AddBlocker(-1);
            #endif
        }
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
        public All<Types4> All() => new(this);

        [MethodImpl(AggressiveInlining)]
        public None<Types4> None() => new(this);

        [MethodImpl(AggressiveInlining)]
        public AllAndNone<Types4, T> AllAndNone<T>(T without = default) where T : struct, IComponentTypes => new(this, without);

        [MethodImpl(AggressiveInlining)]
        public Any<Types4> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C1.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C2.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C3.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C4.Val);
        }


        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).AddBlocker(-1);
            #endif
        }
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
        public All<Types5> All() => new(this);

        [MethodImpl(AggressiveInlining)]
        public None<Types5> None() => new(this);

        [MethodImpl(AggressiveInlining)]
        public AllAndNone<Types5, T> AllAndNone<T>(T without = default) where T : struct, IComponentTypes => new(this, without);

        [MethodImpl(AggressiveInlining)]
        public Any<Types5> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).AddBlocker(1);
            #endif
            
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C1.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C2.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C3.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C4.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C5.Val);
        }


        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).AddBlocker(-1);
            #endif
        }
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
        public All<Types6> All() => new(this);

        [MethodImpl(AggressiveInlining)]
        public None<Types6> None() => new(this);

        [MethodImpl(AggressiveInlining)]
        public AllAndNone<Types6, T> AllAndNone<T>(T without = default) where T : struct, IComponentTypes => new(this, without);

        [MethodImpl(AggressiveInlining)]
        public Any<Types6> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C6).SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C6).AddBlocker(1);
            #endif
            
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C1.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C2.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C3.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C4.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C5.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C6.Val);
        }


        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C6).AddBlocker(-1);
            #endif
        }
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
        public All<Types7> All() => new(this);

        [MethodImpl(AggressiveInlining)]
        public None<Types7> None() => new(this);

        [MethodImpl(AggressiveInlining)]
        public AllAndNone<Types7, T> AllAndNone<T>(T without = default) where T : struct, IComponentTypes => new(this, without);

        [MethodImpl(AggressiveInlining)]
        public Any<Types7> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            Ecs<WorldID>.ModuleComponents.GetPool(C1).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C6).SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.ModuleComponents.GetPool(C7).SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C6).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C7).AddBlocker(1);
            #endif
            
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C1.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C2.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C3.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C4.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C5.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C6.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C7.Val);
        }


        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C6).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C7).AddBlocker(-1);
            #endif
        }
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
        public Types8(
            ComponentDynId c1, ComponentDynId c2, ComponentDynId c3, ComponentDynId c4, ComponentDynId c5, ComponentDynId c6, ComponentDynId c7,
            ComponentDynId c8
        ) {
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
        public All<Types8> All() => new(this);

        [MethodImpl(AggressiveInlining)]
        public None<Types8> None() => new(this);

        [MethodImpl(AggressiveInlining)]
        public AllAndNone<Types8, T> AllAndNone<T>(T without = default) where T : struct, IComponentTypes => new(this, without);

        [MethodImpl(AggressiveInlining)]
        public Any<Types8> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
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
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C6).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C7).AddBlocker(1);
            Ecs<WorldID>.ModuleComponents.GetPool(C8).AddBlocker(1);
            #endif

            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C1.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C2.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C3.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C4.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C5.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C6.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C7.Val);
            BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, C8.Val);
        }


        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.ModuleComponents.GetPool(C1).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C2).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C3).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C4).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C5).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C6).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C7).AddBlocker(-1);
            Ecs<WorldID>.ModuleComponents.GetPool(C8).AddBlocker(-1);
            #endif
        }
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
        public All<TypesArray> All() => new(this);

        [MethodImpl(AggressiveInlining)]
        public None<TypesArray> None() => new(this);

        [MethodImpl(AggressiveInlining)]
        public AllAndNone<TypesArray, T> AllAndNone<T>(T without = default) where T : struct, IComponentTypes => new(this, without);

        [MethodImpl(AggressiveInlining)]
        public Any<TypesArray> Any() => new(this);

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            for (var i = 0; i < Types.Length; i++) {
                Ecs<WorldID>.ModuleComponents.GetPool(Types[i]).SetDataIfCountLess(ref minCount, ref entities);
            }
        }

        [MethodImpl(AggressiveInlining)]
        public void SetMaskBuffer<WorldID>(byte bufId) where WorldID : struct, IWorldId {
            for (var i = 0; i < Types.Length; i++) {
                BitMaskUtils<WorldID, IComponent>.SetInBuffer(bufId, Types[i].Val);
                #if DEBUG
                Ecs<WorldID>.ModuleComponents.GetPool(Types[i]).AddBlocker(1);
                #endif
            }
        }


        [MethodImpl(AggressiveInlining)]
        public void DisposeMask<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
             for (var i = 0; i < Types.Length; i++) {
                var type = Types[i];
                Ecs<WorldID>.ModuleComponents.GetPool(type).AddBlocker(-1);
            }
            #endif
        }
    }
}