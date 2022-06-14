using RepositoryPattern.Context;
using System;

namespace RepositoryPattern
{
    public class WarehouseService
    {
        private readonly IRepository<Product> _productRepository;

        public WarehouseService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public void WriteProductsWithPriceOver100()
        {
            var products = _productRepository.Find(product => product.Price > 100);

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
