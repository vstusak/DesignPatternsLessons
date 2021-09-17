using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            IWatcher _watcher = new SystemWatcher();
            _watcher = new TinderNotificationWatcherDecorator(_watcher);
            _watcher = new PostcardNotificationWatcherDecorator(_watcher);
            _watcher.EventRaised();
            Console.ReadKey();
        }
    }
}
