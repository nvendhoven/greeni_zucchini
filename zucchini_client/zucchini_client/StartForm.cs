using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zucchini_client
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            tb_ip.Text = GetLocalIPAddress().ToString();
            tb_username.Text = "Unknown Zucchini";
        }

        private IPAddress GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip;
                }
            }
            throw new Exception("Local IP Address Not Found!");
        }

        private void tb_ip_Click(object sender, EventArgs e)
        {
            tb_ip.Clear();
        }

        private void tb_username_Click(object sender, EventArgs e)
        {
            tb_username.Clear();
        }

        private void btn_connect_Click(object sender, EventArgs e)
        {
            try
            {
                var lobby = new Lobby(IPAddress.Parse(tb_ip.Text), tb_username.Text);
                Thread.Sleep(1000);
                lobby.Show();
                Hide();
            }
            catch (Exception ex) {
                MessageBox.Show($"Incorrect IP address");
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}
