namespace BuilderPattern;

public interface IReportBuilder
{
    IReportBuilder Reset();
    string Build();
    IReportBuilder AddDateTime();
    IReportBuilder AddHeader();
    IReportBuilder AddBooks();
}