using System;
using System.Collections.Generic;

namespace ProxyPattern
{
    internal class VirtualProxyDataLoader : DataLoader
    {
        public override IEnumerable<ExpensiveResult> ExpensiveResults1
        {
            get
            {
                base.ExpensiveResults1 ??= DataSource.GetEntities();
                Console.WriteLine("expensiveResults1 loaded");

                return base.ExpensiveResults1;
            }
            protected set => base.ExpensiveResults1 = value;
        }

        public override IEnumerable<ExpensiveResult> ExpensiveResults2
        {
            get
            {
                base.ExpensiveResults2 ??= DataSource.GetEntities();
                Console.WriteLine("expensiveResults2 loaded");

                return base.ExpensiveResults2;
            }
            protected set => base.ExpensiveResults2 = value;
        }


    }
}