using VisitorPattern.Products;

namespace VisitorPattern.Visitors
{
    public interface IVisitor
    {
        void VisitToy(Toy toy);
        void VisitBook(Book book);
        void VisitElectronics(Electronics electronics);
    }
}
