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
        Task Execute(TCommand command);
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
        private readonly IProductDetailQueryHandler _productDetailQueryHandler;

        public BuyCommandHandler(
            ProductRepository productRepository, IProductDetailQueryHandler productDetailQueryHandler)
        {
            _productRepository = productRepository;
            _productDetailQueryHandler = productDetailQueryHandler;
        }

        public async Task Execute(BuyCommand command)
        {
            //var product = _productRepository.Get(command.ProductId);
            var query = new ProductDetailQuery { 
            ProductId = command.ProductId
            };
            
            var product = _productDetailQueryHandler.Execute(query);
            product.Quantity =- 1;
            _productRepository.Update(product);
            await _productRepository.SaveChangesAsync();
        }
    }
}
