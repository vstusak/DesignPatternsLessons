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
        private bool _isCompleted;

        public string Name { get; set; }

        public string Text { get; set; }

        public bool IsCompleted
        {
            get
            {
                if (_list.Any())
                {
                    return _list.All(i => i.IsCompleted);
                }
                else
                {
                    return _isCompleted;
                }
            }
            set
            {
                if (_list.Any())
                {
                    _list.ForEach(i => i.IsCompleted = value);
                }
                else
                {
                    _isCompleted = value;
                }                 
            }
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
