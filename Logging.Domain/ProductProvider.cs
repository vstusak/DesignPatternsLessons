using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logging.Domain.Model;

namespace Logging.Domain
{
    public class ProductProvider : IProductProvider
    {
        public IEnumerable<Product> GetProductsForCategory(string category)
        {
            return GetAllProducts().Where(p =>
                string.Equals(category, "All",StringComparison.InvariantCultureIgnoreCase) ||
                string.Equals(p.Category, category, StringComparison.InvariantCultureIgnoreCase));
        }

        public Product? GetProduct(int productId)
        {
            return GetAllProducts().SingleOrDefault(p => p.Id == productId);
        }

        private IEnumerable<Product> GetAllProducts()
        {
            return new List<Product>()
            {
                new Product() {Id = 1, Name="Ball", Category = "Toy", Price = 123},
                new Product() {Id = 2, Name="Bear", Category = "Toy", Price = 853},
                new Product() {Id = 3, Name="Mouse", Category = "Animal", Price = 56},
                new Product() {Id = 4, Name="Bear", Category = "Animal", Price = 456}
            };
        }
    }
}
