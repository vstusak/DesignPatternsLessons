using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepositoryDesignPattern;
using RepositoryDesignPattern.Context;
using RepositoryDesignPattern.Queries;

namespace Cqrs
{
    public interface IQueryHandler<TQuery, TResult>
    {
        TResult Execute(TQuery query);
    }

    public interface IProductQueryHandler : IQueryHandler<ProductQuery, Product>
    {
        
    }

    class ProductQueryHandler : IProductQueryHandler
    {
        private ProductRepository _repository;

        public ProductQueryHandler(ProductRepository repository)
        {
            _repository = repository;
        }

        public Product Execute(ProductQuery query)
        {
            return _repository.Get(query.ProductId);
        }
    }
}
