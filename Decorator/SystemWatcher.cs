using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public interface IWatcher
    {
        void EventRaised();
    }

    public class SystemWatcher : IWatcher
    {
        public void EventRaised()
        {
            Console.WriteLine("System watcher event raised");
        }
    }

    public class NetworkWatcher : IWatcher
    {
        public void EventRaised()
        {
            Console.WriteLine("Network watcher event raised");
        }
    }

    ///////////////////////////////

    public class EmailNotificationWatcherDecorator : IWatcher
    {

        public EmailNotificationWatcherDecorator(IWatcher watcher)
        {
            _decoratedWatcher = watcher;
        }

        private IWatcher _decoratedWatcher;

        public void EventRaised()
        {
            Console.WriteLine($"Sending email using {nameof(EmailNotificationWatcherDecorator)}");
            //var name = this.GetType().Name;
            _decoratedWatcher.EventRaised();
        }
    }

    public class TinderNotificationWatcherDecorator : IWatcher
    {

        public TinderNotificationWatcherDecorator(IWatcher watcher)
        {
            _decoratedWatcher = watcher;
        }

        private IWatcher _decoratedWatcher;

        public void EventRaised()
        {
            Console.WriteLine($"Tinder notification using {nameof(TinderNotificationWatcherDecorator)}");
            //var name = this.GetType().Name;
            _decoratedWatcher.EventRaised();
        }
    }


    public class PostcardNotificationWatcherDecorator : IWatcher
    {

        public PostcardNotificationWatcherDecorator(IWatcher watcher)
        {
            _decoratedWatcher = watcher;
        }

        private IWatcher _decoratedWatcher;

        public void EventRaised()
        {
            Console.WriteLine($"Tinder notification using {nameof(PostcardNotificationWatcherDecorator)}");
            //var name = this.GetType().Name;
            _decoratedWatcher.EventRaised();
        }
    }
}
