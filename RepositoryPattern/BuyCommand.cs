using RepositoryPattern.Context;

namespace RepositoryPattern
{
    internal class BuyCommand : IAcademyCommand
    {
        private readonly Product _selectedProducts;
        private readonly ProductRepository _productRepository;

        public BuyCommand(Product selectedProducts, ProductRepository productRepository)
        {
            _selectedProducts = selectedProducts;
            _productRepository = productRepository;
        }

        public void Execute()
        {
            _selectedProducts.Quantity -= 1;
            _productRepository.Update(_selectedProducts);
        }
    }
}