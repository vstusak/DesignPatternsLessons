using ProductStore.Data;
using Microsoft.Extensions.Logging;
using ProductStore.Contracts.Model;

namespace ProductStore.Domain
{
    public class ProductProvider : IProductProvider
    {
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductProvider> _logger;

        public ProductProvider(IProductRepository productRepository, ILogger<ProductProvider> logger)
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
            _logger.LogInformation($"Getting product with {productId} ProductId.");
            return _productRepository.Get(productId);
        }

        public void DeleteProduct(int id)
        {
            _logger.LogInformation($"3-Deleting product with {id} ProductId.");
            _productRepository.Delete(id);

        }
        public void AddOrUpdateProduct(Product product)
        {
            _logger.LogInformation($"Add or update product.");
            _productRepository.AddOrUpdate(product);
        }

        private IEnumerable<Product> GetAllProducts()
        {
            return new List<Product>()
            {
                new Product() {ProductId = 1, Name="Ball", Category = "Toy", Price = 123},
                new Product() {ProductId = 2, Name="Bear", Category = "Toy", Price = 853},
                new Product() {ProductId = 3, Name="Mouse", Category = "Animal", Price = 56},
                new Product() {ProductId = 4, Name="Bear", Category = "Animal", Price = 456}
            };
        }
    }
}
