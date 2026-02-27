using System.Diagnostics;
using System.Net;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProductStore.Contracts.Model;


namespace ProductStore.Data
{
    public class ProductRepository: IProductRepository    
    {
        private readonly WarehouseContext _warehouseContext;
        private readonly ILogger<ProductRepository> _logger;
        private readonly ILogger _databaseLogger;
        private readonly ILogger _databaseLogger2;

        
        public ProductRepository(WarehouseContext warehouseContext, ILogger<ProductRepository> logger, ILoggerFactory loggerFactory)
        {
            _warehouseContext = warehouseContext;
            _logger = logger;
            _databaseLogger = loggerFactory.CreateLogger("DataAccessLayer");
            _databaseLogger2 = loggerFactory.CreateLogger<ProductRepository>();
        }
        public Product? Get(int productId)
        {
            _logger.LogInformation($"Getting product with {productId} ProductId from warehouse");
            return _warehouseContext.Products.Find(productId);
        }

        public IEnumerable<Product> GetForCategory(string category)
        {
            if (category == "Tom")
            {
                var ex = new ApplicationException("Tom error occured");
                ex.Data.Add("category", category);
                throw ex;
            }

            if (category == "Milan")
            {
                var ex = new SqliteException("Milan SQL error occured", 551);
                ex.Data.Add("category", category);
                throw ex;
            }

            var timer = new Stopwatch();
            
            _logger.LogInformation($"Getting products with {category} category from warehouse");
            
            timer.Start();
            var q = _warehouseContext.Products.Where(p => p.Category == category || category == "All");
            timer.Stop();
            _databaseLogger.LogInformation($"DAL querying products finished in {timer.ElapsedTicks} ticks.");
            _databaseLogger2.LogInformation($"Getting products2 with {category} category from warehouse");
            var queryString = q.ToQueryString();
            //_logger.LogDebug(queryString);

            return q;
        }

        public void Delete(int id)
        {
            _databaseLogger.LogInformation($"4-Deleting product with ProductId {id}.");

            var count =_warehouseContext.Products.Where(p => p.ProductId == id).ExecuteDelete();

            _databaseLogger.LogInformation($"5-Deleted count={count} for product with ProductId {id}.");
        }

        public void AddOrUpdate(Product product)
        {
            _databaseLogger.LogInformation($"Add/Update Product");
            _warehouseContext.Products.Update(product);

            //var entity = _warehouseContext.Products.SingleOrDefault(p => p.ProductId == product.ProductId);
            //if (entity != null)
            //{
            //    _warehouseContext.Products.Update(product);
            //}
            //else
            //{
            //    _warehouseContext.Products.Add(product);
            //}

            //_warehouseContext.Products.Entry(product).State = product.ProductId == 0 ? EntityState.Added : EntityState.Modified;

            _warehouseContext.SaveChanges();
        }
    }
}
