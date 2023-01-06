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

        /// <summary>
        /// tcpサーバーに接続する。(SYN)
        /// </summary>
        /// <param name="ip">tcpサーバーのipアドレス</param>
        /// <param name="port">tcpサーバーのポート番号</param>
        /// <returns></returns>
        public async Task ConnectAsync(string ip, int port)
        {
            client = new System.Net.Sockets.TcpClient();
            try
            {
                await client.ConnectAsync(ip, port);
                Debug.WriteLine("connected");
            }
            catch(SocketException e)
            {
                Debug.WriteLine("connect failed");
                Debug.WriteLine(e.ToString());
                DisConnect();
            }
            catch(Exception x)
            {
                Debug.WriteLine("connect failed");
                Debug.WriteLine(x.ToString());
                DisConnect();
            }
            
        }

        /// <summary>
        /// tcpサーバーにメッセージを送信する
        /// </summary>
        /// <param name="message">送信するメッセージ</param>
        public void Send(string message)
        {
            try
            {
                var ns = client.GetStream();
                Encoding enc = Encoding.UTF8;
                byte[] sendBytes = enc.GetBytes(message);
                ns.Write(sendBytes, 0, sendBytes.Length);
                Debug.WriteLine($"sent message:{message}");
            }
            catch(Exception ex)
            {
                Debug.WriteLine("send failed");
                Debug.WriteLine(ex.ToString());
            }
        }

        /// <summary>
        /// tcpサーバーから切断する(FIN)
        /// </summary>
        public void DisConnect()
        {
            try
            {
                client.Close();
                Debug.WriteLine("disconnected");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("disconnect failed");
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
