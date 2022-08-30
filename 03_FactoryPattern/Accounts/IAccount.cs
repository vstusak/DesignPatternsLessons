﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_FactoryPattern.Accounts
{
    public interface IAccount
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsFree { get; set; }
    }
}
