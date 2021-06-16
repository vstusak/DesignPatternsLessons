using System;
using System.Collections.Generic;

namespace ProxyPattern
{
    public class VirtualProxyDataLoader : DataLoader
    {
        public override IEnumerable<ExpensiveResult> Data1
        {
            get
            {
                //return _privateData1 != null ? _privateData1 : _privateData1 = DataSource.GetEntities();
                Console.WriteLine("Data1 has been loaded.");
                return base.Data1 ??= DataSource.GetEntities();
            }

            protected set => base.Data1 = value;
        }
        public override IEnumerable<ExpensiveResult> Data2
        {
            get
            {
                Console.WriteLine("Data2 has been loaded.");
                return base.Data2 ??= DataSource.GetEntities();
            }

            protected set => base.Data2 = value;
        }

        public VirtualProxyDataLoader()
        {
            Console.WriteLine("VirtualProxyDataLoader constructor called.");
        }
    }
}