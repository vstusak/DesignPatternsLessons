using System;
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
                new Book{Author="Jorge Orwell",Name="1984", NumberOfPages="350"}
            };
        }
    }
}
