namespace BuilderPattern
{
    public class ReportDirector
    {
        private readonly IReportBuilder _builder;

        public ReportDirector(IReportBuilder builder)
        {
            _builder = builder;
        }

        public string Construct()
        {
            _builder.SetHeader();
            _builder.WriteLibrary();
            _builder.SetFooter();
            _builder.AddDateStamp();
            return _builder.Build();
        }
    }
}