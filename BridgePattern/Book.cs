using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class Book:IProduct
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public Dictionary<string, string> GetAllInformation()
        {
            var items = new Dictionary<string, string>()
            {
                {"Title", Title},
                {"Author", Author},
                {"Publisher", Publisher},
            };
            return items;
        }

        public string GetName()
        {
            return Title;
        }
    }
}
