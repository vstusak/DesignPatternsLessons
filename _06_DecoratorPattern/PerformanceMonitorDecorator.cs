using System;
using System.Windows.Forms;

namespace _06_DecoratorPattern
{
    internal class PerformanceMonitorDecorator : IWatcher
    {
        private readonly IWatcher _decoratedObject;

        public PerformanceMonitorDecorator(IWatcher decoratedObject)
        {
            _decoratedObject = decoratedObject;
        }

        public void EventRaised(TextBox textBox)
        {
            var beforeEvent = DateTime.Now.Ticks;
            textBox.AppendText(beforeEvent + Environment.NewLine);
            _decoratedObject.EventRaised(textBox);
            var afterEvent = DateTime.Now.Ticks;
            textBox.AppendText(afterEvent + Environment.NewLine);
            textBox.AppendText(afterEvent-beforeEvent + Environment.NewLine);
        }
    }
}