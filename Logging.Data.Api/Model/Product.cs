namespace ProductStore.Contracts.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Category { get; set; }
        public int Quantity { get; set; }
    }
}
