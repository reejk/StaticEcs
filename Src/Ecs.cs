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
    public abstract partial class Ecs<WorldID> where WorldID : struct, IWorldId {
        internal static EcsConfig cfg;

        [MethodImpl(AggressiveInlining)]
        public static void Create(EcsConfig config) {
            cfg = config;
            World.Create();
            #if !FFS_ECS_DISABLE_EVENTS
            Events.Create();
            #endif
        }
        
        public static void Initialize() {
            World.Initialize();
        }
        
        [MethodImpl(AggressiveInlining)]
        public static void Destroy() {
            #if !FFS_ECS_DISABLE_EVENTS
            Events.Destroy();
            #endif
            World.Destroy();
        }
        
        [MethodImpl(AggressiveInlining)]
        public static void SetLoggerMethods(Action<string> InfoMethod, Action<string> WarnMethod) {
            DebugLogger.InfoMethod = InfoMethod;
            DebugLogger.WarnMethod = WarnMethod;
        }
        
        internal static class DebugLogger {
            private const string InfoText = "[INFO] ";
            private const string WarnText = "[WARN] ";
            
            internal static Action<string> InfoMethod = static s => {
                Console.Write(InfoText);
                Console.WriteLine(s);
            };
            internal static Action<string> WarnMethod = static s => {
                Console.Write(WarnText);
                Console.WriteLine(s);
            };
            
            [MethodImpl(AggressiveInlining)]
            internal static void Info(string msg) {
                InfoMethod(msg);
            }
        
            [MethodImpl(AggressiveInlining)]
            internal static void Warn(string msg) {
                WarnMethod(msg);
            }
        }
    }
    
    public struct EcsConfig {
        public uint BaseEntitiesCount;
        public uint BaseDeletedEntitiesCount;
        public uint BaseComponentTypesCount;
        public uint BaseMaskTypesCount;
        public uint BaseTagTypesCount;
        public uint BaseComponentPoolCount;
        public uint BaseTagPoolCount;
        public uint BaseEventPoolCount;

        public static EcsConfig Default() => new() {
            BaseEntitiesCount = 256,
            BaseDeletedEntitiesCount = 256,
            BaseComponentTypesCount = 64,
            BaseMaskTypesCount = 64,
            BaseTagTypesCount = 64,
            BaseComponentPoolCount = 128,
            BaseTagPoolCount = 128,
            BaseEventPoolCount = 32,
        };
    }
}