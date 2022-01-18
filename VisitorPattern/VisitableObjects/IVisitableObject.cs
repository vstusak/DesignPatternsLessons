using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisitorPattern
{
    internal interface IVisitableObject
    {
        internal void Accept(IVisitor visitor);
    }
}
