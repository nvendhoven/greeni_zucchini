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
    class Server
    {
        //todo add list of rooms and players

        TcpListener server;
        bool running = true;

        public Server() {
            server = new TcpListener(GetLocalIPAddress(), 8080);
            server.Start();

            Console.WriteLine($"-- Server started on ip: {GetLocalIPAddress().ToString()} --");
            ReceivePlayers();
        }

        private void ReceivePlayers() {
            new Thread(() => {
                while (running)
                {
                    server.AcceptSocket();
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
    }
}
