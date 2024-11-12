namespace Strategy.WeatherStrategies
{
    internal class ColdWeatherStrategy : IWeatherStrategy
    {
        public string GetHeadDress()
        {
            return "Beanie";
        }

        public string GetUpperBodyDress()
        {
            return "Jacket";
        }

        public string GetLowerBodyDress()
        {
            return "Trousers";
        }
    }
}
