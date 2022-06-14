using System;
using System.Collections.Generic;

namespace ProxyPattern
{
    public class LazyDataLoader
    {
        private readonly Lazy<IEnumerable<ExpensiveResult>> _expensiveResults1;
        private readonly Lazy<IEnumerable<ExpensiveResult>> _expensiveResults2;

        public IEnumerable<ExpensiveResult> ExpensiveResults1 => _expensiveResults1.Value;

        public IEnumerable<ExpensiveResult> ExpensiveResults2 => _expensiveResults2.Value;


        public LazyDataLoader()
        {
            Console.WriteLine("Lazy constructor called...");
            _expensiveResults1 = new Lazy<IEnumerable<ExpensiveResult>>(DataSource.GetEntities);
            _expensiveResults2 = new Lazy<IEnumerable<ExpensiveResult>>(DataSource.GetEntities);
        }
    }
}
