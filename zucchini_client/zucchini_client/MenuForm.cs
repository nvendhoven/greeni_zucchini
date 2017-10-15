using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using zucchini_client.Network;

namespace zucchini_client
{
    public partial class Lobby : Form , IServerListener
    {
        private Connection _connection;

        public Lobby()
        {
            InitializeComponent();
        }

        private void Lobby_Load(object sender, EventArgs e)
        {
            _connection = new Connection(this);
        }

        /*
         *  Button Delegates 
         */

        private void btn_create_Click(object sender, EventArgs e)
        {
            _connection.Send("Eyo listen upp!!");
        }

        /*
         *  Network Listeners 
         */

        public void OnConnected()
        {
            lb_connection.Invoke(new Action(()=> lb_connection.Text = "Connected to server."));
        }

        public void OnDataReceived()
        {
            throw new NotImplementedException();
        }

        public void OnErrorReceived(string trace)
        {
            lb_connection.Invoke(new Action(() => lb_connection.Text = "Cannot connect to server."));
        }
    }
}
