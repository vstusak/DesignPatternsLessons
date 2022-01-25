using VisitorPattern.VisitableObjects;
using VisitorPattern.Visitors;

namespace VisitorPattern.Products
{
    public class Toy : IProduct
    {
        public Toy(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }

        public int Price { get; set; }
        public void Accept(IVisitor visitor)
        {
            visitor.VisitToy(this);
        }
    }
}
