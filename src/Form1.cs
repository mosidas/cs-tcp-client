using System;
using System.Drawing;
using System.Net;
using System.Windows.Forms;

namespace tcp_client
{
    public partial class Form1 : Form
    {
        private readonly SslTcpClient _client;
        //private readonly TcpClient _client;

        public Form1()
        {
            InitializeComponent();
            //_client = new TcpClient();
            _client = new SslTcpClient();
            _client.DoAction += WriteReceivedMessageInvoke;
            label_status.Text = "  ";
            label_status.BackColor = Color.LightGray;
        }

        private byte[] WriteReceivedMessageInvoke(byte[] s, IPEndPoint endPoint)
        {
            if (InvokeRequired)
            {
                return (byte[])Invoke(new Func<byte[]>(() =>
                {
                    return WriteReceivedMessage(s, endPoint);
                }));
            }
            else
            {
                return WriteReceivedMessage(s, endPoint);
            }
        }

        private byte[] WriteReceivedMessage(byte[] s, IPEndPoint endPoint)
        {
            var message = System.Text.Encoding.UTF8.GetString(s);
            text_responce.Text += $"from: {endPoint.Address}:{endPoint.Port} - message: {message}" + Environment.NewLine;

            return System.Text.Encoding.UTF8.GetBytes("");
        }

        private void button_sync_Click(object sender, EventArgs e)
        {
            _ = _client.Connect(text_ip.Text, int.Parse(text_port.Text));
            label_status.BackColor = Color.Lime;
        }

        private void button_send_Click(object sender, EventArgs e)
        {
            _client.Send(text_message.Text);
        }

        private void button_close_Click(object sender, EventArgs e)
        {
            _client.DisConnect();
            label_status.BackColor = Color.LightGray;
        }

        private void button_renego_Click(object sender, EventArgs e)
        {
            _client.Renegotiation(text_ip.Text);
        }
    }
}
