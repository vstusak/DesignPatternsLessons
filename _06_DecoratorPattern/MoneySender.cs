using System;
using System.Windows.Forms;

namespace _06_DecoratorPattern
{
    public class MoneySender : IWatcher
    {
        private readonly string input;

        public MoneySender(string input)
        {
            this.input = input;
        }

        public void EventRaised(TextBox textBox)
        {
            textBox.AppendText($"Sending money with {this.input}" + Environment.NewLine);
        }
    }
}