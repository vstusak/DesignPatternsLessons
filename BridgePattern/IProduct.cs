using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public interface IProduct
    {
        Dictionary<string, string> GetAllInformation();

        string GetName();
    }
}
