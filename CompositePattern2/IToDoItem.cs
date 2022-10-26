using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern2
{
    public interface IToDoItem
    {
        string Name { get; set; }
        string Text { get; set; }
        bool IsCompleted { get; set; }
        string GetString(int depth);
    }
}
