using System;
using System.Linq;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //var loader = DataLoader.Create();
            var loader = new LazyDataLoader();

            if (false)
            {
                var results = string.Join(' ', loader.ExpensiveResults1);

                Console.WriteLine(results);
            }
            else
            {
                //
            }

            Console.ReadLine();
        }
    }
}
