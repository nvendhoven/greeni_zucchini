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

        private Tuple<string, int>[] _currentCards;
        private bool bufferDone = true;

        public Game(IGameListener listener, List<Player> players)
        {
            _listener = listener;
            Uuid = Guid.NewGuid().ToString();
            Players = players;
            _turnPlayer = players.First();

            _currentCards = new Tuple<string, int>[4] {
                Tuple.Create<string, int>("ZUCCHINI", 0),
                Tuple.Create<string, int>("ZUCCHINI", 0),
                Tuple.Create<string, int>("ZUCCHINI", 0),
                Tuple.Create<string, int>("ZUCCHINI", 0)
            };
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

                    if (bufferDone)
                    {
                        CardGenerator.Generate(out Vegetable vegetable, out int amount);
                        _currentCards[Players.IndexOf(_turnPlayer)] = Tuple.Create<string, int>(vegetable.ToString(), amount);
                        _listener.OnCard(this, vegetable, amount, _turnPlayer);


                        if (Players.IndexOf(_turnPlayer) + 1 < Players.Count)
                        {
                            _turnPlayer = Players.ElementAt(Players.IndexOf(_turnPlayer) + 1);
                        }
                        else
                        {
                            _turnPlayer = Players.First();
                        }
                    }
                }
            }).Start();
        }

        private void RunBuffer() {
            new Thread(() => {
                bufferDone = false;
                Thread.Sleep(3000);
                bufferDone = true;
            }).Start();
        }

        internal void Bell(Player p)
        {
            if (bufferDone)
            {
                int zucchini = 0, carrot = 0, tomato = 0, corn = 0, eggplant = 0;
                foreach (Tuple<string, int> card in _currentCards)
                {
                    switch (card.Item1)
                    {
                        case "ZUCCHINI":
                            zucchini += card.Item2;
                            break;
                        case "EGGPLANT":
                            eggplant += card.Item2;
                            break;
                        case "CORN":
                            corn += card.Item2;
                            break;
                        case "TOMATO":
                            tomato += card.Item2;
                            break;
                        case "CARROT":
                            carrot += card.Item2;
                            break;
                    }
                }

                if (zucchini == 5 || carrot == 5 || tomato == 5 || corn == 5 || eggplant == 5)
                {
                    RunBuffer();
                    _listener.OnBellPressed(this, p, true);
                    _currentCards = new Tuple<string, int>[4] {
                        Tuple.Create<string, int>("ZUCCHINI", 0),
                        Tuple.Create<string, int>("ZUCCHINI", 0),
                        Tuple.Create<string, int>("ZUCCHINI", 0),
                        Tuple.Create<string, int>("ZUCCHINI", 0)
                    };
                }
                else
                    _listener.OnBellPressed(this, p, false);
            }
        }
    }
}
