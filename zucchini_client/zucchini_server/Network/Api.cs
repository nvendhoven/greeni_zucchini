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
           //Program.Print(PrintType.REC, $"received: \"{load.id}\"");

            switch ($"{load.id}") {
                case "player/connect":
                    ChangePlayerData(load.data);
                    break;
                case "room/create":
                    CreateRoom(load.data);
                    break;
                case "room/remove":
                    break;
                case "room/refresh":
                    Refresh(load.data);
                    break;
                default:
                    Program.Print(PrintType.ERR, $"incorrect load id was given! : \"{load.id}\"");
                    break;
            }
        }

        
        void ChangePlayerData(dynamic data) {
            Server.Get().Players.Last().Name = data.name;
            Server.Get().Players.Last().Uuid = data.uuid;
            Program.Print(PrintType.ACK, $"player {data.name} connected");
        }

        void CreateRoom(dynamic data) {
            foreach (Player p in Server.Get().Players) {
                if (p.Uuid == $"{data.hostUuid}") {
                    Server.Get().Rooms.Add(new Room($"{data.roomUuid}", $"{data.name}", p));
                    Program.Print(PrintType.ACK, $"room {data.name} created with host: {p.Name}");
                    return;
                }
            }
            Program.Print(PrintType.ERR, $"room not created, Player with id {data.hostUuid} not found");
        }

        void Refresh(dynamic data) {
            foreach (Player p in Server.Get().Players)
            {
                if (p.Uuid == $"{data.uuid}")
                {

                    var jrooms = new JArray();
                    foreach (Room r in Server.Get().Rooms)
                    {
                        jrooms.Add(new JObject {
                            {"name", r.Name},
                            {"uuid", r.Uuid}
                        });
                    }

                    try
                    {
                        var send = new JObject{
                            {"id","room/refresh"},
                            {"data" , new JObject{
                                {"rooms", jrooms}
                            }}
                        };

                        p.Send(send);
                        Program.Print(PrintType.ACK, $"Refresh request by player: {p.Name}");
                    }
                    catch (Exception e) {
                        Program.Print(PrintType.ERR, e.StackTrace);
                    }
                    return;
                }
            }
            Program.Print(PrintType.ERR, $"room not created, Player with id {data.uuid} not found");
        }

    }
}
