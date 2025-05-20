using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public static class DbInitSeed
    {
        public static async Task InitDb(ProductRepository productRepo)
        {
            var productList = new List<Product>()
            {
                new Product { Name = "Circle", Price = 3.14, Quantity = 5 },
                new Product { Name = "Square", Price = 4, Quantity = 15 },
                new Product { Name = "Sausage", Price = 8.5, Quantity = 2 },
                new Product { Name = "Beer", Price = 35.98, Quantity = 100 },
                new Product { Name = "Jägermeister", Price = 300, Quantity = 2 },
                new Product { Name = "White Wine", Price = 150.50, Quantity = 6 }
            };

            var context = new WarehouseDbContext();

            await context.Database.EnsureDeletedAsync();

            await context.Database.EnsureCreatedAsync();

            productRepo.AddRange(productList);

        }
    }
}
