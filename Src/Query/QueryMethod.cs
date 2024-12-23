namespace FFS.Libraries.StaticEcs {
    
    public interface IQueryMethod {
        public void SetData<WorldID>(ref int minCount, ref int[] entities) where WorldID : struct, IWorldId;
        
        public bool CheckEntity(int entityId);

        public void Dispose<WorldID>() where WorldID : struct, IWorldId;
    }
    
    public interface IPrimaryQueryMethod : IQueryMethod { }
    
    public interface ISealedQueryMethod : IQueryMethod { }
}