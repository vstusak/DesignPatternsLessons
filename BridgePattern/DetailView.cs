using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class DetailView : IView
    {
        public void Render(IProductAdapter productAdapter)
        {
            Console.WriteLine($"Showing DetailView of product:{productAdapter.GetName()}");
            var items = productAdapter.GetAllInformation();
            foreach (var item in items)
            {
                Console.WriteLine($"\t{item.Key}\t{item.Value}");
            }
        }
    }
}
