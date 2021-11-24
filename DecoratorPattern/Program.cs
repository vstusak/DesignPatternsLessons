using System;
using System.Threading;

namespace DecoratorPattern
{
    class Program
    {
        static void Main(string[] args)
        {

            IWatcher watcher = new Watcher();
            watcher = new TinderNotificationForWatcher(watcher);
            watcher = new PerformanceMeasurementForWatcher(watcher);
            watcher.EventRaised();

            watcher = new Watcher();
            watcher = new TinderNotificationForWatcher(watcher);

            Console.ReadLine();
        }
    }


    interface IWatcher
    {
        void EventRaised();
    }

    class Watcher : IWatcher
    {
        public void EventRaised()
        {
            Console.WriteLine("Event has been raised.");
        }
    }

    interface IWatcherDecorator : IWatcher
    {
        //empty
    }

    class TinderNotificationForWatcher : IWatcherDecorator
    {
        private readonly IWatcher _decoratedWatcher;

        public TinderNotificationForWatcher(IWatcher decoratedWatcher)
        {
            _decoratedWatcher = decoratedWatcher;
        }

        public void EventRaised()
        {
            Console.WriteLine("-- Tinder Notification --");
            _decoratedWatcher.EventRaised();
            Console.WriteLine("-- /Tinder Notification --");
            Thread.Sleep(1000);
        }
    }

    class FacebookNotificationForWatcher : IWatcherDecorator
    {
        private readonly IWatcher _decoratedWatcher;

        public FacebookNotificationForWatcher(IWatcher decoratedWatcher)
        {
            _decoratedWatcher = decoratedWatcher;
        }

        public void EventRaised()
        {
            Console.WriteLine("-- Facebook Notification --");
            _decoratedWatcher.EventRaised();
            Console.WriteLine("-- /Facebook Notification --");
            Thread.Sleep(1000);
        }
    }

    class EmailNotificationForWatcher : IWatcherDecorator
    {
        private readonly IWatcher _decoratedWatcher;

        public EmailNotificationForWatcher(IWatcher decoratedWatcher)
        {
            _decoratedWatcher = decoratedWatcher;
        }

        public void EventRaised()
        {
            Console.WriteLine("-- Email Notification --");
            _decoratedWatcher.EventRaised();
            Console.WriteLine("-- /Email Notification --");
            Thread.Sleep(1000);
        }
    }

    class PerformanceMeasurementForWatcher : IWatcherDecorator
    {
        private readonly IWatcher _decoratedWatcher;

        public PerformanceMeasurementForWatcher(IWatcher decoratedWatcher)
        {
            _decoratedWatcher = decoratedWatcher;
        }

        public void EventRaised()
        {
            Console.WriteLine($"-- Perf: {DateTime.Now} --");
            _decoratedWatcher.EventRaised();
            Console.WriteLine($"-- End Perf: {DateTime.Now} --");
        }
    }



}
