using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using zucchini_server.Network;

namespace zucchini_server.Controller
{
    interface IGameListener
    {
        void OnWin(Game game, Player player);
        void OnCard(Game game, Vegetable vegetable, int amount, Player player);
        void OnPlayerLeave(Game game, Player player);
        void OnBellPressed(Game game, Player player, bool isCorrect);
    }
}
