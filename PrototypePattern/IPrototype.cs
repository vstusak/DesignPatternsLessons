using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypePattern
{
    public interface IPrototype<T> where T : class
    {
        T ShallowCopy();
        //TODO: Implement in Person
        T DeepCopy();
    }
}
