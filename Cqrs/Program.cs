using System;
using System.Linq;
using System.Threading.Tasks;
using RepositoryDesignPattern;
using RepositoryDesignPattern.Context;

namespace Cqrs
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await RepositoryDesignPattern.Program.InitDb();

            var context = new WarehouseContext();
            var productRepository = new ProductRepository(context);

            var productQueryHandler = new ProductQueryHandler(productRepository);
            var buyCommandHandler = new BuyCommandHandler(productRepository, productQueryHandler);

            var productToBuy = productRepository.GetAll().First();
            var productIdToBuy = productToBuy.ProductId;

            Console.WriteLine("CQRS Baby!");
            var buyCommand = new BuyCommand(productIdToBuy);
            buyCommandHandler.Execute(buyCommand);
            Console.WriteLine(productToBuy);

            Console.ReadLine();
        }
    }
}
