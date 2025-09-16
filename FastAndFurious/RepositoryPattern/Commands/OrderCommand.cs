namespace RepositoryPattern.Commands;

public class OrderCommand(IRepository<Product> productRepository, int productId, int quantity)
    : ICommand
{
    public void Execute()
    {
        var product = productRepository.Get(productId);
        Console.WriteLine($"State before order: {product.Quantity}");
        product.Quantity -= quantity;
        productRepository.SaveChanges();
        product = productRepository.Get(productId);

        Console.WriteLine($"State after order: {product.Quantity}");
    }

    public void UnDo()
    {
        var product = productRepository.Get(productId);
        Console.WriteLine($"State before undo: {product.Quantity}");
        product.Quantity += quantity;
        productRepository.SaveChanges();
        product = productRepository.Get(productId);
        Console.WriteLine($"State after undo: {product.Quantity}");
    }

    public bool CanExecute()
    {
        try
        {
            var product = productRepository.Get(productId);
            return product.Quantity - quantity >= 0;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
}