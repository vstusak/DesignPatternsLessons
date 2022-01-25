using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPattern.Products;

namespace VisitorPattern
{
    internal class CartCollector
    {
        private ICollection<Cart> _carts;

        public CartCollector()
        {
            _carts = new List<Cart>();
        }

        public void Collect(Cart cart)
        {
            _carts.Add(cart);
        }

        public void Report()
        {
            var toys = _carts.SelectMany(c => c.Products).Where(p => p is Toy).ToList();
            var books = _carts.SelectMany(c => c.Products).Where(p => p is Book).ToList();
            var electronics = _carts.SelectMany(c => c.Products).Where(p => p is Electronics).ToList();

            Console.WriteLine($"Sold {toys.Count} toys for {toys.Sum(t => t.Price)}");
            Console.WriteLine($"Sold {books.Count} books for {books.Sum(b => b.Price)}");
            Console.WriteLine($"Sold {electronics.Count} electronics for {electronics.Sum(e => e.Price)}");
        }
    }
}
