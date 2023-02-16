using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _06_DecoratorPattern
{
    public class MoneySender : IWatcher
    {
        private readonly string input;
        private List<IPlugIn> _plugInList = new List<IPlugIn>();

        public MoneySender(string input)
        {
            this.input = input;
        }

        public void EventRaised(TextBox textBox)
        {
            foreach (var plugIn in _plugInList)
            {
                plugIn.BeforeEvent();
            }

            textBox.AppendText($"Sending money with {this.input}" + Environment.NewLine);

            foreach (var plugIn in _plugInList)
            {
                plugIn.AfterEvent();
            }
        }

        public void AddPlugIn(IPlugIn iPlugIn)
        {
            _plugInList.Add(iPlugIn);
        }

        public void RemovePlugIn(IPlugIn iPlugIn)
        {
            _plugInList.Remove(iPlugIn);
        }
    }
}