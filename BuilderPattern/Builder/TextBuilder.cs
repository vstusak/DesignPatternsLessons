using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace BuilderPattern.Builder
{
    public class TextBuilder : IReportBuilder
    {
        private readonly IEnumerable _books;
        private readonly StringBuilder _result = new();

        public TextBuilder(IEnumerable<Book> books)
        {
            _books = books;
        }

        public IReportBuilder SetHeader()
        {
            _result.AppendLine("Welcome to our library, there is a list of books.");
            return this;
        }

        public IReportBuilder WriteLibrary()
        {
            foreach (var book in _books)
            {
                _result.AppendLine(book.ToString());
            }
            return this;
        }

        public IReportBuilder SetFooter()
        {
            _result.AppendLine("Thanks for reading.");
            return this;
        }

        public IReportBuilder AddDateStamp()
        {
            _result.AppendLine(DateTime.UtcNow.ToString(CultureInfo.InvariantCulture));
            return this;
        }

        public string Build()
        {
            return _result.ToString();
        }
    }
}