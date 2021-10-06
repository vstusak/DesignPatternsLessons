using System.Collections.Generic;

namespace BuilderPattern
{
    class DirectorReportGenerator
    {
        private readonly IReportBuilder _builder;

        public DirectorReportGenerator(IReportBuilder builder)
        {
            _builder = builder;
        }

        public string MakeFullReport(IEnumerable<Book> books)
        {
            //Fancy report (+header, footers)

            return _builder
                .Reset()
                .SetHeader()
                .SetAddress("Adresa Adresovič; Brno")
                .CreateList(books)
                .SetTimeStamp()
                .SetFooter()
                .Build();

            //_builder.Reset();
            //_builder.SetHeader();
            //_builder.SetAddress("Adresa Adresovič; Brno");
            //_builder.CreateList(books);
            //_builder.SetTimeStamp();
            //_builder.SetFooter();
            //return _builder.Build();
        }

        public string MakeListInfo(IEnumerable<Book> books)
        {
            //List of books (+date)

            return _builder
                .Reset()
                .CreateList(books)
                .SetTimeStamp()
                .Build();

            //_builder.Reset();
            //_builder.CreateList(books);
            //_builder.SetTimeStamp();
            //return _builder.Build();
        }
    }
}