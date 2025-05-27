namespace DecoratorPattern
{
    public partial class Form1 : Form
    {
        private INotificator _notificator;

        public Form1()
        {
            InitializeComponent();
            _notificator = new BaseNotificator(output);
        }

        public static void WriteToConsole(string message)
        {
            
        }

        private void FacebookBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void EmailBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void SlackBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void TinderBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void ChromeBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void HitEvent_Click(object sender, EventArgs e)
        {
            _notificator.RaiseEvent();
        }
    }
}
