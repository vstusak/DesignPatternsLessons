using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AdapterPattern
{
    public class CosmosDBContextAdapter : IDbClient
    {
        public DataEntity SomeMethod()
        {
            CosmosDBContext context = new CosmosDBContext();
            DataEntity dataEntity = new DataEntity();

            var data = context.GetData();
            dataEntity.ID = data.CosmosDBID;
            dataEntity.Name = data.Name;
            return dataEntity;
        }
    }
}