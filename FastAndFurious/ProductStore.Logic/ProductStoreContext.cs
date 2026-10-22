using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ProductFuriousStore.Contracts.Entities;

namespace ProductFuriousStore.Logic;

public class ProductStoreContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public ProductStoreContext(DbContextOptions options) : base(options)
    {}

    public bool DataExists()
    {
        return Database.CanConnect() && Database.GetService<IRelationalDatabaseCreator>().HasTables() && HasData();
    }

    private bool HasData()
    {
        return Products.Any();
    }

    public void Seed()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();

        Products.Add(new Product { Category = "TestCategory", Name = "TestProduct1" , Price = 9 });
        Products.Add(new Product { Category = "TestCategory", Name = "TestProduct2", Price = 10 });
        Products.Add(new Product { Category = "Test2Category", Name = "TestProduct3", Price = 15 });
        Products.Add(new Product { Category = "Test2Category", Name = "TestProduct4", Price = 1 });
        Products.Add(new Product { Category = "Test3Category", Name = "TestProduct5", Price = 3 });

        SaveChanges();
    }
}