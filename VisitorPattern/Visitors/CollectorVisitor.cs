using VisitorPattern.Products;

namespace VisitorPattern.Visitors;

public class CollectorVisitor : IVisitor
{
    private readonly List<Toy> _toys = new();
    private readonly List<Book> _books = new();
    private readonly List<Electronics> _electronics = new();

    public void VisitBook(Book book)
    {
        _books.Add(book);
    }

    public void VisitElectronics(Electronics electronics)
    {
        _electronics.Add(electronics);
    }

    public void VisitToy(Toy toy)
    {
        _toys.Add(toy);
    }

    public void GetReport()
    {
        Console.WriteLine($"Sold {_toys.Count} toys for a total price of {_toys.Sum(t => t.Price)}");
        Console.WriteLine($"Sold {_books.Count} books for a total price of {_books.Sum(t => t.Price)}");
        Console.WriteLine($"Sold {_electronics.Count} electronics for a total price of {_electronics.Sum(t => t.Price)}");
    }
}