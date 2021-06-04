using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    public class TextBuilder : IReportBuilder
    {
        private readonly IEnumerable _books;
        private readonly StringBuilder _result = new();

        public TextBuilder(IEnumerable<Book> books)
        {
            _books = books;
        }

        public void SetHeader()
        {
            _result.AppendLine("Welcome to our library, there is a list of books.");
        }

        public void WriteLibrary()
        {
            foreach (var book in _books)
            {
                _result.AppendLine(book.ToString());
            }
        }

        public void SetFooter()
        {
            _result.AppendLine("Thanks for reading.");
        }

        public void AddDateStamp()
        {
            _result.AppendLine(DateTime.UtcNow.ToString());
        }

        public string Build()
        {
            return _result.ToString();
        }
    }
}