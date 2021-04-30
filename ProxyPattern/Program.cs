using System;
using System.Linq;

namespace ProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var loader = new DataLoader();

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
