using VisitorPattern.Products;

namespace VisitorPattern.Visitors;

public class StatisticsVisitor : IVisitor
{
    private int _toys=0;
    private int _books=0;
    private int _electronics=0;


    public void VisitToy(Toy toy)
    {
        _toys += 1;
    }

    public void VisitBook(Book book)
    {
        _books += 1;
    }

    public void VisitElectronics(Electronics electronics)
    {
        _electronics += 1;
    }

    public void Report()
    {
        Console.WriteLine($"Sold {_toys} toys.");
        Console.WriteLine($"Sold {_books} books.");
        Console.WriteLine($"Sold {_electronics} electronics.");
    }
}