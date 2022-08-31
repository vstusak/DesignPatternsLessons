using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPattern.Visitors;

namespace VisitorPattern.Products
{
    public interface IVisitable
    {
        void Accept(IVisitor visitor);
    }
}
