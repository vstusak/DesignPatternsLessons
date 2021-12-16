using System;
using System.Windows.Forms;

namespace PublicToilet
{
    public partial class Form1 : Form
    {
        private readonly PublicToilet _toilet;
        public Form1()
        {
            InitializeComponent();
            _toilet = new PublicToilet();
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
    }
}
