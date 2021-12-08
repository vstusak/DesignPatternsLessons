using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            //var singleton = FileHelper.GetInstance();
            //var result = singleton.ReadFile("myFile");
            //Console.WriteLine(result);

            var fileNames = new List<string>() { "one", "two", "three" };
            var options = new ParallelOptions() { MaxDegreeOfParallelism = 3 };

            Parallel.ForEach(fileNames, options, fileName =>
            {
                var helper = FileHelper.GetInstance();
                var result = helper.ReadFile(fileName);

                Console.WriteLine(result);
            });


        }
    }


    public sealed class FileHelper
    {
        private static FileHelper _instance;

        private FileHelper()
        {
            Console.WriteLine("calling constructor ...");
        }

        public static FileHelper GetInstance()
        {
            return _instance ??= new FileHelper();
        }

        public string ReadFile(string fileName)
        {
            Console.WriteLine("Hello World!");
            return fileName;
        }
    }
}
