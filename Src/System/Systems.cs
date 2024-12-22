using System;
using System.Collections.Generic;
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
        private static ISystemsBatch[] _batchSystems;
        private static (ISystem system, short order)[] _allSystems;
        private static int _allSystemsCount;
        private static int _batchSystemsCount;

        private static uint _currentSystemIndex;
        private static uint _updateSystemsCount;

        [MethodImpl(AggressiveInlining)]
        public static void Create(uint baseSize = 64) {
            _batchSystems = new ISystemsBatch[baseSize];
            _allSystems = new (ISystem, short)[baseSize];
        }

        [MethodImpl(AggressiveInlining)]
        public static void AddCallOnceSystem<S>(short order = 0) where S : ICallOnceSystem, new() {
            if (_allSystemsCount == _allSystems.Length) {
                Array.Resize(ref _allSystems, _allSystemsCount << 1);
            }
            _allSystems[_allSystemsCount++] = (new S(), order);
        }

        [MethodImpl(AggressiveInlining)]
        public static void AddUpdateSystem<S>(short order = 0) where S : IUpdateSystem, new() {
            AddBatchUpdateSystem<SystemsBatch<S>>(order);
        }

        [MethodImpl(AggressiveInlining)]
        public static void AddBatchUpdateSystem<S>(short order = 0) where S : struct, ISystemsBatch {
            if (_allSystemsCount == _allSystems.Length) {
                Array.Resize(ref _allSystems, _allSystemsCount << 1);
            }
            _allSystems[_allSystemsCount++] = (new S(), order);
        }

        [MethodImpl(AggressiveInlining)]
        public static void Initialize() {
            Array.Sort(_allSystems, 0, _allSystemsCount, Comparer<(ISystem, short order)>.Create((a, b) => a.order.CompareTo(b.order)));
            
            for (var i = 0; i < _allSystemsCount; i++) {
                var system = _allSystems[i].system;
                if (system is IInitSystem initSystem) {
                    #if DEBUG
                    EcsDebugLogger.Info($"Init: {initSystem.GetType().GetGenericName()}");
                    #endif
                    initSystem.Init();
                }
                if (system is ISystemsBatch batch) {
                    #if DEBUG
                    EcsDebugLogger.Info($"Init: {batch.GetType().GetGenericName()}");
                    #endif
                    batch.Init();
                    
                    if (_batchSystemsCount == _batchSystems.Length) {
                        Array.Resize(ref _batchSystems, _batchSystemsCount << 1);
                    }

                    _batchSystems[_batchSystemsCount++] = batch;
                    _updateSystemsCount += batch.Count();
                }
            }
        }

        [MethodImpl(AggressiveInlining)]
        public static void Update() {
            for (var i = 0; i < _batchSystemsCount; i++) {
                _batchSystems[i].Run();
            }
        }

        [MethodImpl(AggressiveInlining)]
        public static void Destroy() {
            for (var i = 0; i < _allSystemsCount; i++) {
                var system = _allSystems[i].system;
                if (system is IDestroySystem destroySystem) {
                    destroySystem.Destroy();
                }
                if (system is ISystemsBatch batch) {
                    batch.Destroy();
                }
            }
            
            _batchSystems = default;
            _allSystems = default;
            _allSystemsCount = default;
            _batchSystemsCount = default;
            _currentSystemIndex = default;
            _updateSystemsCount = default;
        }

        [MethodImpl(AggressiveInlining)]
        public static int GetCurrentUpdateSystemIndex() {
            return (int) (_currentSystemIndex % _updateSystemsCount);
        }
        
        [MethodImpl(AggressiveInlining)]
        public static uint GetUpdateSystemsCount() {
            return _updateSystemsCount;
        }

        [MethodImpl(AggressiveInlining)]
        internal static void IncrementSystemIndex() {
            _currentSystemIndex++;
        }
    }
}