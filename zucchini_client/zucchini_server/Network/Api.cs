using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zucchini_server.Network
{
    class Api
    {
        public void Receive(dynamic load) {
           Program.Print(PrintType.REC, $"received: \"{load.id}\"");

            switch ($"{load.id}") {
                case "player/connect":
                    Program.Print(PrintType.ACK, $"Player with id: {load.data.uuid} connected");
                    break;
                case "room/create":
                    Program.Print(PrintType.ACK, $"Room {load.data.name} created");
                    break;
                case "room/remove/todo":
                    break;
                default:
                    Program.Print(PrintType.ERR, $"incorrect load id was given! : \"{load.id}\"");
                    break;
            }
        }
    }
}
