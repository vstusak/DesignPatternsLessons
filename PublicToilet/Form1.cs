using System;
using System.Windows.Forms;
using PublicToilet.ObservatorDesignPattern;

namespace PublicToilet
{
    public partial class Form1 : Form
    {
        private readonly PublicToiletV2 _toilet;
        public Form1()
        {
            InitializeComponent();
            
            _toilet = new PublicToiletV2();
        }

        private void swipeCardButton_Click(object sender, EventArgs e)
        {
            ToiletDoorResult result = _toilet.SwipeCard();
            FillDisplayLabel(result);
        }

        private void openDoor_Click(object sender, EventArgs e)
        {
            ToiletDoorResult result = _toilet.OpenDoor();
            FillDisplayLabel(result);
        }

        private void LeaveToiletButton_Click(object sender, EventArgs e)
        {
            ToiletDoorResult result = _toilet.LeaveToilet();
            FillDisplayLabel(result);
        }

        private void FillDisplayLabel(ToiletDoorResult result)
        {
            DisplayLabel.Text = result.Message;
            DisplayLabel.BackColor = result.Color;
        }

        private void EnableLogging_Click(object sender, EventArgs e)
        {
            var observer = new AdminObserver(textBox1);
            // @TODO Finish unsubscribe in future
            var unsubscriber = _toilet.Subscribe(observer);
            //listView1.Items.Add()
            listBox1.Items.Add(unsubscriber);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            var box = (ListBox)sender;
            var unSubscriber = (UnSubscriber)box.SelectedItem;
            unSubscriber.UnSubscribe();
            box.Items.Remove(unSubscriber);
        }
    }

    
}
