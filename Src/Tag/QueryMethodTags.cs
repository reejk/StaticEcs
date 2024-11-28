#if !FFS_ECS_DISABLE_TAGS
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
    public struct TagAll<TTags> : IQueryMethod, IPrimaryQueryMethod where TTags : struct, IComponentTags {
        public TTags _all;
        private byte _incBufId;
        
        [MethodImpl(AggressiveInlining)]
        public TagAll(TTags all) {
            _all = all;
            _incBufId = default;
        }
        
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _incBufId = BitMaskUtils<WorldID, ITag>.BorrowBuf();
            _all.SetMaskBuffer<WorldID>(_incBufId);
            _all.FillMinData(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return BitMaskUtils<WorldID, ITag>.HasAll(entity._id, _incBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            _all.DisposeMask<WorldID>();
            BitMaskUtils<WorldID, ITag>.DropBuf(_incBufId);
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct TagSingle<TTag> : IQueryMethod, IPrimaryQueryMethod, Stateless 
        where TTag : struct, ITag {
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            var val = default(Tag<TTag>);
            val.FillMinData(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return Ecs<WorldID>.Tags.Pool<TTag>.Has(entity);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId { }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct TagDouble<TTag1, TTag2> : IQueryMethod, IPrimaryQueryMethod, Stateless
        where TTag1 : struct, ITag 
        where TTag2 : struct, ITag {
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            var val = default(Tag<TTag1, TTag2>);
            val.FillMinData(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return Ecs<WorldID>.Tags.Pool<TTag1>.Has(entity) && Ecs<WorldID>.Tags.Pool<TTag2>.Has(entity);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId { }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct TagAllAndNone<TTagsIncluded, TTagsExcluded> : IQueryMethod, IPrimaryQueryMethod
        where TTagsIncluded : struct, IComponentTags
        where TTagsExcluded : struct, IComponentTags {
        public TTagsIncluded _all;
        public TTagsExcluded _exc;
        private byte _incBufId;
        private byte _excBufId;
        
        [MethodImpl(AggressiveInlining)]
        public TagAllAndNone(TTagsIncluded all, TTagsExcluded exc) {
            _all = all;
            _exc = exc;
            _incBufId = default;
            _excBufId = default;
        }
        
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _incBufId = BitMaskUtils<WorldID, ITag>.BorrowBuf();
            _excBufId = BitMaskUtils<WorldID, ITag>.BorrowBuf();
            _all.SetMaskBuffer<WorldID>(_incBufId);
            _all.FillMinData(ref minCount, ref entities);
            _exc.SetMaskBuffer<WorldID>(_excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return BitMaskUtils<WorldID, ITag>.HasAllAndExc(entity._id, _incBufId, _excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            _all.DisposeMask<WorldID>();
            _exc.DisposeMask<WorldID>();
            BitMaskUtils<WorldID, ITag>.DropBuf(_incBufId);
            BitMaskUtils<WorldID, ITag>.DropBuf(_excBufId);
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct TagNone<TTags> : IQueryMethod
        where TTags : struct, IComponentTags {
        public TTags _exc;
        private byte _excBufId;
        
        [MethodImpl(AggressiveInlining)]
        public TagNone(TTags exc) {
            _exc = exc;
            _excBufId = default;
        }
        
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _excBufId = BitMaskUtils<WorldID, ITag>.BorrowBuf();
            _exc.SetMaskBuffer<WorldID>(_excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return BitMaskUtils<WorldID, ITag>.NotHasAny(entity._id, _excBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            _exc.DisposeMask<WorldID>();
            BitMaskUtils<WorldID, ITag>.DropBuf(_excBufId);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct TagAny<TTags> : IQueryMethod where TTags : struct, IComponentTags {
        public TTags _any;
        private byte _anyBufId;
        
        [MethodImpl(AggressiveInlining)]
        public TagAny(TTags any) {
            _any = any;
            _anyBufId = default;
        }
        
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _anyBufId = BitMaskUtils<WorldID, ITag>.BorrowBuf();
            _any.SetMaskBuffer<WorldID>(_anyBufId);
            _any.FillMinData(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return BitMaskUtils<WorldID, ITag>.HasAny(entity._id, _anyBufId);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            _any.DisposeMask<WorldID>();
            BitMaskUtils<WorldID, ITag>.DropBuf(_anyBufId);
        }
    }
}
#endif