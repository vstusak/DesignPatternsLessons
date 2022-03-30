using System;
using System.Threading.Tasks;
using RepositoryDesignPattern.Context;

namespace RepositoryDesignPattern.Commands
{
    internal interface ICommand
    {
        bool CanExecute();
        void Execute();
        void Undo();
    }

    public class BuyCommand : ICommand
    {
        private readonly IRepository<Product> _repository;
        private readonly Guid _productId;

        public BuyCommand(IRepository<Product> repository, Guid productId)
        {
            _repository = repository;
            _productId = productId;
        }

        public bool CanExecute()
        {
            var product = _repository.Get(_productId);
            return product.Quantity > 0;
        }

        public void Execute()
        {
            Console.WriteLine("Executing the execution.");
            var product = _repository.Get(_productId);
            product.Quantity -= 1;
            _repository.Update(product);
            _repository.SaveChanges();
        }

        public void Undo()
        {
            Console.WriteLine("calling Undo");
            var product = _repository.Get(_productId);
            product.Quantity += 1;
            _repository.Update(product);
            _repository.SaveChanges();
        }
    }
}
