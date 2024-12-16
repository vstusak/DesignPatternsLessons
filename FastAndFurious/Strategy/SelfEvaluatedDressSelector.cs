using Strategy.WeatherStrategies;

namespace Strategy;

public class SelfEvaluatedDressSelector : DressSelector
{
    public SelfEvaluatedDressSelector()
    {
        base._weatherStrategies = new()
        {
            { WeatherType.Cold, new ColdWeatherStrategy() },
            { WeatherType.Hot, new HotWeatherStrategy() },
            { WeatherType.Rainy, new RainyWeatherStrategy() },
            { WeatherType.Windy, new WindyWeatherStrategy() }
        };
    }

    public string GetDress(WeatherType weatherType)
    {
        var weatherStrategy = base._weatherStrategies.First(ws => ws.Value.CanProcess(weatherType)).Value;
        base._weatherStrategy = weatherStrategy;
        return base.GetDress();
    }
}