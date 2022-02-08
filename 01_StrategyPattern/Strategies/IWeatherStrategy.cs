﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_StrategyPattern.Strategies
{
    public interface IWeatherStrategy
    {
        Weather Weather { get; }
        string Feet();
        string Body();
        string Legs();
        string Head();


        bool IsApplicable(Weather weather);
    }
}
