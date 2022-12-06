using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_AdapterPattern
{
    public class SQLContextAdapter : IDbClient
    {
        public DataEntity SomeMethod()
        {
            SQLContext context = new SQLContext();
            DataEntity dataEntity = new DataEntity();

            var data = context.LoadData();
            dataEntity.ID = data.SQLID;
            dataEntity.Name = data.Name;
            return dataEntity;
        }
    }
}
