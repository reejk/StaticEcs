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
    public struct All<TComponents> : IPrimaryQueryMethod, ISealedQueryMethod where TComponents : struct, IComponentTypes {
        private BitMask _bitMask;
        public TComponents _all;
        private byte _incBufId;

        [MethodImpl(AggressiveInlining)]
        public All(TComponents all) {
            _all = all;
            _incBufId = default;
            _bitMask = null;
        }

        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _bitMask = Ecs<WorldID>.ModuleComponents.BitMask;
            _incBufId = _bitMask.BorrowBuf();
            _all.SetBitMask<WorldID>(_incBufId);
            _all.SetData(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity(int entityId) {
            return _bitMask.HasAll(entityId, _incBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            _all.Dispose<WorldID>();
            #endif
            _bitMask.DropBuf(_incBufId);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct Single<TComponent> : IPrimaryQueryMethod, ISealedQueryMethod, Stateless 
        where TComponent : struct, IComponent {
        private int[] _dataIdxByEntityId;

        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components<TComponent>.AddBlocker(1);
            #endif
            _dataIdxByEntityId = Ecs<WorldID>.Components<TComponent>.GetDataIdxByEntityId();
            Ecs<WorldID>.Components<TComponent>.SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity(int entityId) {
            return _dataIdxByEntityId[entityId] > 0;
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
    public struct Double<TComponent1, TComponent2> : IPrimaryQueryMethod, ISealedQueryMethod, Stateless
        where TComponent1 : struct, IComponent 
        where TComponent2 : struct, IComponent {
        private int[] _dataIdxByEntityId1;
        private int[] _dataIdxByEntityId2;
        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Components<TComponent1>.AddBlocker(1);
            Ecs<WorldID>.Components<TComponent2>.AddBlocker(1);
            #endif
            _dataIdxByEntityId1 = Ecs<WorldID>.Components<TComponent1>.GetDataIdxByEntityId();
            _dataIdxByEntityId2 = Ecs<WorldID>.Components<TComponent2>.GetDataIdxByEntityId();
            Ecs<WorldID>.Components<TComponent1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Components<TComponent2>.SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity(int entityId) {
            return _dataIdxByEntityId1[entityId] > 0 && _dataIdxByEntityId2[entityId] > 0;
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
    public struct AllAndNone<TComponentsIncluded, TComponentsExcluded> : IPrimaryQueryMethod, ISealedQueryMethod
        where TComponentsIncluded : struct, IComponentTypes
        where TComponentsExcluded : struct, IComponentTypes {
        private BitMask _bitMask;
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
            _bitMask = null;
        }

        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _bitMask = Ecs<WorldID>.ModuleComponents.BitMask;
            _incBufId = _bitMask.BorrowBuf();
            _excBufId = _bitMask.BorrowBuf();

            _all.SetBitMask<WorldID>(_incBufId);
            _all.SetData(ref minCount, ref entities);

            _exc.SetBitMask<WorldID>(_excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity(int entityId) {
            return _bitMask.HasAllAndExc(entityId, _incBufId, _excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            _all.Dispose<WorldID>();
            _exc.Dispose<WorldID>();
            #endif
            _bitMask.DropBuf(_incBufId);
            _bitMask.DropBuf(_excBufId);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct None<TComponents> : IQueryMethod, ISealedQueryMethod
        where TComponents : struct, IComponentTypes {
        private BitMask _bitMask;
        public TComponents _exc;
        private byte _excBufId;
        
        [MethodImpl(AggressiveInlining)]
        public None(TComponents exc) {
            _exc = exc;
            _excBufId = default;
            _bitMask = null;
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _bitMask = Ecs<WorldID>.ModuleComponents.BitMask;
            _excBufId = _bitMask.BorrowBuf();
            _exc.SetBitMask<WorldID>(_excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity(int entityId) {
            return _bitMask.NotHasAny(entityId, _excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            _exc.Dispose<WorldID>();
            #endif
            _bitMask.DropBuf(_excBufId);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct Any<TComponents> : IQueryMethod, ISealedQueryMethod where TComponents : struct, IComponentTypes {
        private BitMask _bitMask;
        public TComponents _any;
        private byte _anyBufId;
        
        [MethodImpl(AggressiveInlining)]
        public Any(TComponents any) {
            _any = any;
            _anyBufId = default;
            _bitMask = null;
        }

        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _bitMask = Ecs<WorldID>.ModuleComponents.BitMask;
            _anyBufId = _bitMask.BorrowBuf();
            _any.SetBitMask<WorldID>(_anyBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity(int entityId) {
            return _bitMask.HasAny(entityId, _anyBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            _any.Dispose<WorldID>();
            #endif
            _bitMask.DropBuf(_anyBufId);
        }
    }
}