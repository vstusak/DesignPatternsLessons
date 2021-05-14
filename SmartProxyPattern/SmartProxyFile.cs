using System.Collections.Generic;
using System.IO;

namespace SmartProxyPattern
{
    public class SmartProxyFile : IFile
    {
        private readonly Dictionary<string, FileStream> _openStreams = new();

        public FileStream GetFileStreamForWrite(string path)
        {
            try
            {
                var stream = File.OpenWrite(path);
                _openStreams.Add(path, stream);
                return stream;
            }
            catch (IOException)
            {
                if (_openStreams.ContainsKey(path))
                {
                    return _openStreams[path];
                }

                throw;
            }
        }
    }
}