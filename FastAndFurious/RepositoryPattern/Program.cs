// See https://aka.ms/new-console-template for more information

// TODO apply repository pattern

using Microsoft.EntityFrameworkCore;
using RepositoryPattern;

await InitDb();

var warehouse = new WarehouseDbContext();

await foreach (var warehouseProduct in warehouse.Products)
{
    Console.WriteLine(warehouseProduct);
}

static async Task InitDb()
{
    var context = new WarehouseDbContext();

    await context.Database.EnsureDeletedAsync();

    await context.Database.EnsureCreatedAsync();

    await context.AddAsync(new Product { Name = "Circle", Price = 3.14, Quantity = 5 });

    await context.AddAsync(new Product { Name = "Square", Price = 4, Quantity = 15 });

    await context.AddAsync(new Product { Name = "Sausage", Price = 8.5, Quantity = 2 });

    await context.AddAsync(new Product { Name = "Beer", Price = 35.98, Quantity = 100 });

    await context.AddAsync(new Product { Name = "Jägermeister", Price = 300, Quantity = 2 });

    await context.AddAsync(new Product { Name = "White Wine", Price = 150.50, Quantity = 6 });

    await context.SaveChangesAsync();

}
