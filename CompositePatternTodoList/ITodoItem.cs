namespace CompositePatternTodoList
{
    public interface ITodoItem
    {
        string Caption { get; set; }
        bool IsDone { get; set; }
        string Text { get; set; }
        string GetString(int depth = 0);
    }
}