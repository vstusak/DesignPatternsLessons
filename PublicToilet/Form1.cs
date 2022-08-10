namespace PublicToilet
{
    public partial class Form1 : Form
    {
        private readonly IToilet _toilet;
        public Form1()
        {
            InitializeComponent();
            _toilet = new ToiletV2();
            label1.Text = "Free.";
            label2.Text = ToiletState.Free.ToString();
        }
        private void btnEnterToilet_Click(object sender, EventArgs e)
        {
            var result = _toilet.Enter();
            label1.Text = result.DisplayText;
            label2.Text = result.ToiletState.ToString();
        }

        private void btnSwipeCard_Click(object sender, EventArgs e)
        {
            var result = _toilet.SwipeCard();
            label1.Text = result.DisplayText;
            label2.Text = result.ToiletState.ToString();
        }

        private void btnLeaveToilet_Click(object sender, EventArgs e)
        {
            var result = _toilet.Leave();
            label1.Text = result.DisplayText;
            label2.Text = result.ToiletState.ToString();
        }
    }
}