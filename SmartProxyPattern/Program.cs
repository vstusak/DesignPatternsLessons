using System;
using System.Collections.Generic;
using System.IO;

namespace SmartProxyPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            IFile file = new SmartFile();

            var filestream1 = file.OpenWrite("log.txt");
            var filestream2 = file.OpenWrite("log.txt");
        }
    }


    public interface IFile
    {        
        FileStream OpenWrite(string path);
    }

    public class StupidFile : IFile
    {        
        public FileStream OpenWrite(string path)
        {
            return File.OpenWrite(path);
        }
    }

    public class SmartFile : IFile
    {
        private readonly Dictionary<string, FileStream> streams= new Dictionary<string, FileStream>();

        public FileStream OpenWrite(string path)
        {

            //if (streams.ContainsKey(path) )
            //{
            //    return streams[path];
            //}

            //var filestream = File.OpenWrite(path);

            //streams.Add(path, filestream);

            //return filestream;

            try
            {
                var filestream = File.OpenWrite(path);

                streams.Add(path, filestream);

                return filestream;
            }
            catch (IOException)
            {

                if (streams.ContainsKey(path))
                {
                    return streams[path];
                }

                throw;
            }

        }
    }
}
