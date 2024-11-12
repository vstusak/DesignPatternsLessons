using System.Diagnostics;
using Strategy.WeatherStrategies;

namespace Strategy;

public class DressSelector
{
    private IWeatherStrategy _weatherStrategy;

    public DressSelector(WeatherType weatherType)
    {
        _weatherStrategy = weatherType switch
        {
            WeatherType.Cold => new ColdWeatherStrategy(),
            WeatherType.Hot => new HotWeatherStrategy(),
            WeatherType.Rainy => new RainyWeatherStrategy(),
            WeatherType.Windy => new WindyWeatherStrategy(),
            //WeatherType.Undefined => throw new ArgumentException($"WeatherType {weatherType} in not supported"),
            _ => throw new ArgumentException($"WeatherType {weatherType} in not supported")
        };
    }

    private string GetHeadDress(WeatherType weatherType)
    {
        //return weatherType switch
        //{
        //    WeatherType.Hot => "Sunglasses",
        //    WeatherType.Cold => "Beanie",
        //    WeatherType.Rainy => "Hood",
        //    WeatherType.Windy => "AntiWindyBeanie",
        //    _ => throw new ArgumentException($"WeatherType {weatherType} in not supported")
        //};
    }

    private string GetUpperBodyDress(WeatherType weatherType)
    {
        //return weatherType switch
        //{
        //    WeatherType.Hot => "T-Shirt",
        //    WeatherType.Cold => "Jacket",
        //    WeatherType.Rainy => "Raincoat",
        //    WeatherType.Windy => "Windbreaker",
        //    _ => throw new ArgumentException($"WeatherType {weatherType} in not supported")
        //};
    }

    private string GetLowerBodyDress(WeatherType weatherType)
    {
        //return weatherType switch
        //{
        //    WeatherType.Hot => "Shorts",
        //    WeatherType.Cold => "Trousers",
        //    WeatherType.Rainy => "Swimsuit",
        //    WeatherType.Windy => "AntiWindyTrousers",
        //    _ => throw new ArgumentException($"WeatherType {weatherType} in not supported")
        //};
    }

    public string GetDress(WeatherType weatherType)
    {


        //var headDress = GetHeadDress(weatherType);
        //var upperBodyDress = GetUpperBodyDress(weatherType);
        //var lowerBodyDress = GetLowerBodyDress(weatherType);
        //var dress = $"{headDress}, {upperBodyDress}, {lowerBodyDress}";
        //return dress;
    }
}