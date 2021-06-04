namespace BuilderPattern
{
    public interface IReportBuilder
    {
        void SetHeader();

        void WriteLibrary();

        void SetFooter();

        void AddDateStamp();

        string Build();
    }
}