namespace BridgePattern;

public class PromotionView : IView
{
    public void Render(IProductAdapter productAdapter)
    {
        Console.WriteLine($"Showing PromotionView of product:");
    }
}