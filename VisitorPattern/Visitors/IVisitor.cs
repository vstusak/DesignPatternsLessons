using VisitorPattern.Products;

namespace VisitorPattern.Visitors;

public interface IVisitor
{
    void VisitBook(Book book);
    void VisitToy(Toy toy);
    void VisitElectronics(Electronics electronics);
}
