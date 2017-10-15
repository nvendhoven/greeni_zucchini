using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace zucchini_client.Network
{
    class Connection
    {

        private IServerListener _server;

        public Connection(IServerListener server) {
            _server = server;
            try
            {
                TcpClient client = new TcpClient();
                client.Connect(GetLocalIPAddress(), 8080);

                server.OnConnected();
            }
            catch (Exception e){
                server.OnErrorReceived(e.StackTrace);
            }
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
