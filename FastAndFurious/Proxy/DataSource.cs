using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    public class DataSource
    {
        public static IEnumerable<ExpensiveResult> GetEntities()
        {
            Console.WriteLine("Getting data from data source.");
            var result = new List<ExpensiveResult>();
            for (var i = 1; i <= 50; i++)
            {
                result.Add(new ExpensiveResult() { Text = i.ToString() });
            }
            return result;
        }
    }
}
