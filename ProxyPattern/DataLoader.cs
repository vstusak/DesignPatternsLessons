using System;
using System.Collections.Generic;

namespace ProxyPattern
{
    public class DataLoader
    {
        protected DataLoader()
        {
            Console.WriteLine("DataLoader constructor called.");
        }

        public static DataLoader Create()
        {
            return new VirtualProxyDataLoader();
        }

        public virtual IEnumerable<ExpensiveResult> Data1 { get; protected set; }
        public virtual IEnumerable<ExpensiveResult> Data2 { get; protected set; }
    }
}