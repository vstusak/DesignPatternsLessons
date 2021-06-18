using RepositoryPattern.Context;
using System;
using System.Linq;

namespace RepositoryPattern
{
    public class WarehouseService
    {
        private readonly WarehouseContext _warehouseContext;

        public WarehouseService(WarehouseContext warehouseContext)
        {
            _warehouseContext = warehouseContext;
        }

        public void WriteProductsWithPriceOver100()
        {
            var products = _warehouseContext.Products.Where(product => product.Price > 100);

            foreach (var product in products)
            {
                Console.WriteLine(product);
            }
        }
    }
}
