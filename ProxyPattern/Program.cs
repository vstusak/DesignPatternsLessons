using System;
using System.Collections;
using System.Collections.Generic;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            DataLoader dl = new DataLoader();
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

    public class DataLoader
    {

        private IEnumerable<ExpensiveResult> _privateData1;
        private IEnumerable<ExpensiveResult> _privateData2;

        public IEnumerable<ExpensiveResult> Data1
        {
            get
            {
                //return _privateData1 != null ? _privateData1 : _privateData1 = DataSource.GetEntities();
                Console.WriteLine("Data1 has been loaded.");
                return _privateData1 ??= DataSource.GetEntities();
            }
        }
        public IEnumerable<ExpensiveResult> Data2
        {
            get
            {
                Console.WriteLine("Data2 has been loaded.");
                return _privateData2 ??= DataSource.GetEntities();
            }
        }
    }


    public class ExpensiveResult
    {
        public string Text { get; set; }
        public override string ToString()
        {
            return Text;
        }
    }

    public static class DataSource
    {
        public static IEnumerable<ExpensiveResult> GetEntities()
        {
            Console.WriteLine("Getting data from data source.");
            var result = new List<ExpensiveResult>();
            for (var i=1; i<=50; i++)
            {
                result.Add(new ExpensiveResult() { Text = i.ToString() });
            }
            return result;
        }
    }


}
