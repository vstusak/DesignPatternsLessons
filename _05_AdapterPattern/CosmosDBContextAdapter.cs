namespace _05_AdapterPattern
{
    public class CosmosDBContextAdapter : IDbClient
    {
        private CosmosDBContext _dbContext;

        public CosmosDBContextAdapter(CosmosDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DataEntity SomeMethod()
        {
            var data = _dbContext.GetData();
            DataEntity dataEntity = new DataEntity(data);

            return dataEntity;
        }
    }
    public class SolarisDBContextAdapter : IDbClient
    {
        private SolarisContext _dbContext;

        public SolarisDBContextAdapter(SolarisContext dbContext)
        {
            _dbContext = dbContext;
        }

        public DataEntity SomeMethod()
        {
            var data = _dbContext.FindData();
            DataEntity dataEntity = new DataEntity(data);

            return dataEntity;
        }
    }
}