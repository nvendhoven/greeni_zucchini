using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using zucchini_server.Network;

namespace zucchini_server.Controller
{
    class Game
    {
        public string Uuid { get; set; }
        public List<Player> Players { get; set; }
        public bool InProgress { get; set; }

        private IGameListener _listener;

        public Game(IGameListener listener, List<Player> players)
        {
            _listener = listener;
            Uuid = Guid.NewGuid().ToString();
            Players = players;
        }

        public void Start()
        {
            InProgress = true;
            Run();
        }

        public void Stop()
        {
            InProgress = false;
        }

        public void PlayerLeave(Player player) {
            _listener.OnPlayerLeave(this, player);
            player.InGame = false;
            Players.Remove(player);
        }

        private void Run() {
            new Thread(() => {

                while (InProgress) {
                    Thread.Sleep(1000);

                    CardGenerator.Generate(out Vegetable vegetable, out int amount);
                    _listener.OnCard(this, vegetable, amount);

                }

            }).Start();
        } 
    }
}
