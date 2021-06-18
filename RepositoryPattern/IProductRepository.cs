using RepositoryPattern.Context;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public interface IProductRepository
    {
        Product Get(Guid guid);

        Product Add(Product product);

        Product Update(Product product);

        Product Find(Expression<Func<Product, bool>> expression);

        IEnumerable<Product> All();

        Task SaveChangesAsync();
    }
}
