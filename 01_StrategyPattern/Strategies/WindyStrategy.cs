using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_StrategyPattern.Strategies
{
    class WindyStrategy : IWeatherStrategy
    {
        public Weather Weather => Weather.Windy;

        public string Body()
        {
            return "Vetrovka";
        }

        public string Feet()
        {
            return "Botasky";
        }

        public string Head()
        {
            return "Plavecka cepice";
        }

        public string Legs()
        {
            return "Sustaky";
        }
    }
}
