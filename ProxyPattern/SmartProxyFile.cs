using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_ProxyPattern
{
    public class SmartProxyFile : IFile
    {
        private FileStream _fileStream;
        private Dictionary<string, FileStream> fileStreams = new Dictionary<string, FileStream>();
        public FileStream OpenWrite(string path)
            //todo: implement dictionary
        {
            if (_fileStream == null)
            {
                _fileStream = File.OpenWrite(path);
            }
            return _fileStream;
        }
    }
}
