using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern2
{
    internal class ToDoList : IToDoList
    {
        private List<IToDoItem> _list = new();

        public string Name { get; set; }

        public string Text { get; set; }

        public bool IsCompleted
        {
            get => _list.Count > 0 && _list.All(i => i.IsCompleted);
            set => _list.ForEach(i => i.IsCompleted = value);
        }

        public void AddItem(IToDoItem item)
        {
            _list.Add(item);
        }

        public string GetString(int depth = 0)
        {
            var result = new StringBuilder();
            result.Append(new string(' ', depth * 4));
            result.AppendLine($"{(IsCompleted ? "[x]" : "[ ]")} {Name}");
            foreach (var item in _list)
            {
                result.Append(item.GetString(depth + 1));
            }

            return result.ToString();
        }
    }
}
