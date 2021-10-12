using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public sealed class FileHelper
    {
        private FileHelper()
        {

        }

        private static FileHelper _instance;
        private static readonly object _lockObject = new object();

        static public FileHelper Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock (_lockObject)
                    {
                        _instance ??= new FileHelper(); //Jeste jeden null check protoze se do tehle podmiky muze dostat vice vlaken
                    }
                }

                return _instance;
            }
        }

        public string ReadFile()
        {
            return String.Empty;
        }
    }


}
