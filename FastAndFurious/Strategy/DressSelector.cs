using Strategy.WeatherStrategies;

namespace Strategy;

public class DressSelector
{
    protected IWeatherStrategy _weatherStrategy;
    protected Dictionary<WeatherType, IWeatherStrategy> _weatherStrategies = new();

    public DressSelector() : this(WeatherType.Hot)
    {
    }

    public DressSelector(WeatherType weatherType)
    {
        ChangeWeather(weatherType);
    }

    public void ChangeWeather(WeatherType weatherType)
    {
        if (_weatherStrategies.TryGetValue(weatherType, out var strategy))
        {
            _weatherStrategy = strategy;
            return;
        }

        _weatherStrategy = weatherType switch
        {
            WeatherType.Cold => new ColdWeatherStrategy(),
            WeatherType.Hot => new HotWeatherStrategy(),
            WeatherType.Rainy => new RainyWeatherStrategy(),
            WeatherType.Windy => new WindyWeatherStrategy(),
            _ => throw new ArgumentException($"WeatherType {weatherType} in not supported")
        };

        _weatherStrategies[weatherType] = _weatherStrategy;
    }

    public string GetHeadDress()
    {
        return _weatherStrategy.GetHeadDress();
    }

    public string GetUpperBodyDress()
    {
        return _weatherStrategy.GetUpperBodyDress();
    }

    public string GetLowerBodyDress()
    {
        return _weatherStrategy.GetLowerBodyDress();
    }

    public string GetDress()
    {
        var headDress = GetHeadDress();
        var upperBodyDress = GetUpperBodyDress();
        var lowerBodyDress = GetLowerBodyDress();
        return $"{headDress}, {upperBodyDress}, {lowerBodyDress}";
    }
}