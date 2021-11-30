using FacadePattern.Entities;

namespace FacadePattern
{
    public interface IWeatherService
    {
        int GetFahrenheit(City city, State state);
    }
}