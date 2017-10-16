using Newtonsoft.Json.Linq;
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

            lb_rooms.DisplayMember = "Name";
            lb_rooms.ValueMember = "Uuid";
        }

        /*
         *  Update UI 
         */

        private void UpdateRoomList() {
            lb_rooms.Invoke(new Action(() => lb_rooms.Items.Clear()));
            foreach (Room r in _rooms) {
                lb_rooms.Invoke(new Action(() => lb_rooms.Items.Add(new ListBoxItem { Name = r.Name, Uuid = r.Uuid })));
            }  
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

        public void OnDataReceived(dynamic load)
        {
            switch ($"{load.id}") {
                case "room/refresh":
                    _rooms.Clear();
                    foreach (dynamic room in load.data.rooms) {
                        _rooms.Add(new Room($"{room.name}",$"{room.uuid}"));
                    }
                    UpdateRoomList();
                    break;
            }
        }

        public void OnErrorReceived(string trace)
        {
            lb_connection.Invoke(new Action(() => lb_connection.Text = "Cannot connect to server."));
        }
    }

    class ListBoxItem
    {
        public string Name { get; set; }
        public string Uuid { get; set; }
    }
}
