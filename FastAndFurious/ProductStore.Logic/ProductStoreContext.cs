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
        throw new NotImplementedException();
    }
}