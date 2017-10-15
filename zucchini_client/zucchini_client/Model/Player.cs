using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zucchini_client.Model
{
    class Player
    {

        public string Uuid { get; set; }
        public string Name { get; set; }

        private bool _self = false;

        public Player(string name)
        {
            Uuid = Guid.NewGuid().ToString();
            _self = true;
            Name = name;
        }

        public Player(string uuid, string name)
        {
            Uuid = uuid;
            Name = name;
        }
       
    }
}
