namespace CommandPattern.Commands
{
    public class BuyOnlyCommand : IOnlyCommand
    {
        public Guid ProductId { get; private set; }

        public BuyOnlyCommand(Guid productId)
        {
            ProductId = productId;
        }
    }
}
