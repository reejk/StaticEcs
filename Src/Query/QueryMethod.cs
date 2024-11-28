namespace FFS.Libraries.StaticEcs {
    
    public interface IPrimaryQueryMethod { }
        
    public interface IQueryMethod {
        public void FillMinData<WorldID>(ref int minCount, ref Ecs<WorldID>.Entity[] entities) where WorldID : struct, IWorldId;
        
        public bool CheckEntity<WorldID>(Ecs<WorldID>.Entity entity) where WorldID : struct, IWorldId;

        public void Dispose<WorldID>() where WorldID : struct, IWorldId;
    }
}