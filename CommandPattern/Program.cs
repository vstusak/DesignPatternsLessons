using CommandPattern.Commands;
using CommandPattern.Memento;
using RepositoryPattern;
using RepositoryPattern.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CQRS.Customers.CommandHandlers;
using CQRS.Customers.Commands;

namespace CommandPattern
{
    public static class Program
    {
        public static async Task Main()
        {
            await InitDbAsync();
            var context = new WarehouseContext();
            var productRepository = new ProductRepository(context);
            var commandManager = new CommandManager();
            var buyCommandHandler = new BuyCommandHandler(productRepository);
            var repositoryCareTaker = new RepositoryCareTaker();
            var commandManagerWithHistory = new CommandManagerWithHistory(repositoryCareTaker, commandManager, productRepository);
            ///////////////////////////////////////////////////////////// ^ IOC container

            WriteAll(productRepository.All());
            var selectedProducts = productRepository.All().First();

            commandManagerWithHistory.Invoke(new BuyCommand(selectedProducts, productRepository));
            commandManagerWithHistory.Invoke(new BuyCommand(selectedProducts, productRepository));
            commandManagerWithHistory.Invoke(new BuyCommand(selectedProducts, productRepository));

            //service.WriteProductsWithPriceOver100();

            WriteAll(productRepository.All());
            Console.WriteLine("Undo will be carry out after pressing enter");
            Console.ReadLine();
            commandManagerWithHistory.Undo();
            WriteAll(productRepository.All());
            Console.WriteLine("Redo will be carry out after pressing enter");
            Console.ReadLine();
            commandManagerWithHistory.Redo();
            WriteAll(productRepository.All());
            commandManager.Undo();
            WriteAll(productRepository.All());
            commandManager.Invoke(new ChangeQuantityCommand(selectedProducts, productRepository, 5));
            WriteAll(productRepository.All());

            ///////////////////////////////////////////////////////////// CQRS
            
            Console.WriteLine("CQRS starts now!");
            var buyCommand = new BuyOnlyCommand(selectedProducts.ProductId);
            buyCommandHandler.Execute(buyCommand);
            WriteAll(productRepository.All());
            Console.ReadLine();




            var createCustomerHandler = new CreateCustomerCommandHandler(context);
            var createCustomerCommand = new CreateCustomerCommand
            {
                FirstName = "John",
                Surname = "Dohn"
            };

            await createCustomerHandler.Execute(createCustomerCommand);
        }

        private static void WriteAll(IEnumerable<Product> all)
        {
            foreach (var product in all)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine();
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
