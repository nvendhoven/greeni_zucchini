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
            this.lv_rooms = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btn_create = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_create = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnl_lobby = new System.Windows.Forms.Panel();
            this.lb_connection = new System.Windows.Forms.Label();
            this.pnl_room = new System.Windows.Forms.Panel();
            this.rtb_chat = new System.Windows.Forms.RichTextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.tb_chat = new System.Windows.Forms.TextBox();
            this.lb_room_name = new System.Windows.Forms.Label();
            this.lv_players = new System.Windows.Forms.ListView();
            this.btn_leave = new System.Windows.Forms.Button();
            this.btn_start = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnl_lobby.SuspendLayout();
            this.pnl_room.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_join
            // 
            this.btn_join.Location = new System.Drawing.Point(12, 390);
            this.btn_join.Name = "btn_join";
            this.btn_join.Size = new System.Drawing.Size(147, 40);
            this.btn_join.TabIndex = 0;
            this.btn_join.Text = "JOIN";
            this.btn_join.UseVisualStyleBackColor = true;
            // 
            // lv_rooms
            // 
            this.lv_rooms.Location = new System.Drawing.Point(12, 12);
            this.lv_rooms.Name = "lv_rooms";
            this.lv_rooms.Size = new System.Drawing.Size(147, 372);
            this.lv_rooms.TabIndex = 1;
            this.lv_rooms.UseCompatibleStateImageBehavior = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(83, 15);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(329, 112);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(202, 298);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(93, 30);
            this.btn_create.TabIndex = 3;
            this.btn_create.Text = "CREATE";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(169, 199);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 29);
            this.label1.TabIndex = 4;
            this.label1.Text = "Join a room!";
            // 
            // tb_create
            // 
            this.tb_create.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_create.Location = new System.Drawing.Point(174, 265);
            this.tb_create.Name = "tb_create";
            this.tb_create.Size = new System.Drawing.Size(152, 27);
            this.tb_create.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(186, 245);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 17);
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
            this.pnl_lobby.Location = new System.Drawing.Point(165, 12);
            this.pnl_lobby.Name = "pnl_lobby";
            this.pnl_lobby.Size = new System.Drawing.Size(508, 418);
            this.pnl_lobby.TabIndex = 7;
            // 
            // lb_connection
            // 
            this.lb_connection.AutoSize = true;
            this.lb_connection.Location = new System.Drawing.Point(164, 130);
            this.lb_connection.Name = "lb_connection";
            this.lb_connection.Size = new System.Drawing.Size(170, 17);
            this.lb_connection.TabIndex = 7;
            this.lb_connection.Text = "not connected to server...";
            this.lb_connection.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // pnl_room
            // 
            this.pnl_room.Controls.Add(this.rtb_chat);
            this.pnl_room.Controls.Add(this.btn_send);
            this.pnl_room.Controls.Add(this.tb_chat);
            this.pnl_room.Controls.Add(this.lb_room_name);
            this.pnl_room.Controls.Add(this.lv_players);
            this.pnl_room.Controls.Add(this.btn_leave);
            this.pnl_room.Controls.Add(this.btn_start);
            this.pnl_room.Location = new System.Drawing.Point(165, 12);
            this.pnl_room.Name = "pnl_room";
            this.pnl_room.Size = new System.Drawing.Size(508, 418);
            this.pnl_room.TabIndex = 8;
            this.pnl_room.Visible = false;
            // 
            // rtb_chat
            // 
            this.rtb_chat.Location = new System.Drawing.Point(6, 50);
            this.rtb_chat.Name = "rtb_chat";
            this.rtb_chat.Size = new System.Drawing.Size(346, 322);
            this.rtb_chat.TabIndex = 6;
            this.rtb_chat.Text = "";
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(358, 375);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(136, 40);
            this.btn_send.TabIndex = 5;
            this.btn_send.Text = "SEND";
            this.btn_send.UseVisualStyleBackColor = true;
            // 
            // tb_chat
            // 
            this.tb_chat.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tb_chat.Location = new System.Drawing.Point(6, 381);
            this.tb_chat.Name = "tb_chat";
            this.tb_chat.Size = new System.Drawing.Size(346, 34);
            this.tb_chat.TabIndex = 4;
            // 
            // lb_room_name
            // 
            this.lb_room_name.AutoSize = true;
            this.lb_room_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_room_name.Location = new System.Drawing.Point(3, 15);
            this.lb_room_name.Name = "lb_room_name";
            this.lb_room_name.Size = new System.Drawing.Size(127, 20);
            this.lb_room_name.TabIndex = 3;
            this.lb_room_name.Text = "ROOM_NAME";
            // 
            // lv_players
            // 
            this.lv_players.Location = new System.Drawing.Point(358, 50);
            this.lv_players.Name = "lv_players";
            this.lv_players.Size = new System.Drawing.Size(136, 276);
            this.lv_players.TabIndex = 2;
            this.lv_players.UseCompatibleStateImageBehavior = false;
            // 
            // btn_leave
            // 
            this.btn_leave.Location = new System.Drawing.Point(358, 6);
            this.btn_leave.Name = "btn_leave";
            this.btn_leave.Size = new System.Drawing.Size(136, 40);
            this.btn_leave.TabIndex = 1;
            this.btn_leave.Text = "LEAVE";
            this.btn_leave.UseVisualStyleBackColor = true;
            // 
            // btn_start
            // 
            this.btn_start.Enabled = false;
            this.btn_start.Location = new System.Drawing.Point(358, 332);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(136, 40);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "START";
            this.btn_start.UseVisualStyleBackColor = true;
            // 
            // Lobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 442);
            this.Controls.Add(this.pnl_room);
            this.Controls.Add(this.pnl_lobby);
            this.Controls.Add(this.lv_rooms);
            this.Controls.Add(this.btn_join);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "Lobby";
            this.Text = "Greeni Zucchini";
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
        private System.Windows.Forms.ListView lv_rooms;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_create;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnl_lobby;
        private System.Windows.Forms.Panel pnl_room;
        private System.Windows.Forms.Label lb_connection;
        private System.Windows.Forms.ListView lv_players;
        private System.Windows.Forms.Button btn_leave;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label lb_room_name;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.TextBox tb_chat;
        private System.Windows.Forms.RichTextBox rtb_chat;
    }
}

