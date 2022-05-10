using RepositoryPattern;
using RepositoryPattern.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS
{
    public interface IQueryHandler<TQuery,TResult>
    {
        TResult Execute(TQuery query);
    }

    public interface IProductDetailQueryHandler : IQueryHandler<ProductDetailQuery, Product>
    {
    }

    public class ProductDetailQueryHandler : IProductDetailQueryHandler
    {
        private IRepository<Product> _productRepository;
        public ProductDetailQueryHandler(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public Product Execute(ProductDetailQuery query)
        {
            return _productRepository.Get(query.ProductId);
        }
    }

    public class ProductDetailQuery
    {
        public Guid ProductId { get; set; } 
    }
}
