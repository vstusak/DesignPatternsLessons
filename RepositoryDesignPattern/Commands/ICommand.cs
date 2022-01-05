using System;
using System.Threading.Tasks;
using RepositoryDesignPattern.Context;

namespace RepositoryDesignPattern.Commands
{
    internal interface ICommand
    {
        bool CanExecute();
        Task Execute();
    }

    public class BuyCommand : ICommand
    {
        private readonly IRepository<Product> _repository;
        private readonly Product _product;

        public BuyCommand(IRepository<Product> repository, Product product)
        {
            _repository = repository;
            _product = product;
        }

        public bool CanExecute()
        {
            throw new NotImplementedException();
        }

        public async Task Execute()
        {
            Console.WriteLine("Executing the execution.");
            _product.Quantity -= 1;
            _repository.Update(_product);
            await _repository.SaveChangesAsync();
        }
    }
}
