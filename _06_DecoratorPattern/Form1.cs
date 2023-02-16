using System;
using System.Windows.Forms;

namespace _06_DecoratorPattern
{
    public partial class Form1 : Form
    {
        private IWatcher _watcher = new MoneySender("Initial creation");
        private PerformanceMonitorPlugIn _performancePlugin;

        public Form1()
        {
            InitializeComponent();
            _performancePlugin = new PerformanceMonitorPlugIn(textBox1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _watcher.EventRaised(textBox1);

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)
            {
                _watcher = new BankAccountMoneyValidation(_watcher);
                checkBox2.Enabled = false;
            }
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
            {
                _watcher = new PerformanceMonitorDecorator(_watcher);
                checkBox1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _watcher = new MoneySender("Reset assignment");
            checkBox1.Checked = false;
            checkBox1.Enabled = true;
            checkBox2.Checked = false;
            checkBox2.Enabled = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ((MoneySender)_watcher).AddPlugIn(_performancePlugin);
        }
        private void AddMessengerButton_Click(object sender, EventArgs e)
        {
            var messengerPlugIn = new MessengerPlugIn(textBox1);
            ((MoneySender)_watcher).AddPlugIn(messengerPlugIn);
        }

        private void RemovePerformanceButton_Click(object sender, EventArgs e)
        {
            ((MoneySender)_watcher).RemovePlugIn(_performancePlugin);
        }
    }
}