using System;
using System.Collections;
using System.Collections.Generic;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            LazyDataLoader dl = new LazyDataLoader();
            if (false)
            {
                Console.WriteLine(string.Join(", ", dl.Data1));
            } 
            else
            {
                Console.WriteLine(string.Join(", ", dl.Data2));
            }

            Console.ReadLine();
        }
        
    }

    public class LazyDataLoader
    {
        private readonly Lazy<IEnumerable<ExpensiveResult>> _data1;
        private readonly Lazy<IEnumerable<ExpensiveResult>> _data2;

        public IEnumerable<ExpensiveResult> Data1 => _data1.Value;

        public IEnumerable<ExpensiveResult> Data2 => _data2.Value;

        public LazyDataLoader()
        {
            _data1 = new Lazy<IEnumerable<ExpensiveResult>>(() => DataSource.GetEntities());
            _data2 = new Lazy<IEnumerable<ExpensiveResult>>(DataSource.GetEntities);
        }
    }
}
