using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class Toy:IProductAdapter
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public Dictionary<string, string> GetAllInformation()
        {
            var items = new Dictionary<string, string>()
            {
                {"Name", Name},
                {"Description", Description},
                {"Color", Color},
            };

            return items;
        }

        public string GetName()
        {
            return Name;
        }

        public string GetDescription()
        {
            return Description;
        }

        public int GetPrice()
        {
            return Price;
        }
    }
}
