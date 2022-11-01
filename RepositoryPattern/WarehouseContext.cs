using Microsoft.EntityFrameworkCore;

namespace _04_RepositoryPattern
{
    public class WarehouseContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Products.db");
        }
    }
}
