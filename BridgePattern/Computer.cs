using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class Computer:IProduct
    {
        public string Name { get; set; }
        public string Cpu { get; set; }
        public string Memory { get; set; }
        public string Gpu { get; set; }
        public Dictionary<string, string> GetAllInformation()
        {
            var items = new Dictionary<string, string>()
            {
                {"Name",Name},
                {"Cpu",Cpu},
                {"Memory", Memory},
                {"Gpu",Gpu}
                              
            };
            return items;
        }

        public string GetName()
        {
            return Name;
        }
    }
}
