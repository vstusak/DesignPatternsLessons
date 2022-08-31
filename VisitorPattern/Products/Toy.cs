using VisitorPattern.Visitors;

namespace VisitorPattern.Products;

public class Toy : IProduct
{
    public string Name { get; set; }
    public int Price { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitToy(this);
    }
}