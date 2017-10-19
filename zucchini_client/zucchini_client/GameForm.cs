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

        const int BEGINCARDS = 30;
        private int[] _score = { BEGINCARDS, BEGINCARDS, BEGINCARDS, BEGINCARDS };
        private bool[] _active = { false, false, false, false };
        private int _numberOfCardsPlayedInCurrentRound = 0;
        private string _selfUuid;

        public GameForm(string selfUuid, string uuid, List<Player> players, Lobby menu)
        {
            InitializeComponent();
            Uuid = uuid;
            _players = players;
            _selfUuid = selfUuid;
            _menu = menu;
        }

        private void GameForm_Load(object sender, EventArgs e)
        {
            InitUI();
            lb_note.Text = "";
        }

        public void InitUI() {
            this.Invoke(new MethodInvoker(() =>
            {
                lb_player1_cards.Text = BEGINCARDS.ToString();
                lb_player2_cards.Text = BEGINCARDS.ToString();
                lb_player3_cards.Text = BEGINCARDS.ToString();
                lb_player4_cards.Text = BEGINCARDS.ToString();

                var pos = this.PointToScreen(lb_player1_cards.Location);
                pos = pb_player1_deck.PointToClient(pos);

                lb_player1_cards.Parent = pb_player1_deck;
                lb_player1_cards.Location = pos;

                var pos2 = this.PointToScreen(lb_player2_cards.Location);
                pos2 = pb_player2_deck.PointToClient(pos2);

                lb_player2_cards.Parent = pb_player2_deck;
                lb_player2_cards.Location = pos2;

                var pos3 = this.PointToScreen(lb_player3_cards.Location);
                pos3 = pb_player3_deck.PointToClient(pos3);

                lb_player3_cards.Parent = pb_player3_deck;
                lb_player3_cards.Location = pos3;

                var pos4 = this.PointToScreen(lb_player4_cards.Location);
                pos4 = pb_player4_deck.PointToClient(pos4);

                lb_player4_cards.Parent = pb_player4_deck;
                lb_player4_cards.Location = pos4;

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
                        _active[0] = true;
                    }
                    else if (i == 1)
                    {
                        lb_player2_name.Text = _players.ElementAt(i).Name;
                        _active[1] = true;
                    }
                    else if (i == 2)
                    {
                        lb_player3_cards.Visible = true;
                        lb_player3_name.Visible = true;
                        pb_player3_deck.Visible = true;
                        _active[2] = true;

                        lb_player3_name.Text = _players.ElementAt(i).Name;
                    }
                    else if (i == 3)
                    {
                        lb_player4_cards.Visible = true;
                        lb_player4_name.Visible = true;
                        pb_player4_deck.Visible = true;
                        _active[3] = true;

                        lb_player4_name.Text = _players.ElementAt(i).Name;
                    }
                }
            }));
        }

        private void NewRound()
        {
            this.Invoke(new MethodInvoker(() =>
            {
                pb_player1_currentcard.Visible = false;
                pb_player2_currentcard.Visible = false;
                pb_player3_currentcard.Visible = false;
                pb_player4_currentcard.Visible = false;
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
                _numberOfCardsPlayedInCurrentRound++;
                if (_players.IndexOf(player) == 0)
                {
                    pb_player1_currentcard.Image = image;
                    pb_player1_currentcard.Visible = true;
                    AddScore(-1, player);
                }
                else if (_players.IndexOf(player) == 1)
                {
                    pb_player2_currentcard.Image = RotateImage(image, 90);
                    pb_player2_currentcard.Visible = true;
                    AddScore(-1, player);
                }
                else if (_players.IndexOf(player) == 2)
                {
                    pb_player3_currentcard.Image = RotateImage(image, 180);
                    pb_player3_currentcard.Visible = true;
                    AddScore(-1, player);
                }
                else if (_players.IndexOf(player) == 3)
                {
                    pb_player4_currentcard.Image = RotateImage(image, 270);
                    pb_player4_currentcard.Visible = true;
                    AddScore(-1, player);
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
                            if (bool.Parse($"{load.data.isCorrect}"))
                            {
                                ShowNote($"{p.Name} pressed and won { _numberOfCardsPlayedInCurrentRound} cards!");
                                AddScore(_numberOfCardsPlayedInCurrentRound, p);
                                _numberOfCardsPlayedInCurrentRound = 0; 
                                NewRound();
                                CheckLose();
                            }
                            else {
                                ShowNote($"{p.Name} pressed incorrectly!");
                                GiveToOther(p);
                            }
                            return;
                        }
                    }
                    break;
                case "game/leave":
                    foreach (Player p in _players)
                    {
                        if (p.Uuid == $"{load.data.playerUuid}")
                        {
                            PlayerLeave(p);
                            return;
                        }
                    }
                    break;
                case "game/win":
                    MessageBox.Show($"You won!");
                    _menu.LeaveGame();
                    break;
            }
        }

        private void CheckLose() {
            foreach (Player p in _players)
            {
                if (p.Uuid == _selfUuid)
                {
                    if (_score[_players.IndexOf(p)] <= 0) {
                        _menu.LeaveGame();
                    }
                }
            }
        }

        private void PlayerLeave(Player player) {
            this.Invoke(new MethodInvoker(() =>
            {
                if (_players.IndexOf(player) == 0)
                {
                    _active[0] = false;
                    _score[0] = -1;
                    pb_player1_deck.Visible = false;
                    lb_player1_cards.Visible = false;
                    lb_player1_name.Visible = false;
                    pb_player1_currentcard.Visible = false;
                }
                else if (_players.IndexOf(player) == 1)
                {
                    _active[1] = false;
                    _score[1] = -1;
                    pb_player2_deck.Visible = false;
                    lb_player2_cards.Visible = false;
                    lb_player2_name.Visible = false;
                    pb_player2_currentcard.Visible = false;
                }
                else if (_players.IndexOf(player) == 2)
                {
                    _active[2] = false;
                    _score[2] = -1;
                    pb_player3_deck.Visible = false;
                    lb_player3_cards.Visible = false;
                    lb_player3_name.Visible = false;
                    pb_player3_currentcard.Visible = false;
                }
                else if (_players.IndexOf(player) == 3)
                {
                    _active[3] = false;
                    _score[3] = -1;
                    pb_player4_deck.Visible = false;
                    lb_player4_cards.Visible = false;
                    lb_player4_name.Visible = false;
                    pb_player4_currentcard.Visible = false;
                }
            }));
        }

        private void GiveToOther(Player player) {
            var amountToLose = 0;
            int index = 0;
            foreach (Player p in _players)
            {
                if (player != p && _active[index])
                {
                    AddScore(1, p);
                    amountToLose++;
                }
                index++;
            }
            foreach (Player p in _players)
            {
                if (player == p)
                {
                    AddScore(-amountToLose, p);
                }
            }
        }

        private void AddScore(int amount, Player player)
        {
            this.Invoke(new MethodInvoker(() =>
            {
                if (_players.IndexOf(player) == 0)
                {
                    _score[0] += amount;
                }
                else if (_players.IndexOf(player) == 1)
                {
                    _score[1] += amount;
                }
                else if (_players.IndexOf(player) == 2)
                {
                    _score[2] += amount;
                }
                else if (_players.IndexOf(player) == 3)
                {
                    _score[3] += amount;
                }

                lb_player1_cards.Text = _score[0].ToString();

                if (_score[0] < 0)
                    lb_player1_cards.ForeColor = Color.Red;
                else
                    lb_player1_cards.ForeColor = Color.White;

                lb_player2_cards.Text = _score[1].ToString();

                if (_score[1] < 0)
                    lb_player2_cards.ForeColor = Color.Red;
                else
                    lb_player2_cards.ForeColor = Color.White;

                lb_player3_cards.Text = _score[2].ToString();

                if (_score[2] < 0)
                    lb_player3_cards.ForeColor = Color.Red;
                else
                    lb_player3_cards.ForeColor = Color.White;

                lb_player4_cards.Text = _score[3].ToString();

                if (_score[3] < 0)
                    lb_player4_cards.ForeColor = Color.Red;
                else
                    lb_player4_cards.ForeColor = Color.White;
            }));
        }


        private void ShowNote(string text) {
            new Thread(() => {
                lb_note.Invoke(new Action(() => lb_note.Text = text));
                Thread.Sleep(3200);
                lb_note.Invoke(new Action(() => lb_note.Text = ""));
            }).Start();
        }

        private void GameForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _menu.LeaveGame();
        }

        private void GameForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                _menu.Bell();
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
