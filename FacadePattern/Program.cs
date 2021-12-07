using System;
using Castle.Windsor;

namespace FacadePattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Install(new FacadeInstaller());

            var zip = "569878";
            //var city = locationLookUpService.GetCity(zip);
            //var state = locationLookUpService.GetState(zip);

            //var tempF = weatherService.GetFahrenheit(city, state);
            //var tempC = temperatureConventorService.ToCelsia(tempF);
            
            var facade = container.Resolve<IFacadeClass>();
            var result = facade.GetWeather(zip);

            Console.WriteLine($"Wheather for city {result.City.Name} " +
                $"and state {result.State.Name} is {result.TempC}°C/{result.TempF}°F");
        }
    }
}
