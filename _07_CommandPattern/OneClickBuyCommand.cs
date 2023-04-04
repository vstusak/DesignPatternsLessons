public class OneClickBuyCommand : ICommand
{
    private int _productId;
    private int _count;
    private IOrderNotificator _orderNotificator;
    private IInventory _inventory;

    public OneClickBuyCommand(int productId, int count, IOrderNotificator orderNotificator, IInventory inventory)
    {
        _productId = productId;
        _count = count;
        _orderNotificator = orderNotificator;
        _inventory = inventory;
    }

    public void Invoke()
    {
        var product = _inventory.GetProduct(_productId);
        product.Amount -= _count;
        var message = $"Koupil jsi {product.Name} v počtu {_count} kusů. Na skladě zůstalo {product.Amount} kusů.";
        _orderNotificator.SendNotification(message);
    }

}

public interface IOrderNotificator
{
    void SendNotification(string notificationMessage);
}

public class OrderNotificator : IOrderNotificator
{
    public void SendNotification(string notificationMessage)
    {
        Console.WriteLine(notificationMessage);
    }
}

public interface IInventory
{
    Product GetProduct(int productId);
}

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
        throw new NotImplementedException(); // TODO implement GetProduct

    }
}