using System.Linq.Expressions;

namespace _04_RepositoryPattern
{
    internal interface IRepository<T>
    {
        IEnumerable<T> GetAll();
        T Add(T item);
        T Update(T item);
        T Get(Guid id);
        void Remove(T item);

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
    }
}