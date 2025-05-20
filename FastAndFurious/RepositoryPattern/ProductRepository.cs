using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly WarehouseDbContext _warehouseDbContext;

        public ProductRepository(WarehouseDbContext warehouseDbContext)
        {
            _warehouseDbContext = warehouseDbContext;
        }

        public Product Get(int id)
        {
            return _warehouseDbContext.Products.Single(p => p.ProductId == id);
        }

        public int Add(Product entity)
        {
            var entityEntry = _warehouseDbContext.Add(entity);
            _warehouseDbContext.SaveChanges();
            return entityEntry.Entity.ProductId;
        }

        public void AddRange(ICollection<Product> entities)
        {
            _warehouseDbContext.AddRange(entities);
            _warehouseDbContext.SaveChanges();
        }

        public IEnumerable<Product> GetAll()
        {
            return _warehouseDbContext.Products;
        }
    }
}
