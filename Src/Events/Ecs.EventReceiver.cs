#if !FFS_ECS_DISABLE_EVENTS
using System;
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;

namespace FFS.Libraries.StaticEcs {
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct EventReceiver<WorldID, T> where T : struct where WorldID : struct, IWorldId {
        internal int _id;

        [MethodImpl(AggressiveInlining)]
        internal EventReceiver(int id) {
            _id = id;
        }
            
        [MethodImpl(AggressiveInlining)]
        public void MarkAsReadAll() {
            #if DEBUG
            if (_id < 0) throw new Exception($"[ Ecs<{typeof(WorldID)}>.EventReceiver<{typeof(T)}>.MarkAsReadAll ] receiver is deleted");
            #endif
            Ecs<WorldID>.Events.Pool<T>.MarkAsReadAll(_id);
        }
            
        [MethodImpl(AggressiveInlining)]
        public void SuppressAll() {
            #if DEBUG
            if (_id < 0) throw new Exception($"[ Ecs<{typeof(WorldID)}>.EventReceiver<{typeof(T)}>.SuppressAll ] receiver is deleted");
            #endif
            Ecs<WorldID>.Events.Pool<T>.ClearEvents(_id);
        }

        [MethodImpl(AggressiveInlining)]
        public Ecs<WorldID>.EventIterator<T> GetEnumerator() {
            #if DEBUG
            if (_id < 0) throw new Exception($"[ Ecs<{typeof(WorldID)}>.EventReceiver<{typeof(T)}>.GetEnumerator ] receiver is deleted");
            if (Ecs<WorldID>.Events.Pool<T>.IsBlocked()) throw new Exception($"[ Ecs<{typeof(WorldID)}>.EventReceiver<{typeof(T)}>.GetEnumerator ] event pool is blocked");
            #endif
            return new Ecs<WorldID>.EventIterator<T>(_id);
        }
    }
    
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public abstract partial class Ecs<WorldID> {
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public ref struct EventIterator<T> where T : struct {
            private Event<T> _current;
            internal readonly int _id;

            [MethodImpl(AggressiveInlining)]
            internal EventIterator(int id) {
                _id = id;
                _current = new Event<T>(-1);
                Events.Pool<T>.AddBlocker(1);
            }

            public Event<T> Current {
                [MethodImpl(AggressiveInlining)] get => _current;
            }

            [MethodImpl(AggressiveInlining)]
            public bool MoveNext() => Events.Pool<T>.ShiftReceiverOffset(_id, _current._idx, out _current._idx);
            
            #if DEBUG
            [MethodImpl(AggressiveInlining)]
            public void Dispose() {
                Events.Pool<T>.AddBlocker(-1);
            }
            #endif
        }
    }
}
#endif