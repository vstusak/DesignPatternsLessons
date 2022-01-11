using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_StrategyPattern.Strategies
{
    class TornadoStrategy : IWeatherStrategy
    {
        public string Body()
        {
            return "Chainmail";
        }

        public string Feet()
        {
            return "Vezenska koule";
        }

        public string Head()
        {
            return "Kotva";
        }

        public string Legs()
        {
            return "Kratasy";
        }
    }
}
