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
    public struct MaskAll<TMasks> : IQueryMethod where TMasks : struct, IComponentMasks {
        public TMasks _all;
        private byte _incBufId;

        [MethodImpl(AggressiveInlining)]
        public MaskAll(TMasks all) {
            _all = all;
            _incBufId = default;
        }

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _incBufId = BitMaskUtils<WorldID, IMask>.BorrowBuf();
            _all.SetMask<WorldID>(_incBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return BitMaskUtils<WorldID, IMask>.HasAll(entity._id, _incBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BitMaskUtils<WorldID, IMask>.DropBuf(_incBufId);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct MaskSingle<TMask> : IQueryMethod, Stateless
        where TMask : struct, IMask {
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId { }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return Ecs<WorldID>.Masks<TMask>.Has(entity);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId { }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct MaskDouble<TMask1, TMask2> : IQueryMethod, Stateless
        where TMask1 : struct, IMask
        where TMask2 : struct, IMask {
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId { }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return Ecs<WorldID>.Masks<TMask1>.Has(entity) && Ecs<WorldID>.Masks<TMask2>.Has(entity);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId { }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct MaskAllAndNone<TMasksIncluded, TMasksExcluded> : IQueryMethod
        where TMasksIncluded : struct, IComponentMasks
        where TMasksExcluded : struct, IComponentMasks {
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
        }

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _incBufId = BitMaskUtils<WorldID, IMask>.BorrowBuf();
            _excBufId = BitMaskUtils<WorldID, IMask>.BorrowBuf();

            _all.SetMask<WorldID>(_incBufId);
            _exc.SetMask<WorldID>(_excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return BitMaskUtils<WorldID, IMask>.HasAllAndExc(entity._id, _incBufId, _excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BitMaskUtils<WorldID, IMask>.DropBuf(_incBufId);
            BitMaskUtils<WorldID, IMask>.DropBuf(_excBufId);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct MaskNone<TMasks> : IQueryMethod
        where TMasks : struct, IComponentMasks {
        public TMasks _exc;
        private byte _excBufId;

        [MethodImpl(AggressiveInlining)]
        public MaskNone(TMasks exc) {
            _exc = exc;
            _excBufId = default;
        }

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _excBufId = BitMaskUtils<WorldID, IMask>.BorrowBuf();
            _exc.SetMask<WorldID>(_excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return BitMaskUtils<WorldID, IMask>.NotHasAny(entity._id, _excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BitMaskUtils<WorldID, IMask>.DropBuf(_excBufId);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct MaskAny<TMasks> : IQueryMethod where TMasks : struct, IComponentMasks {
        public TMasks _any;
        private byte _anyBufId;

        [MethodImpl(AggressiveInlining)]
        public MaskAny(TMasks any) {
            _any = any;
            _anyBufId = default;
        }

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _anyBufId = BitMaskUtils<WorldID, IMask>.BorrowBuf();
            _any.SetMask<WorldID>(_anyBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return BitMaskUtils<WorldID, IMask>.HasAny(entity._id, _anyBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            BitMaskUtils<WorldID, IMask>.DropBuf(_anyBufId);
        }
    }
}
#endif