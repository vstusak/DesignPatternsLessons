using VisitorPattern.Products;

namespace VisitorPattern.Visitors;

public class DiscountVisitor : IVisitor
{
    
    public void VisitToy(Toy toy)
    {
        throw new NotImplementedException();
    }

    public void VisitBook(Book book)
    {
        throw new NotImplementedException();
    }

    public void VisitElectronics(Electronics electronics)
    {
        throw new NotImplementedException();
    }
}