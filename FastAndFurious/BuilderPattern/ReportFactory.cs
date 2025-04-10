// vytvorit report/string, bud jednoducha verze (datum + seznam polozek na sklade) anebo full report (+ header + footer)
// builder obsahuje metody ktere urcuji co vytvorit do seznamu
// director rozhoduje jestli jednoducha nebo full verze
// seznam knizek v knihovne

using System.Text;

namespace BuilderPattern;

public class ReportFactory
{
    private readonly BookRepository _bookRepository;
    private StringBuilder _stringBuilder = new StringBuilder();
    private readonly IMyDateTimeProvider _dateTimeProvider;

    public ReportFactory(BookRepository bookRepository, IMyDateTimeProvider dateTimeProvider)
    {
        _bookRepository = bookRepository;
        _dateTimeProvider = dateTimeProvider;
    }

    private void Reset()
    {
        _stringBuilder = _stringBuilder.Clear();
    }

    public string CreateFullReport()
    {
        var books = GetBooks();
        var builder = new StringBuilder();
        builder.AppendLine("Hello this is content of our library");
        builder.AppendLine(new string('-', 30));
        builder.AppendJoin('\n', books);
        builder.AppendLine($"\nCollected at {_dateTimeProvider.GetDateTime()}");

        return builder.ToString();
    }

    public string CreateSimpleReport()
    {
        var books = GetBooks();
        var builder = new StringBuilder();
        builder.AppendJoin('\n', books);

        return builder.ToString();
    }

    private IEnumerable<Book> GetBooks()
    {
        return _bookRepository.GetAllBooks();
    }
}