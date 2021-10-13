using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.Context;

namespace RepositoryDesignPattern
{
    class Program
    {
        async static Task Main(string[] args)
        {
            await InitDb();

            var context = new WarehouseContext();

            var products = context.Products;

            foreach (var product in products)
            {
                Console.WriteLine( product);
            }

        }

        private static async Task InitDb()
        {
            var context = new WarehouseContext();

            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            await context.AddAsync((new Product() { Name = "Circle", Price = 3.14, Quantity = 5}));
            await context.AddAsync((new Product() { Name = "Square", Price = 4, Quantity = 15 }));
            await context.AddAsync((new Product() { Name = "Sausage", Price = 8.5, Quantity = 2 }));
            await context.AddAsync((new Product() { Name = "Beer", Price = 35.98, Quantity = 100 }));
            await context.AddAsync((new Product() { Name = "Jagermeister", Price = 300, Quantity = 2 }));
            await context.AddAsync((new Product() { Name = "White Wine", Price = 150.50, Quantity = 6 }));

            await context.SaveChangesAsync();
        }
    }
}
