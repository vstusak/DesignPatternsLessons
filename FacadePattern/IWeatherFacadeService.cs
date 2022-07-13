namespace FacadePattern;

public interface IWeatherFacadeService
{
    WeatherResult GetWeather(string zip);
}