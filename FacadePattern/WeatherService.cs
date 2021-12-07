using FacadePattern.Entities;

namespace FacadePattern
{
    public class WeatherService
        : IWeatherService, IAutoInstall
    {
        public int GetFahrenheit(City city, State state)
        {
            return 55;
        }
    }
}