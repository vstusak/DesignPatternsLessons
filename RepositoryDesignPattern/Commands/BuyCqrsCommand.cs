using System;
using System.Collections.Generic;
using System.Text;
using RepositoryDesignPattern.Context;

namespace RepositoryDesignPattern.Commands
{
    public class BuyCqrsCommand
    {
        public Guid ProductId { get; }

        public BuyCqrsCommand(Guid productId)
        {
            ProductId = productId;
        }
    }

    public class BuyCqrsCommandHandler : IBuyCqrsCommandHandler
    {
        private readonly IRepository<Product> _repository;

        public BuyCqrsCommandHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public void Execute(BuyCqrsCommand buyCommand)
        {
            Console.WriteLine("Executing the CQRS execution.");

            var _product = _repository.Get(buyCommand.ProductId);
            if (_product.Quantity > 0)
            {
                _product.Quantity -= 1;
                _repository.Update(_product);
                _repository.SaveChanges();
            }
            else
            {
                Console.WriteLine("Out of stock.");
            }

        }
    }

    public interface IBuyCqrsCommandHandler
    { 
        void Execute(BuyCqrsCommand buyCommand);
    }

}
