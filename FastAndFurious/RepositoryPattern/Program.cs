// See https://aka.ms/new-console-template for more information

using RepositoryPattern;

var warehouse = new WarehouseDbContext();

var productRepo = new ProductRepository(warehouse);

await DbInitSeed.InitDb(productRepo);

var warehouseProducts = productRepo.GetAll();

foreach (var warehouseProduct in warehouseProducts)
{
    Console.WriteLine(warehouseProduct);
}
