using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VisitorPattern.Products;

namespace VisitorPattern.Visitors
{
    public class ToyDiscountVisitor : IVisitor
    {
        private int _discountPercentage { get; set; }

        public void VisitBook(Book book)
        {
            //not appliable
        }

        public void VisitElectronics(Electronics electronics)
        {
            //not appliable
        }

        public void VisitToy(Toy toy)
        {
            toy.Price -= (int)(toy.Price * _discountPercentage / 100.0);
        }

        public ToyDiscountVisitor(int discountPercentage)
        {
            _discountPercentage = discountPercentage;
        }
    }
}
