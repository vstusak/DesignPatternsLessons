using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryPattern;

namespace CQRS
{
    public interface ICommandHandler<TCommand>
    {
        void Execute(TCommand command);
    }

    public class BuyCommand
    {
        public Guid ProductId { get; set; }

        public BuyCommand(Guid productId)
        {
            ProductId = productId;
        }
    }

    public interface IBuyCommandHandler : ICommandHandler<BuyCommand>
    {
    }

    public class BuyCommandHandler : IBuyCommandHandler
    {
        private readonly ProductRepository _productRepository;

        public BuyCommandHandler(
            ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Execute(BuyCommand command)
        {
            // implementation
        }
    }
}
