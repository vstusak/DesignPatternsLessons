using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPattern
{
    public class FileAdapterExample
    {
        private readonly IFileAdapter _fileAdapter;

        public FileAdapterExample(IFileAdapter fileAdapter)
        {
            _fileAdapter = fileAdapter;
        }

        public string Read(string path)
        {

            if (_fileAdapter.Exists(path))
            {
                return _fileAdapter.ReadAllText(path);
            }

            return string.Empty;
        }
    }

    public interface IFileAdapter
    {
        bool Exists(string path);

        string ReadAllText(string path);
    }

    public class FileAdapter : IFileAdapter
    {
        public bool Exists(string path) => File.Exists(path);

        public string ReadAllText(string path) => File.ReadAllText(path);
    }
}
