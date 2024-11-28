#if !FFS_ECS_DISABLE_TAGS
using System;
using System.Runtime.CompilerServices;
using System.Threading;
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
        public abstract partial class Tags {
            private static ulong[] _bitMap;
            private static IPoolWrapper[] _pools;
            private static Action[] _resetActions;
            private static Action[] _reInitActions;
            private static ushort _actionsCount;
            private static ushort _poolsCount;

            internal static ushort BitMapLen;

            [MethodImpl(AggressiveInlining)]
            internal static void Create(uint baseComponentsCapacity) {
                _pools = new IPoolWrapper[baseComponentsCapacity];
                _reInitActions ??= new Action[baseComponentsCapacity];
                _resetActions ??= new Action[baseComponentsCapacity];
            }

            [MethodImpl(AggressiveInlining)]
            internal static void Initialize() {
                var count = _actionsCount;
                _actionsCount = 0;
                for (var i = 0; i < count; i++) {
                    _reInitActions[i]();
                }

                BitMapLen = Utils.CalculateMaskLen(_poolsCount);
                _bitMap = new ulong[World.EntitiesCapacity() * BitMapLen];
                BitMaskUtils<WorldID, ITag>.Create(_bitMap, 32, BitMapLen);
            }

            [MethodImpl(AggressiveInlining)]
            internal static void ReInitialize() {
                var newEntityComponentBitMapLen = Utils.CalculateMaskLen(_poolsCount);

                Array.Resize(ref _bitMap, World.EntitiesCapacity() * newEntityComponentBitMapLen);
                for (var i = World._entityVersionsCount - 1; i > 0; i--) {
                    for (var j = BitMapLen - 1; j >= 0; j--) {
                        var idx = i * BitMapLen + j;
                        ref var bits = ref _bitMap[idx];
                        _bitMap[idx + i] = bits;
                        bits = 0UL;
                    }
                }

                BitMapLen = newEntityComponentBitMapLen;
                BitMaskUtils<WorldID, ITag>.SetNewBitMap(_bitMap);
                BitMaskUtils<WorldID, ITag>.ResizeBuffer(BitMapLen);
            }

            internal static void SetBasePoolCapacity<T>(uint capacity) where T : struct, ITag {
                TagInfo<T>.BaseCapacity = capacity;
            }

            internal static void SetBasePoolCapacity(uint capacity) {
                TagInfo.BaseCapacity = capacity;
            }

            [MethodImpl(AggressiveInlining)]
            internal static TagDynId RegisterTag<C>() where C : struct, ITag {
                Assert.Check(World.Status == WorldStatus.Created || World.Status == WorldStatus.Initialized, $"World<{typeof(WorldID)}>, Method: RegisterTag, World not created");
                if (TagInfo<C>.Has()) {
                    return GetDynamicId<C>();
                }

                TagInfo<C>.Register();
                Pool<C>.Create(TagInfo<C>.Id, TagInfo<C>.BaseCapacity ?? TagInfo.BaseCapacity);
                if (_poolsCount == _pools.Length) {
                    Array.Resize(ref _pools, _poolsCount << 1);
                }

                _pools[_poolsCount++] = new PoolWrapper<C>();

                if (_actionsCount == _reInitActions.Length) {
                    Array.Resize(ref _reInitActions, _actionsCount << 1);
                    Array.Resize(ref _resetActions, _actionsCount << 1);
                }

                _reInitActions[TagInfo<C>.Id] = static () => RegisterTag<C>();
                _resetActions[TagInfo<C>.Id] = static () => TagInfo<C>.Reset();
                _actionsCount++;

                if (World.IsInitialized() && _poolsCount % 64 == 0) {
                    ReInitialize();
                }

                return GetDynamicId<C>();
            }

            [MethodImpl(AggressiveInlining)]
            public static IPoolWrapper GetPool(TagDynId id) {
                Assert.Check(World.IsInitialized(), $"World<{typeof(WorldID)}>, Method: GetTagPool, World not initialized");
                return _pools[id.Val];
            }

            [MethodImpl(AggressiveInlining)]
            public static PoolWrapper<T> GetPool<T>() where T : struct, ITag {
                Assert.Check(World.IsInitialized(), $"World<{typeof(WorldID)}>, Method: GetTagPool, World not initialized");
                Assert.Check(TagInfo<T>.Has(), $"World<{typeof(WorldID)}>, Method: GetTagPool, Component not registered");
                return default;
            }

            [MethodImpl(AggressiveInlining)]
            public static TagDynId GetDynamicId<T>() where T : struct, ITag {
                Assert.Check(World.IsInitialized(), $"World<{typeof(WorldID)}>, Method: GetDynamicId, World not initialized");
                return new TagDynId(Pool<T>.Id());
            }

            [MethodImpl(AggressiveInlining)]
            public static ushort TagsCount(Entity entity) {
                Assert.Check(World.IsInitialized(), $"World<{typeof(WorldID)}>, Method: TagsCount, World not initialized");
                return BitMaskUtils<WorldID, ITag>.Len(entity._id);
            }

            [MethodImpl(AggressiveInlining)]
            public static bool HasAllTags(Entity entity, byte allBufId) {
                Assert.Check(World.IsInitialized(), $"World<{typeof(WorldID)}>, Method: HasAllTags, World not initialized");
                return BitMaskUtils<WorldID, ITag>.HasAll(entity._id, allBufId);
            }

            [MethodImpl(AggressiveInlining)]
            public static bool HasAnyTags(Entity entity, byte anyBufId) {
                Assert.Check(World.IsInitialized(), $"World<{typeof(WorldID)}>, Method: HasAnyTags, World not initialized");
                return BitMaskUtils<WorldID, ITag>.HasAny(entity._id, anyBufId);
            }

            [MethodImpl(AggressiveInlining)]
            public static bool NotHasAnyTags(Entity entity, byte excBufId) {
                Assert.Check(World.IsInitialized(), $"World<{typeof(WorldID)}>, Method: NotHasAnyTags, World not initialized");
                return BitMaskUtils<WorldID, ITag>.NotHasAny(entity._id, excBufId);
            }

            [MethodImpl(AggressiveInlining)]
            public static bool HasAllAndExcTags(Entity entity, byte allBufId, byte excBufId) {
                Assert.Check(World.IsInitialized(), $"World<{typeof(WorldID)}>, Method: HasAllAndExcTags, World not initialized");
                return BitMaskUtils<WorldID, ITag>.HasAllAndExc(entity._id, allBufId, excBufId);
            }

            [MethodImpl(AggressiveInlining)]
            internal static void DestroyEntity(Entity entity) {
                var id = BitMaskUtils<WorldID, ITag>.GetMinIndex(entity._id);
                while (id >= 0) {
                    _pools[id].Del(entity);
                    id = BitMaskUtils<WorldID, ITag>.GetMinIndex(entity._id);
                }
            }
            
            [MethodImpl(AggressiveInlining)]
            public static string ToPrettyStringEntity(Entity entity) {
                var str = "Tags:\n";
                var bufId = BitMaskUtils<WorldID, ITag>.BorrowBuf();
                Array.Copy(_bitMap, entity._id * BitMapLen, BitMaskUtils<WorldID, ITag>._buffer, bufId * BitMaskUtils<WorldID, ITag>._len, BitMapLen);
                var id = BitMaskUtils<WorldID, ITag>.GetMinIndexBuffer(bufId);
                while (id >= 0) {
                    str += _pools[id].ToStringComponent(entity);
                    BitMaskUtils<WorldID, ITag>.DelInBuffer(bufId, (ushort) id);
                    id = BitMaskUtils<WorldID, ITag>.GetMinIndexBuffer(bufId);
                }
                BitMaskUtils<WorldID, ITag>.DropBuf(bufId);
                return str;
            }

            [MethodImpl(AggressiveInlining)]
            internal static void CopyEntity(Entity srcEntity, Entity dstEntity) {
                var bufId = BitMaskUtils<WorldID, ITag>.BorrowBuf();
                Array.Copy(_bitMap, srcEntity._id * BitMapLen, BitMaskUtils<WorldID, ITag>._buffer, bufId * BitMaskUtils<WorldID, ITag>._len, BitMapLen);
                var id = BitMaskUtils<WorldID, ITag>.GetMinIndexBuffer(bufId);
                while (id >= 0) {
                    _pools[id].Copy(srcEntity, dstEntity);
                    BitMaskUtils<WorldID, ITag>.Del(bufId, (ushort) id);
                    id = BitMaskUtils<WorldID, ITag>.GetMinIndex(bufId);
                }

                BitMaskUtils<WorldID, ITag>.DropBuf(bufId);
            }

            [MethodImpl(AggressiveInlining)]
            internal static void Resize(int cap) {
                for (int i = 0, iMax = _poolsCount; i < iMax; i++) {
                    _pools[i].Resize(cap);
                }
                Array.Resize(ref _bitMap, cap * BitMapLen);
                BitMaskUtils<WorldID, ITag>.SetNewBitMap(_bitMap);
            }

            [MethodImpl(AggressiveInlining)]
            internal static void SetTagBit(Entity entity, ushort index) {
                BitMaskUtils<WorldID, ITag>.Set(entity._id, index);
            }

            [MethodImpl(AggressiveInlining)]
            internal static void UnsetTagBit(Entity entity, ushort index) {
                BitMaskUtils<WorldID, ITag>.Del(entity._id, index);
            }
            
                        
            [MethodImpl(AggressiveInlining)]
            internal static void Clear() {
                for (var i = 0; i < _poolsCount; i++) {
                    _pools[i].Clear();
                }

                Array.Clear(_bitMap, 0, _bitMap.Length);
            }

            internal static void Destroy() {
                for (var i = 0; i < _poolsCount; i++) {
                    _pools[i].Destroy();
                    _resetActions[i]();
                }

                BitMaskUtils<WorldID, ITag>.Destroy();
                _pools = null;
                _poolsCount = 0;
                _bitMap = null;
                BitMapLen = 0;
                TagCounter.Value = -1;
            }

            #if ENABLE_IL2CPP
            [Il2CppEagerStaticClassConstruction]
            #endif
            private static class TagCounter {
                public static int Value = -1;
            }

            #if ENABLE_IL2CPP
            [Il2CppEagerStaticClassConstruction]
            #endif
            private static class TagInfo {
                public static uint BaseCapacity = 128;
            }

            #if ENABLE_IL2CPP
            [Il2CppEagerStaticClassConstruction]
            #endif
            private static class TagInfo<T> where T : struct, ITag {
                public static ushort Id = ushort.MaxValue;
                public static Type Type;
                public static uint? BaseCapacity;

                public static void Register() {
                    Id = (ushort) Interlocked.Increment(ref TagCounter.Value);
                    Type = typeof(T);
                }

                public static void Reset() {
                    Id = ushort.MaxValue;
                }

                public static bool Has() => Id < ushort.MaxValue;
            }
        }
    }
}
#endif