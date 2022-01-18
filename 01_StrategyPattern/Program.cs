using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_StrategyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var dressPicker = new DressPicker();
            Console.WriteLine($"Obleceni: {dressPicker}");

            dressPicker.SetStrategy(Weather.Sunny);
            Console.WriteLine($"Obleceni: {dressPicker}");            
        }
    }
}
