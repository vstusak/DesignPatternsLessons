using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    class ProductRepository : IRepository<Product>
    {
        private readonly WarehouseDbContext _warehouseDbContext;

        public ProductRepository(WarehouseDbContext warehouseDbContext)
        {
            _warehouseDbContext = warehouseDbContext;
        }

        public Product Get(int id)
        {
            throw new NotImplementedException();
        }

        public int Create(Product entity)
        {
            throw new NotImplementedException();
        }
    }
}
