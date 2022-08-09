namespace CompositePatternTodoList;
public interface ITodoList : ITodoItem
{
    void Add(ITodoItem item);
    void Remove(ITodoItem item);
}
