using System;
using RepositoryDesignPattern;
using RepositoryDesignPattern.Context;

namespace Cqrs
{
    public class BuyCommandHandler : IBuyCommandHandler
    {
        private readonly IProductQueryHandler _queryHandler;
        private readonly IRepository<Product> _repository;

        public BuyCommandHandler(IRepository<Product> repository, IProductQueryHandler queryHandler)
        {
            _repository = repository;
            _queryHandler = queryHandler;
        }

        public void Execute(BuyCommand command)
        {
            Console.WriteLine("Executing the CQRS execution.");

            var query = new ProductQuery(command.ProductId);
            var product = _queryHandler.Execute(query);

            if (product.Quantity > 0)
            {
                product.Quantity -= 1;
                _repository.Update(product);
                _repository.SaveChanges();
            }
            else
            {
                Console.WriteLine("Out of stock.");
            }
        }
    }
}