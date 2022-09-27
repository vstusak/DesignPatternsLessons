namespace RepositoryPattern
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; private set; }

        public Product()
        {
            ProductId = Guid.NewGuid();
        }

    }
}
