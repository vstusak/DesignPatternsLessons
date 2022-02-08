using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_StrategyPattern.Strategies
{
    class RainyStrategy : IWeatherStrategy
    {
        public Weather Weather => Weather.Rainy;

        public string Body()
        {
            return "Plastenka";
        }

        public string Feet()
        {
            return "Gumaky";
        }

        public string Head()
        {
            return "Rybarsky klobouk";
        }

        public string Legs()
        {
            return "Rybarske kalhoty";
        }
        public bool IsApplicable(Weather weather)
        {
            return weather == Weather;
        }
    }
}
