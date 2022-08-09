using System.Text;

namespace CompositePatternTodoList
{
    public class TodoItem : ITodoItem
    {
        public string Caption { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; } = false;

        public TodoItem(string caption, string text)
        {
            Caption = caption;
            Text = text;
        }

        public string GetString()
        {
            var isDoneText = IsDone
                ? "[x]"
                : string.Empty;

            return $"{isDoneText} {Caption} - {Text}";

            //public ITodoItem Add(ITodoItem item)
            //{
            //    var todoComposite = new TodoCompositeItem()
            //    {
            //        Caption = item.Caption,
            //        Text = item.Text,
            //        IsDone = item.IsDone
            //    };

            //    return todoComposite.Add(item);
            //}
        }
    }

    public class TodoCompositeItem : ITodoList
    {
        public string Caption { get; set; }

        public string Text { get; set; }

        public bool IsDone
        {
            get => Items.All(item => item.IsDone);
            set => Items.ForEach(i => i.IsDone = value);
        }

        private List<ITodoItem> Items { get; set; } = new List<ITodoItem>();

        public TodoCompositeItem(string caption, string text)
        {
            Caption = caption;
            Text = text;
        }

        public void Add(ITodoItem item)
        {
            Items.Add(item);
        }

        public string GetString()
        {
            var isDoneText = IsDone
                ? "[x]"
                : string.Empty;

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{isDoneText} {Caption}-{Text}");

            foreach (var item in Items)
            {
                stringBuilder.AppendLine($"-{item.GetString()}");
            }

            return stringBuilder.ToString();
        }

        public void Remove(ITodoItem item)
        {
            Items.Remove(item);
        }
    }
}
