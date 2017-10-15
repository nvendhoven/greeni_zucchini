using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zucchini_client.Model;

namespace zucchini_client.Network
{
    class ApiCaller
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

        public void RemoveRoom(Room room)
        {
            var data = new JObject{
                {"id","room/remove"},
                {"data" , new JObject{
                    {"Uuid", room.Uuid}
                }}
            };
            Connection.Send(data);
        }
    }
}
