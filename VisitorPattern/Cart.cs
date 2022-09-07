using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPattern.Products;
using VisitorPattern.Visitors;

namespace VisitorPattern
{
    public class Cart
    {
        public IList<IProduct> _items = new List<IProduct>();
        public void AddItem(IProduct product)
        {
            _items.Add(product);
        }

        public void OrderItems()
        {
            foreach (var product in _items)
            {
                Console.WriteLine(product.Name);
            }

            Console.WriteLine($"Total price: {_items.Sum(i => i.Price)}");
        }

        public void ApplyVisitor(IVisitor visitor)
        {
            foreach (var item in _items)
            {
                item.Accept(visitor);
            }
        }
    }
}
