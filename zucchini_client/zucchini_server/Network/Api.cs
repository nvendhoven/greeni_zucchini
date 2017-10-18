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
                    // TODO : Remove room
                    break;
                case "room/refresh":
                    Refresh(load.data);
                    break;
                case "room/join":
                    JoinRoom(load.data);
                    break;
                case "room/leave":
                    LeaveRoom(load.data);
                    break;
                case "room/players":
                    PlayersInRoom(load.data);
                    break;
                case "room/message":
                    Message(load.data);
                    break;
                case "room/start":
                    StartGame(load.data);
                    break;
                default:
                    Program.Print(PrintType.ERR, $"incorrect load id was given! : \"{load.id}\"");
                    break;
            }
        }

        void StartGame(dynamic data) {
            foreach (Room r in Server.Get().Rooms) {
                if(r.Uuid == $"{data.roomUuid}")
                {
                    r.InGame = true;

                    var send = new JObject{
                                    {"id","room/start"},
                                    {"data" , new JObject{
                                        {"roomUuid", r.Uuid}
                                    }}
                                };

                    Server.Get().SendToAllPlayersInRoom(r, send);
                }
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
                    p.Host = true;
                    Server.Get().Rooms.Add(new Room($"{data.roomUuid}", $"{data.name}", p));
                    Program.Print(PrintType.ACK, $"room {data.name} created with host: {p.Name}");
                    return;
                }
            }
            Program.Print(PrintType.ERR, $"room not created, Player with id {data.hostUuid} not found");
        }

        void PlayersInRoom(dynamic data)
        {
            Program.Print(PrintType.ACK, $"players request by player: {data.playerUuid}");

            foreach (Player p in Server.Get().Players)
            {
                if (p.Uuid == $"{data.playerUuid}")
                {
                    foreach (Room r in Server.Get().Rooms)
                    {
                        if (r.Uuid == $"{data.roomUuid}")
                        {
                            var jplayers = new JArray();
                            foreach (Player p2 in r.Players)
                            {
                                jplayers.Add(new JObject {
                                    {"name", p2.Name},
                                    {"uuid", p2.Uuid},
                                    {"isHost", p2.Host}
                                });
                            }

                            try
                            {
                                var send = new JObject{
                                    {"id","room/players"},
                                    {"data" , new JObject{
                                        {"players", jplayers}
                                    }}
                                };

                                p.Send(send);
                            }
                            catch (Exception e)
                            {
                                Program.Print(PrintType.ERR, e.StackTrace);
                            }
                            return;
                        }
                    }
                }
            }
            Program.Print(PrintType.ERR, $"room with id {data.roomUuid} not found!");
        }

        void JoinRoom(dynamic data)
        {
            foreach (Player p in Server.Get().Players)
            {
                if (p.Uuid == $"{data.playerUuid}")
                {
                    foreach (Room r in Server.Get().Rooms)
                    {
                        if (r.Uuid == $"{data.roomUuid}")
                        {
                            if (r.Players.Count < Server.ROOM_SIZE)
                            {
                                var send = new JObject{
                                        {"id","room/join"},
                                        {"data" , new JObject{
                                            {"playerName", p.Name}
                                        }}
                                };

                                Server.Get().SendToAllPlayersInRoom(r, send);

                                r.Players.Add(p);
                                Program.Print(PrintType.ACK, $"{p.Name} joined room {r.Name}");
                                return;
                            }
                            else {
                                var send2 = new JObject{
                                    {"id","room/join/failed"},
                                    {"data" , new JObject{
                                        {"reason", "Room is full!"}
                                    }}
                                };
                                p.Send(send2);
                                return;
                            }
                        }
                    }

                    var send3 = new JObject{
                        {"id","room/join/failed"},
                        {"data" , new JObject{
                            {"reason", "Room no longer excists!"}
                        }}
                    };
                    p.Send(send3);
                    return;
                }
            }
            Program.Print(PrintType.ERR, $"joining room failed! Room and Player do not excist!");
        }

        void LeaveRoom(dynamic data) //todo, check if host, choose new host
        {
            foreach (Room r in Server.Get().Rooms)
            {
                if (r.Uuid == $"{data.roomUuid}")
                {
                    foreach (Player p in Server.Get().Players)
                    {
                        if (p.Uuid == $"{data.playerUuid}")
                        {
                            var send = new JObject{
                                    {"id","room/leave"},
                                    {"data" , new JObject{
                                        {"playerName", p.Name}
                                    }}
                            };

                            r.Players.Remove(p);

                            if (p.Host)
                            {
                                p.Host = false;

                                if (r.Players.Count != 0)
                                {

                                    var send2 = new JObject{
                                        {"id","room/newHost"},
                                        {"data" , new JObject{
                                            {"playerName", r.Players.First().Name}
                                        }}
                                    };
                                    r.Players.First().Host = true;
                                    r.Players.First().Send(send2);
                                }
                                else
                                {
                                    Server.Get().Rooms.Remove(r);
                                    Program.Print(PrintType.ACK, $"room {r.Name} has been removed");
                                    return;
                                }
                            }

                            Server.Get().SendToAllPlayersInRoom(r, send);

                            Program.Print(PrintType.ACK, $"{p.Name} left room {r.Name}");
                            return;
                        }
                    }
                }
            }

            Program.Print(PrintType.ERR, $"joining room failed! Room or Player does not excist!");
        }

        void Message(dynamic data)
        {
            foreach (Room r in Server.Get().Rooms)
            {
                if (r.Uuid == $"{data.roomUuid}")
                {
                    foreach (Player p in Server.Get().Players)
                    {
                        if (p.Uuid == $"{data.playerUuid}")
                        {
                            var send = new JObject{
                                    {"id","room/message"},
                                    {"data" , new JObject{
                                        {"message", data.message},
                                        {"playerName", p.Name}
                                    }}
                            };

                            Server.Get().SendToAllPlayersInRoom(r, send);

                            Program.Print(PrintType.ACK, $"{p.Name} sended a message!");
                            return;
                        }
                    }
                }
            }

            Program.Print(PrintType.ERR, $"joining room failed! Room or Player does not excist!");
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
                            {"uuid", r.Uuid},
                            {"amount", r.Players.Count}
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
            Program.Print(PrintType.ERR, $"failed to refresh to player with id {data.uuid} not found");
        }

    }
}
