using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zucchini_server.Network
{
    class Player
    {
        private TcpClient _client;
        private NetworkStream _stream;
        private IPlayerListener _listener;

        private bool _connected = true;

        public Player(TcpClient client, IPlayerListener listener)
        {
            _client = client;
            _listener = listener;
            _stream = _client.GetStream();
            Read();
        }

        public void Read() {
            new Thread(() =>
            {
                while (Server.RUNNING && _connected)
                {
                    try
                    {
                        byte[] buffer = new byte[_client.ReceiveBufferSize];

                        int bytesRead = _stream.Read(buffer, 0, _client.ReceiveBufferSize);
                        _listener.OnReceiveData(Encoding.ASCII.GetString(buffer, 0, bytesRead));
                    }
                    catch (Exception e) {
                        Disconnect();
                    }
                }
            }).Start();
        }

        private void Disconnect() {
            _connected = false;
            _stream.Close();
            _client.Close();
            _listener.OnDisconnect(this);
        }
    }
}
