namespace BridgePattern;

public class ListView : IView
{
    public void Render(IProductAdapter productAdapter)
    {
        Console.WriteLine($"Showing ListView of product:{productAdapter.GetName()}");
        Console.WriteLine($"Description: {productAdapter.GetDescription()}");
        Console.WriteLine($"Price is {productAdapter.GetPrice()}");
    }
}