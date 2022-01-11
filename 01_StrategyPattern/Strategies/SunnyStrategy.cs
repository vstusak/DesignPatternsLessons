using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_StrategyPattern.Strategies
{
    class SunnyStrategy : IWeatherStrategy
    {
        public string Body()
        {
            return "Havajske tricko";
        }

        public string Feet()
        {
            return "Zabky";
        }

        public string Head()
        {
            return "Klobouk";
        }

        public string Legs()
        {
            return "Sortky";
        }
    }
}
