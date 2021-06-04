using System;
using System.Collections.Generic;

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
}