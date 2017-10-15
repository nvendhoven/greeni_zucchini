using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zucchini_client.Model;

namespace zucchini_client.Network
{
    class API
    {
        public Connection Connection { get; set; }

        public API(Connection connection)
        {
            Connection = connection;
        }

        public void ConnectPlayer(Player player)
        {
            dynamic data = new JObject{
                {"data","player/connect"},
                new JObject{
                    {"uuid", player.Uuid},
                    {"name", player.Name}
                }
            };
            Connection.Send(data);
        }

        public void CreateRoom(Room room, Player hostPlayer)
        {
            dynamic data = new JObject{
                {"data","room/create"},
                new JObject{
                    {"roomUuid", room.Uuid},
                    {"hostUuid", hostPlayer.Uuid},
                    {"name", room.Name}
                }
            };
            Connection.Send(data);
        }

        public void RemoveRoom(Room room)
        {
            dynamic data = new JObject{
                {"data","room/remove"},
                new JObject{
                    {"Uuid", room.Uuid}
                }
            };
            Connection.Send(data);
        }
    }
}
