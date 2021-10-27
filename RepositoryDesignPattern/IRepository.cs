using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RepositoryDesignPattern.Context;

namespace RepositoryDesignPattern
{
    public interface IRepository<T>
    {
        T Get(Guid id);
        T Add(T item);
        T Update(T item);
        T Find(Expression<Func<T, bool>> expression);
        IEnumerable<T> GetAll();
        Task SaveChangesAsync();
    }

    public class ProductRepository : GenericRepository<Product>
    {
        public ProductRepository(WarehouseContext context) : base(context)
        {
        }
        
        public override Product Update(Product product)
        {
            using var context2 = new WarehouseContext();
            var dbProduct = context2.Products.Single(x => x.ProductId == product.ProductId);
            if (dbProduct.Quantity != product.Quantity)
            {
                product.LastQuantityModified = DateTimeOffset.UtcNow;
            }
            return base.Update(product);
        }
    }

    public class GenericRepository<T> : IRepository<T> where T:class
    {
        protected readonly WarehouseContext Context;

        public GenericRepository(WarehouseContext context)
        {
            Context = context;
        }
        public T Get(Guid id)
        {
            return Context.Find<T>(id);
        }

        public T Add(T item)
        {
            return Context.Add(item).Entity;
        }

        public virtual T Update(T item)
        {
            return Context.Update(item).Entity;
        }

        public T Find(Expression<Func<T, bool>> expression)
        {
            return Context.Find<T>(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }

        public async Task SaveChangesAsync()
        {
            await Context.SaveChangesAsync();
        }
    }
}
