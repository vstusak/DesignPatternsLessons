using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using System.Xml.Linq;

namespace _04_RepositoryPattern
{
    internal class ProductRepository : IProductRepository
    {
        private readonly WarehouseContext _warehouseContext;

        public ProductRepository(WarehouseContext warehouseContext)
        {
            _warehouseContext = warehouseContext;
        }

        public IEnumerable<Product> GetAll()
        {
            var products = _warehouseContext.Products;
            return products;
        }

        public Product Get(string name)
        {
            var product = _warehouseContext.Products.First(x => x.Name == name);
            return product;
        }

        public Product Add(Product product)
        {
            EntityEntry<Product> eeProduct = _warehouseContext.Add(product);
            return eeProduct.Entity;
        }

        public void Remove(Product product)
        {
            _warehouseContext.Remove(product);
        }

        public Product Update(Product product)
        {
            var eeProduct = _warehouseContext.Update(product);
            return eeProduct.Entity;
        }

        public IEnumerable<Product> Find(Expression<Func<Product, bool>> expression)
        {
            var products = _warehouseContext.Products.Where(expression);
            return products;
        }
    }
}