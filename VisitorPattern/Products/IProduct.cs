using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern.Products
{
    public interface IProduct
    {
        string Name { get; set; }
        int Price { get; set; }
    }
}
