public class Inventory : IInventory
{
    private readonly List<Product> _products;

    public Inventory()
    {
        _products = new List<Product>
        {
            new Product() {ProductId = 1, Amount = 5, Name = "Bodkociarka" },
            new Product() {ProductId = 2, Amount = 10, Name = "Plafon" },
            new Product() {ProductId = 3, Amount = 8, Name = "Cucoriedka"},
        };
    }

    public Product GetProduct(int productId)
    {        
        var product = _products.Single(p => p.ProductId == productId);
        return product;
    }
}