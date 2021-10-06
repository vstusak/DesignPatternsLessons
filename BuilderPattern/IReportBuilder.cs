using System.Collections.Generic;

namespace BuilderPattern
{
    public interface IReportBuilder
    {
        IReportBuilder Reset();
        IReportBuilder SetHeader();
        IReportBuilder SetAddress(string address);
        IReportBuilder CreateList(IEnumerable<Book> books);
        IReportBuilder SetTimeStamp();
        IReportBuilder SetFooter();
        string Build();
    }
}