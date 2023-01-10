using System;
using System.Diagnostics;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace tcp_client
{
    public class SslTcpClient
    {
        public delegate byte[] ReceiveMessageCallback(byte[] message, IPEndPoint endPoint);
        public event ReceiveMessageCallback DoAction;

        private System.Net.Sockets.TcpClient _client;
        private SslStream _sslStream;

        public static bool ValidateServerCertificate(
              object sender,
              X509Certificate certificate,
              X509Chain chain,
              SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
            {
                return true;
            }

            Debug.WriteLine("Certificate error: {0}", sslPolicyErrors);

            return false;
        }


        /// <summary>
        /// tcpサーバーに接続する。(SYN)
        /// </summary>
        /// <param name="serverName">tcpサーバーのipアドレス</param>
        /// <param name="port">tcpサーバーのポート番号</param>
        /// <returns></returns>
        public async Task Connect(string serverName, int port)
        {
            _client = new System.Net.Sockets.TcpClient();
            try
            {
                await _client.ConnectAsync("127.0.0.1", port);
                
                _sslStream = new SslStream(
                    _client.GetStream(),
                    false,
                    new RemoteCertificateValidationCallback(ValidateServerCertificate),
                    null);

                try
                {
                    _sslStream.AuthenticateAsClient(serverName);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("authentication failed");
                    DisConnect();
                    Debug.WriteLine(ex.ToString());
                    return;
                }

                Debug.WriteLine("connected");
            }
            catch (SocketException e)
            {
                Debug.WriteLine("connect failed");
                Debug.WriteLine(e.ToString());
                DisConnect();
                return;
            }
            catch (Exception x)
            {
                Debug.WriteLine("connect failed");
                Debug.WriteLine(x.ToString());
                DisConnect();
                return;
            }

            _ = ReceiveMessage();


        }

        /// <summary>
        /// tcpサーバーにメッセージを送信する
        /// </summary>
        /// <param name="message">送信するメッセージ</param>
        public void Send(string message)
        {
            try
            {
                Encoding enc = Encoding.UTF8;
                byte[] sendBytes = enc.GetBytes(message);
                _sslStream.Write(sendBytes, 0, sendBytes.Length);
                Debug.WriteLine($"sent message: {message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("send failed");
                Debug.WriteLine(ex.ToString());
            }
        }

        private async Task<bool> ReceiveMessage()
        {
            Debug.WriteLine("receive start");
            try
            {
                while (true)
                {
                    if (!_client.Connected)
                    {
                        return true;
                    }

                    byte[] receivedMessage = null;
                    byte[] result_bytes = new byte[_client.ReceiveBufferSize];
                    int bytes = -1;
                    using (var ms = new System.IO.MemoryStream())
                    {
                        // メッセージを読み取る。
                        bytes = await _sslStream.ReadAsync(result_bytes, 0, result_bytes.Length);
                        ms.Write(result_bytes, 0, bytes);
                        receivedMessage = ms.ToArray();
                    }

                    if (bytes == 0)
                    {
                        Debug.WriteLine("receive end");
                        return true;
                    }

                    string str = "";
                    for (int i = 0; i < receivedMessage.Length; i++)
                    {
                        str += string.Format("{0:X2}", receivedMessage[i]);
                    }
                    var ip = ((IPEndPoint)_client.Client.RemoteEndPoint).Address;
                    var port = ((IPEndPoint)_client.Client.RemoteEndPoint).Port;
                    Debug.WriteLine($"from {ip}:{port} - received massage: {str}");

                    // 受信データに対して何らかの処理をする。
                    var responce = DoAction(receivedMessage, (IPEndPoint)_client.Client.RemoteEndPoint);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// tcpサーバーから切断する(FIN)
        /// </summary>
        public void DisConnect()
        {
            try
            {
                if(_sslStream != null)
                {
                    // close_notify送信はsslstreamに実装されていないので作成。
                    // コピペ元：https://stackoverflow.com/questions/237807/net-sslstream-doesnt-close-tls-connection-properly
                    SslDirectCall.CloseNotify(_sslStream);
                }

                if (_client != null)
                {
                    _client.Close();
                }
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
