namespace BuilderPattern.Builder
{
    public interface IReportBuilder
    {
        IReportBuilder SetHeader();

        IReportBuilder WriteLibrary();

        IReportBuilder SetFooter();

        IReportBuilder AddDateStamp();

        string Build();
    }
}