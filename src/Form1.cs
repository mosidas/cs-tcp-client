using System;
using System.Drawing;
using System.Windows.Forms;

namespace tcp_client
{
    public partial class Form1 : Form
    {
        public TcpClient Client;

        public Form1()
        {
            InitializeComponent();
            Client = new TcpClient();
            label_status.Text = "  ";
            label_status.BackColor = Color.LightGray;
        }

        private void button_sync_Click(object sender, EventArgs e)
        {
            _ = Client.ConnectAsync(text_ip.Text, int.Parse(text_port.Text));
            label_status.BackColor = Color.Lime;
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            Client.Send(text_message.Text);
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            Client.DisConnect();
            label_status.BackColor = Color.LightGray;
        }
    }
}
