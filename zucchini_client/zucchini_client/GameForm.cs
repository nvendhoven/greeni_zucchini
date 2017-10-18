using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
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

        private Tuple<string, int>[] _currentCards; 

        public GameForm(string uuid, List<Player> players, Lobby menu)
        {
            InitializeComponent();
            Uuid = uuid;
            _players = players;
            _menu = menu;
            _currentCards = new Tuple<string, int>[4] {
                Tuple.Create<string, int>("ZUCCHINI", 0),
                Tuple.Create<string, int>("ZUCCHINI", 0),
                Tuple.Create<string, int>("ZUCCHINI", 0),
                Tuple.Create<string, int>("ZUCCHINI", 0)
            };
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            UpdateUI();
            lb_note.Text = "";
        }

        public void UpdateUI() {
            this.Invoke(new MethodInvoker(() =>
            {
                pb_player1_currentcard.Visible = false;
                pb_player2_currentcard.Visible = false;

                lb_player3_cards.Visible = false;
                lb_player3_name.Visible = false;
                pb_player3_deck.Visible = false;
                pb_player3_currentcard.Visible = false;

                lb_player4_cards.Visible = false;
                lb_player4_name.Visible = false;
                pb_player4_deck.Visible = false;
                pb_player4_currentcard.Visible = false;

                for (int i = 0; i < _players.Count; i++) {
                    if (i == 0)
                    {
                        lb_player1_name.Text = _players.ElementAt(i).Name;
                    }
                    else if (i == 1)
                    {
                        lb_player2_name.Text = _players.ElementAt(i).Name;
                    }
                    else if (i == 2)
                    {
                        lb_player3_cards.Visible = true;
                        lb_player3_name.Visible = true;
                        pb_player3_deck.Visible = true;
 

                        lb_player3_name.Text = _players.ElementAt(i).Name;
                    }
                    else if (i == 3)
                    {
                        lb_player4_cards.Visible = true;
                        lb_player4_name.Visible = true;
                        pb_player4_deck.Visible = true;

                        lb_player4_name.Text = _players.ElementAt(i).Name;
                    }
                }
            }));
        }

        public void CardChange(string vegetable, int amount, Player player)
        {
            var image = Properties.Resources.achterkantkaart;
            switch (vegetable) {
                case "ZUCCHINI":
                    switch (amount)
                    {
                        case 1:
                            image = Properties.Resources.zuch1;
                            break;
                        case 2:
                            image = Properties.Resources.zuch2;
                            break;
                        case 3:
                            image = Properties.Resources.zuch3;
                            break;
                        case 4:
                            image = Properties.Resources.zuch4;
                            break;
                        case 5:
                            image = Properties.Resources.zuch5;
                            break;
                    }
                    break;
                case "EGGPLANT":
                    switch (amount)
                    {
                        case 1:
                            image = Properties.Resources.eggplant1;
                            break;
                        case 2:
                            image = Properties.Resources.eggplant2;
                            break;
                        case 3:
                            image = Properties.Resources.eggplant3;
                            break;
                        case 4:
                            image = Properties.Resources.eggplant4;
                            break;
                        case 5:
                            image = Properties.Resources.eggplant5;
                            break;
                    }
                    break;
                case "CORN":
                    switch (amount)
                    {
                        case 1:
                            image = Properties.Resources.corn1;
                            break;
                        case 2:
                            image = Properties.Resources.corn2;
                            break;
                        case 3:
                            image = Properties.Resources.corn3;
                            break;
                        case 4:
                            image = Properties.Resources.corn4;
                            break;
                        case 5:
                            image = Properties.Resources.corn5;
                            break;
                    }
                    break;
                case "TOMATO":
                    switch (amount)
                    {
                        case 1:
                            image = Properties.Resources.tomato1;
                            break;
                        case 2:
                            image = Properties.Resources.tomato2;
                            break;
                        case 3:
                            image = Properties.Resources.tomato3;
                            break;
                        case 4:
                            image = Properties.Resources.tomato4;
                            break;
                        case 5:
                            image = Properties.Resources.tomato5;
                            break;
                    }
                    break;
                case "CARROT":
                    switch (amount)
                    {
                        case 1:
                            image = Properties.Resources.karrot1;
                            break;
                        case 2:
                            image = Properties.Resources.karrot2;
                            break;
                        case 3:
                            image = Properties.Resources.karrot3;
                            break;
                        case 4:
                            image = Properties.Resources.karrot4;
                            break;
                        case 5:
                            image = Properties.Resources.karrot5;
                            break;
                    }
                    break;
            }

            this.Invoke(new MethodInvoker(() =>
            {
                if (_players.IndexOf(player) == 0)
                {
                    pb_player1_currentcard.Image = image;
                    pb_player1_currentcard.Visible = true;
                    _currentCards[0] = Tuple.Create<string, int>(vegetable, amount);
                }
                else if (_players.IndexOf(player) == 1)
                {
                    pb_player2_currentcard.Image = RotateImage(image, 90);
                    pb_player2_currentcard.Visible = true;
                    _currentCards[1] = Tuple.Create<string, int>(vegetable, amount);
                }
                else if (_players.IndexOf(player) == 2)
                {
                    pb_player3_currentcard.Image = RotateImage(image, 180);
                    pb_player3_currentcard.Visible = true;
                    _currentCards[2] = Tuple.Create<string, int>(vegetable, amount);
                }
                else if (_players.IndexOf(player) == 3)
                {
                    pb_player4_currentcard.Image = RotateImage(image, 270);
                    pb_player4_currentcard.Visible = true;
                    _currentCards[3] = Tuple.Create<string, int>(vegetable, amount);
                }
            }));
        }

        public void OnDataReceived(dynamic load) {
            switch ($"{load.id}")
            { 
                case "game/card":
                    foreach (Player p in _players) {
                        if (p.Uuid == $"{load.data.playerUuid}") {
                            CardChange($"{load.data.vegetable}", int.Parse($"{load.data.amount}"), p);
                            return;
                        }
                    }
                    break;
                case "game/bell":
                    foreach (Player p in _players)
                    {
                        if (p.Uuid == $"{load.data.playerUuid}")
                        {
                            ShowNote($"{p.Name} pressed! Correct:{load.data.isCorrect}");
                            return;
                        }
                    }
                    break;
                case "game/leave":

                    break;
            }
         }

        private void ShowNote(string text) {
            new Thread(() => {
                lb_note.Invoke(new Action(() => lb_note.Text = text));
                Thread.Sleep(5000);
                lb_note.Invoke(new Action(() => lb_note.Text = ""));
            }).Start();
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _menu.LeaveGame();

            Hide();
            _menu.Game = null;
            _menu.Show();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                Debug.WriteLine("Pressed");

                int zucchini = 0, carrot = 0, tomato = 0, corn = 0, eggplant = 0;
                foreach (Tuple<string, int> card in _currentCards) {
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
                    _menu.Bell(true);
                else
                    _menu.Bell(false);
            }
        }

        public Image RotateImage(Image img, int deg)
        {
            var bmp = new Bitmap(img);

            using (Graphics gfx = Graphics.FromImage(bmp))
            {
                gfx.Clear(Color.White);
                gfx.DrawImage(img, 0, 0, img.Width, img.Height);
            }

            if(deg == 90)
                bmp.RotateFlip(RotateFlipType.Rotate90FlipNone);
            if (deg == 180)
                bmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
            if (deg == 270)
                bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);

            return bmp;
        }
    }
}
