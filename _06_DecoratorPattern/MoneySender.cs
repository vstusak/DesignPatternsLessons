using System;
using System.Windows.Forms;

namespace _06_DecoratorPattern
{
    public class MoneySender : IWatcher
    {
        public void EventRaised(TextBox textBox)
        {
            textBox.AppendText("Sending money" + Environment.NewLine);
        }
    }
}