using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

            Console.WriteLine("---------------------");

            IWatcher watcher2 = new Watcher();
            watcher2.AddPlugin(TinderPlugin.Name, new TinderPlugin());
            watcher2.AddPlugin(PerformancePlugin.Name, new PerformancePlugin());
            watcher2.EventRaised();
            watcher2.RemovePlugin(TinderPlugin.Name);

            Console.ReadLine();
        }
    }


    interface IWatcher
    {
        void AddPlugin(string name, IPlugin plugin);
        void EventRaised();
        void RemovePlugin(string pluginName);
    }

    class Watcher : IWatcher
    {
        private Dictionary<string, IPlugin> plugins { get; set; } = new Dictionary<string, IPlugin>();
        public void EventRaised()
        {
            foreach (IPlugin plugin in plugins.Values)
            {
                plugin.BeforeEvent();
            }

            Console.WriteLine("Event has been raised.");

            foreach(IPlugin plugin in plugins.Values)
            {
                plugin.AfterEvent();
            }
        }

        public void AddPlugin(string name, IPlugin plugin)
        {
            plugins[name] = plugin;
        }

        public void RemovePlugin(string pluginName)
        {
            plugins.Remove(pluginName);
        }
    }

    public interface IPlugin
    {
        static string Name { get; }
        void BeforeEvent();
        void AfterEvent();
    }

    public class TinderPlugin : IPlugin
    {
        public static string Name => "Tinder";

        public void AfterEvent()
        {
            Console.WriteLine("-- /Tinder Notification --");
        }

        public void BeforeEvent()
        {
            Console.WriteLine("-- Tinder Notification --");
        }
    }

    public class PerformancePlugin : IPlugin
    {
        public static string Name => "Performance";

        public void AfterEvent()
        {
            Console.WriteLine($"-- End Perf: {DateTime.Now} --");
        }

        public void BeforeEvent()
        {
            Console.WriteLine($"-- Perf: {DateTime.Now} --");
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

        public void AddPlugin(string name, IPlugin plugin)
        {
            throw new NotImplementedException();
        }

        public void EventRaised()
        {
            Console.WriteLine("-- Tinder Notification --");
            _decoratedWatcher.EventRaised();
            Console.WriteLine("-- /Tinder Notification --");
            Thread.Sleep(1000);
        }

        public void RemovePlugin(string pluginName)
        {
            throw new NotImplementedException();
        }
    }

    class FacebookNotificationForWatcher : IWatcherDecorator
    {
        private readonly IWatcher _decoratedWatcher;

        public FacebookNotificationForWatcher(IWatcher decoratedWatcher)
        {
            _decoratedWatcher = decoratedWatcher;
        }

        public void AddPlugin(string name, IPlugin plugin)
        {
            throw new NotImplementedException();
        }

        public void EventRaised()
        {
            Console.WriteLine("-- Facebook Notification --");
            _decoratedWatcher.EventRaised();
            Console.WriteLine("-- /Facebook Notification --");
            Thread.Sleep(1000);
        }

        public void RemovePlugin(string pluginName)
        {
            throw new NotImplementedException();
        }
    }

    class EmailNotificationForWatcher : IWatcherDecorator
    {
        private readonly IWatcher _decoratedWatcher;

        public EmailNotificationForWatcher(IWatcher decoratedWatcher)
        {
            _decoratedWatcher = decoratedWatcher;
        }

        public void AddPlugin(string name, IPlugin plugin)
        {
            throw new NotImplementedException();
        }

        public void EventRaised()
        {
            Console.WriteLine("-- Email Notification --");
            _decoratedWatcher.EventRaised();
            Console.WriteLine("-- /Email Notification --");
            Thread.Sleep(1000);
        }

        public void RemovePlugin(string pluginName)
        {
            throw new NotImplementedException();
        }
    }

    class PerformanceMeasurementForWatcher : IWatcherDecorator
    {
        private readonly IWatcher _decoratedWatcher;

        public PerformanceMeasurementForWatcher(IWatcher decoratedWatcher)
        {
            _decoratedWatcher = decoratedWatcher;
        }

        public void AddPlugin(string name, IPlugin plugin)
        {
            throw new NotImplementedException();
        }

        public void EventRaised()
        {
            Console.WriteLine($"-- Perf: {DateTime.Now} --");
            _decoratedWatcher.EventRaised();
            Console.WriteLine($"-- End Perf: {DateTime.Now} --");
        }

        public void RemovePlugin(string pluginName)
        {
            throw new NotImplementedException();
        }
    }



}
