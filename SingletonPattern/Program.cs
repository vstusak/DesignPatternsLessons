using System;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var fileHelper = FileHelper.Instance;
            var text = fileHelper.ReadFile();
        }
    }

    // singleton 
    //  - only one private ctor
    //  - one private static field for instance
    //  - sealed class
}
