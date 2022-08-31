using VisitorPattern.Visitors;

namespace VisitorPattern.Products;

public class Electronics : IProduct
{
    public string Name { get; set; }
    public int Price { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitElectronics(this);
    }
}