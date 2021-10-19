using RepositoryPattern.Context;
using System.Collections.Generic;

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

        public bool CanExecute()
        {
            //kontrola aktualních dat na naší straně
            var choosenProduct = _productRepository.Get(_selectedProducts.ProductId);
            return choosenProduct.Quantity > 0;
        }

        public void Execute()
        {
            var choosenProduct = _productRepository.Get(_selectedProducts.ProductId);
            choosenProduct.Quantity -= 1;
            _productRepository.Update(choosenProduct);
        }

        public void Undo()
        {
            var choosenProduct = _productRepository.Get(_selectedProducts.ProductId);
            choosenProduct.Quantity += 1;
            _productRepository.Update(choosenProduct);
        }
    }
}