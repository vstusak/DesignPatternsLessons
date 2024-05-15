using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logging.Data.Model;

namespace Logging.Data
{
    public class WarehouseContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=products.db");
        }

        public void Seed()
        {
            //TODO: do not delete if db file exists
            Database.EnsureDeleted();
            Database.EnsureCreated();

            Products.Add(new Product() { Id = 1, Name = "Ball", Category = "Toy", Price = 123 });
            Products.Add(new Product() { Id = 2, Name = "Bear", Category = "Toy", Price = 853 });
            Products.Add(new Product() { Id = 3, Name = "Mouse", Category = "Animal", Price = 56 });
            Products.Add(new Product() { Id = 4, Name = "Bear", Category = "Animal", Price = 456 });

            SaveChanges();
        }
    }
}
