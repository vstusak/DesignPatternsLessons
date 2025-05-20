using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern
{
    public interface IRepository<T>
    {
        public T Get(int id);
        public int Add(T entity);
        public void AddRange(ICollection<T>  entities);
        public IEnumerable<T> GetAll();
    }
}
