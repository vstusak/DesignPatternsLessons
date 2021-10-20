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

    public class GenericRepository<T> : IRepository<T> where T:class
    {
        private readonly WarehouseContext _context;

        public GenericRepository(WarehouseContext context)
        {
            _context = context;
        }
        public T Get(Guid id)
        {
            return _context.Find<T>(id);
        }

        public T Add(T item)
        {
            return _context.Add(item).Entity;
        }

        public T Update(T item)
        {
            return _context.Update(item).Entity;
        }

        public T Find(Expression<Func<T, bool>> expression)
        {
            return _context.Find<T>(expression);
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
