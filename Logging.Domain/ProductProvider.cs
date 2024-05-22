using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logging.Data;
using Logging.Data.Model;
using Microsoft.Extensions.Logging;

namespace Logging.Domain
{
    public class ProductProvider : IProductProvider
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductProvider> _logger;

        public ProductProvider( IProductRepository productRepository, ILogger<ProductProvider> logger)
        {
            _productRepository = productRepository;
            _logger = logger;
        }

        public IEnumerable<Product> GetProductsForCategory(string category)
        {
            _logger.LogInformation($"Getting enumeration of products with {category} category.");
            return _productRepository.GetForCategory(category);
        }

        public Product? GetProduct(int productId)
        {
            _logger.LogInformation($"Getting product with {productId} Id.");
            return _productRepository.Get(productId);
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
