using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    public sealed class StaticFileHelper
    {
        private static readonly StaticFileHelper _instance = new StaticFileHelper();

        public static readonly string RandomString = "hello";

        public static StaticFileHelper Instance { 
            get 
            {
                return _instance;
            } 
        }

        static StaticFileHelper()
        {

        }

        public string ReadFile()
        {
            return String.Empty;
        }
    }
}
