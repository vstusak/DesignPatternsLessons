using System.ComponentModel;
using PublicToilet.ObserverDesignPattern;

namespace PublicToilet
{
    public partial class Form1 : Form
    {
        private readonly IToiletV2 _toilet;
        public Form1()
        {
            InitializeComponent();
            _toilet = new ToiletV2();
            label1.Text = "Free.";
        }
        private void btnEnterToilet_Click(object sender, EventArgs e)
        {
            var result = _toilet.Enter();
            label1.Text = result.DisplayText;
        }

        private void btnSwipeCard_Click(object sender, EventArgs e)
        {
            var result = _toilet.SwipeCard();
            label1.Text = result.DisplayText;
        }

        private void btnLeaveToilet_Click(object sender, EventArgs e)
        {
            var result = _toilet.Leave();
            label1.Text = result.DisplayText;
        }

        private void btnCreateObserver_Click(object sender, EventArgs e)
        {
            var observer = new Observer(_toilet, textBox1);
            var unsubscriber = _toilet.AddObserver(observer);
            lbObservers.Items.Add(unsubscriber);
        }

        private void btnRemoveObserver_Click(object sender, EventArgs e)
        {
            if (lbObservers.SelectedItem is not null)
            {
                ((Unsubscriber)lbObservers.SelectedItem).RemoveObserver();
                lbObservers.Items.Remove(lbObservers.SelectedItem);
            }
        }
    }
}