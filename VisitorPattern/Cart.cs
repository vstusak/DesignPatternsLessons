using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    internal class Cart
    {
        public ICollection<IProduct> Products;

        public Cart()
        {
            Products = new List<IProduct>();
        }

        public void AddItem(IProduct item)
        {
            Products.Add(item);
        }

        public void Order()
        {
            Console.WriteLine("Order content:");
            foreach (var item in Products)
            {
                Console.WriteLine($" {item.Name} : {item.Price} czk");
            }

            Console.WriteLine($"    Total: {Products.Sum(item => item.Price)}");
        }
    }
}
