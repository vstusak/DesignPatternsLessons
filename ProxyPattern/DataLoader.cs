using System;
using System.Collections.Generic;

namespace ProxyPattern
{
    public class DataLoader
    {
        protected DataLoader()
        {
            Console.WriteLine("Ctor called");
        }

        public virtual IEnumerable<ExpensiveResult> ExpensiveResults1
        {
            get;
            protected set;
        }

        public virtual IEnumerable<ExpensiveResult> ExpensiveResults2
        {
            get;
            protected set;
        }

        public static DataLoader Create()
        {
            return new VirtualProxyDataLoader();
        }
    }
}
