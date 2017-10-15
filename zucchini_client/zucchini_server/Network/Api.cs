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
            Console.WriteLine($"- received: \"{load.id}\" -");

            switch ($"{load.id}") {
                case "player/connect":
                    Console.WriteLine($"- Player with id: {load.data.uuid} connected-");
                    break;
                case "room/create":
                    Console.WriteLine($"- Room {load.data.name} created-");
                    break;
                case "room/remove":
                    break;
                default: Console.WriteLine($"-! incorrect load id !-");
                    break;
            }
        }
    }
}
