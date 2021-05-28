using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var dressPicker = new DressPicker();

            dressPicker.SetDressStrategy(new SunnyDressStrategy());

            Console.WriteLine($"Suggested coat is {dressPicker.GetCoat()}");
            Console.WriteLine($"Suggested hat style is {dressPicker.GetHeadcover()}");
            Console.WriteLine($"Suggested shoe is {dressPicker.GetShoes()}");
            Console.WriteLine($"Suggested troussers is {dressPicker.GetTroussers()}");            
        }
    }

    public enum Weather
    {
        Rainy,
        Sunny,
        Snowy,
        Windy
    }    

    public class DressPicker
    {    
        private IDressStrategy _dressStrategy;

        public void SetDressStrategy(IDressStrategy strategy)
        {
            _dressStrategy = strategy;
        }

        public string GetShoes()
        {
            return _dressStrategy.GetShoes();
        }

        public string GetTroussers ()
        {
            return _dressStrategy.GetTroussers();
        }

        public string GetCoat ()
        {
            return _dressStrategy.GetCoat();
        }

        public string GetHeadcover ()
        {
            return "Coat head cover unsupported";
        }

      }
}
