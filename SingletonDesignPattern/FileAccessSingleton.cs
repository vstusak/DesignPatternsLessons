using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPattern
{
    public class FileAccessSingleton
    {
        private static FileAccessSingleton _instance;
        private static readonly object _lockObject = new Object();

        private FileAccessSingleton()
        {
        }

        public static FileAccessSingleton GetInstance()
        {
            lock (_lockObject)
            {
                if (_instance == null)
                {
                    lock (_instance)
                    {
                        _instance = new FileAccessSingleton();
                    }
                }
            }

            return _instance;
        }

        public void WriteToFile(string data)
        {
            File.WriteAllText("temp.txt", data);
        }
    }
}