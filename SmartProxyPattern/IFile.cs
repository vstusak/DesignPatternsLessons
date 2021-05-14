using System.IO;

namespace SmartProxyPattern
{
    public interface IFile
    {
        FileStream GetFileStreamForWrite(string path);
    }
}