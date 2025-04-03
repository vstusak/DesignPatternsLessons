// vytvorit report/string, bud jednoducha verze (datum + seznam polozek na sklade) anebo full report (+ header + footer)
// builder obsahuje metody ktere urcuji co vytvorit do seznamu
// director rozhoduje jestli jednoducha nebo full verze
// seznam knizek v knihovne




namespace BuilderPattern;

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