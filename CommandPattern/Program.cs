using CommandPattern.Commands;
using RepositoryPattern;
using RepositoryPattern.Context;

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
            ///////////////////////////////////////////////////////////// ^ IOC container

            WriteAll(productRepository.All());
            var selectedProducts = productRepository.All().First();

            commandManager.Invoke(new BuyCommand(selectedProducts, productRepository));
            commandManager.Invoke(new BuyCommand(selectedProducts, productRepository));
            commandManager.Invoke(new BuyCommand(selectedProducts, productRepository));

            //service.WriteProductsWithPriceOver100();

            WriteAll(productRepository.All());
            Console.ReadLine();
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
