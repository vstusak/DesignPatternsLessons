using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public class FileLogger
    {

        private static FileLogger _instance = null;

        private readonly string _filePath = "log.txt";

        private FileLogger()
        {
            
        }
        public static FileLogger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FileLogger();
            }
            return _instance;
        }

        public void LogToFile(string message)
        {
            using StreamWriter writer = new StreamWriter(new FileStream(_filePath, FileMode.OpenOrCreate));
            writer.WriteLine(message);
        }
    }
}
