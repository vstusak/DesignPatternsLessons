using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}