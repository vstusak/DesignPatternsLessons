﻿namespace StrategyPattern.DressPickerStrategies
{
    public class SunnyDressStrategy : IDressStrategy
    {
        public string SuggestPants()
        {
            return "kratasy";
        }

        public string SuggestShoes()
        {
            return "zabky";
        }
    }

}
