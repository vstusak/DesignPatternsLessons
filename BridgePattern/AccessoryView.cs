namespace BridgePattern;

public class AccessoryView : IView
{
    public void Render(IProductAdapter productAdapter)
    {
        Console.WriteLine($"Showing AccessoryView of product:");
    }
}