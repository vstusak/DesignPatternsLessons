public class OneClickBuyCommand : ICommand
{
    private int _productId;
    private int _count;
    private List<Product> _products;

    public OneClickBuyCommand(int productId, int count)
    {
        _productId = productId;
        _count = count;
        _products = new List<Product>
        {
            new Product() {ProductId = 1, Amount = 5, Name = "Bodkociarka" },
            new Product() {ProductId = 2, Amount = 10, Name = "Plafon" },
            new Product() {ProductId = 3, Amount = 8, Name = "Cucoriedka"},
        };
    }

    public void Invoke()
    {
        var product = _products.Single(product => product.ProductId == _productId);
        product.Amount -= _count;
        var message = $"Koupil jsi {product.Name} v počtu {_count} kusů. Na skladě zůstalo {product.Amount} kusů.";
        var notification = new OrderNotificator();
        notification.SendNotification(message);
    }

}

public class OrderNotificator // TODO zmenit na interface
{
    public void SendNotification(string notificationMessage)
    {
        Console.WriteLine(notificationMessage);
    }
}