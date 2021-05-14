using System;
using System.Text;

namespace SmartProxyPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //var stupidFile = new StupidFile();
            var smartFile = new SmartProxyFile();
            var file = smartFile.GetFileStreamForWrite("stupidFile.txt");
            file.Write(Encoding.ASCII.GetBytes("Example"));

            var file2 = smartFile.GetFileStreamForWrite("stupidFile.txt");
            file2.Write(Encoding.ASCII.GetBytes("Example"));

            Console.ReadLine();
        }
    }
}