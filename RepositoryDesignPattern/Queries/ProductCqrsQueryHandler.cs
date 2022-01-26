using System;
using System.Collections.Generic;
using System.Text;
using RepositoryDesignPattern.Context;

namespace RepositoryDesignPattern.Queries
{
    public class ProductCqrsQueryHandler : IProductCqrsQueryHandler
    {
        private readonly IRepository<Product> _repository;

        public ProductCqrsQueryHandler(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public Product Execute(ProductQuery productQuery)
        {
            return _repository.Get(productQuery.ProductId);
        }
    }

    public interface IProductCqrsQueryHandler
    {
        Product Execute(ProductQuery productQuery);
    }

    public class ProductQuery
    {
        public Guid ProductId { get; }

        public ProductQuery(Guid productId)
        {
            ProductId = productId;
        }
    }
}
