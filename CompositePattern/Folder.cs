using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern;
public class Folder : IFolder
{
    private IList<ISystemItem> systemItems = new List<ISystemItem>();

    public Folder(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public int GetSize()
    {
        return systemItems.Sum(si => si.GetSize());
    }

    public void AddItem(ISystemItem item)
    {
        // todo create extension for systemItems.Contains (string name)
        if (systemItems.Any(si => si.Name == item.Name))
        {
            Console.WriteLine($"{item.Name} already exists.");
            return;
        }

        systemItems.Add(item);
    }

    public void RemoveItem(string itemName)
    {
        var item = systemItems.FirstOrDefault(si => si.Name == itemName);
        if(item != null)
        {
            systemItems.Remove(item);
        }
    }
}
