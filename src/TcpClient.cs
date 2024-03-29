﻿using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace tcp_client
{
    public class TcpClient
    {
        public delegate byte[] ReceiveMessageCallback(byte[] message, IPEndPoint endPoint);
        public event ReceiveMessageCallback DoAction;

        private System.Net.Sockets.TcpClient _client;

        /// <summary>
        /// tcpサーバーに接続する。(SYN)
        /// </summary>
        /// <param name="ip">tcpサーバーのipアドレス</param>
        /// <param name="port">tcpサーバーのポート番号</param>
        /// <returns></returns>
        public async Task Connect(string ip, int port)
        {
            _client = new System.Net.Sockets.TcpClient();
            try
            {
                await _client.ConnectAsync("127.0.0.1", port);
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
                var ns = _client.GetStream();
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
