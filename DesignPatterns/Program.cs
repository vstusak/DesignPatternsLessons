using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            var weather = WeatherTypes.Sunny;
            Console.WriteLine(GetInfoMessage(weather));

            weather = WeatherTypes.Cloudy;
            Console.WriteLine(GetInfoMessage(weather));

            Console.ReadLine();
        }

        private static string GetInfoMessage(WeatherTypes weather)
        {
            return $"Today is '{weather.ToString()}' you need '{GetShoes(weather)}', '{GetPants(weather)}'";
        }

        private static string GetPants(WeatherTypes weather)
        {
            switch (weather)
            {
                case WeatherTypes.Sunny:
                    return "kratasy";
                case WeatherTypes.Rainy:
                    return "nepromokave kalhoty";
                case WeatherTypes.Snow:
                    return "oteplovaky";
                case WeatherTypes.Cloudy:
                case WeatherTypes.Hail:
                    return "dlouhe kalhoty";
                case WeatherTypes.Foggy:
                    return "nic";
                default:
                    throw new ArgumentOutOfRangeException(nameof(weather), weather, null);
            }
        }

        public static string GetShoes(WeatherTypes weather)
        {
            switch (weather)
            {
                case WeatherTypes.Sunny:
                    return "zabky";
                case WeatherTypes.Rainy:
                    return "holinky";
                case WeatherTypes.Snow:
                    return "zimni boty";
                case WeatherTypes.Cloudy:
                case WeatherTypes.Hail:
                    return "nepromokave boty";
                case WeatherTypes.Foggy:
                    return "pevna obuv";
                default:
                    throw new ArgumentOutOfRangeException(nameof(weather), weather, null);
            }
        } 
        // podle typu pocasi vybrat obleceni
        // slunecno - zabky, kratasy, tricko, slunecni bryle
        // destivo - holinky, dlouhe kalhoty, bunda, destnik

        // co cast tela, to metoda
    }



    public enum WeatherTypes
    {
        Sunny,
        Rainy,
        Snow,
        Cloudy,
        Hail,
        Foggy
    }
}
