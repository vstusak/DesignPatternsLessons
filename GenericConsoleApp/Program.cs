using CQRS;
using RepositoryPattern;
using RepositoryPattern.Context;
using System;
using System.Threading.Tasks;

namespace GenericConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await InitDbAsync();
            var context = new WarehouseContext();
            ProductRepository productRepository = new ProductRepository(context);
            IProductDetailQueryHandler productDetailQueryHandler = new ProductDetailQueryHandler(productRepository);
            IBuyCommandHandler buyCommandHandler = new CQRS.BuyCommandHandler(productRepository,productDetailQueryHandler);
            ////////////////////////////////////////

            Console.WriteLine("Hello World!");
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
