namespace CompositePatternTodoList
{
    public class TodoItem : ITodoItem
    {
        public string Caption { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; } = false;

        public ITodoItem Add(ITodoItem item)
        {
            var todoComposite = new TodoCompositeItem()
            {
                Caption = item.Caption,
                Text = item.Text,
                IsDone = item.IsDone
            };

            return todoComposite.Add(item);
        }
    }

    public class TodoCompositeItem : ITodoItem
    {
        public string Caption { get; set; }
        public string Text { get; set; }
        public bool IsDone { get; set; } = false;

        private IList<ITodoItem> Items { get; set; } = new List<ITodoItem>();

        public ITodoItem Add(ITodoItem item)
        {
            Items.Add(item);
            return this;
        }
    }
}
