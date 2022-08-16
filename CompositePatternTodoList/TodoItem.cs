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

        public string GetString(int depth = 0)
        {

            var isDoneText = IsDone
                ? "[x]"
                : "[ ]";

            return $"{GetOs(depth)} {isDoneText} {Caption} - {Text}";

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

        private string GetOs(int depth)
        {
            return new string('O', depth);
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

        public string GetString(int depth = 0)
        {
            var isDoneText = IsDone
                ? "[x]"
                : "[ ]";

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"{GetOs(depth)} {isDoneText} {Caption}-{Text}");

            var newDepth = depth + 1;

            foreach (var item in Items)
            {
                stringBuilder.AppendLine($"{item.GetString(newDepth)}");
            }

            return stringBuilder.ToString();
        }

        public void Remove(ITodoItem item)
        {
            Items.Remove(item);
        }

        private string GetOs(int depth)
        {
            return new string('O', depth);
        }
    }
}
