using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace zucchini_server.Network
{
    class Server : IPlayerListener
    {
        //todo add list of rooms

        private TcpListener _server;
        public static bool RUNNING = true;

        private List<Player> _players = new List<Player>();

        public Server() {
            _server = new TcpListener(GetLocalIPAddress(), 8080);
            _server.Start();

            Console.WriteLine($"-- Server started on ip: {GetLocalIPAddress().ToString()} --");
            ReceivePlayers();
        }

        private void ReceivePlayers() {
            new Thread(() => {
                while (RUNNING)
                {
                    _players.Add(new Player(_server.AcceptTcpClient(), this));
                    Console.WriteLine($"- Player Connected! -");
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

        /*
         *  Listener methods
         */

        public void OnDisconnect(Player player)
        {
            _players.Remove(player);
            Console.WriteLine($"- Player Disconnected -");
        }

        public void OnReceiveData(string data)
        {
            Console.WriteLine($"- Received: {data}-");
        }
    }
}
