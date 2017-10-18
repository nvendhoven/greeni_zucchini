using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zucchini_client.Model
{
    public class Room
    {
        public string Name { get; set; }
        public string Uuid { get; set; }
        public Player Host { get; set; }
        public int Amount { get; set; }

        public Room(string name, string uuid, int amount)
        {
            Uuid = uuid;
            Name = name;
            Amount = amount;
        }

        public Room(string name, Player host)
        {
            Uuid = Guid.NewGuid().ToString();
            Name = name;
            Host = host;
        }

        public Room(string uuid, string name, Player host)
        {
            Uuid = uuid;
            Name = name;
            Host = host;
        }
    }
}
