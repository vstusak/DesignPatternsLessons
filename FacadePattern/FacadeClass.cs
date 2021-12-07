namespace FacadePattern
{

    public class FacadeClass 
        : IFacadeClass, IAutoInstall
    {
        private readonly ITemperatureConventorService temperatureConventorService;
        private readonly ILocationLookUpService locationLookUpService;
        private readonly IWeatherService weatherService;

        public FacadeClass(
            ITemperatureConventorService temperatureConventorService,
            ILocationLookUpService locationLookUpService,
            IWeatherService weatherService)
        {
            this.temperatureConventorService = temperatureConventorService;
            this.locationLookUpService = locationLookUpService;
            this.weatherService = weatherService;
        }

        public WeatherFacadeResult GetWeather(string zip)
        {
            var city = locationLookUpService.GetCity(zip);
            var state = locationLookUpService.GetState(zip);

            var tempF = weatherService.GetFahrenheit(city, state);
            var tempC = temperatureConventorService.ToCelsia(tempF);

            return new WeatherFacadeResult(city, state, tempF, tempC);
        }
    }
}
