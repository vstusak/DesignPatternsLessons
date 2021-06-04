using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace BuilderPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var books = new List<Book>
            {
                new Book(){Author = "Robert C. Martin", Name = "Clean Code", NumberOfPages = "324"},
                new Book(){Author = "Carlton Mellic", Name = "The hunted vagina", NumberOfPages = "250"},
                new Book(){Author = "Dominic Dan", Name = "Popol všetkych zarovna", NumberOfPages = "netusim"},
                new Book(){Author = "J. K. Rowling", Name = "Harry Potter", NumberOfPages = "hrozne moc"},
                new Book(){Author = "Aaron Dembski-Bowden", Name = "Helsreach", NumberOfPages = "416"}
            };

            var builder = new TextBuilder(books);
            var director = new ReportDirector(builder);

            var report = director.Construct();

            Console.WriteLine(report);
        }
    }

    public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public string NumberOfPages { get; set; }

        public override string ToString()
        {
            return $"Name: {Name}, ({Author}, {NumberOfPages})";
        }
    }

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

    public interface IReportBuilder
    {
        void SetHeader();

        void WriteLibrary();

        void SetFooter();

        void AddDateStamp();

        string Build();
    }

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