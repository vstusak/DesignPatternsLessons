using System;
using System.Windows.Forms;

namespace _06_DecoratorPattern
{
    public class MessengerPlugIn : IPlugIn
    {
        private readonly TextBox _textBox;

        public MessengerPlugIn(TextBox textBox)
        {
            _textBox = textBox;
        }
        public void BeforeEvent()
        {
            _textBox.AppendText("Messenger Text Before" + Environment.NewLine);
        }

        public void AfterEvent()
        {
            _textBox.AppendText("Messenger Text After" + Environment.NewLine);
        }
    }
}