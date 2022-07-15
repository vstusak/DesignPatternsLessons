using RepositoryPattern.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    //public interface IProductRepository
    //{
    //    Product Get(Guid guid);

    //    Product Add(Product product);

    //    Product Update(Product product);

    //    Product Find(Expression<Func<Product, bool>> expression);

    //    IEnumerable<Product> All();

    //    Task SaveChangesAsync();
    //}

    public interface IRepository<T>
    {
        T Get(Guid guid);

        T Add(T entity);

        T Update(T entity);

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        IEnumerable<T> All();

        Task SaveChangesAsync();
    }

    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected readonly WarehouseContext context;

        public GenericRepository(WarehouseContext context)
        {
            this.context = context;
        }

        public virtual T Add(T entity)
        {
            return context.Add(entity).Entity;
        }

        public virtual IEnumerable<T> All()
        {
            return context.Set<T>().ToList();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return context.Set<T>().AsQueryable().Where(expression).ToList();
        }

        public virtual T Get(Guid guid)
        {
            return context.Find<T>(guid);
            //return context.Set<T>().FirstOrDefault(entity => entity.TId == guid);
        }

        public virtual async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }

        public virtual T Update(T entity)
        {
            return context.Set<T>().Update(entity).Entity;
        }
    }
}
