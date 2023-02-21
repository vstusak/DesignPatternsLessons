using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonDesignPattern
{
    public class FileAccessSingleton
    {
        private static FileAccessSingleton _instance;

        public static FileAccessSingleton GetInstance()
        {
            if (_instance == null)
            {
                _instance = new FileAccessSingleton();
            }
            return _instance;
        }

        public void WriteToFile(string data)
        {
            File.WriteAllText("temp.txt", data);
        }
    }
}
