using _01_StrategyPattern.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_StrategyPattern
{
    public class DressPicker
    {
        private IWeatherStrategy _strategy;
        //private readonly Dictionary<Weather, IWeatherStrategy> _strategies = new Dictionary<Weather, IWeatherStrategy>();
        private readonly List<IWeatherStrategy> _listOfStrategies = new List<IWeatherStrategy>() { new SunnyStrategy(), new WindyStrategy(),
            new RainyStrategy(), new SnowyStrategy(), new TornadoStrategy(), new MistyStrategy() };


        public DressPicker() : this(Weather.Snowy)
        {
        }
        public DressPicker(Weather weather)
        {
            SetStrategy(weather);
        }

        public void SetStrategy(Weather weather)
        {
            foreach (var strategy in _listOfStrategies)
            {
                //TODO implement IsApplicable() method
                if (strategy.IsApplicable(weather))
                {
                    _strategy = strategy;
                }

                //if (strategy.Weather == weather)
                //{
                //    _strategy = strategy;
                //}
            }
            //if (_strategies.ContainsKey(weather))
            //{
            //    _strategy = _strategies[weather];
            //}
            //else
            //{
            //    switch (weather)
            //    {
            //        case Weather.Sunny:
            //            _strategy = new SunnyStrategy();
            //            break;
            //        case Weather.Windy:
            //            _strategy = new WindyStrategy();
            //            break;
            //        case Weather.Rainy:
            //            _strategy = new RainyStrategy();
            //            break;
            //        case Weather.Snowy:
            //            _strategy = new SnowyStrategy();
            //            break;
            //        case Weather.Tornado:
            //            _strategy = new TornadoStrategy();
            //            break;
            //        case Weather.Misty:
            //            _strategy = new MistyStrategy();
            //            break;
            //        default:
            //            throw new NotSupportedException();
            //    }
            //    _strategies.Add(weather, _strategy);
            //}

        }
        public string Head()
        {
            return _strategy.Head();

            #region Switch (weather)
            //    switch (weather)
            //    {
            //        case Weather.Sunny:
            //            return "Klobouk";
            //        case Weather.Windy:
            //            return "Plavecka cepice";
            //        case Weather.Rainy:
            //            return "Rybarsky klobouk";
            //        case Weather.Snowy:
            //            return "Kulich";
            //        case Weather.Tornado:
            //            return "Kotva";
            //        case Weather.Misty:
            //            return "Celovka";
            //        default:
            //            throw new NotSupportedException();
            //    }
            #endregion Switch (weather)
        }

        public string Feet()
        {
            return _strategy.Feet();
        }

        public string Body()
        {
            return _strategy.Body();
        }

        public string Legs()
        {
            return _strategy.Legs();
        }

        public override string ToString()
        {
            return $"{Head()}, {Feet()}, {Body()}, {Legs()}";
        }
    }
}
