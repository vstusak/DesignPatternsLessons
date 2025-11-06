namespace RepositoryPattern.CQRS;

public class OrderCQRSCommandHandler : IOrderCQRSCommandHandler
{
    private readonly IRepository<Product> _productRepository;

    public OrderCQRSCommandHandler(IRepository<Product> productRepository)
    {
        _productRepository = productRepository;
    }


	public void Handle(OrderCQRSCommand command)
	{
        var product = _productRepository.Get(command.ProductId);
        Console.WriteLine($"State before order: {product.Quantity}");
        product.Quantity -= command.Quantity;
        _productRepository.SaveChanges();
        product = _productRepository.Get(command.ProductId);

        Console.WriteLine($"State after order: {product.Quantity}");
    }
}

public interface IOrderCQRSCommandHandler
{
    void Handle(OrderCQRSCommand command);
}
