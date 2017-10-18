using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zucchini_client.Model
{
    public class Player
    {

        public string Uuid { get; set; }
        public string Name { get; set; }
        public bool Host { get; set; } = false;

        public Player(string name)
        {
            Uuid = Guid.NewGuid().ToString();
            Name = name;
        }

        public Player(string name, string uuid)
        {
            Uuid = uuid;
            Name = name;
        }

        public Player(string name, string uuid, bool host)
        {
            Uuid = uuid;
            Name = name;
            Host = host;
        }

    }
}
