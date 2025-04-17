namespace BuilderPattern;

public class ReportDirector
{
    private IReportBuilder _reportBuilder;

    public ReportDirector(IReportBuilder reportBuilder)
    {
        this._reportBuilder = reportBuilder;
    }

    public string CreateReportBasedOnParameters(string command)
    {
        if (command == "s")
        {
            return CreateSimpleReport();
        }
        else if (command == "f")
        {
            return CreateFullReport();
        }
        else
        {
            throw new NotSupportedException(command);
        }
    }

    public string CreateFullReport()
    {
        return _reportBuilder.Reset()
            .AddHeader()
            .AddBooks()
            .AddDateTime()
            .Build();
    }

    public string CreateSimpleReport()
    {
        return _reportBuilder.Reset()
            .AddBooks()
            .Build();
    }
}

//public class Extensions
//{
//    public static AddCustomText(this IReportBuilder reportBuilder, string customText)
//    {
//    }
//}