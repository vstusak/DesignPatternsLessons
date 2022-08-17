using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPattern.Products;

namespace VisitorPattern
{
    public class Collector
    {
        private IList<Cart> _carts = new List<Cart>();
        public void Collect(Cart cart)
        {
            _carts.Add(cart);
        }

        public void GetReport()
        {
            //var toys = new List<Toy>();
            //var books = new List<Book>();
            //var electronics = new List<Electronics>();

            //foreach (var cart in _carts)
            //{
            //    foreach (var cartItem in cart._items)
            //    {
            //        if (cartItem is Toy)
            //        {
            //            toys.Add((Toy)cartItem);
            //        }
            //        else if (cartItem is Book)
            //        {
            //            books.Add((Book)cartItem);
            //        }
            //        else
            //        {
            //            electronics.Add((Electronics)cartItem);
            //        }
            //    }
            //}

            var toys = _carts.SelectMany(c => c._items).Where(i => i is Toy).ToList();
            var books = _carts.SelectMany(c => c._items).Where(i => i is Book).ToList();
            var electronics = _carts.SelectMany(c => c._items).Where(i => i is Electronics).ToList();

            Console.WriteLine($"Sold {toys.Count} toys for a total price of {toys.Sum(t => t.Price)}");
            Console.WriteLine($"Sold {books.Count} books for a total price of {books.Sum(t => t.Price)}");
            Console.WriteLine($"Sold {electronics.Count} electronics for a total price of {electronics.Sum(t => t.Price)}");
        }
    }
}
