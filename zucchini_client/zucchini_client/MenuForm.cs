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
    public partial class Lobby : Form , IServerListener
    {
        private ApiCaller _api;
        private Player _self;

        private List<Room> _rooms = new List<Room>();

        public Lobby()
        {
            InitializeComponent();
        }

        private void Lobby_Load(object sender, EventArgs e)
        {
            pnl_room.Visible = false;

            _api = new ApiCaller(new Connection(this));
            _self = new Player("Directnix");

            _api.ConnectPlayer(_self);
        }

        /*
         *  Button Delegates 
         */

        private void btn_create_Click(object sender, EventArgs e)
        {
            var room = new Room(tb_create.Text, _self);
            _api.CreateRoom(room);

            pnl_lobby.Visible = false;
            pnl_room.Visible = true;
        }

        private void btn_join_Click(object sender, EventArgs e)
        {
            _api.RemoveRoom(new Room("Error", _self));
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            _api.RefreshRooms(_self);
        }

        private void btn_leave_Click(object sender, EventArgs e)
        {
            //todo leave room
            pnl_room.Visible = false;
            pnl_lobby.Visible = true;
        }

        /*
         *  Network Listeners 
         */

        public void OnConnected()
        {
            lb_connection.Invoke(new Action(()=> lb_connection.Text = "Connected to server."));
        }

        public void OnDataReceived(string data)
        {
            lb_connection.Invoke(new Action(() => lb_connection.Text = "ACK"));
        }

        public void OnErrorReceived(string trace)
        {
            lb_connection.Invoke(new Action(() => lb_connection.Text = "Cannot connect to server."));
        }
    }
}
