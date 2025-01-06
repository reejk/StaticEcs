#if !FFS_ECS_DISABLE_EVENTS
using System;
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
    public abstract partial class Ecs<WorldID> {
        public abstract partial class Events {
            #if ENABLE_IL2CPP
            [Il2CppSetOption(Option.NullChecks, false)]
            [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
            [Il2CppEagerStaticClassConstruction]
            #endif
            internal struct Pool<T> where T : struct, IEvent {
                internal static Pool<T> Value;
                internal T[] _data;
                internal int[] _dataReceiverUnreadCount;
                internal int[] _dataReceiverOffsets;
                internal ushort[] _deletedReceivers;
                internal int _dataCount;
                internal int _dataFirstIdx;
                internal ushort _deletedReceiversCount;
                internal ushort _receiversCount;
                internal ushort Id;
                internal bool Initialized;
                
                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                private int _blockers;
                #endif

                [MethodImpl(AggressiveInlining)]
                internal void Create(ushort id) {
                    Id = id;
                    _data = new T[cfg.BaseEventPoolCount];
                    _dataReceiverUnreadCount = new int[cfg.BaseEventPoolCount];
                    _dataFirstIdx = 0;
                    _dataCount = 0;
                    _dataReceiverOffsets = new int[8];
                    _deletedReceivers = new ushort[8];
                    _receiversCount = 0;
                    _deletedReceiversCount = 0;
                    Initialized = true;
                }

                [MethodImpl(AggressiveInlining)]
                internal EventReceiver<WorldID, T> CreateReceiver() {
                    #if DEBUG || FFS_ECS_ENABLE_DEBUG
                    if (_blockers > 0) throw new Exception($"[ Ecs<{typeof(World)}>.Events.Pool<{typeof(T)}>.CreateReceiver ] event pool cannot be changed, it is in read-only mode");
                    #endif
                    for (var i = _dataFirstIdx; i < _dataCount; i++) {
                        _dataReceiverUnreadCount[i]++;
                    }
                    
                    if (_deletedReceiversCount > 0) {
                        var receiver = _deletedReceivers[--_deletedReceiversCount];
                        _dataReceiverOffsets[receiver] = _dataFirstIdx;
                        return new EventReceiver<WorldID, T>(receiver);
                    }
                    
                    if (_receiversCount == _dataReceiverOffsets.Length) {
                        Array.Resize(ref _dataReceiverOffsets, _receiversCount << 1);
                        for (var i = _receiversCount; i < _dataReceiverOffsets.Length; i++) {
                            _dataReceiverOffsets[i] = _dataFirstIdx;
                        }
                    }
                    
                    return new EventReceiver<WorldID, T>(_receiversCount++);
                }
                
                [MethodImpl(AggressiveInlining)]
                internal void DeleteReceiver(ref EventReceiver<WorldID, T> receiver) {
                    #if DEBUG || FFS_ECS_ENABLE_DEBUG
                    if (_blockers > 0) throw new Exception($"[ Ecs<{typeof(World)}>.Events.Pool<{typeof(T)}>.DeleteReceiver ] event pool cannot be changed, it is in read-only mode");
                    #endif
                    if (_deletedReceiversCount == _deletedReceivers.Length) {
                        Array.Resize(ref _deletedReceivers, _deletedReceiversCount << 1);
                    }
                    
                    MarkAsReadAll(receiver._id);

                    _dataReceiverOffsets[receiver._id] = -1;
                    _deletedReceivers[_deletedReceiversCount++] = (ushort) receiver._id;
                    receiver._id = -1;
                }

                [MethodImpl(AggressiveInlining)]
                internal void Destroy() {
                    Initialized = false;
                    _dataReceiverUnreadCount = default;
                    _deletedReceiversCount = default;
                    _dataReceiverOffsets = default;
                    _deletedReceivers = default;
                    _receiversCount = default;
                    _dataFirstIdx = default;
                    _dataCount = default;
                    _data = default;
                    Id = default;
                }
                
                [MethodImpl(AggressiveInlining)]
                internal ref T Get(int idx) {
                    return ref _data[idx];
                }

                [MethodImpl(AggressiveInlining)]
                internal void Add(T value = default) {
                    #if DEBUG || FFS_ECS_ENABLE_DEBUG
                    if (_blockers > 0) throw new Exception($"[ Ecs<{typeof(World)}>.Events.Pool<{typeof(T)}>.Add ] event pool cannot be changed, it is in read-only mode");
                    #endif
                    if (_receiversCount > 0) {
                        if (_dataCount == _data.Length) {
                            Array.Resize(ref _data, _dataCount << 1);
                            Array.Resize(ref _dataReceiverUnreadCount, _dataCount << 1);
                        }
                        _data[_dataCount] = value;
                        _dataReceiverUnreadCount[_dataCount] = _receiversCount;
                        #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
                        if (_debugEventListeners != null) {
                            foreach (var listener in _debugEventListeners) {
                                listener.OnEventAdd(ref value, _dataCount - 1);
                            }
                        }

                        _dataCount++;
                        #endif
                    }
                }
                
                [MethodImpl(AggressiveInlining)]
                internal void Del(int idx) {
                    #if DEBUG || FFS_ECS_ENABLE_DEBUG || FFS_ECS_ENABLE_DEBUG_EVENTS
                    if (_debugEventListeners != null) {
                        foreach (var listener in _debugEventListeners) {
                            listener.OnEventAdd(ref _data[idx], idx);
                        }
                    }
                    #endif
                    _data[idx] = default;
                    _dataReceiverUnreadCount[idx] = 0;
                    
                    if (idx == _dataCount - 1) {
                        _dataCount--;
                        TryDropOffsets();
                        return;
                    }

                    if (_dataFirstIdx + 4 >= idx) {
                        while (idx >= _dataFirstIdx) {
                            _data[idx] = _data[--idx];
                        }
                    } else if (idx != _dataFirstIdx) {
                        Array.Copy(_data, _dataFirstIdx, _data, _dataFirstIdx + 1, idx - _dataFirstIdx);
                    }

                    _dataFirstIdx++;
                    if (TryDropOffsets()) {
                        return;
                    }
                    
                    for (var i = 0; i < _receiversCount; i++) {
                        ref var offset = ref _dataReceiverOffsets[i];
                        if (offset >= 0 && offset < _dataFirstIdx) {
                            offset = _dataFirstIdx;
                        }
                    }
                }
                
                [MethodImpl(AggressiveInlining)]
                internal bool ShiftReceiverOffset(int receiverId, int previous, out int next) {
                    if (previous >= 0) {
                        ref var unreadCount = ref _dataReceiverUnreadCount[previous];
                        if (unreadCount != 0 && --unreadCount == 0) {
                            _data[previous] = default;
                            _dataFirstIdx++;
                            if (TryDropOffsets()) {
                                next = -1;
                                return false;
                            }
                        }
                    }
                    
                    ref var offset = ref _dataReceiverOffsets[receiverId];
                    if (offset < _dataCount) {
                        next = offset++;
                        return true;
                    }

                    next = -1;
                    return false;
                }
                
                [MethodImpl(AggressiveInlining)]
                internal void MarkAsReadAll(int receiverId) {
                    ref var offset = ref _dataReceiverOffsets[receiverId];
                    for (; offset < _dataCount; offset++) {
                        ref var unreadCount = ref _dataReceiverUnreadCount[offset];
                        if (unreadCount != 0 && --unreadCount == 0) {
                            _data[offset] = default;
                            _dataFirstIdx++;
                            if (TryDropOffsets()) {
                                return;
                            }
                        }
                    }
                }

                [MethodImpl(AggressiveInlining)]
                internal void ClearEvents(int receiverId) {
                    ref var offset = ref _dataReceiverOffsets[receiverId];
                    for (; offset < _dataCount; offset++) {
                        Del(offset);
                    }
                }

                [MethodImpl(AggressiveInlining)]
                private bool TryDropOffsets() {
                    if (_dataFirstIdx == _dataCount) {
                        _dataFirstIdx = 0;
                        _dataCount = 0;
                        for (var i = 0; i < _receiversCount; i++) {
                            ref var offset = ref _dataReceiverOffsets[i];
                            if (offset > 0) {
                                offset = 0;
                            }
                        }

                        return true;
                    }

                    return false;
                }

                #if DEBUG || FFS_ECS_ENABLE_DEBUG
                [MethodImpl(AggressiveInlining)]
                internal void AddBlocker(int val) {
                    _blockers += val;
                }
                
                [MethodImpl(AggressiveInlining)]
                internal bool IsBlocked() {
                    return _blockers > 0;
                }
                #endif
            }
        }
    }
}
#endif