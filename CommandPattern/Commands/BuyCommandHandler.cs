using RepositoryPattern;

namespace CommandPattern.Commands
{
    public class BuyCommandHandler : ICommandHandler
    {
        private readonly ProductRepository _productRepository;

        public BuyCommandHandler(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Execute(BuyOnlyCommand command)
        {
            var choosenProduct = _productRepository.Get(command.ProductId);
            choosenProduct.Quantity -= 1;
            _productRepository.Update(choosenProduct);
        }
    }
}
