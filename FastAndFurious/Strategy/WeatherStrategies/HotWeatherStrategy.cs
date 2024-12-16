namespace Strategy.WeatherStrategies
{
    internal class HotWeatherStrategy : IWeatherStrategy
    {
        public string GetHeadDress()
        {
            return "Sunglasses";
        }

        public string GetUpperBodyDress()
        {
            return "T-Shirt";
        }

        public string GetLowerBodyDress()
        {
            return "Shorts";
        }

        public bool CanProcess(WeatherType weatherType)
        {
            return weatherType == WeatherType.Hot;
        }
    }
}
