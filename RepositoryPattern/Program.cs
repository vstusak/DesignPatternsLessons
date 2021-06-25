using RepositoryPattern.Context;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public static class Program
    {
        public static async Task Main()
        {
            await InitDbAsync();
            var context = new WarehouseContext();
            var service = new WarehouseService(
                new ProductRepository(context));

            service.WriteProductsWithPriceOver100();
        }

        private static async Task InitDbAsync()
        {
            using var context = new WarehouseContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Add(new Product { Name = "Socks", Price = 120, Quantity = 3 });
            context.Add(new Product { Name = "Plate", Price = 40, Quantity = 4 });
            context.Add(new Product { Name = "Book", Price = 200, Quantity = 100 });
            context.Add(new Product { Name = "Headphones", Price = 1500, Quantity = 1 });
            context.Add(new Product { Name = "Coaster", Price = 10, Quantity = 500 });

            await context.SaveChangesAsync();
        }
    }
}
