using VisitorPattern.Visitors;

namespace VisitorPattern.VisitableObjects
{
    public interface IVisitableObject
    {
        void Accept(IVisitor visitor);
    }
}
