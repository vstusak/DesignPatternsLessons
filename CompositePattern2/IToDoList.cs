﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompositePattern2
{
    public interface IToDoList : IToDoItem
    {
        void AddItem(IToDoItem item);
        //void RemoveItem(IToDoItem item);
    }
}
