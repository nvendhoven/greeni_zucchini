using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zucchini_server.Network
{
    interface IPlayerListener
    {
        void OnDisconnect(Player player);
        void OnReceiveData(string data);
    }
}
