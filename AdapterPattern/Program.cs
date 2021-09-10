using System;

namespace AdapterPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var mySource = Sources.File;
            IReaderAdapter readerAdapter = mySource switch
            {
                Sources.File => new FileReaderAdapter(),
                Sources.Database => new DatabaseReaderAdapter(),
                Sources.Web => new WebReaderAdapter(),
                _ => throw new NotSupportedException("ne"),
            };
            var result = readerAdapter.Read();

            //switch (mySource)
            //{
            //    case Sources.File:
            //        var fileReader = new FileReader();
            //        var file = fileReader.ReadFile();
            //        break;
            //    case Sources.Database:
            //        var dbReader = new DatabaseReader();
            //        var db = dbReader.ReadDatabase();
            //        break;
            //    case Sources.Web:
            //        var webReader = new WebReader();
            //        var web = webReader.ReadWeb();
            //        break;
            //    default:
            //        throw new NotImplementedException("nemam");
            //}
        }
    }

    public interface IReaderAdapter
    {
        string Read();
    }

    public class FileReaderAdapter : IReaderAdapter
    {
        public string Read()
        {
            var fileReader = new FileReader();
            return fileReader.ReadFile();
        }
    }
    public class DatabaseReaderAdapter : IReaderAdapter
    {
        public string Read()
        {
            var dbReader = new DatabaseReader();
            return dbReader.ReadDatabase();
        }
    }
    public class WebReaderAdapter : IReaderAdapter
    {
        public string Read()
        {
            var webReader = new WebReader();
            return webReader.ReadWeb();
        }
    }

    public enum Sources
    {
        File,
        Database,
        Web
    }

    #region third party - not ours!
    public class FileReader
    {
        public string ReadFile()
        {
            return string.Empty;
        }
    }

    public class DatabaseReader
    {
        public string ReadDatabase()
        {
            return string.Empty;
        }
    }

    public class WebReader
    {
        public string ReadWeb()
        {
            return string.Empty;
        }
    }
    #endregion

}
