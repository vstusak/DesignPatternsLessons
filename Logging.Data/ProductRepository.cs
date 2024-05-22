using Logging.Data.Model;
using Microsoft.Extensions.Logging;

namespace Logging.Data
{
    public class ProductRepository: IProductRepository    
    {
        private readonly WarehouseContext _warehouseContext;
        private readonly ILogger<ProductRepository> _logger;


        //ToDo: implement  DB layer logging
        //ToDo: log debug the query details
        public ProductRepository(WarehouseContext warehouseContext, ILogger<ProductRepository> logger )
        {
            _warehouseContext = warehouseContext;
            _logger = logger;
        }
        public Product? Get(int productId)
        {
            _logger.LogInformation($"Getting product with {productId} Id from warehouse");
            return _warehouseContext.Products.Find(productId);
        }

        public IEnumerable<Product> GetForCategory(string category)
        {
            _logger.LogInformation($"Getting products with {category} category from warehouse");
            return _warehouseContext.Products.Where(p => p.Category == category 
                                                         || category == "All");
        }
    }
}
