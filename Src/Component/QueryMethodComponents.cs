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
    public struct All<TComponents> : IQueryMethod, IPrimaryQueryMethod where TComponents : struct, IComponentTypes {
        public TComponents _all;
        private byte _incBufId;

        [MethodImpl(AggressiveInlining)]
        public All(TComponents all) {
            _all = all;
            _incBufId = default;
        }

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _incBufId = BitMaskUtils<WorldID, IComponent>.BorrowBuf();
            _all.SetMaskBuffer<WorldID>(_incBufId);
            _all.FillMinData(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return BitMaskUtils<WorldID, IComponent>.HasAll(entity._id, _incBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            _all.DisposeMask<WorldID>();
            BitMaskUtils<WorldID, IComponent>.DropBuf(_incBufId);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Single<TComponent> : IQueryMethod, IPrimaryQueryMethod, Stateless 
        where TComponent : struct, IComponent {
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components<TComponent>.AddBlocker(1);
            #endif
            var val = default(Types<TComponent>);
            val.FillMinData(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return Ecs<WorldID>.Components<TComponent>.Has(entity);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components<TComponent>.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct Double<TComponent1, TComponent2> : IQueryMethod, IPrimaryQueryMethod, Stateless
        where TComponent1 : struct, IComponent 
        where TComponent2 : struct, IComponent {
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components<TComponent1>.AddBlocker(1);
            Ecs<WorldID>.Components<TComponent2>.AddBlocker(1);
            #endif
            var val = default(Types<TComponent1, TComponent2>);
            val.FillMinData(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return Ecs<WorldID>.Components<TComponent1>.Has(entity) && Ecs<WorldID>.Components<TComponent2>.Has(entity);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components<TComponent1>.AddBlocker(-1);
            Ecs<WorldID>.Components<TComponent2>.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct AllAndNone<TComponentsIncluded, TComponentsExcluded> : IQueryMethod, IPrimaryQueryMethod
        where TComponentsIncluded : struct, IComponentTypes
        where TComponentsExcluded : struct, IComponentTypes {
        public TComponentsIncluded _all;
        public TComponentsExcluded _exc;
        private byte _incBufId;
        private byte _excBufId;
        
        [MethodImpl(AggressiveInlining)]
        public AllAndNone(TComponentsIncluded all, TComponentsExcluded exc) {
            _all = all;
            _exc = exc;
            _incBufId = default;
            _excBufId = default;
        }

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _incBufId = BitMaskUtils<WorldID, IComponent>.BorrowBuf();
            _excBufId = BitMaskUtils<WorldID, IComponent>.BorrowBuf();

            _all.SetMaskBuffer<WorldID>(_incBufId);
            _all.FillMinData(ref minCount, ref entities);

            _exc.SetMaskBuffer<WorldID>(_excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return BitMaskUtils<WorldID, IComponent>.HasAllAndExc(entity._id, _incBufId, _excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            _all.DisposeMask<WorldID>();
            _exc.DisposeMask<WorldID>();
            BitMaskUtils<WorldID, IComponent>.DropBuf(_incBufId);
            BitMaskUtils<WorldID, IComponent>.DropBuf(_excBufId);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct None<TComponents> : IQueryMethod
        where TComponents : struct, IComponentTypes {
        public TComponents _exc;
        private byte _excBufId;
        
        [MethodImpl(AggressiveInlining)]
        public None(TComponents exc) {
            _exc = exc;
            _excBufId = default;
        }
        
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _excBufId = BitMaskUtils<WorldID, IComponent>.BorrowBuf();
            _exc.SetMaskBuffer<WorldID>(_excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return BitMaskUtils<WorldID, IComponent>.NotHasAny(entity._id, _excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            _exc.DisposeMask<WorldID>();
            BitMaskUtils<WorldID, IComponent>.DropBuf(_excBufId);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct Any<TComponents> : IQueryMethod where TComponents : struct, IComponentTypes {
        public TComponents _any;
        private byte _anyBufId;
        
        [MethodImpl(AggressiveInlining)]
        public Any(TComponents any) {
            _any = any;
            _anyBufId = default;
        }

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _anyBufId = BitMaskUtils<WorldID, IComponent>.BorrowBuf();
            _any.SetMaskBuffer<WorldID>(_anyBufId);
            _any.FillMinData(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return BitMaskUtils<WorldID, IComponent>.HasAny(entity._id, _anyBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            _any.DisposeMask<WorldID>();
            BitMaskUtils<WorldID, IComponent>.DropBuf(_anyBufId);
        }
    }
}