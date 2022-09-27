using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using RepositoryDesignPattern.Context;

namespace RepositoryDesignPattern
{
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

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
