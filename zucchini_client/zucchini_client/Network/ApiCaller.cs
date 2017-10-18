using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zucchini_client.Model;

namespace zucchini_client.Network
{
    public class ApiCaller
    {
        public Connection Connection { get; set; }

        public ApiCaller(Connection connection)
        {
            Connection = connection;
        }

        public void ConnectPlayer(Player player)
        {
            var data = new JObject{
                {"id","player/connect"},
                {"data" , new JObject{
                    {"uuid", player.Uuid},
                    {"name", player.Name}
                }}
            };
            Connection.Send(data);
        }

        public void CreateRoom(Room room)
        {
            var data = new JObject{
                {"id","room/create"},
                {"data" , new JObject{
                    {"roomUuid", room.Uuid},
                    {"hostUuid", room.Host.Uuid },
                    {"name", room.Name}
                }}
            };
            Connection.Send(data);
        }

        public void Bell(string gameuuid, Player player)
        {
            var data = new JObject{
                {"id","game/bell"},
                {"data" , new JObject{
                    {"gameUuid", gameuuid},
                    {"playerUuid", player.Uuid }
                }}
            };
            Connection.Send(data);
        }

        public void RemoveRoom(Room room)
        {
            var data = new JObject{
                {"id","room/remove"},
                {"data" , new JObject{
                    {"uuid", room.Uuid}
                }}
            };
            Connection.Send(data);
        }

        public void JoinRoom(string roomuuid, Player player)
        {
            var data = new JObject{
                {"id","room/join"},
                {"data" , new JObject{
                    {"roomUuid", roomuuid},
                    {"playerUuid", player.Uuid},
                }}
            };
            Connection.Send(data);
        }

        public void StartGame(string roomuuid)
        {
            var data = new JObject{
                {"id","room/start"},
                {"data" , new JObject{
                    {"roomUuid", roomuuid}
                }}
            };
            Connection.Send(data);
        }

        public void LeaveGame(string gameuuid, Player player)
        {
            var data = new JObject{
                {"id","game/leave"},
                {"data" , new JObject{
                    {"gameUuid", gameuuid},
                    {"playerUuid", player.Uuid}
                }}
            };
            Connection.Send(data);
        }

        public void LeaveRoom(string roomuuid, Player player)
        {
            var data = new JObject{
                {"id","room/leave"},
                {"data" , new JObject{
                    {"roomUuid", roomuuid},
                    {"playerUuid", player.Uuid},
                }}
            };
            Connection.Send(data);
        }

        public void Message(string message, string roomuuid, Player player)
        {
            var data = new JObject{
                {"id","room/message"},
                {"data" , new JObject{
                    {"message", message},
                    {"roomUuid", roomuuid},
                    {"playerUuid", player.Uuid},
                }}
            };
            Connection.Send(data);
        }

        public void FetchPlayersInRoom(string roomuuid, Player player)
        {
            var data = new JObject{
                {"id","room/players"},
                {"data" , new JObject{
                    {"roomUuid", roomuuid},
                    {"playerUuid", player.Uuid},
                }}
            };
            Connection.Send(data);
        }

        public void RefreshRooms(Player player)
        {
            var data = new JObject{
                {"id","room/refresh"},
                {"data" , new JObject{
                    {"uuid", player.Uuid}
                }}
            };
            Connection.Send(data);
        }
    }
}
