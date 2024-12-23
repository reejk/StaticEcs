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
    public struct TagAll<TTags> : IPrimaryQueryMethod, ISealedQueryMethod where TTags : struct, IComponentTags {
        private BitMask _bitMask;
        public TTags _all;
        private byte _incBufId;
        
        [MethodImpl(AggressiveInlining)]
        public TagAll(TTags all) {
            _all = all;
            _incBufId = default;
            _bitMask = null;
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _bitMask = Ecs<WorldID>.ModuleTags.BitMask;
            _incBufId = _bitMask.BorrowBuf();
            _all.SetMask<WorldID>(_incBufId);
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
    public struct TagSingle<TTag> : IPrimaryQueryMethod, ISealedQueryMethod, Stateless 
        where TTag : struct, ITag {
        private int[] _dataIdxByEntityId;
        
        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags<TTag>.AddBlocker(1);
            #endif
            _dataIdxByEntityId = Ecs<WorldID>.Tags<TTag>.GetDataIdxByEntityId();
            Ecs<WorldID>.Tags<TTag>.SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity(int entityId) {
            return _dataIdxByEntityId[entityId] > 0;
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags<TTag>.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct TagDouble<TTag1, TTag2> : IPrimaryQueryMethod, ISealedQueryMethod, Stateless
        where TTag1 : struct, ITag 
        where TTag2 : struct, ITag {
        private int[] _dataIdxByEntityId1;
        private int[] _dataIdxByEntityId2;
        
        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags<TTag1>.AddBlocker(1);
            Ecs<WorldID>.Tags<TTag2>.AddBlocker(1);
            #endif
            _dataIdxByEntityId1 = Ecs<WorldID>.Tags<TTag1>.GetDataIdxByEntityId();
            _dataIdxByEntityId2 = Ecs<WorldID>.Tags<TTag2>.GetDataIdxByEntityId();
            Ecs<WorldID>.Tags<TTag1>.SetDataIfCountLess(ref minCount, ref entities);
            Ecs<WorldID>.Tags<TTag2>.SetDataIfCountLess(ref minCount, ref entities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity(int entityId) {
            return _dataIdxByEntityId1[entityId] > 0 && _dataIdxByEntityId2[entityId] > 0;
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            #if DEBUG
            Ecs<WorldID>.Tags<TTag1>.AddBlocker(-1);
            Ecs<WorldID>.Tags<TTag2>.AddBlocker(-1);
            #endif
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct TagAllAndNone<TTagsIncluded, TTagsExcluded> : IPrimaryQueryMethod, ISealedQueryMethod
        where TTagsIncluded : struct, IComponentTags
        where TTagsExcluded : struct, IComponentTags {
        private BitMask _bitMask;
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
            _bitMask = null;
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _bitMask = Ecs<WorldID>.ModuleTags.BitMask;
            _incBufId = _bitMask.BorrowBuf();
            _excBufId = _bitMask.BorrowBuf();
            _all.SetMask<WorldID>(_incBufId);
            _all.SetData(ref minCount, ref entities);
            _exc.SetMask<WorldID>(_excBufId);
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
    public struct TagNone<TTags> : IQueryMethod, ISealedQueryMethod
        where TTags : struct, IComponentTags {
        private BitMask _bitMask;
        public TTags _exc;
        private byte _excBufId;
        
        [MethodImpl(AggressiveInlining)]
        public TagNone(TTags exc) {
            _exc = exc;
            _excBufId = default;
            _bitMask = null;
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _bitMask = Ecs<WorldID>.ModuleTags.BitMask;
            _excBufId = _bitMask.BorrowBuf();
            _exc.SetMask<WorldID>(_excBufId);
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
    public struct TagAny<TTags> : IQueryMethod, ISealedQueryMethod where TTags : struct, IComponentTags {
        private BitMask _bitMask;
        public TTags _any;
        private byte _anyBufId;
        
        [MethodImpl(AggressiveInlining)]
        public TagAny(TTags any) {
            _any = any;
            _anyBufId = default;
            _bitMask = null;
        }
        
        [MethodImpl(AggressiveInlining)]
        public void SetData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId {
            _bitMask = Ecs<WorldID>.ModuleTags.BitMask;
            _anyBufId = _bitMask.BorrowBuf();
            _any.SetMask<WorldID>(_anyBufId);
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
#endif