using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PublicToilet
{
    public partial class Form1 : Form
    {
        private PublicToilet _toilet;
        public Form1()
        {
            InitializeComponent();
            _toilet = new PublicToilet();

        }

        private void swipeCardButton_Click(object sender, EventArgs e)
        {
            _toilet.SwipeCard();

            if (_toilet.ReleaseDoor)
            {
                label1.Text = "Door is unlocked";
                label1.BackColor = Color.Green;
            }
        }

        private void openDoor_Click(object sender, EventArgs e)
        {
            _toilet.OpenDoor();

            if (_toilet.ReleaseDoor)
            {
                label1.Text = "Door is closed";
                label1.BackColor = Color.Red;
            }
        }
    }
}
