using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_StrategyPattern.Strategies
{
    class SnowyStrategy : IWeatherStrategy
    {
        public string Body()
        {
            return "Svetr";
        }

        public string Feet()
        {
            return "Snehule";
        }

        public string Head()
        {
            return "Kulich";
        }

        public string Legs()
        {
            return "Oteplovacky";
        }
    }
}
