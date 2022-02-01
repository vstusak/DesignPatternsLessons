using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_StrategyPattern.Strategies
{
    class MistyStrategy : IWeatherStrategy
    {
        public Weather Weather => Weather.Misty;

        public string Body()
        {
            return "Reflexni vesta";
        }

        public string Feet()
        {
            return "Tenisky";
        }

        public string Head()
        {
            return "Celovka";
        }

        public string Legs()
        {
            return "Reflexni kalhoty";
        }
    }
}
