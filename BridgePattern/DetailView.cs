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

    public class PromotionView : IView
    {
        public void Render(IProductAdapter productAdapter)
        {
            Console.WriteLine($"Showing PromotionView of product:");
        }
    }

    public class ListView : IView
    {
        public void Render(IProductAdapter productAdapter)
        {
            Console.WriteLine($"Showing ListView of product:{productAdapter.GetName()}");
            Console.WriteLine($"Description: {productAdapter.GetDescription()}");
            Console.WriteLine($"Price is {productAdapter.GetPrice()}");
        }
    }

    public class AccessoryView : IView
    {
        public void Render(IProductAdapter productAdapter)
        {
            Console.WriteLine($"Showing AccessoryView of product:");
        }
    }

    interface IView
    {
        void Render(IProductAdapter productAdapter);
    }
}
