﻿#if !FFS_ECS_DISABLE_EVENTS
using System;
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;

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
        public struct Event<E> where E : struct {
            internal int _idx;
                
            [MethodImpl(AggressiveInlining)]
            public Event(int idx) {
                _idx = idx;
            }

            public ref E Value {
                [MethodImpl(AggressiveInlining)]
                get {
                    #if DEBUG
                    if (_idx < 0) throw new Exception($"[ Ecs<{typeof(World)}>.Event<{typeof(E)}>.Value ] event is deleted");
                    #endif
                    return ref Events.Pool<E>.Get(_idx);
                }
            }

            [MethodImpl(AggressiveInlining)]
            public void Suppress() {
                #if DEBUG
                if (_idx < 0) throw new Exception($"[ Ecs<{typeof(World)}>.Event<{typeof(E)}>.Suppress ] event is deleted");
                #endif
                Events.Pool<E>.Del((ushort) _idx);
                _idx = -1;
            }
        }
    }
}
#endif

namespace FFS.Libraries.StaticEcs {
    public interface IEvent { }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct EventDynId : IEquatable<EventDynId> {
        internal readonly ushort Val;
        
        internal EventDynId(ushort val) {
            Val = val;
        }

        [MethodImpl(AggressiveInlining)]
        public bool Equals(EventDynId other) => Val == other.Val;

        [MethodImpl(AggressiveInlining)]
        public override int GetHashCode() => Val;

        [MethodImpl(AggressiveInlining)]
        public override string ToString() => $"EventDynId ID: {Val}";
    }
}