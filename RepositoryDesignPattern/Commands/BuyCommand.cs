using System;
using RepositoryDesignPattern.Context;

namespace RepositoryDesignPattern.Commands
{
    public class BuyCommand : ICommand
    {
        private readonly IRepository<Product> _productRepository;
        private readonly Guid _productId;

        public BuyCommand(IRepository<Product> productRepository, Guid productId)
        {
            _productRepository = productRepository;
            _productId = productId;
        }

        public bool CanExecute()
        {
            var product = _productRepository.Get(_productId);
            return product.Quantity > 0;
        }

        public void Execute()
        {
            Console.WriteLine("Executing the execution.");
            var product = _productRepository.Get(_productId);
            product.Quantity -= 1;
            _productRepository.Update(product);
            _productRepository.SaveChanges();
        }

        public void Undo()
        {
            Console.WriteLine("calling Undo");
            var product = _productRepository.Get(_productId);
            product.Quantity += 1;
            _productRepository.Update(product);
            _productRepository.SaveChanges();
        }
    }
}