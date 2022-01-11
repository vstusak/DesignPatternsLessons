﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_StrategyPattern.Strategies
{
    class RainyStrategy : IWeatherStrategy
    {
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
    }
}
