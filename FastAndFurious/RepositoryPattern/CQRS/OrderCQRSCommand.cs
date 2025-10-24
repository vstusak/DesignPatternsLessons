namespace RepositoryPattern.CQRS;

public class OrderCQRSCommand
{
    public int ProductId { get; set; }
    public int Quantity { get; set; }
}
