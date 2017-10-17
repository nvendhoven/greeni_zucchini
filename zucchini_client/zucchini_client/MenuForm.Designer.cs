namespace zucchini_client
{
    partial class Lobby
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_join = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_create = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_create = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_lobby = new System.Windows.Forms.Panel();
            this.lb_connection = new System.Windows.Forms.Label();
            this.pnl_room = new System.Windows.Forms.Panel();
            this.lb_players = new System.Windows.Forms.ListBox();
            this.rtb_chat = new System.Windows.Forms.RichTextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.tb_chat = new System.Windows.Forms.TextBox();
            this.lb_room_name = new System.Windows.Forms.Label();
            this.btn_leave = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            this.btn_refresh = new System.Windows.Forms.Button();
            this.lb_rooms = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_lobby.SuspendLayout();
            this.pnl_room.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_join
            // 
            this.btn_join.Location = new System.Drawing.Point(9, 317);
            this.btn_join.Margin = new System.Windows.Forms.Padding(2);
            this.btn_join.Name = "btn_join";
            this.btn_join.Size = new System.Drawing.Size(110, 32);
            this.btn_join.TabIndex = 0;
            this.btn_join.Text = "JOIN";
            this.btn_join.UseVisualStyleBackColor = true;
            this.btn_join.Click += new System.EventHandler(this.btn_join_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(62, 12);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(247, 91);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(152, 242);
            this.btn_create.Margin = new System.Windows.Forms.Padding(2);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(70, 24);
            this.btn_create.TabIndex = 3;
            this.btn_create.Text = "CREATE";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(127, 162);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Join a room!";
            // 
            // tb_create
            // 
            this.tb_create.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_create.Location = new System.Drawing.Point(130, 215);
            this.tb_create.Margin = new System.Windows.Forms.Padding(2);
            this.tb_create.Name = "tb_create";
            this.tb_create.Size = new System.Drawing.Size(115, 23);
            this.tb_create.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 199);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "or create one here:";
            // 
            // pnl_lobby
            // 
            this.pnl_lobby.Controls.Add(this.lb_connection);
            this.pnl_lobby.Controls.Add(this.label1);
            this.pnl_lobby.Controls.Add(this.pictureBox1);
            this.pnl_lobby.Controls.Add(this.label2);
            this.pnl_lobby.Controls.Add(this.btn_create);
            this.pnl_lobby.Controls.Add(this.tb_create);
            this.pnl_lobby.Location = new System.Drawing.Point(124, 13);
            this.pnl_lobby.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_lobby.Name = "pnl_lobby";
            this.pnl_lobby.Size = new System.Drawing.Size(381, 340);
            this.pnl_lobby.TabIndex = 7;
            // 
            // lb_connection
            // 
            this.lb_connection.Location = new System.Drawing.Point(62, 106);
            this.lb_connection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_connection.Name = "lb_connection";
            this.lb_connection.Size = new System.Drawing.Size(247, 19);
            this.lb_connection.TabIndex = 7;
            this.lb_connection.Text = "not connected to server...";
            this.lb_connection.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnl_room
            // 
            this.pnl_room.Controls.Add(this.lb_players);
            this.pnl_room.Controls.Add(this.rtb_chat);
            this.pnl_room.Controls.Add(this.btn_send);
            this.pnl_room.Controls.Add(this.tb_chat);
            this.pnl_room.Controls.Add(this.lb_room_name);
            this.pnl_room.Controls.Add(this.btn_leave);
            this.pnl_room.Controls.Add(this.btn_start);
            this.pnl_room.Location = new System.Drawing.Point(124, 13);
            this.pnl_room.Margin = new System.Windows.Forms.Padding(2);
            this.pnl_room.Name = "pnl_room";
            this.pnl_room.Size = new System.Drawing.Size(381, 340);
            this.pnl_room.TabIndex = 8;
            // 
            // lb_players
            // 
            this.lb_players.FormattingEnabled = true;
            this.lb_players.Location = new System.Drawing.Point(268, 37);
            this.lb_players.Name = "lb_players";
            this.lb_players.Size = new System.Drawing.Size(102, 225);
            this.lb_players.TabIndex = 7;
            // 
            // rtb_chat
            // 
            this.rtb_chat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtb_chat.Location = new System.Drawing.Point(4, 37);
            this.rtb_chat.Margin = new System.Windows.Forms.Padding(2);
            this.rtb_chat.Name = "rtb_chat";
            this.rtb_chat.ReadOnly = true;
            this.rtb_chat.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtb_chat.Size = new System.Drawing.Size(260, 262);
            this.rtb_chat.TabIndex = 6;
            this.rtb_chat.Text = "";
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(268, 305);
            this.btn_send.Margin = new System.Windows.Forms.Padding(2);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(102, 32);
            this.btn_send.TabIndex = 5;
            this.btn_send.Text = "SEND";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // tb_chat
            // 
            this.tb_chat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_chat.Location = new System.Drawing.Point(5, 305);
            this.tb_chat.Margin = new System.Windows.Forms.Padding(2);
            this.tb_chat.Name = "tb_chat";
            this.tb_chat.Size = new System.Drawing.Size(260, 28);
            this.tb_chat.TabIndex = 4;
            // 
            // lb_room_name
            // 
            this.lb_room_name.AutoSize = true;
            this.lb_room_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_room_name.Location = new System.Drawing.Point(2, 7);
            this.lb_room_name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lb_room_name.Name = "lb_room_name";
            this.lb_room_name.Size = new System.Drawing.Size(107, 17);
            this.lb_room_name.TabIndex = 3;
            this.lb_room_name.Text = "ROOM_NAME";
            // 
            // btn_leave
            // 
            this.btn_leave.Location = new System.Drawing.Point(268, 0);
            this.btn_leave.Margin = new System.Windows.Forms.Padding(2);
            this.btn_leave.Name = "btn_leave";
            this.btn_leave.Size = new System.Drawing.Size(102, 32);
            this.btn_leave.TabIndex = 1;
            this.btn_leave.Text = "LEAVE";
            this.btn_leave.UseVisualStyleBackColor = true;
            this.btn_leave.Click += new System.EventHandler(this.btn_leave_Click);
            // 
            // btn_start
            // 
            this.btn_start.Enabled = false;
            this.btn_start.Location = new System.Drawing.Point(268, 270);
            this.btn_start.Margin = new System.Windows.Forms.Padding(2);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(102, 32);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(9, 13);
            this.btn_refresh.Margin = new System.Windows.Forms.Padding(2);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(110, 32);
            this.btn_refresh.TabIndex = 7;
            this.btn_refresh.Text = "REFRESH";
            this.btn_refresh.UseVisualStyleBackColor = true;
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // lb_rooms
            // 
            this.lb_rooms.FormattingEnabled = true;
            this.lb_rooms.Location = new System.Drawing.Point(9, 50);
            this.lb_rooms.Name = "lb_rooms";
            this.lb_rooms.Size = new System.Drawing.Size(110, 264);
            this.lb_rooms.TabIndex = 9;
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 359);
            this.Controls.Add(this.lb_rooms);
            this.Controls.Add(this.btn_refresh);
            this.Controls.Add(this.pnl_room);
            this.Controls.Add(this.pnl_lobby);
            this.Controls.Add(this.btn_join);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Lobby";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Greeni Zucchini";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Lobby_FormClosed);
            this.Load += new System.EventHandler(this.Lobby_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnl_lobby.ResumeLayout(false);
            this.pnl_lobby.PerformLayout();
            this.pnl_room.ResumeLayout(false);
            this.pnl_room.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_join;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_create;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnl_lobby;
        private System.Windows.Forms.Panel pnl_room;
        private System.Windows.Forms.Label lb_connection;
        private System.Windows.Forms.Button btn_leave;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label lb_room_name;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox tb_chat;
        private System.Windows.Forms.RichTextBox rtb_chat;
        private System.Windows.Forms.Button btn_refresh;
        private System.Windows.Forms.ListBox lb_rooms;
        private System.Windows.Forms.ListBox lb_players;
    }
}

