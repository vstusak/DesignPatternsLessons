namespace _05_AdapterPattern
{
    public class DataEntity
    {
        public string Name { get; internal set; }
        public int ID { get; internal set; }

        public DataEntity()
        {
        }
        public DataEntity(CosmosDBEntity entity)
        {
            ID = entity.CosmosDBID;
            Name = entity.Name;
        }
        public DataEntity(SolarisEntity entity)
        {
            ID = entity.SolarisID;
            Name = entity.Name;
        }

    }
}