namespace CompositePattern;

class MyFolder : IFolder
{
    private List<ISystemItem> _items= new List<ISystemItem>();

    public MyFolder(string Name)
    {
        this.Name = Name;
    }

    public void AddItem(ISystemItem item)
    {
        if (_items.Any(si=> si.Name == item.Name))
        {
            Console.WriteLine($"Item {item.Name} already added");
            return;
        }
        _items.Add(item);
    }
        
    public void RemoveItem(string Name)
    {
        _items.Remove(null);
        var forRemoval = _items.SingleOrDefault(si => si.Name == Name);

        if (forRemoval != null)
        {
            _items.Remove(forRemoval);
        }
    }

    public string Name { get; }
    public int GetSize()
    {
        return _items.Sum(si => si.GetSize());
    }
}