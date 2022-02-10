namespace SimpleClient
{
	partial class RoomsList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomsList));
            this.CreateNewRoomButton = new System.Windows.Forms.Button();
            this.RoomsListView = new System.Windows.Forms.ListView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LogOutButton = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogOutButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // CreateNewRoomButton
            // 
            this.CreateNewRoomButton.BackColor = System.Drawing.Color.Red;
            this.CreateNewRoomButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.CreateNewRoomButton.Location = new System.Drawing.Point(12, 76);
            this.CreateNewRoomButton.Name = "CreateNewRoomButton";
            this.CreateNewRoomButton.Size = new System.Drawing.Size(128, 29);
            this.CreateNewRoomButton.TabIndex = 7;
            this.CreateNewRoomButton.Text = "Create New Room";
            this.CreateNewRoomButton.UseVisualStyleBackColor = false;
            this.CreateNewRoomButton.Click += new System.EventHandler(this.CreateNewRoomButton_Click);
            // 
            // RoomsListView
            // 
            this.RoomsListView.BackColor = System.Drawing.Color.Black;
            this.RoomsListView.BackgroundImage = global::SimpleClient.Properties.Resources.gradient_blue_white_linear_1920x1080_c2_ffffff_add8e6_a_90_f_14;
            this.RoomsListView.HideSelection = false;
            this.RoomsListView.Location = new System.Drawing.Point(19, 181);
            this.RoomsListView.Name = "RoomsListView";
            this.RoomsListView.Size = new System.Drawing.Size(769, 257);
            this.RoomsListView.TabIndex = 6;
            this.RoomsListView.UseCompatibleStateImageBehavior = false;
            this.RoomsListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RoomsListView_MouseClick);
            this.RoomsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RoomsListView_MouseDoubleClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SimpleClient.Properties.Resources._9695825021544526172_256;
            this.pictureBox1.Location = new System.Drawing.Point(19, 111);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(121, 64);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // LogOutButton
            // 
            this.LogOutButton.Image = ((System.Drawing.Image)(resources.GetObject("LogOutButton.Image")));
            this.LogOutButton.Location = new System.Drawing.Point(582, 12);
            this.LogOutButton.Name = "LogOutButton";
            this.LogOutButton.Size = new System.Drawing.Size(206, 58);
            this.LogOutButton.TabIndex = 8;
            this.LogOutButton.TabStop = false;
            this.LogOutButton.Click += new System.EventHandler(this.LogOutButton_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::SimpleClient.Properties.Resources.DanYr4AVMAABJ_K;
            this.pictureBox2.Location = new System.Drawing.Point(-12, 2);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(171, 68);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // RoomsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(201)))), ((int)(((byte)(244)))));
            this.BackgroundImage = global::SimpleClient.Properties.Resources.Blue_Gradient_Blur_Background_For_Free;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LogOutButton);
            this.Controls.Add(this.CreateNewRoomButton);
            this.Controls.Add(this.RoomsListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RoomsList";
            this.Text = "Rooms List";
            this.Load += new System.EventHandler(this.RoomsList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogOutButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button CreateNewRoomButton;
		private System.Windows.Forms.ListView RoomsListView;
		private System.Windows.Forms.PictureBox LogOutButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}