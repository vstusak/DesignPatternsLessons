using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
        void SaveChanges();
    }
}
