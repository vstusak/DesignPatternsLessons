using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProxyPattern
{
    public class VirtualProxyDataLoader : DataLoader
    {
        public VirtualProxyDataLoader()
        {
            Console.WriteLine($"Constructor [VirtualProxyDataLoader] has been loaded.");
        }

        public override IEnumerable<ExpensiveResult> expensiveResults
        {
            get
            {
                if (base.expensiveResults == null)
                {
                    base.expensiveResults = DataSource.GetEntities();
                }
                return base.expensiveResults;
            }
            protected set
            {
                base.expensiveResults = value;
            }
        }
        
    }
}
