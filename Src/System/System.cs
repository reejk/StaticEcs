using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

namespace FFS.Libraries.StaticEcs {

    public interface ISystem { }
    public interface ICallOnceSystem : ISystem { }

    public interface IInitSystem : ICallOnceSystem {
        public void Init();
    }

    public interface IUpdateSystem : ISystem {
        public void Update();
    }

    public interface IDestroySystem : ICallOnceSystem {
        public void Destroy();
    }
    
    public interface ISystemsBatch {
        public void Run();
        internal void Init();
        internal void Destroy();
        internal uint Count();
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public abstract partial class Systems<SysID> {
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        internal struct SW<TSystem>
            where TSystem : IUpdateSystem, new() {
            internal TSystem System;

            [MethodImpl(AggressiveInlining)]
            public void Init() {
                System = new TSystem();
                if (System is IInitSystem system) {
                    system.Init();
                    System = (TSystem) system;
                }
            }

            [MethodImpl(AggressiveInlining)]
            public void Run() {
                System.Update();
                IncrementSystemIndex();
            }

            [MethodImpl(AggressiveInlining)]
            public void Destroy() {
                if (System is IDestroySystem system) {
                    system.Destroy();
                    System = (TSystem) system;
                }
            }
        }
    }
}