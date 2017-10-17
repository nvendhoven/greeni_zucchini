using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zucchini_server.Network
{
    struct Room
    {
        public string Uuid { get; set; }
        public string Name { get; set; }
        public Player Host { get; set; }
        public List<Player> Players { get; set; }
        public bool InGame { get; set; }

        public Room(string uuid, string name, Player host) : this()
        {
            Uuid = uuid;
            Name = name;
            Host = host;
            InGame = false;
            Players = new List<Player>();
            Players.Add(host);
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
        }

        public void RemovePlayer(Player player)
        {
            Players.Remove(player);
        }
    }
}
