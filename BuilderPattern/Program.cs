using System;
using System.Linq;
using System.Collections.Generic;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var books = new List<Book>
            {
                new Book{Author="Arthur C. Doyle",Name="Baskervil Dog", NumberOfPages="100"},
                new Book{Author="Robert C. Martin",Name="Clean Code", NumberOfPages="324"},
                new Book{Author="Frenk Abagnale",Name="Catch me if you can", NumberOfPages="650"},
                new Book{Author="Karel Capek",Name="R.U.R.", NumberOfPages="50"},
                new Book{Author="Jorge Orwell",Name="1984", NumberOfPages="350"},
                new Book{Author="Jorge Orwell",Name="1984", NumberOfPages="350"},
                new Book{Author="",Name="1985", NumberOfPages="350"}
            };

            var simpleBuilder = new SimpleReportBuilder();

            var director = new DirectorReportGenerator(simpleBuilder);
            var report = director.MakeFullReport(books);
            var listInfo = director.MakeListInfo(books);

            Console.WriteLine(report);
            Console.WriteLine(listInfo);
            Console.WriteLine();


            //Not builder, just introduce to fluent/linq/anonymous class
            var authors = books
                .Where(book => !string.IsNullOrWhiteSpace(book.Author))
                .Select(book => new { Author = book.Author, Name = book.Name }).Distinct().ToList();

            foreach (var author in authors)
            {
                Console.WriteLine(author.Name);
                Console.WriteLine(author.Author);
            }
            //-------


            Console.ReadLine();
        }

    }
}
