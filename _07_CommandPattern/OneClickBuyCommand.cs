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

    public bool CanInvoke()
    {
        var product = _inventory.GetProduct(_productId);
        var result = product.Amount >= _count;
        return result;
    }

    public void Invoke()
    {
        var product = _inventory.GetProduct(_productId);
        product.Amount -= _count;
        var message = $"Koupil jsi {product.Name} v počtu {_count} kusů. Na skladě zůstalo {product.Amount} kusů.";
        _orderNotificator.SendNotification(message);
    }

    public void Undo()
    {
        var product = _inventory.GetProduct(_productId);
        product.Amount += _count;
        var message = $"Vrátil jsi {product.Name} v počtu {_count} kusů. Na skladě zůstalo {product.Amount} kusů.";
        _orderNotificator.SendNotification(message);
    }

    public void ValidationMessage()
    {
        var product = _inventory.GetProduct(_productId);
        var message = $"Nepodařilo se koupit {product.Name} v počtu {_count} kusů. Na skladě je jen {product.Amount} kusů.";
        _orderNotificator.SendNotification(message);
    }
}