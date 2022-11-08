namespace _04_RepositoryPattern
{
    public static class Program
    {
        public static void Main()
        {
            InitDb();
            //var productRepository = new ProductRepository(new WarehouseContext());
            var productRepository = new GenericRepository<Product>(new WarehouseContext());
            var customerRepository = new GenericRepository<Customer>(new WarehouseContext());

            var service = new WarehouseService(productRepository);
            service.WriteAllProducts();

            var balls = productRepository.GetAll().First(product=>string.Equals(product.Name, "ball", StringComparison.InvariantCultureIgnoreCase));
            balls.Quantity -= 1;
            productRepository.Update(balls);
            service.WriteAllProducts();
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