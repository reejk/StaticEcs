using System.Runtime.CompilerServices;
using static System.Runtime.CompilerServices.MethodImplOptions;
#if ENABLE_IL2CPP
using Unity.IL2CPP.CompilerServices;
#endif

namespace FFS.Libraries.StaticEcs {
    
    public interface IQueryWithAdds: IQueryWith {}
    
    public interface IQueryWith {
        public void FillMinData<WorldID>(ref int minComponentsCount, ref Ecs<WorldID>.Entity[] minEntities) where WorldID : struct, IWorldId;

        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId;

        public void Dispose<WorldID>() where WorldID : struct, IWorldId;
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public static class With {
        [MethodImpl(AggressiveInlining)]
        public static With<QM1> Create<QM1>(QM1 qm1) where QM1 : struct, IQueryMethod, IPrimaryQueryMethod {
            return new With<QM1>(qm1);
        }

        [MethodImpl(AggressiveInlining)]
        public static With<QM1, QM2> Create<QM1, QM2>(QM1 qm1, QM2 qm2)
            where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
            where QM2 : struct, IQueryMethod {
            return new With<QM1, QM2>(qm1, qm2);
        }

        [MethodImpl(AggressiveInlining)]
        public static With<QM1, QM2, QM3> Create<QM1, QM2, QM3>(QM1 qm1, QM2 qm2, QM3 qm3)
            where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
            where QM2 : struct, IQueryMethod
            where QM3 : struct, IQueryMethod {
            return new With<QM1, QM2, QM3>(qm1, qm2, qm3);
        }

        [MethodImpl(AggressiveInlining)]
        public static With<QM1, QM2, QM3, QM4> Create<QM1, QM2, QM3, QM4>(QM1 qm1, QM2 qm2, QM3 qm3, QM4 qm4)
            where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
            where QM2 : struct, IQueryMethod
            where QM3 : struct, IQueryMethod
            where QM4 : struct, IQueryMethod {
            return new With<QM1, QM2, QM3, QM4>(qm1, qm2, qm3, qm4);
        }

        [MethodImpl(AggressiveInlining)]
        public static With<QM1, QM2, QM3, QM4, QM5> Create<QM1, QM2, QM3, QM4, QM5>(QM1 qm1, QM2 qm2, QM3 qm3, QM4 qm4, QM5 qm5)
            where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
            where QM2 : struct, IQueryMethod
            where QM3 : struct, IQueryMethod
            where QM4 : struct, IQueryMethod
            where QM5 : struct, IQueryMethod {
            return new With<QM1, QM2, QM3, QM4, QM5>(qm1, qm2, qm3, qm4, qm5);
        }

        [MethodImpl(AggressiveInlining)]
        public static With<QM1, QM2, QM3, QM4, QM5, QM6> Create<QM1, QM2, QM3, QM4, QM5, QM6>(QM1 qm1, QM2 qm2, QM3 qm3, QM4 qm4, QM5 qm5, QM6 qm6)
            where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
            where QM2 : struct, IQueryMethod
            where QM3 : struct, IQueryMethod
            where QM4 : struct, IQueryMethod
            where QM5 : struct, IQueryMethod
            where QM6 : struct, IQueryMethod {
            return new With<QM1, QM2, QM3, QM4, QM5, QM6>(qm1, qm2, qm3, qm4, qm5, qm6);
        }

        [MethodImpl(AggressiveInlining)]
        public static With<QM1, QM2, QM3, QM4, QM5, QM6, QM7> Create<QM1, QM2, QM3, QM4, QM5, QM6, QM7>(
            QM1 qm1, QM2 qm2, QM3 qm3, QM4 qm4, QM5 qm5, QM6 qm6, QM7 qm7
        )
            where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
            where QM2 : struct, IQueryMethod
            where QM3 : struct, IQueryMethod
            where QM4 : struct, IQueryMethod
            where QM5 : struct, IQueryMethod
            where QM6 : struct, IQueryMethod
            where QM7 : struct, IQueryMethod {
            return new With<QM1, QM2, QM3, QM4, QM5, QM6, QM7>(qm1, qm2, qm3, qm4, qm5, qm6, qm7);
        }

        [MethodImpl(AggressiveInlining)]
        public static With<QM1, QM2, QM3, QM4, QM5, QM6, QM7, QM8> Create<QM1, QM2, QM3, QM4, QM5, QM6, QM7, QM8>(
            QM1 qm1, QM2 qm2, QM3 qm3, QM4 qm4, QM5 qm5, QM6 qm6, QM7 qm7, QM8 qm8
        )
            where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
            where QM2 : struct, IQueryMethod
            where QM3 : struct, IQueryMethod
            where QM4 : struct, IQueryMethod
            where QM5 : struct, IQueryMethod
            where QM6 : struct, IQueryMethod
            where QM7 : struct, IQueryMethod
            where QM8 : struct, IQueryMethod {
            return new With<QM1, QM2, QM3, QM4, QM5, QM6, QM7, QM8>(qm1, qm2, qm3, qm4, qm5, qm6, qm7, qm8);
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public readonly struct WithNothing : IQueryWith {
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minComponentsCount, ref Ecs<WorldID>.Entity[] minEntities) where WorldID : struct, IWorldId { }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return true;
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId { }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct With<QM1> : IQueryWith
        where QM1 : struct, IQueryMethod, IPrimaryQueryMethod {
        private QM1 _qm1;

        public With(QM1 qm1) {
            _qm1 = qm1;
        }

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minComponentsCount, ref Ecs<WorldID>.Entity[] minEntities) where WorldID : struct, IWorldId {
            _qm1.FillMinData(ref minComponentsCount, ref minEntities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return _qm1.CheckEntity(entity);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            _qm1.Dispose<WorldID>();
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct With<QM1, QM2> : IQueryWith
        where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
        where QM2 : struct, IQueryMethod {
        private QM1 qm1;
        private QM2 qm2;

        public With(QM1 qm1, QM2 qm2) {
            this.qm1 = qm1;
            this.qm2 = qm2;
        }

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minComponentsCount, ref Ecs<WorldID>.Entity[] minEntities) where WorldID : struct, IWorldId {
            qm1.FillMinData(ref minComponentsCount, ref minEntities);
            qm2.FillMinData(ref minComponentsCount, ref minEntities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return qm1.CheckEntity(entity) && qm2.CheckEntity(entity);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            qm1.Dispose<WorldID>();
            qm2.Dispose<WorldID>();
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct With<QM1, QM2, QM3> : IQueryWith
        where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
        where QM2 : struct, IQueryMethod
        where QM3 : struct, IQueryMethod {
        private QM1 qm1;
        private QM2 qm2;
        private QM3 qm3;

        public With(QM1 qm1, QM2 qm2, QM3 qm3) {
            this.qm1 = qm1;
            this.qm2 = qm2;
            this.qm3 = qm3;
        }

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minComponentsCount, ref Ecs<WorldID>.Entity[] minEntities) where WorldID : struct, IWorldId {
            qm1.FillMinData(ref minComponentsCount, ref minEntities);
            qm2.FillMinData(ref minComponentsCount, ref minEntities);
            qm3.FillMinData(ref minComponentsCount, ref minEntities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return qm1.CheckEntity(entity) && qm2.CheckEntity(entity) && qm3.CheckEntity(entity);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            qm1.Dispose<WorldID>();
            qm2.Dispose<WorldID>();
            qm3.Dispose<WorldID>();
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct With<QM1, QM2, QM3, QM4> : IQueryWith
        where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
        where QM2 : struct, IQueryMethod
        where QM3 : struct, IQueryMethod
        where QM4 : struct, IQueryMethod {
        private QM1 qm1;
        private QM2 qm2;
        private QM3 qm3;
        private QM4 qm4;

        public With(QM1 qm1, QM2 qm2, QM3 qm3, QM4 qm4) {
            this.qm1 = qm1;
            this.qm2 = qm2;
            this.qm3 = qm3;
            this.qm4 = qm4;
        }

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minComponentsCount, ref Ecs<WorldID>.Entity[] minEntities) where WorldID : struct, IWorldId {
            qm1.FillMinData(ref minComponentsCount, ref minEntities);
            qm2.FillMinData(ref minComponentsCount, ref minEntities);
            qm3.FillMinData(ref minComponentsCount, ref minEntities);
            qm4.FillMinData(ref minComponentsCount, ref minEntities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return qm1.CheckEntity(entity) && qm2.CheckEntity(entity) && qm3.CheckEntity(entity) && qm4.CheckEntity(entity);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            qm1.Dispose<WorldID>();
            qm2.Dispose<WorldID>();
            qm3.Dispose<WorldID>();
            qm4.Dispose<WorldID>();
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct With<QM1, QM2, QM3, QM4, QM5> : IQueryWith
        where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
        where QM2 : struct, IQueryMethod
        where QM3 : struct, IQueryMethod
        where QM4 : struct, IQueryMethod
        where QM5 : struct, IQueryMethod {
        private QM1 qm1;
        private QM2 qm2;
        private QM3 qm3;
        private QM4 qm4;
        private QM5 qm5;

        public With(QM1 qm1, QM2 qm2, QM3 qm3, QM4 qm4, QM5 qm5) {
            this.qm1 = qm1;
            this.qm2 = qm2;
            this.qm3 = qm3;
            this.qm4 = qm4;
            this.qm5 = qm5;
        }

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minComponentsCount, ref Ecs<WorldID>.Entity[] minEntities) where WorldID : struct, IWorldId {
            qm1.FillMinData(ref minComponentsCount, ref minEntities);
            qm2.FillMinData(ref minComponentsCount, ref minEntities);
            qm3.FillMinData(ref minComponentsCount, ref minEntities);
            qm4.FillMinData(ref minComponentsCount, ref minEntities);
            qm5.FillMinData(ref minComponentsCount, ref minEntities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return qm1.CheckEntity(entity) && qm2.CheckEntity(entity) && qm3.CheckEntity(entity) && qm4.CheckEntity(entity) && qm5.CheckEntity(entity);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            qm1.Dispose<WorldID>();
            qm2.Dispose<WorldID>();
            qm3.Dispose<WorldID>();
            qm4.Dispose<WorldID>();
            qm5.Dispose<WorldID>();
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct With<QM1, QM2, QM3, QM4, QM5, QM6> : IQueryWith
        where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
        where QM2 : struct, IQueryMethod
        where QM3 : struct, IQueryMethod
        where QM4 : struct, IQueryMethod
        where QM5 : struct, IQueryMethod
        where QM6 : struct, IQueryMethod {
        private QM1 qm1;
        private QM2 qm2;
        private QM3 qm3;
        private QM4 qm4;
        private QM5 qm5;
        private QM6 qm6;

        public With(QM1 qm1, QM2 qm2, QM3 qm3, QM4 qm4, QM5 qm5, QM6 qm6) {
            this.qm1 = qm1;
            this.qm2 = qm2;
            this.qm3 = qm3;
            this.qm4 = qm4;
            this.qm5 = qm5;
            this.qm6 = qm6;
        }

        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minComponentsCount, ref Ecs<WorldID>.Entity[] minEntities) where WorldID : struct, IWorldId {
            qm1.FillMinData(ref minComponentsCount, ref minEntities);
            qm2.FillMinData(ref minComponentsCount, ref minEntities);
            qm3.FillMinData(ref minComponentsCount, ref minEntities);
            qm4.FillMinData(ref minComponentsCount, ref minEntities);
            qm5.FillMinData(ref minComponentsCount, ref minEntities);
            qm6.FillMinData(ref minComponentsCount, ref minEntities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return qm1.CheckEntity(entity) && qm2.CheckEntity(entity) && qm3.CheckEntity(entity) && qm4.CheckEntity(entity) && qm5.CheckEntity(entity) && qm6.CheckEntity(entity);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            qm1.Dispose<WorldID>();
            qm2.Dispose<WorldID>();
            qm3.Dispose<WorldID>();
            qm4.Dispose<WorldID>();
            qm5.Dispose<WorldID>();
            qm6.Dispose<WorldID>();
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct With<QM1, QM2, QM3, QM4, QM5, QM6, QM7> : IQueryWith
        where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
        where QM2 : struct, IQueryMethod
        where QM3 : struct, IQueryMethod
        where QM4 : struct, IQueryMethod
        where QM5 : struct, IQueryMethod
        where QM6 : struct, IQueryMethod
        where QM7 : struct, IQueryMethod {
        private QM1 qm1;
        private QM2 qm2;
        private QM3 qm3;
        private QM4 qm4;
        private QM5 qm5;
        private QM6 qm6;
        private QM7 qm7;

        public With(QM1 qm1, QM2 qm2, QM3 qm3, QM4 qm4, QM5 qm5, QM6 qm6, QM7 qm7) {
            this.qm1 = qm1;
            this.qm2 = qm2;
            this.qm3 = qm3;
            this.qm4 = qm4;
            this.qm5 = qm5;
            this.qm6 = qm6;
            this.qm7 = qm7;
        }
        
        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minComponentsCount, ref Ecs<WorldID>.Entity[] minEntities) where WorldID : struct, IWorldId {
            qm1.FillMinData(ref minComponentsCount, ref minEntities);
            qm2.FillMinData(ref minComponentsCount, ref minEntities);
            qm3.FillMinData(ref minComponentsCount, ref minEntities);
            qm4.FillMinData(ref minComponentsCount, ref minEntities);
            qm5.FillMinData(ref minComponentsCount, ref minEntities);
            qm6.FillMinData(ref minComponentsCount, ref minEntities);
            qm7.FillMinData(ref minComponentsCount, ref minEntities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return qm1.CheckEntity(entity) && qm2.CheckEntity(entity) && qm3.CheckEntity(entity) && qm4.CheckEntity(entity) && qm5.CheckEntity(entity) && qm6.CheckEntity(entity) && qm7.CheckEntity(entity);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            qm1.Dispose<WorldID>();
            qm2.Dispose<WorldID>();
            qm3.Dispose<WorldID>();
            qm4.Dispose<WorldID>();
            qm5.Dispose<WorldID>();
            qm6.Dispose<WorldID>();
            qm7.Dispose<WorldID>();
        }
    }

    #if ENABLE_IL2CPP
    [Il2CppSetOption(Option.NullChecks, false)]
    [Il2CppSetOption(Option.ArrayBoundsChecks, false)]
    #endif
    public struct With<QM1, QM2, QM3, QM4, QM5, QM6, QM7, QM8> : IQueryWith
        where QM1 : struct, IQueryMethod, IPrimaryQueryMethod
        where QM2 : struct, IQueryMethod
        where QM3 : struct, IQueryMethod
        where QM4 : struct, IQueryMethod
        where QM5 : struct, IQueryMethod
        where QM6 : struct, IQueryMethod
        where QM7 : struct, IQueryMethod
        where QM8 : struct, IQueryMethod {
        private QM1 qm1;
        private QM2 qm2;
        private QM3 qm3;
        private QM4 qm4;
        private QM5 qm5;
        private QM6 qm6;
        private QM7 qm7;
        private QM8 qm8;

        public With(QM1 qm1, QM2 qm2, QM3 qm3, QM4 qm4, QM5 qm5, QM6 qm6, QM7 qm7, QM8 qm8) {
            this.qm1 = qm1;
            this.qm2 = qm2;
            this.qm3 = qm3;
            this.qm4 = qm4;
            this.qm5 = qm5;
            this.qm6 = qm6;
            this.qm7 = qm7;
            this.qm8 = qm8;
        }


        [MethodImpl(AggressiveInlining)]
        public void FillMinData<WorldID>(ref int minComponentsCount, ref Ecs<WorldID>.Entity[] minEntities) where WorldID : struct, IWorldId {
            qm1.FillMinData(ref minComponentsCount, ref minEntities);
            qm2.FillMinData(ref minComponentsCount, ref minEntities);
            qm3.FillMinData(ref minComponentsCount, ref minEntities);
            qm4.FillMinData(ref minComponentsCount, ref minEntities);
            qm5.FillMinData(ref minComponentsCount, ref minEntities);
            qm6.FillMinData(ref minComponentsCount, ref minEntities);
            qm7.FillMinData(ref minComponentsCount, ref minEntities);
            qm8.FillMinData(ref minComponentsCount, ref minEntities);
        }

        [MethodImpl(AggressiveInlining)]
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId {
            return qm1.CheckEntity(entity) && qm2.CheckEntity(entity) && qm3.CheckEntity(entity) && qm4.CheckEntity(entity) && qm5.CheckEntity(entity) && qm6.CheckEntity(entity) && qm7.CheckEntity(entity) && qm8.CheckEntity(entity);
        }

        [MethodImpl(AggressiveInlining)]
        public void Dispose<WorldID>() where WorldID : struct, IWorldId {
            qm1.Dispose<WorldID>();
            qm2.Dispose<WorldID>();
            qm3.Dispose<WorldID>();
            qm4.Dispose<WorldID>();
            qm5.Dispose<WorldID>();
            qm6.Dispose<WorldID>();
            qm7.Dispose<WorldID>();
            qm8.Dispose<WorldID>();
        }
    }
}