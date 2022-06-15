using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgePattern
{
    public class DetailView : IView
    {
        public void Render(IProduct product)
        {
            Console.WriteLine($"Showing DetailView of product:");
            Console.WriteLine(product.GetName());
            var items = product.GetAllInformation();
            foreach (var item in items)
            {
                Console.WriteLine($"{item.Key} = {item.Value}");
            }
        }
    }

    public class PromotionView : IView
    {
        public void Render(IProduct product)
        {
            Console.WriteLine($"Showing PromotionView of product:");
        }
    }

    public class ListView : IView
    {
        public void Render(IProduct product)
        {
            Console.WriteLine($"Showing ListView of product:");
        }
    }

    public class AccessoryView : IView
    {
        public void Render(IProduct product)
        {
            Console.WriteLine($"Showing AccessoryView of product:");
        }
    }

    interface IView
    {
        void Render(IProduct product);
    }
}
