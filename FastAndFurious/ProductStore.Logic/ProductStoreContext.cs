using Microsoft.EntityFrameworkCore;
using ProductFuriousStore.Contracts.Entities;

namespace ProductFuriousStore.Logic;

public class ProductStoreContext : DbContext

{
    public DbSet<Product> Products { get; set; }
}