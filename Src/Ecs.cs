using System.Runtime.CompilerServices;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

namespace FFS.Libraries.StaticEcs {
    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public abstract partial class Ecs<WorldID> where WorldID : struct, IWorldId {
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CreateWorld(EcsConfig cfg) {
            World.Create(cfg);
        }
        
        public static void InitializeWorld() {
            World.Initialize();
        }
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void DestroyWorld() {
            World.Destroy();
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

        public static EcsConfig Default() => new() {
            BaseEntitiesCount = 256,
            BaseDeletedEntitiesCount = 256,
            BaseComponentTypesCount = 64,
            BaseMaskTypesCount = 64,
            BaseTagTypesCount = 64,
            BaseComponentPoolCount = 128,
            BaseTagPoolCount = 128,
        };
    }
}