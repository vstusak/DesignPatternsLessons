namespace Strategy.WeatherStrategies
{
    internal class RainyWeatherStrategy : IWeatherStrategy
    {
        public string GetHeadDress()
        {
            return "Hood";
        }

        public string GetUpperBodyDress()
        {
            return "Raincoat";
        }

        public string GetLowerBodyDress()
        {
            return "Swimsuit";
        }

        public bool CanProcess(WeatherType weatherType)
        {
            return weatherType == WeatherType.Rainy;
        }
    }
}
