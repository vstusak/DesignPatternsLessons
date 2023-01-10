using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _06_DecoratorPattern
{
    internal class BankAccounMoneyValidation : IWatcher
    {
        private readonly IWatcher _decoratedObject;
        private int balance = 1001;

        public BankAccounMoneyValidation(IWatcher decoratedObject)
        {
            _decoratedObject = decoratedObject;
        }

        public void EventRaised(TextBox textBox)
        {
            var payment = 500;
            if (balance < payment)
            {
                textBox.AppendText("Payment failed. Low balance. " + Environment.NewLine);
            }
            else
            {
                _decoratedObject.EventRaised(textBox);
                textBox.AppendText("Payment was sent. " + Environment.NewLine);
                balance = balance - payment;
            }
        }
    }
}
