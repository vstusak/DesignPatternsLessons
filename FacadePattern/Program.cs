using System;
using System.Data;

namespace FacadePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var temperatureConventorService = new TemperatureConventorService();
            var locationLookUpService = new LocationLookUpService();
            var weatherService = new WeatherService();

            var zip = "569878";
            var city = locationLookUpService.GetCity(zip);
            var state = locationLookUpService.GetState(zip);

            var tempF = weatherService.GetFahrenheit(city, state);
            var tempC = temperatureConventorService.ToCelsia(tempF);

            Console.WriteLine($"Wheather for city {city.Name} and state {state.Name} is {tempC}°C/{tempF}°F");
        }
    }
}
