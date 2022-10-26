using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern2
{
    internal class ToDoItem : IToDoItem
    {
        public string Name { get; set; }

        public string Text { get; set; }

        public bool IsCompleted { get; set; } = false;

        public string GetString(int depth = 0)
        {
            var result = new StringBuilder();
            result.Append(new string(' ', depth * 4));
            result.AppendLine($"{(IsCompleted ? "[x]" : "[ ]")} {Name}");
            return result.ToString();
        }
    }
}
