namespace _04_RepositoryPattern
{
    internal class WarehouseService
    {
        private readonly IRepository<Product> _productRepository;

        public WarehouseService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public void WriteAllProducts()
        {
            //var context = new WarehouseContext();
            IEnumerable<Product> products = _productRepository.GetAll();

            foreach (var item in products)
            {
                Console.WriteLine($"{item}");
            }
        }

        public void WriteProductsWithQuantity3()
        {
            //Product Find(Expression<Func<Product, bool>> expression);
            IEnumerable<Product> products = _productRepository.Find(product => product.Quantity == 3);

            foreach (var item in products)
            {
                Console.WriteLine($"{item}");
            }
        }
    }
}