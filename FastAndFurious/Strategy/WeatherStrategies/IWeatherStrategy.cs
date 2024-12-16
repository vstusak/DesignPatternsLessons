namespace Strategy.WeatherStrategies
{
    public interface IWeatherStrategy
    {
        string GetHeadDress();
        string GetUpperBodyDress();
        string GetLowerBodyDress();
        bool CanProcess(WeatherType weatherType);
    }
}
