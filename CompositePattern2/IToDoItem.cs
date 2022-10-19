using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern2
{
    public interface IToDoItem
    {
        string Name { get; }
        string Text { get; }
        bool IsCompleted { get; }
        string GetString();
    }
}
