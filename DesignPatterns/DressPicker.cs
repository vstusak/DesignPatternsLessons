using System;
using System.Collections.Generic;
using StrategyPattern.DressPickerStrategies;

namespace StrategyPattern
{
    public class DressPicker
    {
        private IDressStrategy _dressStrategy;
        private readonly Dictionary<WeatherTypes,IDressStrategy> _strategies = new();

        public DressPicker() 
            : this(WeatherTypes.Sunny)
        {}

        public IDressStrategy CreateStrategy(WeatherTypes weather)
        {
            return weather switch
            {
                WeatherTypes.Sunny => new SunnyDressStrategy(),
                WeatherTypes.Cloudy => new CloudyDressStrategy(),
                _ => throw new NotImplementedException("sorryjako")
            };
        }

        public DressPicker(WeatherTypes weather)
        {
            SetWeather(weather);
        }

        public void SetWeather(WeatherTypes weather)
        {
            _dressStrategy = _strategies.ContainsKey(weather)
                ? _strategies[weather]
                : _strategies.AddAndReturn(weather, CreateStrategy(weather));
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

    public static class Extensions
    {
        public static TValue AddAndReturn<TKey,TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            dictionary.Add(key,value);
            return dictionary[key];
        }
    }

}
