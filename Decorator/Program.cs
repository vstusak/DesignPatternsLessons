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

            // idea of "removing" by decorator pattern
            _watcher = new SystemWatcher();
            _watcher = new PostcardNotificationWatcherDecorator(_watcher);
        }

        static void main2()
        {
            IWatcher _watcher = new SystemWatcher();
            List<IPlugin> plugins = new List<IPlugin>();
            plugins.ForEach(p => p.BeforeAction());
            _watcher.EventRaised();
            plugins.ForEach(p => p.AfterAction());
        }
    }

    public interface IPlugin
    {
        void BeforeAction();
        void AfterAction();
    }
}
