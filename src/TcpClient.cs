using System;
using System.Diagnostics;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace tcp_client
{
    public class TcpClient
    {
        private System.Net.Sockets.TcpClient client;


        public async Task ConnectAsync(string ip, int port)
        {
            client = new System.Net.Sockets.TcpClient();
            try
            {
                await client.ConnectAsync(ip, port);
                Debug.WriteLine("Connect");
            }
            catch(SocketException e)
            {
                Debug.WriteLine(e.ToString());
                DisConnect();
            }
            catch(Exception x)
            {
                Debug.WriteLine(x.ToString());
                DisConnect();
            }
            
        }

        public void Send(string message)
        {
            try
            {
                var ns = client.GetStream();
                Encoding enc = Encoding.UTF8;
                byte[] sendBytes = enc.GetBytes(message);
                ns.Write(sendBytes, 0, sendBytes.Length);
                Debug.WriteLine($"Send:{message}");
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                client.Close();
            }
            
        }

        public void DisConnect()
        {
            try
            {
                client.Close();
                Debug.WriteLine("DisConnect");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
