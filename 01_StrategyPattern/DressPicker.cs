using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_StrategyPattern
{
    public class DressPicker
    {
        public string Head(Weather weather)
        {
            switch (weather)
            {
                case Weather.Sunny:
                    return "Klobouk";
                case Weather.Windy:
                    return "Plavecka cepice";
                case Weather.Rainy:
                    return "Rybarsky klobouk";
                case Weather.Snowy:
                    return "Kulich";
                case Weather.Tornado:
                    return "Kotva";
                case Weather.Misty:
                    return "Celovka";
                default:
                    throw new NotSupportedException();
            }
        }

        public string Feet(Weather weather)
        {
            switch (weather)
            {
                case Weather.Sunny:
                    return "Zabky";
                case Weather.Windy:
                    return "Botasky";
                case Weather.Rainy:
                    return "Gumaky";
                case Weather.Snowy:
                    return "Snehule";
                case Weather.Tornado:
                    return "Vezenska koule";
                case Weather.Misty:
                    return "Tenisky";
                default:
                    throw new NotSupportedException();
            }
        }

        public string Body(Weather weather)
        {
            switch (weather)
            {
                case Weather.Sunny:
                    return "Havajske tricko";
                case Weather.Windy:
                    return "Vetrovka";
                case Weather.Rainy:
                    return "Plastenka";
                case Weather.Snowy:
                    return "Svetr";
                case Weather.Tornado:
                    return "Chainmail";
                case Weather.Misty:
                    return "Reflexni vesta";
                default:
                    throw new NotSupportedException();
            }
        }

        public string Legs(Weather weather)
        {
            switch (weather)
            {
                case Weather.Sunny:
                    return "Sortky";
                case Weather.Windy:
                    return "Sustaky";
                case Weather.Rainy:
                    return "Rybarske kalhoty";
                case Weather.Snowy:
                    return "Oteplovacky";
                case Weather.Tornado:
                    return "Kratasy";
                case Weather.Misty:
                    return "Reflexni kalhoty";
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
