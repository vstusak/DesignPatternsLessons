using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryPattern.Accounts
{
    public interface IAccount
    {
        string AccountType { get; }
        bool IsFree { get; }
    }
}
