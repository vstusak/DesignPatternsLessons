using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility2.Handlers
{
    public enum HandlerType
    {
        Unknown,
        Default,
        Validation,
        Cash
    }
}
