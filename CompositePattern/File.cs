using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern;
public class File : ISystemItem
{
    private readonly int size;

    public File(string name, int size)
    {
        Name = name;
        this.size = size;
    }

    public string Name { get; }

    public int GetSize()
     => size;
}
