using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zucchini_client.Network
{
    class Connection
    {

        private IServerListener _server;
        private TcpClient _client;
        private NetworkStream _stream;

        public Connection(IServerListener server) {
            _server = server;
            try
            {
                _client = new TcpClient();
                _client.Connect(GetLocalIPAddress(), 8080);
                _stream = _client.GetStream();

                _server.OnConnected();
                Read();
            }
            catch (Exception e){
                _server.OnErrorReceived(e.StackTrace);
            }
        }

        /*
        *  Server methods
        */
    
        public void Send(JObject json)
        {
            new Thread(() => {

                try
                {
                    byte[] bytesToSend = ASCIIEncoding.ASCII.GetBytes(json.ToString());
                    _stream.Write(bytesToSend, 0, bytesToSend.Length);
                }
                catch (Exception e) {

                }
            }).Start();
        }

        public void Read() {
            new Thread(() => {
                while (true) {
                    byte[] bytesToRead = new byte[_client.ReceiveBufferSize];
                    int bytesRead = _stream.Read(bytesToRead, 0, _client.ReceiveBufferSize);

                    _server.OnDataReceived(JObject.Parse(Encoding.ASCII.GetString(bytesToRead, 0, bytesRead)));
                }
            }).Start();
        }

        /*
         *  Function methods
         */

        private IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }
    }
}
