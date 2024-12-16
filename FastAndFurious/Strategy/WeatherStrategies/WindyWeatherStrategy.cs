namespace Strategy.WeatherStrategies
{
    internal class WindyWeatherStrategy : IWeatherStrategy
    {
        public string GetHeadDress()
        {
            return "AntiWindyBeanie";
        }

        public string GetUpperBodyDress()
        {
            return "Windbreaker";
        }

        public string GetLowerBodyDress()
        {
            return "AntiWindyTrousers";
        }

        public bool CanProcess(WeatherType weatherType)
        {
            return weatherType == WeatherType.Windy;
        }
    }
}
