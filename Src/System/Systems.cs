using System;
using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;
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

        private static uint _currentSystemIndex;
        private static uint _systemsCount;

        [MethodImpl(AggressiveInlining)]
        public static void Create(uint baseSize = 64) {
            _runSystems = new ISystemsBatch[baseSize];
            _initChain = new Action[baseSize];
            _destroyChain = new Action[baseSize];
            _otherSystems = new ISystem[baseSize];
        }

        [MethodImpl(AggressiveInlining)]
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

        [MethodImpl(AggressiveInlining)]
        public static void AddUpdateSystem<S>() where S : IUpdateSystem, new() {
            AddBatchUpdateSystem<SystemsBatch<S>>();
        }

        [MethodImpl(AggressiveInlining)]
        public static void AddBatchUpdateSystem<S>() where S : struct, ISystemsBatch {
            CheckResize();
            var idx = _runSystemsCount;

            _initChain[_initChainCount++] = () => _runSystems[idx].Init();
            _destroyChain[_destroyChainCount++] = () => _runSystems[idx].Destroy();
            _runSystems[_runSystemsCount] = default(S);
            _systemsCount += _runSystems[_runSystemsCount++].Count();
        }

        [MethodImpl(AggressiveInlining)]
        public static void Initialize() {
            for (var i = 0; i < _initChainCount; i++) {
                _initChain[i]();
            }
        }

        [MethodImpl(AggressiveInlining)]
        public static void Update() {
            for (var i = 0; i < _runSystemsCount; i++) {
                _runSystems[i].Run();
            }
        }

        [MethodImpl(AggressiveInlining)]
        public static void Destroy() {
            for (var i = 0; i < _destroyChainCount; i++) {
                _destroyChain[i]();
            }
            
            _initChain = default;
            _destroyChain = default;
            _runSystems = default;
            _otherSystems = default;
            _otherSystemsCount = default;
            _initChainCount = default;
            _destroyChainCount = default;
            _runSystemsCount = default;
            _currentSystemIndex = default;
            _systemsCount = default;
        }

        [MethodImpl(AggressiveInlining)]
        public static int GetCurrentSystemIndex() {
            return (int) (_currentSystemIndex % _systemsCount);
        }
        
        [MethodImpl(AggressiveInlining)]
        public static uint GetSystemsCount() {
            return _systemsCount;
        }

        [MethodImpl(AggressiveInlining)]
        internal static void IncrementSystemIndex() {
            _currentSystemIndex++;
        }

        [MethodImpl(AggressiveInlining)]
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