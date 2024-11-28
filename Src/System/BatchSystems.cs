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
    public abstract partial class Systems<SysID> {
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public struct SystemsBatch<
                                   S01, S02, S03, S04, S05, S06, S07, S08,
                                   S09, S10, S11, S12, S13, S14, S15, S16,
                                   S17, S18, S19, S20, S21, S22, S23, S24,
                                   S25, S26, S27, S28, S29, S30, S31, S32,
                                   S33, S34, S35, S36, S37, S38, S39, S40,
                                   S41, S42, S43, S44, S45, S46, S47, S48,
                                   S49, S50, S51, S52, S53, S54, S55, S56,
                                   S57, S58, S59, S60, S61, S62, S63, S64
        > : ISystemsBatch
            where S01 : IUpdateSystem, new() where S02 : IUpdateSystem, new() where S03 : IUpdateSystem, new() where S04 : IUpdateSystem, new() where S05 : IUpdateSystem, new() where S06 : IUpdateSystem, new() where S07 : IUpdateSystem, new() where S08 : IUpdateSystem, new()
            where S09 : IUpdateSystem, new() where S10 : IUpdateSystem, new() where S11 : IUpdateSystem, new() where S12 : IUpdateSystem, new() where S13 : IUpdateSystem, new() where S14 : IUpdateSystem, new() where S15 : IUpdateSystem, new() where S16 : IUpdateSystem, new()
            where S17 : IUpdateSystem, new() where S18 : IUpdateSystem, new() where S19 : IUpdateSystem, new() where S20 : IUpdateSystem, new() where S21 : IUpdateSystem, new() where S22 : IUpdateSystem, new() where S23 : IUpdateSystem, new() where S24 : IUpdateSystem, new()
            where S25 : IUpdateSystem, new() where S26 : IUpdateSystem, new() where S27 : IUpdateSystem, new() where S28 : IUpdateSystem, new() where S29 : IUpdateSystem, new() where S30 : IUpdateSystem, new() where S31 : IUpdateSystem, new() where S32 : IUpdateSystem, new()
            where S33 : IUpdateSystem, new() where S34 : IUpdateSystem, new() where S35 : IUpdateSystem, new() where S36 : IUpdateSystem, new() where S37 : IUpdateSystem, new() where S38 : IUpdateSystem, new() where S39 : IUpdateSystem, new() where S40 : IUpdateSystem, new()
            where S41 : IUpdateSystem, new() where S42 : IUpdateSystem, new() where S43 : IUpdateSystem, new() where S44 : IUpdateSystem, new() where S45 : IUpdateSystem, new() where S46 : IUpdateSystem, new() where S47 : IUpdateSystem, new() where S48 : IUpdateSystem, new()
            where S49 : IUpdateSystem, new() where S50 : IUpdateSystem, new() where S51 : IUpdateSystem, new() where S52 : IUpdateSystem, new() where S53 : IUpdateSystem, new() where S54 : IUpdateSystem, new() where S55 : IUpdateSystem, new() where S56 : IUpdateSystem, new()
            where S57 : IUpdateSystem, new() where S58 : IUpdateSystem, new() where S59 : IUpdateSystem, new() where S60 : IUpdateSystem, new() where S61 : IUpdateSystem, new() where S62 : IUpdateSystem, new() where S63 : IUpdateSystem, new() where S64 : IUpdateSystem, new()
        {
            SW<S01> s01; SW<S02> s02; SW<S03> s03; SW<S04> s04; SW<S05> s05; SW<S06> s06; SW<S07> s07; SW<S08> s08;
            SW<S09> s09; SW<S10> s10; SW<S11> s11; SW<S12> s12; SW<S13> s13; SW<S14> s14; SW<S15> s15; SW<S16> s16;
            SW<S17> s17; SW<S18> s18; SW<S19> s19; SW<S20> s20; SW<S21> s21; SW<S22> s22; SW<S23> s23; SW<S24> s24;
            SW<S25> s25; SW<S26> s26; SW<S27> s27; SW<S28> s28; SW<S29> s29; SW<S30> s30; SW<S31> s31; SW<S32> s32; 
            SW<S33> s33; SW<S34> s34; SW<S35> s35; SW<S36> s36; SW<S37> s37; SW<S38> s38; SW<S39> s39; SW<S40> s40;
            SW<S41> s41; SW<S42> s42; SW<S43> s43; SW<S44> s44; SW<S45> s45; SW<S46> s46; SW<S47> s47; SW<S48> s48;
            SW<S49> s49; SW<S50> s50; SW<S51> s51; SW<S52> s52; SW<S53> s53; SW<S54> s54; SW<S55> s55; SW<S56> s56;
            SW<S57> s57; SW<S58> s58; SW<S59> s59; SW<S60> s60; SW<S61> s61; SW<S62> s62; SW<S63> s63; SW<S64> s64;
    
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Init() {
                s01.Init(); s02.Init(); s03.Init(); s04.Init(); s05.Init(); s06.Init(); s07.Init(); s08.Init();
                s09.Init(); s10.Init(); s11.Init(); s12.Init(); s13.Init(); s14.Init(); s15.Init(); s16.Init();
                s17.Init(); s18.Init(); s19.Init(); s20.Init(); s21.Init(); s22.Init(); s23.Init(); s24.Init(); 
                s25.Init(); s26.Init(); s27.Init(); s28.Init(); s29.Init(); s30.Init(); s31.Init(); s32.Init();
                s33.Init(); s34.Init(); s35.Init(); s36.Init(); s37.Init(); s38.Init(); s39.Init(); s40.Init();
                s41.Init(); s42.Init(); s43.Init(); s44.Init(); s45.Init(); s46.Init(); s47.Init(); s48.Init(); 
                s49.Init(); s50.Init(); s51.Init(); s52.Init(); s53.Init(); s54.Init(); s55.Init(); s56.Init();
                s57.Init(); s58.Init(); s59.Init(); s60.Init(); s61.Init(); s62.Init(); s63.Init(); s64.Init();
            }
    
            [MethodImpl(AggressiveInlining)]
            public void Run() {
                s01.Run(); s02.Run(); s03.Run(); s04.Run(); s05.Run(); s06.Run(); s07.Run(); s08.Run();
                s09.Run(); s10.Run(); s11.Run(); s12.Run(); s13.Run(); s14.Run(); s15.Run(); s16.Run();
                s17.Run(); s18.Run(); s19.Run(); s20.Run(); s21.Run(); s22.Run(); s23.Run(); s24.Run();
                s25.Run(); s26.Run(); s27.Run(); s28.Run(); s29.Run(); s30.Run(); s31.Run(); s32.Run();
                s33.Run(); s34.Run(); s35.Run(); s36.Run(); s37.Run(); s38.Run(); s39.Run(); s40.Run();
                s41.Run(); s42.Run(); s43.Run(); s44.Run(); s45.Run(); s46.Run(); s47.Run(); s48.Run();
                s49.Run(); s50.Run(); s51.Run(); s52.Run(); s53.Run(); s54.Run(); s55.Run(); s56.Run();
                s57.Run(); s58.Run(); s59.Run(); s60.Run(); s61.Run(); s62.Run(); s63.Run(); s64.Run();
            }
            
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Destroy() {
                s01.Destroy(); s02.Destroy(); s03.Destroy(); s04.Destroy(); s05.Destroy(); s06.Destroy(); s07.Destroy(); s08.Destroy();
                s09.Destroy(); s10.Destroy(); s11.Destroy(); s12.Destroy(); s13.Destroy(); s14.Destroy(); s15.Destroy(); s16.Destroy();
                s17.Destroy(); s18.Destroy(); s19.Destroy(); s20.Destroy(); s21.Destroy(); s22.Destroy(); s23.Destroy(); s24.Destroy(); 
                s25.Destroy(); s26.Destroy(); s27.Destroy(); s28.Destroy(); s29.Destroy(); s30.Destroy(); s31.Destroy(); s32.Destroy();
                s33.Destroy(); s34.Destroy(); s35.Destroy(); s36.Destroy(); s37.Destroy(); s38.Destroy(); s39.Destroy(); s40.Destroy();
                s41.Destroy(); s42.Destroy(); s43.Destroy(); s44.Destroy(); s45.Destroy(); s46.Destroy(); s47.Destroy(); s48.Destroy(); 
                s49.Destroy(); s50.Destroy(); s51.Destroy(); s52.Destroy(); s53.Destroy(); s54.Destroy(); s55.Destroy(); s56.Destroy();
                s57.Destroy(); s58.Destroy(); s59.Destroy(); s60.Destroy(); s61.Destroy(); s62.Destroy(); s63.Destroy(); s64.Destroy();
            }
    
            uint ISystemsBatch.Count() => 64;
        }
    
    
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public struct SystemsBatch<
                                   S01, S02, S03, S04, S05, S06, S07, S08,
                                   S09, S10, S11, S12, S13, S14, S15, S16,
                                   S17, S18, S19, S20, S21, S22, S23, S24,
                                   S25, S26, S27, S28, S29, S30, S31, S32,
                                   S33, S34, S35, S36, S37, S38, S39, S40,
                                   S41, S42, S43, S44, S45, S46, S47, S48,
                                   S49, S50, S51, S52, S53, S54, S55, S56
        > : ISystemsBatch
            where S01 : IUpdateSystem, new() where S02 : IUpdateSystem, new() where S03 : IUpdateSystem, new() where S04 : IUpdateSystem, new() where S05 : IUpdateSystem, new() where S06 : IUpdateSystem, new() where S07 : IUpdateSystem, new() where S08 : IUpdateSystem, new()
            where S09 : IUpdateSystem, new() where S10 : IUpdateSystem, new() where S11 : IUpdateSystem, new() where S12 : IUpdateSystem, new() where S13 : IUpdateSystem, new() where S14 : IUpdateSystem, new() where S15 : IUpdateSystem, new() where S16 : IUpdateSystem, new()
            where S17 : IUpdateSystem, new() where S18 : IUpdateSystem, new() where S19 : IUpdateSystem, new() where S20 : IUpdateSystem, new() where S21 : IUpdateSystem, new() where S22 : IUpdateSystem, new() where S23 : IUpdateSystem, new() where S24 : IUpdateSystem, new()
            where S25 : IUpdateSystem, new() where S26 : IUpdateSystem, new() where S27 : IUpdateSystem, new() where S28 : IUpdateSystem, new() where S29 : IUpdateSystem, new() where S30 : IUpdateSystem, new() where S31 : IUpdateSystem, new() where S32 : IUpdateSystem, new()
            where S33 : IUpdateSystem, new() where S34 : IUpdateSystem, new() where S35 : IUpdateSystem, new() where S36 : IUpdateSystem, new() where S37 : IUpdateSystem, new() where S38 : IUpdateSystem, new() where S39 : IUpdateSystem, new() where S40 : IUpdateSystem, new()
            where S41 : IUpdateSystem, new() where S42 : IUpdateSystem, new() where S43 : IUpdateSystem, new() where S44 : IUpdateSystem, new() where S45 : IUpdateSystem, new() where S46 : IUpdateSystem, new() where S47 : IUpdateSystem, new() where S48 : IUpdateSystem, new()
            where S49 : IUpdateSystem, new() where S50 : IUpdateSystem, new() where S51 : IUpdateSystem, new() where S52 : IUpdateSystem, new() where S53 : IUpdateSystem, new() where S54 : IUpdateSystem, new() where S55 : IUpdateSystem, new() where S56 : IUpdateSystem, new()
        {
            SW<S01> s01; SW<S02> s02; SW<S03> s03; SW<S04> s04; SW<S05> s05; SW<S06> s06; SW<S07> s07; SW<S08> s08;
            SW<S09> s09; SW<S10> s10; SW<S11> s11; SW<S12> s12; SW<S13> s13; SW<S14> s14; SW<S15> s15; SW<S16> s16;
            SW<S17> s17; SW<S18> s18; SW<S19> s19; SW<S20> s20; SW<S21> s21; SW<S22> s22; SW<S23> s23; SW<S24> s24;
            SW<S25> s25; SW<S26> s26; SW<S27> s27; SW<S28> s28; SW<S29> s29; SW<S30> s30; SW<S31> s31; SW<S32> s32; 
            SW<S33> s33; SW<S34> s34; SW<S35> s35; SW<S36> s36; SW<S37> s37; SW<S38> s38; SW<S39> s39; SW<S40> s40;
            SW<S41> s41; SW<S42> s42; SW<S43> s43; SW<S44> s44; SW<S45> s45; SW<S46> s46; SW<S47> s47; SW<S48> s48;
            SW<S49> s49; SW<S50> s50; SW<S51> s51; SW<S52> s52; SW<S53> s53; SW<S54> s54; SW<S55> s55; SW<S56> s56;
    
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Init() {
                s01.Init(); s02.Init(); s03.Init(); s04.Init(); s05.Init(); s06.Init(); s07.Init(); s08.Init();
                s09.Init(); s10.Init(); s11.Init(); s12.Init(); s13.Init(); s14.Init(); s15.Init(); s16.Init();
                s17.Init(); s18.Init(); s19.Init(); s20.Init(); s21.Init(); s22.Init(); s23.Init(); s24.Init(); 
                s25.Init(); s26.Init(); s27.Init(); s28.Init(); s29.Init(); s30.Init(); s31.Init(); s32.Init();
                s33.Init(); s34.Init(); s35.Init(); s36.Init(); s37.Init(); s38.Init(); s39.Init(); s40.Init();
                s41.Init(); s42.Init(); s43.Init(); s44.Init(); s45.Init(); s46.Init(); s47.Init(); s48.Init(); 
                s49.Init(); s50.Init(); s51.Init(); s52.Init(); s53.Init(); s54.Init(); s55.Init(); s56.Init();
            }
    
            [MethodImpl(AggressiveInlining)]
            public void Run() {
                s01.Run(); s02.Run(); s03.Run(); s04.Run(); s05.Run(); s06.Run(); s07.Run(); s08.Run();
                s09.Run(); s10.Run(); s11.Run(); s12.Run(); s13.Run(); s14.Run(); s15.Run(); s16.Run();
                s17.Run(); s18.Run(); s19.Run(); s20.Run(); s21.Run(); s22.Run(); s23.Run(); s24.Run();
                s25.Run(); s26.Run(); s27.Run(); s28.Run(); s29.Run(); s30.Run(); s31.Run(); s32.Run();
                s33.Run(); s34.Run(); s35.Run(); s36.Run(); s37.Run(); s38.Run(); s39.Run(); s40.Run();
                s41.Run(); s42.Run(); s43.Run(); s44.Run(); s45.Run(); s46.Run(); s47.Run(); s48.Run();
                s49.Run(); s50.Run(); s51.Run(); s52.Run(); s53.Run(); s54.Run(); s55.Run(); s56.Run();
            }
            
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Destroy() {
                s01.Destroy(); s02.Destroy(); s03.Destroy(); s04.Destroy(); s05.Destroy(); s06.Destroy(); s07.Destroy(); s08.Destroy();
                s09.Destroy(); s10.Destroy(); s11.Destroy(); s12.Destroy(); s13.Destroy(); s14.Destroy(); s15.Destroy(); s16.Destroy();
                s17.Destroy(); s18.Destroy(); s19.Destroy(); s20.Destroy(); s21.Destroy(); s22.Destroy(); s23.Destroy(); s24.Destroy(); 
                s25.Destroy(); s26.Destroy(); s27.Destroy(); s28.Destroy(); s29.Destroy(); s30.Destroy(); s31.Destroy(); s32.Destroy();
                s33.Destroy(); s34.Destroy(); s35.Destroy(); s36.Destroy(); s37.Destroy(); s38.Destroy(); s39.Destroy(); s40.Destroy();
                s41.Destroy(); s42.Destroy(); s43.Destroy(); s44.Destroy(); s45.Destroy(); s46.Destroy(); s47.Destroy(); s48.Destroy(); 
                s49.Destroy(); s50.Destroy(); s51.Destroy(); s52.Destroy(); s53.Destroy(); s54.Destroy(); s55.Destroy(); s56.Destroy();
            }
    
            uint ISystemsBatch.Count() => 56;
        }
    
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public struct SystemsBatch<
                                   S01, S02, S03, S04, S05, S06, S07, S08,
                                   S09, S10, S11, S12, S13, S14, S15, S16,
                                   S17, S18, S19, S20, S21, S22, S23, S24,
                                   S25, S26, S27, S28, S29, S30, S31, S32,
                                   S33, S34, S35, S36, S37, S38, S39, S40,
                                   S41, S42, S43, S44, S45, S46, S47, S48
        > : ISystemsBatch
            where S01 : IUpdateSystem, new() where S02 : IUpdateSystem, new() where S03 : IUpdateSystem, new() where S04 : IUpdateSystem, new() where S05 : IUpdateSystem, new() where S06 : IUpdateSystem, new() where S07 : IUpdateSystem, new() where S08 : IUpdateSystem, new()
            where S09 : IUpdateSystem, new() where S10 : IUpdateSystem, new() where S11 : IUpdateSystem, new() where S12 : IUpdateSystem, new() where S13 : IUpdateSystem, new() where S14 : IUpdateSystem, new() where S15 : IUpdateSystem, new() where S16 : IUpdateSystem, new()
            where S17 : IUpdateSystem, new() where S18 : IUpdateSystem, new() where S19 : IUpdateSystem, new() where S20 : IUpdateSystem, new() where S21 : IUpdateSystem, new() where S22 : IUpdateSystem, new() where S23 : IUpdateSystem, new() where S24 : IUpdateSystem, new()
            where S25 : IUpdateSystem, new() where S26 : IUpdateSystem, new() where S27 : IUpdateSystem, new() where S28 : IUpdateSystem, new() where S29 : IUpdateSystem, new() where S30 : IUpdateSystem, new() where S31 : IUpdateSystem, new() where S32 : IUpdateSystem, new()
            where S33 : IUpdateSystem, new() where S34 : IUpdateSystem, new() where S35 : IUpdateSystem, new() where S36 : IUpdateSystem, new() where S37 : IUpdateSystem, new() where S38 : IUpdateSystem, new() where S39 : IUpdateSystem, new() where S40 : IUpdateSystem, new()
            where S41 : IUpdateSystem, new() where S42 : IUpdateSystem, new() where S43 : IUpdateSystem, new() where S44 : IUpdateSystem, new() where S45 : IUpdateSystem, new() where S46 : IUpdateSystem, new() where S47 : IUpdateSystem, new() where S48 : IUpdateSystem, new()
        {
            SW<S01> s01; SW<S02> s02; SW<S03> s03; SW<S04> s04; SW<S05> s05; SW<S06> s06; SW<S07> s07; SW<S08> s08;
            SW<S09> s09; SW<S10> s10; SW<S11> s11; SW<S12> s12; SW<S13> s13; SW<S14> s14; SW<S15> s15; SW<S16> s16;
            SW<S17> s17; SW<S18> s18; SW<S19> s19; SW<S20> s20; SW<S21> s21; SW<S22> s22; SW<S23> s23; SW<S24> s24;
            SW<S25> s25; SW<S26> s26; SW<S27> s27; SW<S28> s28; SW<S29> s29; SW<S30> s30; SW<S31> s31; SW<S32> s32; 
            SW<S33> s33; SW<S34> s34; SW<S35> s35; SW<S36> s36; SW<S37> s37; SW<S38> s38; SW<S39> s39; SW<S40> s40;
            SW<S41> s41; SW<S42> s42; SW<S43> s43; SW<S44> s44; SW<S45> s45; SW<S46> s46; SW<S47> s47; SW<S48> s48;
    
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Init() {
                s01.Init(); s02.Init(); s03.Init(); s04.Init(); s05.Init(); s06.Init(); s07.Init(); s08.Init();
                s09.Init(); s10.Init(); s11.Init(); s12.Init(); s13.Init(); s14.Init(); s15.Init(); s16.Init();
                s17.Init(); s18.Init(); s19.Init(); s20.Init(); s21.Init(); s22.Init(); s23.Init(); s24.Init(); 
                s25.Init(); s26.Init(); s27.Init(); s28.Init(); s29.Init(); s30.Init(); s31.Init(); s32.Init();
                s33.Init(); s34.Init(); s35.Init(); s36.Init(); s37.Init(); s38.Init(); s39.Init(); s40.Init();
                s41.Init(); s42.Init(); s43.Init(); s44.Init(); s45.Init(); s46.Init(); s47.Init(); s48.Init(); 
            }
    
            [MethodImpl(AggressiveInlining)]
            public void Run() {
                s01.Run(); s02.Run(); s03.Run(); s04.Run(); s05.Run(); s06.Run(); s07.Run(); s08.Run();
                s09.Run(); s10.Run(); s11.Run(); s12.Run(); s13.Run(); s14.Run(); s15.Run(); s16.Run();
                s17.Run(); s18.Run(); s19.Run(); s20.Run(); s21.Run(); s22.Run(); s23.Run(); s24.Run();
                s25.Run(); s26.Run(); s27.Run(); s28.Run(); s29.Run(); s30.Run(); s31.Run(); s32.Run();
                s33.Run(); s34.Run(); s35.Run(); s36.Run(); s37.Run(); s38.Run(); s39.Run(); s40.Run();
                s41.Run(); s42.Run(); s43.Run(); s44.Run(); s45.Run(); s46.Run(); s47.Run(); s48.Run();
            }
            
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Destroy() {
                s01.Destroy(); s02.Destroy(); s03.Destroy(); s04.Destroy(); s05.Destroy(); s06.Destroy(); s07.Destroy(); s08.Destroy();
                s09.Destroy(); s10.Destroy(); s11.Destroy(); s12.Destroy(); s13.Destroy(); s14.Destroy(); s15.Destroy(); s16.Destroy();
                s17.Destroy(); s18.Destroy(); s19.Destroy(); s20.Destroy(); s21.Destroy(); s22.Destroy(); s23.Destroy(); s24.Destroy(); 
                s25.Destroy(); s26.Destroy(); s27.Destroy(); s28.Destroy(); s29.Destroy(); s30.Destroy(); s31.Destroy(); s32.Destroy();
                s33.Destroy(); s34.Destroy(); s35.Destroy(); s36.Destroy(); s37.Destroy(); s38.Destroy(); s39.Destroy(); s40.Destroy();
                s41.Destroy(); s42.Destroy(); s43.Destroy(); s44.Destroy(); s45.Destroy(); s46.Destroy(); s47.Destroy(); s48.Destroy(); 
            }
    
            uint ISystemsBatch.Count() => 48;
        }
    
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public struct SystemsBatch<
                                   S01, S02, S03, S04, S05, S06, S07, S08,
                                   S09, S10, S11, S12, S13, S14, S15, S16,
                                   S17, S18, S19, S20, S21, S22, S23, S24,
                                   S25, S26, S27, S28, S29, S30, S31, S32,
                                   S33, S34, S35, S36, S37, S38, S39, S40
        > : ISystemsBatch
            where S01 : IUpdateSystem, new() where S02 : IUpdateSystem, new() where S03 : IUpdateSystem, new() where S04 : IUpdateSystem, new() where S05 : IUpdateSystem, new() where S06 : IUpdateSystem, new() where S07 : IUpdateSystem, new() where S08 : IUpdateSystem, new()
            where S09 : IUpdateSystem, new() where S10 : IUpdateSystem, new() where S11 : IUpdateSystem, new() where S12 : IUpdateSystem, new() where S13 : IUpdateSystem, new() where S14 : IUpdateSystem, new() where S15 : IUpdateSystem, new() where S16 : IUpdateSystem, new()
            where S17 : IUpdateSystem, new() where S18 : IUpdateSystem, new() where S19 : IUpdateSystem, new() where S20 : IUpdateSystem, new() where S21 : IUpdateSystem, new() where S22 : IUpdateSystem, new() where S23 : IUpdateSystem, new() where S24 : IUpdateSystem, new()
            where S25 : IUpdateSystem, new() where S26 : IUpdateSystem, new() where S27 : IUpdateSystem, new() where S28 : IUpdateSystem, new() where S29 : IUpdateSystem, new() where S30 : IUpdateSystem, new() where S31 : IUpdateSystem, new() where S32 : IUpdateSystem, new()
            where S33 : IUpdateSystem, new() where S34 : IUpdateSystem, new() where S35 : IUpdateSystem, new() where S36 : IUpdateSystem, new() where S37 : IUpdateSystem, new() where S38 : IUpdateSystem, new() where S39 : IUpdateSystem, new() where S40 : IUpdateSystem, new()
        {
            SW<S01> s01; SW<S02> s02; SW<S03> s03; SW<S04> s04; SW<S05> s05; SW<S06> s06; SW<S07> s07; SW<S08> s08;
            SW<S09> s09; SW<S10> s10; SW<S11> s11; SW<S12> s12; SW<S13> s13; SW<S14> s14; SW<S15> s15; SW<S16> s16;
            SW<S17> s17; SW<S18> s18; SW<S19> s19; SW<S20> s20; SW<S21> s21; SW<S22> s22; SW<S23> s23; SW<S24> s24;
            SW<S25> s25; SW<S26> s26; SW<S27> s27; SW<S28> s28; SW<S29> s29; SW<S30> s30; SW<S31> s31; SW<S32> s32; 
            SW<S33> s33; SW<S34> s34; SW<S35> s35; SW<S36> s36; SW<S37> s37; SW<S38> s38; SW<S39> s39; SW<S40> s40;
    
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Init() {
                s01.Init(); s02.Init(); s03.Init(); s04.Init(); s05.Init(); s06.Init(); s07.Init(); s08.Init();
                s09.Init(); s10.Init(); s11.Init(); s12.Init(); s13.Init(); s14.Init(); s15.Init(); s16.Init();
                s17.Init(); s18.Init(); s19.Init(); s20.Init(); s21.Init(); s22.Init(); s23.Init(); s24.Init(); 
                s25.Init(); s26.Init(); s27.Init(); s28.Init(); s29.Init(); s30.Init(); s31.Init(); s32.Init();
                s33.Init(); s34.Init(); s35.Init(); s36.Init(); s37.Init(); s38.Init(); s39.Init(); s40.Init();
            }
    
            [MethodImpl(AggressiveInlining)]
            public void Run() {
                s01.Run(); s02.Run(); s03.Run(); s04.Run(); s05.Run(); s06.Run(); s07.Run(); s08.Run();
                s09.Run(); s10.Run(); s11.Run(); s12.Run(); s13.Run(); s14.Run(); s15.Run(); s16.Run();
                s17.Run(); s18.Run(); s19.Run(); s20.Run(); s21.Run(); s22.Run(); s23.Run(); s24.Run();
                s25.Run(); s26.Run(); s27.Run(); s28.Run(); s29.Run(); s30.Run(); s31.Run(); s32.Run();
                s33.Run(); s34.Run(); s35.Run(); s36.Run(); s37.Run(); s38.Run(); s39.Run(); s40.Run();
            }
            
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Destroy() {
                s01.Destroy(); s02.Destroy(); s03.Destroy(); s04.Destroy(); s05.Destroy(); s06.Destroy(); s07.Destroy(); s08.Destroy();
                s09.Destroy(); s10.Destroy(); s11.Destroy(); s12.Destroy(); s13.Destroy(); s14.Destroy(); s15.Destroy(); s16.Destroy();
                s17.Destroy(); s18.Destroy(); s19.Destroy(); s20.Destroy(); s21.Destroy(); s22.Destroy(); s23.Destroy(); s24.Destroy(); 
                s25.Destroy(); s26.Destroy(); s27.Destroy(); s28.Destroy(); s29.Destroy(); s30.Destroy(); s31.Destroy(); s32.Destroy();
                s33.Destroy(); s34.Destroy(); s35.Destroy(); s36.Destroy(); s37.Destroy(); s38.Destroy(); s39.Destroy(); s40.Destroy();
            }
    
            uint ISystemsBatch.Count() => 40;
        }
    
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public struct SystemsBatch<
                                   S01, S02, S03, S04, S05, S06, S07, S08,
                                   S09, S10, S11, S12, S13, S14, S15, S16,
                                   S17, S18, S19, S20, S21, S22, S23, S24,
                                   S25, S26, S27, S28, S29, S30, S31, S32
        > : ISystemsBatch
            where S01 : IUpdateSystem, new() where S02 : IUpdateSystem, new() where S03 : IUpdateSystem, new() where S04 : IUpdateSystem, new() where S05 : IUpdateSystem, new() where S06 : IUpdateSystem, new() where S07 : IUpdateSystem, new() where S08 : IUpdateSystem, new()
            where S09 : IUpdateSystem, new() where S10 : IUpdateSystem, new() where S11 : IUpdateSystem, new() where S12 : IUpdateSystem, new() where S13 : IUpdateSystem, new() where S14 : IUpdateSystem, new() where S15 : IUpdateSystem, new() where S16 : IUpdateSystem, new()
            where S17 : IUpdateSystem, new() where S18 : IUpdateSystem, new() where S19 : IUpdateSystem, new() where S20 : IUpdateSystem, new() where S21 : IUpdateSystem, new() where S22 : IUpdateSystem, new() where S23 : IUpdateSystem, new() where S24 : IUpdateSystem, new()
            where S25 : IUpdateSystem, new() where S26 : IUpdateSystem, new() where S27 : IUpdateSystem, new() where S28 : IUpdateSystem, new() where S29 : IUpdateSystem, new() where S30 : IUpdateSystem, new() where S31 : IUpdateSystem, new() where S32 : IUpdateSystem, new()
        {
            SW<S01> s01; SW<S02> s02; SW<S03> s03; SW<S04> s04; SW<S05> s05; SW<S06> s06; SW<S07> s07; SW<S08> s08;
            SW<S09> s09; SW<S10> s10; SW<S11> s11; SW<S12> s12; SW<S13> s13; SW<S14> s14; SW<S15> s15; SW<S16> s16;
            SW<S17> s17; SW<S18> s18; SW<S19> s19; SW<S20> s20; SW<S21> s21; SW<S22> s22; SW<S23> s23; SW<S24> s24;
            SW<S25> s25; SW<S26> s26; SW<S27> s27; SW<S28> s28; SW<S29> s29; SW<S30> s30; SW<S31> s31; SW<S32> s32; 
    
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Init() {
                s01.Init(); s02.Init(); s03.Init(); s04.Init(); s05.Init(); s06.Init(); s07.Init(); s08.Init();
                s09.Init(); s10.Init(); s11.Init(); s12.Init(); s13.Init(); s14.Init(); s15.Init(); s16.Init();
                s17.Init(); s18.Init(); s19.Init(); s20.Init(); s21.Init(); s22.Init(); s23.Init(); s24.Init(); 
                s25.Init(); s26.Init(); s27.Init(); s28.Init(); s29.Init(); s30.Init(); s31.Init(); s32.Init();
            }
    
            [MethodImpl(AggressiveInlining)]
            public void Run() {
                s01.Run(); s02.Run(); s03.Run(); s04.Run(); s05.Run(); s06.Run(); s07.Run(); s08.Run();
                s09.Run(); s10.Run(); s11.Run(); s12.Run(); s13.Run(); s14.Run(); s15.Run(); s16.Run();
                s17.Run(); s18.Run(); s19.Run(); s20.Run(); s21.Run(); s22.Run(); s23.Run(); s24.Run();
                s25.Run(); s26.Run(); s27.Run(); s28.Run(); s29.Run(); s30.Run(); s31.Run(); s32.Run();
            }
            
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Destroy() {
                s01.Destroy(); s02.Destroy(); s03.Destroy(); s04.Destroy(); s05.Destroy(); s06.Destroy(); s07.Destroy(); s08.Destroy();
                s09.Destroy(); s10.Destroy(); s11.Destroy(); s12.Destroy(); s13.Destroy(); s14.Destroy(); s15.Destroy(); s16.Destroy();
                s17.Destroy(); s18.Destroy(); s19.Destroy(); s20.Destroy(); s21.Destroy(); s22.Destroy(); s23.Destroy(); s24.Destroy(); 
                s25.Destroy(); s26.Destroy(); s27.Destroy(); s28.Destroy(); s29.Destroy(); s30.Destroy(); s31.Destroy(); s32.Destroy();
            }
    
            uint ISystemsBatch.Count() => 32;
        }
    
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public struct SystemsBatch<
                                   S01, S02, S03, S04, S05, S06, S07, S08,
                                   S09, S10, S11, S12, S13, S14, S15, S16,
                                   S17, S18, S19, S20, S21, S22, S23, S24
        > : ISystemsBatch
            where S01 : IUpdateSystem, new() where S02 : IUpdateSystem, new() where S03 : IUpdateSystem, new() where S04 : IUpdateSystem, new() where S05 : IUpdateSystem, new() where S06 : IUpdateSystem, new() where S07 : IUpdateSystem, new() where S08 : IUpdateSystem, new()
            where S09 : IUpdateSystem, new() where S10 : IUpdateSystem, new() where S11 : IUpdateSystem, new() where S12 : IUpdateSystem, new() where S13 : IUpdateSystem, new() where S14 : IUpdateSystem, new() where S15 : IUpdateSystem, new() where S16 : IUpdateSystem, new()
            where S17 : IUpdateSystem, new() where S18 : IUpdateSystem, new() where S19 : IUpdateSystem, new() where S20 : IUpdateSystem, new() where S21 : IUpdateSystem, new() where S22 : IUpdateSystem, new() where S23 : IUpdateSystem, new() where S24 : IUpdateSystem, new()
        {
            SW<S01> s01; SW<S02> s02; SW<S03> s03; SW<S04> s04; SW<S05> s05; SW<S06> s06; SW<S07> s07; SW<S08> s08;
            SW<S09> s09; SW<S10> s10; SW<S11> s11; SW<S12> s12; SW<S13> s13; SW<S14> s14; SW<S15> s15; SW<S16> s16;
            SW<S17> s17; SW<S18> s18; SW<S19> s19; SW<S20> s20; SW<S21> s21; SW<S22> s22; SW<S23> s23; SW<S24> s24;
    
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Init() {
                s01.Init(); s02.Init(); s03.Init(); s04.Init(); s05.Init(); s06.Init(); s07.Init(); s08.Init();
                s09.Init(); s10.Init(); s11.Init(); s12.Init(); s13.Init(); s14.Init(); s15.Init(); s16.Init();
                s17.Init(); s18.Init(); s19.Init(); s20.Init(); s21.Init(); s22.Init(); s23.Init(); s24.Init(); 
            }
    
            [MethodImpl(AggressiveInlining)]
            public void Run() {
                s01.Run(); s02.Run(); s03.Run(); s04.Run(); s05.Run(); s06.Run(); s07.Run(); s08.Run();
                s09.Run(); s10.Run(); s11.Run(); s12.Run(); s13.Run(); s14.Run(); s15.Run(); s16.Run();
                s17.Run(); s18.Run(); s19.Run(); s20.Run(); s21.Run(); s22.Run(); s23.Run(); s24.Run();
            }
            
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Destroy() {
                s01.Destroy(); s02.Destroy(); s03.Destroy(); s04.Destroy(); s05.Destroy(); s06.Destroy(); s07.Destroy(); s08.Destroy();
                s09.Destroy(); s10.Destroy(); s11.Destroy(); s12.Destroy(); s13.Destroy(); s14.Destroy(); s15.Destroy(); s16.Destroy();
                s17.Destroy(); s18.Destroy(); s19.Destroy(); s20.Destroy(); s21.Destroy(); s22.Destroy(); s23.Destroy(); s24.Destroy(); 
            }
    
            uint ISystemsBatch.Count() => 24;
        }
    
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public struct SystemsBatch<
                                   S01, S02, S03, S04, S05, S06, S07, S08,
                                   S09, S10, S11, S12, S13, S14, S15, S16
        > : ISystemsBatch
            where S01 : IUpdateSystem, new() where S02 : IUpdateSystem, new() where S03 : IUpdateSystem, new() where S04 : IUpdateSystem, new() where S05 : IUpdateSystem, new() where S06 : IUpdateSystem, new() where S07 : IUpdateSystem, new() where S08 : IUpdateSystem, new()
            where S09 : IUpdateSystem, new() where S10 : IUpdateSystem, new() where S11 : IUpdateSystem, new() where S12 : IUpdateSystem, new() where S13 : IUpdateSystem, new() where S14 : IUpdateSystem, new() where S15 : IUpdateSystem, new() where S16 : IUpdateSystem, new()
        {
            SW<S01> s01; SW<S02> s02; SW<S03> s03; SW<S04> s04; SW<S05> s05; SW<S06> s06; SW<S07> s07; SW<S08> s08;
            SW<S09> s09; SW<S10> s10; SW<S11> s11; SW<S12> s12; SW<S13> s13; SW<S14> s14; SW<S15> s15; SW<S16> s16;
    
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Init() {
                s01.Init(); s02.Init(); s03.Init(); s04.Init(); s05.Init(); s06.Init(); s07.Init(); s08.Init();
                s09.Init(); s10.Init(); s11.Init(); s12.Init(); s13.Init(); s14.Init(); s15.Init(); s16.Init();
            }
    
            [MethodImpl(AggressiveInlining)]
            public void Run() {
                s01.Run(); s02.Run(); s03.Run(); s04.Run(); s05.Run(); s06.Run(); s07.Run(); s08.Run();
                s09.Run(); s10.Run(); s11.Run(); s12.Run(); s13.Run(); s14.Run(); s15.Run(); s16.Run();
            }
            
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Destroy() {
                s01.Destroy(); s02.Destroy(); s03.Destroy(); s04.Destroy(); s05.Destroy(); s06.Destroy(); s07.Destroy(); s08.Destroy();
                s09.Destroy(); s10.Destroy(); s11.Destroy(); s12.Destroy(); s13.Destroy(); s14.Destroy(); s15.Destroy(); s16.Destroy();
            }
    
            uint ISystemsBatch.Count() => 16;
        }
    
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public struct SystemsBatch<S01, S02, S03, S04, S05, S06, S07, S08> : ISystemsBatch
            where S01 : IUpdateSystem, new() where S02 : IUpdateSystem, new() where S03 : IUpdateSystem, new() where S04 : IUpdateSystem, new() where S05 : IUpdateSystem, new() where S06 : IUpdateSystem, new() where S07 : IUpdateSystem, new() where S08 : IUpdateSystem, new()
        {
            SW<S01> s01; SW<S02> s02; SW<S03> s03; SW<S04> s04; SW<S05> s05; SW<S06> s06; SW<S07> s07; SW<S08> s08;
    
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Init() {
                s01.Init(); s02.Init(); s03.Init(); s04.Init(); s05.Init(); s06.Init(); s07.Init(); s08.Init();
            }
    
            [MethodImpl(AggressiveInlining)]
            public void Run() {
                s01.Run(); s02.Run(); s03.Run(); s04.Run(); s05.Run(); s06.Run(); s07.Run(); s08.Run();
            }
            
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Destroy() {
                s01.Destroy(); s02.Destroy(); s03.Destroy(); s04.Destroy(); s05.Destroy(); s06.Destroy(); s07.Destroy(); s08.Destroy();
            }
    
            uint ISystemsBatch.Count() => 8;
        }
        
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public struct SystemsBatch<S01, S02, S03, S04, S05, S06, S07> : ISystemsBatch
            where S01 : IUpdateSystem, new() where S02 : IUpdateSystem, new() where S03 : IUpdateSystem, new() where S04 : IUpdateSystem, new() where S05 : IUpdateSystem, new() where S06 : IUpdateSystem, new() where S07 : IUpdateSystem, new() 
        {
            SW<S01> s01; SW<S02> s02; SW<S03> s03; SW<S04> s04; SW<S05> s05; SW<S06> s06; SW<S07> s07;
    
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Init() {
                s01.Init(); s02.Init(); s03.Init(); s04.Init(); s05.Init(); s06.Init(); s07.Init();
            }
    
            [MethodImpl(AggressiveInlining)]
            public void Run() {
                s01.Run(); s02.Run(); s03.Run(); s04.Run(); s05.Run(); s06.Run(); s07.Run();
            }
            
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Destroy() {
                s01.Destroy(); s02.Destroy(); s03.Destroy(); s04.Destroy(); s05.Destroy(); s06.Destroy(); s07.Destroy();
            }
    
            uint ISystemsBatch.Count() => 7;
        }
        
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public struct SystemsBatch<S01, S02, S03, S04, S05, S06> : ISystemsBatch
            where S01 : IUpdateSystem, new() where S02 : IUpdateSystem, new() where S03 : IUpdateSystem, new() where S04 : IUpdateSystem, new() where S05 : IUpdateSystem, new() where S06 : IUpdateSystem, new()
        {
            SW<S01> s01; SW<S02> s02; SW<S03> s03; SW<S04> s04; SW<S05> s05; SW<S06> s06;
    
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Init() {
                s01.Init(); s02.Init(); s03.Init(); s04.Init(); s05.Init(); s06.Init();
            }
    
            [MethodImpl(AggressiveInlining)]
            public void Run() {
                s01.Run(); s02.Run(); s03.Run(); s04.Run(); s05.Run(); s06.Run();
            }
            
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Destroy() {
                s01.Destroy(); s02.Destroy(); s03.Destroy(); s04.Destroy(); s05.Destroy(); s06.Destroy();
            }
    
            uint ISystemsBatch.Count() => 6;
        }
        
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public struct SystemsBatch<S01, S02, S03, S04, S05> : ISystemsBatch
            where S01 : IUpdateSystem, new() where S02 : IUpdateSystem, new() where S03 : IUpdateSystem, new() where S04 : IUpdateSystem, new() where S05 : IUpdateSystem, new()
        {
            SW<S01> s01; SW<S02> s02; SW<S03> s03; SW<S04> s04; SW<S05> s05;
    
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Init() {
                s01.Init(); s02.Init(); s03.Init(); s04.Init(); s05.Init();
            }
    
            [MethodImpl(AggressiveInlining)]
            public void Run() {
                s01.Run(); s02.Run(); s03.Run(); s04.Run(); s05.Run();
            }
            
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Destroy() {
                s01.Destroy(); s02.Destroy(); s03.Destroy(); s04.Destroy(); s05.Destroy();
            }
    
            uint ISystemsBatch.Count() => 5;
        }
        
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public struct SystemsBatch<S01, S02, S03, S04> : ISystemsBatch
            where S01 : IUpdateSystem, new() where S02 : IUpdateSystem, new() where S03 : IUpdateSystem, new() where S04 : IUpdateSystem, new()
        {
            SW<S01> s01; SW<S02> s02; SW<S03> s03; SW<S04> s04;
    
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Init() {
                s01.Init(); s02.Init(); s03.Init(); s04.Init();
            }
    
            [MethodImpl(AggressiveInlining)]
            public void Run() {
                s01.Run(); s02.Run(); s03.Run(); s04.Run();
            }
            
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Destroy() {
                s01.Destroy(); s02.Destroy(); s03.Destroy(); s04.Destroy();
            }
    
            uint ISystemsBatch.Count() => 4;
        }
        
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public struct SystemsBatch<S01, S02, S03> : ISystemsBatch
            where S01 : IUpdateSystem, new() where S02 : IUpdateSystem, new() where S03 : IUpdateSystem, new()
        {
            SW<S01> s01; SW<S02> s02; SW<S03> s03;
    
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Init() {
                s01.Init(); s02.Init(); s03.Init();
            }
    
            [MethodImpl(AggressiveInlining)]
            public void Run() {
                s01.Run(); s02.Run(); s03.Run();
            }
            
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Destroy() {
                s01.Destroy(); s02.Destroy(); s03.Destroy();
            }
    
            uint ISystemsBatch.Count() => 3;
        }
        
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public struct SystemsBatch<S01, S02> : ISystemsBatch
            where S01 : IUpdateSystem, new() where S02 : IUpdateSystem, new()
        {
            SW<S01> s01; SW<S02> s02;
    
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Init() {
                s01.Init(); s02.Init();
            }
    
            [MethodImpl(AggressiveInlining)]
            public void Run() {
                s01.Run(); s02.Run();
            }
            
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Destroy() {
                s01.Destroy(); s02.Destroy();
            }
    
            uint ISystemsBatch.Count() => 2;
        }
        
        #if ENABLE_IL2CPP
        [Il2CppSetOption(Option.NullChecks, false)]
        [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
        #endif
        public struct SystemsBatch<S01> : ISystemsBatch
            where S01 : IUpdateSystem, new()
        {
            SW<S01> s01;

            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Init() {
                s01.Init();
            }
    
            [MethodImpl(AggressiveInlining)]
            public void Run() {
                s01.Run();
            }
            
            [MethodImpl(AggressiveInlining)]
            void ISystemsBatch.Destroy() {
                s01.Destroy();
            }
    
            uint ISystemsBatch.Count() => 1;
        }
    }
}