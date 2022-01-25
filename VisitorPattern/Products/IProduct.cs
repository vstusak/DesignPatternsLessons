using VisitorPattern.VisitableObjects;

namespace VisitorPattern.Products
{
    public interface IProduct: IVisitableObject
    {
        string Name {  get; }
        int Price {  get; }
    }
}
