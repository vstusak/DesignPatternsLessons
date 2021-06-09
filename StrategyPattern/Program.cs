using System;
using System.Collections.Generic;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var dressPicker = new DressPicker();

            dressPicker.SetDressWeather(Weather.Sunny);

            Console.WriteLine($"Suggested coat is {dressPicker.GetCoat()}");
            Console.WriteLine($"Suggested hat style is {dressPicker.GetHeadcover()} and glasses");
            Console.WriteLine($"Suggested shoe is {dressPicker.GetShoes()}");
            Console.WriteLine($"Suggested troussers is {dressPicker.GetTroussers()}");

            dressPicker.SetDressWeather(Weather.Rainy);

            Console.WriteLine($"Suggested coat is {dressPicker.GetCoat()}");
            Console.WriteLine($"Suggested hat style is {dressPicker.GetHeadcover()}");
            Console.WriteLine($"Suggested shoe is {dressPicker.GetShoes()}");
            Console.WriteLine($"Suggested troussers is {dressPicker.GetTroussers()}");
        }
    }

    /// <summary>
    /// Weather enum.
    /// </summary>
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

        // c#8
        private readonly Dictionary<Weather, IDressStrategy> strategies = new Dictionary<Weather, IDressStrategy>();

        // c#9
        //private Dictionary<Weather, IDressStrategy> strategies = new();

        /// <summary>
        /// Will create Dresspicker with Sunny weather.
        /// </summary>
        public DressPicker() : this(Weather.Sunny)
        {
        }

        public DressPicker(Weather weather)
        {
            SetDressWeather(weather);
        }

        /// <summary>
        /// Setting weather for dresspicker.
        /// </summary>
        /// <param name="weather">Weather specified</param>
        /// <exception cref="NotImplementedException">Throws when not suported weather selected.</exception>
        public void SetDressWeather(Weather weather)
        {
            if (strategies.ContainsKey(weather))
            {
                _dressStrategy = strategies[weather];
            }
            else
            {
                var strategy = CreateStrategy(weather);
                strategies.Add(weather, strategy);
                _dressStrategy = strategy;
            }
        }

        private IDressStrategy CreateStrategy(Weather weather)
        {
            return weather switch
            {
                Weather.Rainy => new RainyDressStrategy(),
                Weather.Sunny => new SunnyDressStrategy(),
                _ => throw new NotImplementedException("Option not implemented")
            };
        }

        public string GetShoes()
        {
            return _dressStrategy.GetShoes();
        }

        public string GetTroussers()
        {
            return _dressStrategy.GetTroussers();
        }

        public string GetCoat()
        {
            return _dressStrategy.GetCoat();
        }

        public string GetHeadcover()
        {
            return "Coat head cover unsupported";
        }
    }
}
