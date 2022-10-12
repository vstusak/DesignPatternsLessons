using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    public class MyFile : ISystemItem
    {
        public string Name { get; }
        private readonly int _size;

        public MyFile(string name, int size)
        {
            Name = name;
            _size = size;
        }

        public int GetSize()
        {
            return _size;
        }
    }
}
