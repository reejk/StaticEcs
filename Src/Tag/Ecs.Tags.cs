#if !FFS_ECS_DISABLE_TAGS
using System;
using System.Collections.Generic;
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
        internal abstract class ModuleTags {
            #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
            internal static List<ITagDebugEventListener> _debugEventListeners;
            #endif

            internal static BitMask BitMask;
            
            private static ulong[] _bitMap;
            private static ITagsWrapper[] _pools;
            private static Dictionary<Type, int> _poolsByType;
            private static Action[] _resetActions;
            private static Action[] _reInitActions;
            private static ushort _actionsCount;
            private static ushort _poolsCount;
            private static ushort BitMapLen;

            [MethodImpl(AggressiveInlining)]
            internal static void Create(uint baseComponentsCapacity) {
                _pools = new ITagsWrapper[baseComponentsCapacity];
                _poolsByType = new Dictionary<Type, int>();
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
                BitMask ??= new BitMask();
                BitMask.Create(_bitMap, 32, BitMapLen);
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
                BitMask.SetNewBitMap(_bitMap);
                BitMask.ResizeBuffer(BitMapLen);
            }

            internal static void SetBasePoolCapacity<T>(uint capacity) where T : struct, ITag {
                TagInfo<T>.BaseCapacity = capacity;
            }

            internal static void SetBasePoolCapacity(uint capacity) {
                TagInfo.BaseCapacity = capacity;
            }

            [MethodImpl(AggressiveInlining)]
            internal static TagDynId RegisterTag<C>() where C : struct, ITag {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (World.Status == WorldStatus.NotCreated) throw new Exception($"World<{typeof(WorldID)}>, Method: RegisterTag, World not created");
                #endif
                if (TagInfo<C>.Has()) {
                    return Tags<C>.Value.DynamicId();
                }
                
                BitMask ??= new BitMask();

                TagInfo<C>.Register(_poolsCount);
                Tags<C>.Value.Create(_poolsCount, BitMask, TagInfo<C>.BaseCapacity ?? TagInfo.BaseCapacity);
                
                if (_poolsCount == _pools.Length) {
                    Array.Resize(ref _pools, _poolsCount << 1);
                }
                
                if (_actionsCount == _reInitActions.Length) {
                    Array.Resize(ref _reInitActions, _actionsCount << 1);
                    Array.Resize(ref _resetActions, _actionsCount << 1);
                }

                _pools[_poolsCount] = new TagsWrapper<C>();
                _poolsByType[typeof(C)] = _poolsCount;
                _reInitActions[_poolsCount] = static () => RegisterTag<C>();
                _resetActions[_poolsCount] = static () => TagInfo<C>.Reset();

                _actionsCount++;
                _poolsCount++;

                if (World.IsInitialized() && _poolsCount % 64 == 0) {
                    ReInitialize();
                }

                return Tags<C>.Value.DynamicId();
            }

            [MethodImpl(AggressiveInlining)]
            internal static ITagsWrapper GetPool(TagDynId id) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: GetTagPool, World not initialized");
                #endif
                return _pools[id.Val];
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static ITagsWrapper GetPool(Type tagType) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: GetTagPool, World not initialized");
                #endif
                return _pools[_poolsByType[tagType]];
            }

            [MethodImpl(AggressiveInlining)]
            internal static TagsWrapper<T> GetPool<T>() where T : struct, ITag {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: GetTagPool, World not initialized");
                #endif
                return default;
            }

            [MethodImpl(AggressiveInlining)]
            internal static ushort TagsCount(Entity entity) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: TagsCount, World not initialized");
                #endif
                return BitMask.Len(entity._id);
            }

            [MethodImpl(AggressiveInlining)]
            internal static void DestroyEntity(Entity entity) {
                var id = BitMask.GetMinIndex(entity._id);
                while (id >= 0) {
                    _pools[id].Del(entity);
                    id = BitMask.GetMinIndex(entity._id);
                }
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static string ToPrettyStringEntity(Entity entity) {
                var str = "Tags:\n";
                var bufId = BitMask.BorrowBuf();
                Array.Copy(_bitMap, entity._id * BitMapLen, BitMask._buffer, bufId * BitMask._len, BitMapLen);
                var id = BitMask.GetMinIndexBuffer(bufId);
                while (id >= 0) {
                    str += _pools[id].ToStringComponent(entity);
                    BitMask.DelInBuffer(bufId, (ushort) id);
                    id = BitMask.GetMinIndexBuffer(bufId);
                }
                BitMask.DropBuf(bufId);
                return str;
            }
            
            [MethodImpl(AggressiveInlining)]
            internal static void GetAllTags(Entity entity, List<ITag> result) {
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                if (!World.IsInitialized()) throw new Exception($"World<{typeof(WorldID)}>, Method: GetAllTags, World not initialized");
                #endif
                result.Clear();
                var bufId = BitMask.BorrowBuf();
                Array.Copy(_bitMap, entity._id * BitMapLen, BitMask._buffer, bufId * BitMask._len, BitMapLen);
                var id = BitMask.GetMinIndexBuffer(bufId);
                while (id >= 0) {
                    result.Add(_pools[id].GetRaw());
                    BitMask.DelInBuffer(bufId, (ushort) id);
                    id = BitMask.GetMinIndexBuffer(bufId);
                }
                BitMask.DropBuf(bufId);
            }

            [MethodImpl(AggressiveInlining)]
            internal static void CopyEntity(Entity srcEntity, Entity dstEntity) {
                var bufId = BitMask.BorrowBuf();
                Array.Copy(_bitMap, srcEntity._id * BitMapLen, BitMask._buffer, bufId * BitMask._len, BitMapLen);
                var id = BitMask.GetMinIndexBuffer(bufId);
                while (id >= 0) {
                    _pools[id].Copy(srcEntity, dstEntity);
                    BitMask.Del(bufId, (ushort) id);
                    id = BitMask.GetMinIndex(bufId);
                }

                BitMask.DropBuf(bufId);
            }

            [MethodImpl(AggressiveInlining)]
            internal static void Resize(int cap) {
                for (int i = 0, iMax = _poolsCount; i < iMax; i++) {
                    _pools[i].Resize(cap);
                }
                Array.Resize(ref _bitMap, cap * BitMapLen);
                BitMask.SetNewBitMap(_bitMap);
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

                BitMask.Destroy();
                BitMask = default;
                _pools = default;
                _poolsByType = default;
                _poolsCount = default;
                _bitMap = default;
                BitMapLen = default;
                #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
                _debugEventListeners = default;
                #endif
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
                public static uint? BaseCapacity;

                public static void Register(ushort val) {
                    Id = val;
                }

                public static void Reset() {
                    Id = ushort.MaxValue;
                }

                public static bool Has() => Id < ushort.MaxValue;
            }
        }
        
        #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
        public interface ITagDebugEventListener {
            void OnTagAdd<T>(Entity entity) where T : struct, ITag;
            void OnTagDelete<T>(Entity entity) where T : struct, ITag;
        }
        #endif

    }
    
    public struct DeleteTagsSystem<WorldId, T> : IUpdateSystem where T : struct, ITag where WorldId : struct, IWorldId {
        [MethodImpl(AggressiveInlining)]
        public void Update() {
            Ecs<WorldId>.World.QueryEntities.For<TagAll<T>>().DeleteTagForAll<T>();
        }
    }
}
#endif