using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using ProductStore.Contracts.Model;

namespace Logging.Data
{
    public class WarehouseContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=products.db");
        //    // https://stackoverflow.com/questions/55513532/ef-core-enablesensitivedatalogging-does-not-work-as-expected
        //    // or enable here optionsBuilder.UseSqlite("Data Source=products.db").EnableSensitiveDataLogging();

        //    //TODO fix conenction for SQL - maybe wrong nuget package
        //    //optionsBuilder.AddSqlServerDbContext<WarehouseContext>(connectionName: "database");

        //    optionsBuilder.UseLoggerFactory(LoggerFactory.Create(builder => builder.AddDebug()));

        //optionsBuilder.UseSqlServer("StoreDb");
        //}

        public WarehouseContext(DbContextOptions options) : base(options)
        {

        }

        //public void Seed()
        //{
        //    Database.EnsureDeleted();
        //    Database.EnsureCreated();
            
        //    //Removed Ids as they are automatically added in db
        //    Products.Add(new Product() { Name = "Ball", Category = "Toy", Price = 123 });
        //    Products.Add(new Product() { Name = "Bear", Category = "Toy", Price = 853 });
        //    Products.Add(new Product() { Name = "Mouse", Category = "Animal", Price = 56 });
        //    Products.Add(new Product() { Name = "Bear", Category = "Animal", Price = 456 });

        //    SaveChanges();
        //}

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

    public class WarehouseContextFactory : IDesignTimeDbContextFactory<WarehouseContext>
    {
        public WarehouseContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WarehouseContext>();
            optionsBuilder.UseSqlServer("StoreDb");

            return new WarehouseContext(optionsBuilder.Options);
        }
    }
}
