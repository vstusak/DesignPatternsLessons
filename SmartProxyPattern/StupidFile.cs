using System.IO;

namespace SmartProxyPattern
{
    public class StupidFile : IFile
    {
        public FileStream GetFileStreamForWrite(string path)
        {
            return File.OpenWrite(path);
        }
    }
}