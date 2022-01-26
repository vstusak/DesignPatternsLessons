using System;
using System.Collections.Generic;
using System.Text;
using RepositoryDesignPattern.Context;
using RepositoryDesignPattern.Queries;

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
        private readonly IProductCqrsQueryHandler _queryHandler;

        public BuyCqrsCommandHandler(IRepository<Product> repository, IProductCqrsQueryHandler queryHandler)
        {
            _repository = repository;
            _queryHandler = queryHandler;
        }

        public void Execute(BuyCqrsCommand buyCommand)
        {
            Console.WriteLine("Executing the CQRS execution.");

            var query = new ProductQuery(buyCommand.ProductId);
            var _product = _queryHandler.Execute(query);

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
