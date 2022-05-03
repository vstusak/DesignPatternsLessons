using System;
using System.Collections.Generic;
using System.Linq;
using BuilderPattern.Builder;

namespace BuilderPattern
{
    internal class Program
    {
        private static void Main()
        {
            var books = new List<Book>
            {
                new(){Author = "Robert C. Martin", Name = "Clean Code", NumberOfPages = "324"},
                new(){Author = "Carlton Mellic", Name = "The hunted vagina", NumberOfPages = "250"},
                new(){Author = "Dominic Dan", Name = "Popol všetkych zarovna", NumberOfPages = "netusim"},
                new(){Author = "J. K. Rowling", Name = "Harry Potter", NumberOfPages = "hrozne moc"},
                new(){Author = "Aaron Dembski-Bowden", Name = "Helsreach", NumberOfPages = "416"},
                new(){Author = "J. K. Rowling", Name = "Harry Potter # 2", NumberOfPages = "ještě víc"},
            };

            var authors = books.Where(book => !string.IsNullOrEmpty(book.Author))
                .Select(book => book.Author)
                .Distinct()
                .OrderBy(author => author)
                .ToList();

            foreach (var author in authors)
            {
                Console.WriteLine(author);
            }

            var dateTimeProvider = new DateTimeProvider();
            var builder = new TextBuilder(books, dateTimeProvider);
            //var director = new ReportDirector(builder);
            
            var report = builder.SetHeader().WriteLibrary().SetFooter().AddDateStamp().Build();
            Console.WriteLine(report);
        }
    }
}