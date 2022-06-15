using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public interface IProductAdapter
    {
        Dictionary<string, string> GetAllInformation();

        string GetName();
        string GetDescription();
        int GetPrice();
    }
}
