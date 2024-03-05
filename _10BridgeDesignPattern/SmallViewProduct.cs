using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_BridgePattern
{
    internal class SmallViewProduct
    {
        private readonly Product _product;

        public SmallViewProduct(Product product)
        {
            _product = product;
        }

        public void Write()
        {
            Console.WriteLine(_product.Name);
            Console.WriteLine(_product.Company);
            Console.WriteLine(_product.Pictures);
            Console.WriteLine(_product.Description);
        }
    }
}