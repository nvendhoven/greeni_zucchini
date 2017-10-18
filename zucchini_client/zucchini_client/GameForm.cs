using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zucchini_client
{
    public partial class GameForm : Form
    {
        private Lobby _menu;

        public GameForm(Lobby menu)
        {
            InitializeComponent();
            _menu = menu;
        }

        public void OnDataReceived(dynamic load) {

        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // TODO : Game leave to server
            Hide();
            _menu.Game = null;
            _menu.Show();

        }

    }
}
