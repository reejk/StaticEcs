using System;
using System.Runtime.CompilerServices;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

namespace FFS.Libraries.StaticEcs {
    public interface ISystemsId { }

    public struct DefaultSystemsId : ISystemsId { }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public abstract partial class Systems<SysID> where SysID : struct, ISystemsId {
        private static Action[] _initChain;
        private static Action[] _destroyChain;
        private static ISystemsBatch[] _runSystems;
        private static ISystem[] _otherSystems;
        private static int _otherSystemsCount;
        private static int _initChainCount;
        private static int _destroyChainCount;
        private static int _runSystemsCount;

        private static uint CurrentSystemIndex;
        private static uint _systemsCount;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Create(uint baseSize = 64) {
            _runSystems = new ISystemsBatch[baseSize];
            _initChain = new Action[baseSize];
            _destroyChain = new Action[baseSize];
            _otherSystems = new ISystem[baseSize];
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddCallOnceSystem<S>() where S : ICallOnceSystem, new() {
            CheckResize();
            var idx = _otherSystemsCount;

            if (typeof(IInitSystem).IsAssignableFrom(typeof(S))) {
                _initChain[_initChainCount++] = () => ((IInitSystem) _otherSystems[idx]).Init();
            }

            if (typeof(IDestroySystem).IsAssignableFrom(typeof(S))) {
                _destroyChain[_destroyChainCount++] = () => ((IDestroySystem) _otherSystems[idx]).Destroy();
            }

            _otherSystems[_otherSystemsCount++] = new S();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddUpdateSystem<S>() where S : IUpdateSystem, new() {
            AddBatchUpdateSystem<SystemsBatch<S>>();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void AddBatchUpdateSystem<S>() where S : struct, ISystemsBatch {
            CheckResize();
            var idx = _runSystemsCount;

            _initChain[_initChainCount++] = () => _runSystems[idx].Init();
            _destroyChain[_destroyChainCount++] = () => _runSystems[idx].Destroy();
            _runSystems[_runSystemsCount] = default(S);
            _systemsCount += _runSystems[_runSystemsCount++].Count();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Initialize() {
            for (var i = 0; i < _initChainCount; i++) {
                _initChain[i]();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Update() {
            for (var i = 0; i < _runSystemsCount; i++) {
                _runSystems[i].Run();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Destroy() {
            for (var i = 0; i < _destroyChainCount; i++) {
                _destroyChain[i]();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetCurrentSystemIndex() {
            return (int) (CurrentSystemIndex % _systemsCount);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static uint IncrementSystemIndex() {
            return CurrentSystemIndex++;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void CheckResize() {
            if (_runSystemsCount == _runSystems.Length) {
                Array.Resize(ref _runSystems, _runSystemsCount << 1);
            }

            if (_initChainCount == _initChain.Length) {
                Array.Resize(ref _initChain, _initChainCount << 1);
            }

            if (_destroyChainCount == _destroyChain.Length) {
                Array.Resize(ref _destroyChain, _destroyChainCount << 1);
            }

            if (_otherSystemsCount == _otherSystems.Length) {
                Array.Resize(ref _otherSystems, _otherSystemsCount << 1);
            }
        }
    }
}