﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern
{
    public interface IFolder:ISystemItem
    {
        void AddItem(ISystemItem item);
        void RemoveItem(string Name);
    }
}