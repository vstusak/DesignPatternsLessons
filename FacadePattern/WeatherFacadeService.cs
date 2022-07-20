using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    public class WeatherFacadeService : IWeatherFacadeService, IAutoInstall
    {
        private readonly ILocationLookupService _locationLookupService;
        private readonly IWeatherService _weatherService;
        private readonly ITemperatureConverterService _temperatureConverterService;

        public WeatherFacadeService(ILocationLookupService locationLookupService, IWeatherService weatherService, ITemperatureConverterService temperatureConverterService)
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
