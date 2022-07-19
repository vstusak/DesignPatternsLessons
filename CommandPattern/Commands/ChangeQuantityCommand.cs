using RepositoryPattern;
using RepositoryPattern.Context;
using System;

namespace CommandPattern.Commands
{
    public class ChangeQuantityCommand : IAcademyCommand
    {
        private readonly Product _selectedProducts;
        private readonly ProductRepository _productRepository;
        private readonly int _quantity;

        public ChangeQuantityCommand(Product selectedProducts, ProductRepository productRepository, int quantity)
        {
            _selectedProducts = selectedProducts;
            _productRepository = productRepository;
            _quantity = quantity;
        }

        public void Execute()
        {
            var chosenProduct = _productRepository.Get(_selectedProducts.ProductId);
            chosenProduct.Quantity += _quantity;
            _productRepository.Update(chosenProduct);
        }

        public bool CanExecute()
        {
            var currentQuantity = _productRepository.Get(_selectedProducts.ProductId).Quantity;
            return _quantity > 0 || currentQuantity > Math.Abs(_quantity);
        }

        public void Undo()
        {
            var chosenProduct = _productRepository.Get(_selectedProducts.ProductId);
            chosenProduct.Quantity -= _quantity;
            _productRepository.Update(chosenProduct);
        }
    }
}