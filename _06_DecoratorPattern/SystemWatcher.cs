using System;
using System.Windows.Forms;

namespace _06_DecoratorPattern
{
    public class SystemWatcher : IWatcher
    {
        public void EventRaised(TextBox textBox)
        {
            textBox.AppendText("Something happened" + Environment.NewLine);
        }
    }
}