using System;

namespace SingletonPattern
{
    public sealed class LazyFileHelper
    {
        private static readonly Lazy<LazyFileHelper> _instance = new Lazy<LazyFileHelper>();

        public static LazyFileHelper Instance { 
            get 
            { 
                return _instance.Value; 
            } 
        }

        private LazyFileHelper()
        {

        }
    }
}
