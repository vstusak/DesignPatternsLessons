using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logging.Data.Api.Model;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Debug;

namespace Logging.Data
{
    public class WarehouseContext: DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=products.db");
            // https://stackoverflow.com/questions/55513532/ef-core-enablesensitivedatalogging-does-not-work-as-expected
            // or enable here optionsBuilder.UseSqlite("Data Source=products.db").EnableSensitiveDataLogging();
            optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));
        }

        public void Seed()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();

            Products.Add(new Product() { Id = 1, Name = "Ball", Category = "Toy", Price = 123 });
            Products.Add(new Product() { Id = 2, Name = "Bear", Category = "Toy", Price = 853 });
            Products.Add(new Product() { Id = 3, Name = "Mouse", Category = "Animal", Price = 56 });
            Products.Add(new Product() { Id = 4, Name = "Bear", Category = "Animal", Price = 456 });

            SaveChanges();
        }

        public bool DatabaseExists()
        {
            return Database.CanConnect()
                   && Database.GetService<IRelationalDatabaseCreator>().HasTables()
                   && HasData();
        }

        private bool HasData()
        {
            return Products.Any();
        }
    }
}
