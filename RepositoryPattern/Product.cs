namespace _04_RepositoryPattern
{
    public class Product
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public Guid ProductId { get; private set; }
        public DateTime LastTimeModified { get; set; }

        public Product()
        {
            ProductId = Guid.NewGuid();
        }

        public override string ToString()
        {
            return $"{ProductId}, {Name}: {Price}, {Quantity}, {LastTimeModified}";
        }
    }
}
