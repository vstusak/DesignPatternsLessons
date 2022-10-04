using System.Security.Cryptography.X509Certificates;

namespace _04_RepositoryPattern
{
    public static class Program
    {
        public static void Main()
        {
            InitDb();
        }

        public static void InitDb()
        {
            var context = new WarehouseContext();
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            context.Add(new Product()
            {
                Name = "Ball",
                Price = 35,
                Quantity = 20
            });

            context.Add(new Product()
            {
                Name = "Pencil",
                Price = 7,
                Quantity = 150
            });

            context.Add(new Product()
            {
                Name = "Paper",
                Price = 2,
                Quantity = 750
            });

            context.SaveChanges();
        }
    }
}