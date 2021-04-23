using System;

namespace DesignPatterns
{
    public class DressPicker
    {
        private IDressStrategy _dressStrategy;

        public DressPicker() 
            : this(WeatherTypes.Sunny)
        {}

        public DressPicker(WeatherTypes weather)
        {
            SetWeather(weather);
        }

        public void SetWeather(WeatherTypes weather)
        {
            switch (weather)
            {
                case WeatherTypes.Sunny:
                    _dressStrategy = new SunnyDressStrategy();
                    break;
                case WeatherTypes.Cloudy:
                    _dressStrategy = new CloudyDressStrategy();
                    break;
                default:
                    throw new NotImplementedException("sorry");
            }
        }

        public string GetShoes()
        {
            return _dressStrategy.SuggestShoes();
        }

        public string GetPants()
        {
            return _dressStrategy.SuggestPants();
        }

    }

}
