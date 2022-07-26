namespace CompositePattern;
public interface IFolder : ISystemItem
{
    void AddItem(ISystemItem item);
    void RemoveItem(string itemName);
}
