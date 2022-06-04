using cosmos_bms_server.Services;
using System.Diagnostics;

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
            string[] result = await Firebase.SendMessageAsync(txtState.Text);
            Debug.WriteLine(result[0]);
            Debug.WriteLine(result[1]);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}