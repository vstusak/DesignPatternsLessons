using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryDesignPattern;

namespace Cqrs
{
    interface ICommandHandler<TCommand>
    {
        void Execute(TCommand command);
    }

    interface IBuyCommandHandler : ICommandHandler<BuyCommand>
    {
        
    }

    class BuyCommandHandler : IBuyCommandHandler
    {
        private readonly IProductQueryHandler _queryHandler;
        private readonly ProductRepository _repository;

        public BuyCommandHandler(ProductRepository repository, IProductQueryHandler queryHandler)
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
