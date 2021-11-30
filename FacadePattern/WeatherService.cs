using FacadePattern.Entities;

namespace FacadePattern
{
    public class WeatherService : IWeatherService
    {
        public int GetFahrenheit(City city, State state)
        {
            return 55;
        }
    }
}