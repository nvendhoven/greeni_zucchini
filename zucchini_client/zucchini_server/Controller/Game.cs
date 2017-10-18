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
        private Player _turnPlayer;

        public Game(IGameListener listener, List<Player> players)
        {
            _listener = listener;
            Uuid = Guid.NewGuid().ToString();
            Players = players;
            _turnPlayer = players.First();
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
                    Thread.Sleep(1500);

                    CardGenerator.Generate(out Vegetable vegetable, out int amount);
                    _listener.OnCard(this, vegetable, amount, _turnPlayer);

                    if (Players.IndexOf(_turnPlayer) + 1 < Players.Count)
                    {
                        _turnPlayer = Players.ElementAt(Players.IndexOf(_turnPlayer) + 1);
                    }
                    else {
                        _turnPlayer = Players.First();
                    }

                }

            }).Start();
        }

        internal void Bell(bool isCorrect, Player p)
        {
            _listener.OnBellPressed(this, p, isCorrect);
        }
    }
}
