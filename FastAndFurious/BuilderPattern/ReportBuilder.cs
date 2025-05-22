// vytvorit report/string, bud jednoducha verze (datum + seznam polozek na sklade) anebo full report (+ header + footer)
// builder obsahuje metody ktere urcuji co vytvorit do seznamu
// director rozhoduje jestli jednoducha nebo full verze
// seznam knizek v knihovne

using System.Text;

namespace BuilderPattern;



public class ReportBuilder : IReportBuilder
{
    private readonly IBookRepository _bookRepository;
    private StringBuilder _stringBuilder = new StringBuilder();
    private readonly IMyDateTimeAdapter _dateTimeAdapter;

    public ReportBuilder(IBookRepository bookRepository, IMyDateTimeAdapter dateTimeAdapter)
    {
        _bookRepository = bookRepository;
        _dateTimeAdapter = dateTimeAdapter;
    }

    public IReportBuilder Reset()
    {
        _stringBuilder = _stringBuilder.Clear();
        return this;
    }

    public string Build()
    {
        return _stringBuilder.ToString();
    }

    public IReportBuilder AddDateTime()
    {
        _stringBuilder.AppendLine($"\nCollected at {_dateTimeAdapter.GetDateTime()}");
        return this;
    }

    public IReportBuilder AddHeader()
    {
        _stringBuilder.AppendLine("Hello this is content of our library");
        _stringBuilder.AppendLine(new string('-', 30));
        return this;
    }

    public IReportBuilder AddBooks()
    {
        var books = GetBooks();
        _stringBuilder.AppendJoin('\n', books);
        return this;
    }

    private IEnumerable<Book> GetBooks()
    {
        return _bookRepository.GetAllBooks();
    }
}