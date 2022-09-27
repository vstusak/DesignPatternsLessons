using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryDesignPattern.Commands;
using RepositoryDesignPattern.Context;
using RepositoryDesignPattern.Memento;
using RepositoryDesignPattern.Queries;

namespace RepositoryDesignPattern
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            await InitDb();

            var context = new WarehouseContext();
            //var productRepository = new GenericRepository<Product>(context);
            var productRepository = new ProductRepository(context);
            var commandController = new CommandController();
            var careTaker = new ProductRepositoryCareTaker(productRepository);
            var commandControllerWithHistory = new CommandControllerWithHistory(commandController, careTaker);
            var warehouseService = new WarehouseService(productRepository);
            var productQueryHandler = new ProductCqrsQueryHandler(productRepository);
            var buyCqrsCommandHandler = new BuyCqrsCommandHandler(productRepository, productQueryHandler);

            var products = warehouseService.GetAll();
            
            //foreach (var product in products)
            //{
            //    Console.WriteLine(product);
            //}
            
            var productToBuy = products.First();
            var productIdToBuy = productToBuy.ProductId;

            Console.WriteLine(productToBuy);
            Console.WriteLine(productIdToBuy);
            var command = new BuyCommand(productRepository, productIdToBuy);
            commandControllerWithHistory.Invoke(command);
            Console.WriteLine(productToBuy);

            commandControllerWithHistory.Undo();
            Console.WriteLine(productToBuy);

            //*****************************************************************
            //CQRS
            Console.WriteLine("CQRS Baby!");
            var buyCqrsCommand = new BuyCqrsCommand(productIdToBuy);
            buyCqrsCommandHandler.Execute(buyCqrsCommand);
            Console.WriteLine(productToBuy);

            Console.ReadLine();
        }

        public static async Task InitDb()
        {
            var context = new WarehouseContext();

            await context.Database.EnsureDeletedAsync();
            await context.Database.EnsureCreatedAsync();
            await context.AddAsync(new Product { Name = "Circle", Price = 3.14, Quantity = 5});
            await context.AddAsync(new Product { Name = "Square", Price = 4, Quantity = 15 });
            await context.AddAsync(new Product { Name = "Sausage", Price = 8.5, Quantity = 2 });
            await context.AddAsync(new Product { Name = "Beer", Price = 35.98, Quantity = 100 });
            await context.AddAsync(new Product { Name = "Jägermeister", Price = 300, Quantity = 2 });
            await context.AddAsync(new Product { Name = "White Wine", Price = 150.50, Quantity = 6 });

            await context.SaveChangesAsync();
        }
    }
}
