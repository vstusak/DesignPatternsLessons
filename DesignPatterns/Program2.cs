using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns
{
    // podle typu pocasi vybrat obleceni
    // slunecno - zabky, kratasy, tricko, slunecni bryle
    // destivo - holinky, dlouhe kalhoty, bunda, destnik

    // co cast tela, to metoda
    public class Program2
    {
        //private static DressPicker dressPicker;
        static void Main(string[] args)
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
            return $"Today is '{weather.ToString()}' you need '{dressPicker.GetShoes()}', '{dressPicker.GetPants()}'";
        }

    }
}
