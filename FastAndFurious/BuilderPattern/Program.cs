// vytvorit report/string, bud jednoducha verze (datum + seznam polozek na sklade) anebo full report (+ header + footer)
// builder obsahuje metody ktere urcuji co vytvorit do seznamu
// director rozhoduje jestli jednoducha nebo full verze
// seznam knizek v knihovne

using System.Collections;

var outputWriter = new OutputWriter();
var reportFactory = new ReportFactory(new BookRepository());

outputWriter.Write("1");



public class Book
{
    public string Author { get; set; }
    public string Name { get; set; }
    public string NumberOfPages { get; set; }
}


public class ReportFactory
{
    private readonly BookRepository _bookRepository;

    public ReportFactory(BookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }
    public string CreateReport()
    {
        //var books = _bookRepository
        return null;
    }
}

public class BookRepository
{
    public List<Book> GetAllBooks()
    {
        return new List<Book>
        {
            new Book{Author="Arthur C. Doyle",Name="Baskervil Dog", NumberOfPages="100"},
            new Book{Author="Robert C. Martin",Name="Clean Code", NumberOfPages="324"},
            new Book{Author="Frenk Abagnale",Name="Catch me if you can", NumberOfPages="650"},
            new Book{Author="Karel Capek",Name="R.U.R.", NumberOfPages="50"},
            new Book{Author="Jorge Orwell",Name="1984", NumberOfPages="350"},
            new Book{Author="Jorge Orwell",Name="1984", NumberOfPages="350"},
            new Book{Author="",Name="1985", NumberOfPages="350"}
        };
    }
}

public class OutputWriter
{
    public void Write(string input)
    {
        Console.WriteLine(input);
    }
}
