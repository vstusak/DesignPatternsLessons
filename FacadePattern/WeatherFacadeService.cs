using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    public class WeatherFacadeService
    {
        private readonly LocationLookupService _locationLookupService;
        private readonly WeatherService _weatherService;
        private readonly TemperatureConverterService _temperatureConverterService;

        public WeatherFacadeService(LocationLookupService locationLookupService, WeatherService weatherService, TemperatureConverterService temperatureConverterService)
        {
            _locationLookupService = locationLookupService;
            _weatherService = weatherService;
            _temperatureConverterService = temperatureConverterService;
        }

        public WeatherResult GetWeather(string zip)
        {
            var result = new WeatherResult();

            result.City = _locationLookupService.GetCity(zip);
            result.State = _locationLookupService.GetState(zip);
            result.Fahrenheit = _weatherService.GetFahrenheit(result.City, result.State);
            result.Celsius = _temperatureConverterService.ToCelsius(result.Fahrenheit);

            return result;
        }
    }
}
