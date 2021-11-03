using System;

namespace AdapterPattern
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var fileReader = new FileReader();
            var databaseReader = new DatabaseReader();
            var webReader = new WebReader();
            //***************************************

            var stringResult = string.Empty;
            var mySource = Sources.database;

            //switch (mySource)
            //{
            //    case Sources.file:
            //        stringResult = fileReader.ReadFile();
            //        break;
            //    case Sources.database:
            //        stringResult = databaseReader.ReadDatabase();
            //        break;
            //    case Sources.web:
            //        stringResult = webReader.ReadWeb();
            //        break;
            //    default:
            //        throw new ArgumentOutOfRangeException();
            //}

            IReaderAdapter readerAdapter = null;

            switch (mySource)
            {
                case Sources.file:
                    readerAdapter = new FileReaderAdapter();
                    break;
                case Sources.database:
                    readerAdapter = new DatabaseReaderAdapter();
                    break;
                case Sources.web:
                    readerAdapter = new WebReaderAdapter();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            stringResult = readerAdapter.Read();

            Console.WriteLine(stringResult);
            Console.ReadLine();
        }
    }

    interface IReaderAdapter
    {
        string Read();
    }

    public class FileReaderAdapter : IReaderAdapter
    {
        public string Read()
        {
            var fileReader = new FileReader(); // Should be taken from constructor by dependency injection
            return fileReader.ReadFile();
        }
    }

    public class DatabaseReaderAdapter : IReaderAdapter
    {
        public string Read()
        {
            var databaseReader = new DatabaseReader(); // Should be taken from constructor by dependency injection
            return databaseReader.ReadDatabase();
        }
    }

    public class WebReaderAdapter : IReaderAdapter
    {
        public string Read()
        {
            var webReader = new WebReader(); // Should be taken from constructor by dependency injection
            return webReader.ReadWeb();
        }
    }

    //*** 3rd party library - can't edit ***

    public class FileReader
    {
        public string ReadFile()
        {
            return "ReadByFileReader";
        }
    }

    public class DatabaseReader
    {
        public string ReadDatabase()
        {
            return "ReadByDatabaseReader";
        }
    }

    public class WebReader
    {
        public string ReadWeb()
        {
            return "ReadByWebReader";
        }
    }

    public enum Sources
    {
        file,
        database,
        web
    }
}
