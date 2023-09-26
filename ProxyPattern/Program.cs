using System;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = DataLoader.Create();
            //var loader = new LazyDataLoader();

            if (true)
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
