using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyPattern
{
    public class DataLoader
    {
        private IEnumerable<ExpensiveResult> expensiveResults1;
        private IEnumerable<ExpensiveResult> expensiveResults2;

        public DataLoader()
        {
            Console.WriteLine("Ctor called");
        }

        public IEnumerable<ExpensiveResult> ExpensiveResults1
        {
            get
            {
                expensiveResults1 ??= DataSource.GetEntities();
                Console.WriteLine("expensiveResults1 loaded");

                return expensiveResults1;
            }
            set => expensiveResults1 = value;
        }

        public IEnumerable<ExpensiveResult> ExpensiveResults2
        {
            get
            {
                expensiveResults2 ??= DataSource.GetEntities();
                Console.WriteLine("expensiveResults2 loaded");

                return expensiveResults2;
            }
            set => expensiveResults2 = value;
        }

        public DataLoader Create()
        {
            return new VirtualProxyDataLoader();
        }
    }
}
