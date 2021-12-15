using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
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

            Console.WriteLine("BeforeParalleForEach");

            Parallel.ForEach(fileNames, options, fileName =>
            {
                var helper = FileHelper3.GetInstance();
                var result = helper.ReadFile(fileName);

                Console.WriteLine(result);
            });
        }
    }

    public sealed class FileHelper3
    {
        private static readonly Lazy<FileHelper3> _instance = new Lazy<FileHelper3>(() => new FileHelper3());

        private FileHelper3()
        {
            Thread.Sleep(10000);
            Console.WriteLine("calling constructor ...");
        }

        public static FileHelper3 GetInstance()
        {
            Console.WriteLine("GetInstance");
            return _instance.Value;
        }

        public string ReadFile(string fileName)
        {
            Console.WriteLine("Hello World!");
            return fileName;
        }
    }

    public sealed class FileHelper2
    {
        private static readonly FileHelper2 _instance = new FileHelper2();

        static FileHelper2()
        {
            Console.WriteLine("calling static constructor ...");
        }
        private FileHelper2()
        {
            Console.WriteLine("calling constructor ...");
        }

        public static FileHelper2 GetInstance()
        {
            Console.WriteLine("GetInstance");
            return _instance;
        }

        public string ReadFile(string fileName)
        {
            Console.WriteLine("Hello World!");
            return fileName;
        }
    }

    public sealed class FileHelper
    {
        private static FileHelper _instance;
        private static readonly Object peadlock = new object();

        private FileHelper()
        {
            Console.WriteLine("calling constructor ...");
        }

        public static FileHelper GetInstance()
        {
            //return _instance ?? _instance = new FileHelper();
            if (_instance == null)
            {
                lock (peadlock)
                {
                    if (_instance == null)
                    {
                        _instance = new FileHelper();
                    }
                }
            }
            return _instance;
        }

        public string ReadFile(string fileName)
        {
            Console.WriteLine("Hello World!");
            return fileName;
        }
    }
}
