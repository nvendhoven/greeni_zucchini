using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zucchini_client.Model;
using zucchini_client.Network;

namespace zucchini_client
{
    public partial class GameForm : Form
    {
        private Lobby _menu;
        public string Uuid { get; set; }

        private List<Player> _players;

        public GameForm(string uuid, List<Player> players, Lobby menu)
        {
            InitializeComponent();
            Uuid = uuid;
            _players = players;
            _menu = menu;
        }

        public void OnDataReceived(dynamic load) {
            switch ($"{load.id}")
            { 
                case "game/card":

                    break;
                case "game/bell/right":

                    break;
                case "game/bell/wrong":

                    break;
                case "game/leave":

                    break;
            }
         }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _menu.LeaveGame();

            Hide();
            _menu.Game = null;
            _menu.Show();
        }

    }
}
