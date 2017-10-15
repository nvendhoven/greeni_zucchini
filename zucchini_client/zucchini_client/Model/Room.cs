using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zucchini_client.Model
{
    class Room
    {
        public string Name { get; set; }
        public Player Host { get; set; }
        public List<Player> Players { get; set; }

        public Room(string name, Player host)
        {
            Name = name;
            Host = host;
        }
    }
}
