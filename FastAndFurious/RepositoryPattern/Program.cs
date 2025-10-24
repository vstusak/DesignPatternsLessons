// See https://aka.ms/new-console-template for more information

using RepositoryPattern;
using RepositoryPattern.Commands;
using RepositoryPattern.CQRS;

var warehouse = new WarehouseDbContext();

var productRepo = new ProductRepository(warehouse);

await DbInitSeed.InitDb(productRepo);

PrintStateOfProductWarehouse(productRepo);

Console.WriteLine("Type the product ID:");
var productId = System.Console.ReadLine() ?? string.Empty;
Console.WriteLine("Type the quantity to order:");
var quantity = System.Console.ReadLine() ?? string.Empty;

//var firstOrderCommand = new OrderCommand(productRepo, Int32.Parse(productId), int.Parse(quantity));

//var invoker = new CommandInvoker();
//invoker.ExecuteCommand(firstOrderCommand);

//PrintStateOfProductWarehouse(productRepo);

//invoker.UnDo();

var orderCqrsCommand = new OrderCQRSCommand
{
    ProductId = Int32.Parse(productId),
    Quantity = int.Parse(quantity)
};

/**
 * @TODO Introduce interface to command handler and explain why we need it
 * @TODO Introduce generic interface to command handler
 * @TODO Implement query handler from usage (implementing against interfaces)
 */
var handler = new OrderCQRSCommandHandler(productRepo);

handler.Handle(orderCqrsCommand);

PrintStateOfProductWarehouse(productRepo);
return;

static void PrintStateOfProductWarehouse(ProductRepository productRepository)
{
    var products = productRepository.GetAll();

    foreach (var warehouseProduct in products)
    {
        Console.WriteLine(warehouseProduct);
    }
}
// invoice <- command
// invoker - execute, revert
// client - using invoker, create command