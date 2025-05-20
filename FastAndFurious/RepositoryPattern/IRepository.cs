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
        public int Create(T entity);
    }
}
