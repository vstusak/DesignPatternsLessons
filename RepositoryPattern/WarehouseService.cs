using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _04_RepositoryPattern
{
    internal class WarehouseService
    {
        private readonly IProductRepository _productRepository;

        public WarehouseService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void WriteAllProducts()
        {
            //var context = new WarehouseContext();
            IEnumerable<Product> products = _productRepository.GetAll();

            foreach (var item in products)
            {
                Console.WriteLine($"{item}");
            }
        }

        public void WriteProductsWithQuantity3()
        {
            //Product Find(Expression<Func<Product, bool>> expression);
            IEnumerable<Product> products = _productRepository.Find(product => product.Quantity == 3);

            foreach (var item in products)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}