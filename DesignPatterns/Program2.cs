using System;

namespace StrategyPattern
{
    // podle typu pocasi vybrat obleceni
    // slunecno - zabky, kratasy, tricko, slunecni bryle
    // destivo - holinky, dlouhe kalhoty, bunda, destnik

    // co cast tela, to metoda
    public class Program2
    {
        //private static DressPicker dressPicker;
        public static void Main()
        {
            var dressPicker = new DressPicker();

            var weather = WeatherTypes.Sunny;
            dressPicker.SetWeather(weather);
            Console.WriteLine(GetInfoMessage(dressPicker, weather));

            weather = WeatherTypes.Cloudy;
            dressPicker.SetWeather(weather);
            Console.WriteLine(GetInfoMessage(dressPicker, weather));

            Console.ReadLine();
        }
        private static string GetInfoMessage(DressPicker dressPicker, WeatherTypes weather)
        {
            return $"Today is '{weather}' you need '{dressPicker.GetShoes()}', '{dressPicker.GetPants()}'";
        }

    }
}
