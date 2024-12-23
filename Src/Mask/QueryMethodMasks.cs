#if !FFS_ECS_DISABLE_MASKS
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
    public struct MaskAll<TMasks> : IQueryMethod, ISealedQueryMethod where TMasks : struct, IComponentMasks {
        private BitMask _bitMask;
        public TMasks _all;
        private byte _incBufId;

        [MethodImpl(AggressiveInlining)]
        public MaskAll(TMasks all) {
            _all = all;
            _incBufId = default;
            _bitMask = null;
        }

        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _bitMask = Ecs<WorldID>.ModuleComponents.BitMask;
            _incBufId = _bitMask.BorrowBuf();
            _all.SetMask<WorldID>(_incBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity(int entityId) {
            return _bitMask.HasAll(entityId, _incBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            _bitMask.DropBuf(_incBufId);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct MaskSingle<TMask> : IQueryMethod, ISealedQueryMethod, Stateless
        where TMask : struct, IMask {
        private BitMask _bitMask;
        private ushort _id;
        
        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _bitMask = Ecs<WorldID>.ModuleComponents.BitMask;
            _id = Ecs<WorldID>.Masks<TMask>.id;
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity(int entityId) {
            return _bitMask.Has(entityId, _id);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId { }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct MaskDouble<TMask1, TMask2> : IQueryMethod, ISealedQueryMethod, Stateless
        where TMask1 : struct, IMask
        where TMask2 : struct, IMask {
        private BitMask _bitMask;
        private ushort _id1;
        private ushort _id2;

        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _bitMask = Ecs<WorldID>.ModuleComponents.BitMask;
            _id1 = Ecs<WorldID>.Masks<TMask1>.id;
            _id2 = Ecs<WorldID>.Masks<TMask2>.id;
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity(int entityId) {
            return _bitMask.Has(entityId, _id1) && _bitMask.Has(entityId, _id2);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId { }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct MaskAllAndNone<TMasksIncluded, TMasksExcluded> : IQueryMethod, ISealedQueryMethod
        where TMasksIncluded : struct, IComponentMasks
        where TMasksExcluded : struct, IComponentMasks {
        private BitMask _bitMask;
        public TMasksIncluded _all;
        public TMasksExcluded _exc;
        private byte _incBufId;
        private byte _excBufId;

        [MethodImpl(AggressiveInlining)]
        public MaskAllAndNone(TMasksIncluded all, TMasksExcluded exc) {
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

            _all.SetMask<WorldID>(_incBufId);
            _exc.SetMask<WorldID>(_excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity(int entityId) {
            return _bitMask.HasAllAndExc(entityId, _incBufId, _excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            _bitMask.DropBuf(_incBufId);
            _bitMask.DropBuf(_excBufId);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct MaskNone<TMasks> : IQueryMethod, ISealedQueryMethod
        where TMasks : struct, IComponentMasks {
        private BitMask _bitMask;
        public TMasks _exc;
        private byte _excBufId;

        [MethodImpl(AggressiveInlining)]
        public MaskNone(TMasks exc) {
            _exc = exc;
            _excBufId = default;
            _bitMask = null;
        }

        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _bitMask = Ecs<WorldID>.ModuleComponents.BitMask;
            _excBufId = _bitMask.BorrowBuf();
            _exc.SetMask<WorldID>(_excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity(int entityId) {
            return _bitMask.NotHasAny(entityId, _excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            _bitMask.DropBuf(_excBufId);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct MaskAny<TMasks> : IQueryMethod, ISealedQueryMethod where TMasks : struct, IComponentMasks {
        private BitMask _bitMask;
        public TMasks _any;
        private byte _anyBufId;

        [MethodImpl(AggressiveInlining)]
        public MaskAny(TMasks any) {
            _any = any;
            _anyBufId = default;
            _bitMask = null;
        }

        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _bitMask = Ecs<WorldID>.ModuleComponents.BitMask;
            _anyBufId = _bitMask.BorrowBuf();
            _any.SetMask<WorldID>(_anyBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity(int entityId) {
            return _bitMask.HasAny(entityId, _anyBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            _bitMask.DropBuf(_anyBufId);
        }
    }
}
#endif