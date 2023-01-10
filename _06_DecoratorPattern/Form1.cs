using System;
using System.Windows.Forms;

namespace _06_DecoratorPattern
{
    public partial class Form1 : Form
    {
        private IWatcher _watcher = new MoneySender();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _watcher.EventRaised(textBox1);

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            _watcher = new BankAccounMoneyValidation(_watcher);
        }

        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}