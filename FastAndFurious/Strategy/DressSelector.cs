namespace Strategy;

public class DressSelector
{
    public string GetHeadDress(WeatherType weatherType)
    {
        return weatherType switch
        {
            WeatherType.Hot => "Sunglasses",
            WeatherType.Cold => "Beanie",
            WeatherType.Rainy => "Hood",
            WeatherType.Windy => "AntiWindyBeanie",
            _ => throw new ArgumentException($"WeatherType {weatherType} in not supported")
        };
    }

    public string GetUpperBodyDress(WeatherType weatherType)
    {
        return weatherType switch
        {
            WeatherType.Hot => "Nothing",
            WeatherType.Cold => "Jacket",
            WeatherType.Rainy => "Raincoat",
            WeatherType.Windy => "Windbreaker",
            _ => throw new ArgumentException($"WeatherType {weatherType} in not supported")
        };
    }

    public string GetLowerBodyDress(WeatherType weatherType)
    {
        return weatherType switch
        {
            WeatherType.Hot => "Nothing",
            WeatherType.Cold => "Trousers",
            WeatherType.Rainy => "Swimsuit",
            WeatherType.Windy => "AntiWindyTrousers",
            _ => throw new ArgumentException($"WeatherType {weatherType} in not supported")
        };
    }
}