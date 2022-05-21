using cosmos_bms_server.Services;

namespace cosmos_bms_server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            await Firebase.SendMessageAsync(txtState.Text);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}