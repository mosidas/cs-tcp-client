using System;
using System.Diagnostics;
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
        private System.Net.Sockets.TcpClient _client;
        private SslStream _sslStream;

        public static bool ValidateServerCertificate(
              object sender,
              X509Certificate certificate,
              X509Chain chain,
              SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors == SslPolicyErrors.None)
                return true;

            Console.WriteLine("Certificate error: {0}", sslPolicyErrors);

            // Do not allow this client to communicate with unauthenticated servers.
            return false;
        }


        /// <summary>
        /// tcpサーバーに接続する。(SYN)
        /// </summary>
        /// <param name="serverName">tcpサーバーのipアドレス</param>
        /// <param name="port">tcpサーバーのポート番号</param>
        /// <returns></returns>
        public void Connect(string serverName, int port)
        {
            _client = new System.Net.Sockets.TcpClient();
            try
            {
                _client.Connect(serverName, port);
                Debug.WriteLine("connected");

                _sslStream = new SslStream(
                _client.GetStream(),
                false,
                new RemoteCertificateValidationCallback(ValidateServerCertificate),
                null
                );

                try
                {
                    _sslStream.AuthenticateAsClient(serverName);
                }
                catch (AuthenticationException aex)
                {
                    Debug.WriteLine("authentication failed - closing the connection.");
                    DisConnect();
                    Debug.WriteLine(aex.ToString());
                    return;
                }
            }
            catch (SocketException e)
            {
                Debug.WriteLine("connect failed");
                Debug.WriteLine(e.ToString());
                DisConnect();
            }
            catch (Exception x)
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
        public void Send(string message, string serverName)
        {
            try
            {
                Encoding enc = Encoding.UTF8;
                byte[] sendBytes = enc.GetBytes(message);
                _sslStream.Write(sendBytes, 0, sendBytes.Length);
                Debug.WriteLine($"sent message:{message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine("send failed");
                Debug.WriteLine(ex.ToString());
                _client.Close();
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
