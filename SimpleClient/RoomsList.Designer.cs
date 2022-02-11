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
			this.LogOutButton = new System.Windows.Forms.PictureBox();
			this.pictureBox2 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.ConnectedUsersListBox = new System.Windows.Forms.ListBox();
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
			this.RoomsListView.BackColor = System.Drawing.Color.White;
			this.RoomsListView.HideSelection = false;
			this.RoomsListView.Location = new System.Drawing.Point(19, 181);
			this.RoomsListView.Name = "RoomsListView";
			this.RoomsListView.Size = new System.Drawing.Size(595, 257);
			this.RoomsListView.TabIndex = 6;
			this.RoomsListView.UseCompatibleStateImageBehavior = false;
			this.RoomsListView.View = System.Windows.Forms.View.SmallIcon;
			this.RoomsListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RoomsListView_MouseClick);
			this.RoomsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RoomsListView_MouseDoubleClick);
			// 
			// LogOutButton
			// 
			this.LogOutButton.Image = ((System.Drawing.Image)(resources.GetObject("LogOutButton.Image")));
			this.LogOutButton.Location = new System.Drawing.Point(640, 12);
			this.LogOutButton.Name = "LogOutButton";
			this.LogOutButton.Size = new System.Drawing.Size(148, 42);
			this.LogOutButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
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
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Candara", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(264, 139);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(112, 39);
			this.label1.TabIndex = 11;
			this.label1.Text = "Rooms";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(678, 158);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(0, 13);
			this.label2.TabIndex = 13;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Candara", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.ForeColor = System.Drawing.Color.ForestGreen;
			this.label3.Location = new System.Drawing.Point(633, 139);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(135, 39);
			this.label3.TabIndex = 14;
			this.label3.Text = "• Online";
			// 
			// ConnectedUsersListBox
			// 
			this.ConnectedUsersListBox.FormattingEnabled = true;
			this.ConnectedUsersListBox.Location = new System.Drawing.Point(638, 185);
			this.ConnectedUsersListBox.Name = "ConnectedUsersListBox";
			this.ConnectedUsersListBox.Size = new System.Drawing.Size(128, 251);
			this.ConnectedUsersListBox.TabIndex = 15;
			// 
			// RoomsList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(201)))), ((int)(((byte)(244)))));
			this.BackgroundImage = global::SimpleClient.Properties.Resources.Blue_Gradient_Blur_Background_For_Free;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.ConnectedUsersListBox);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox2);
			this.Controls.Add(this.LogOutButton);
			this.Controls.Add(this.CreateNewRoomButton);
			this.Controls.Add(this.RoomsListView);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "RoomsList";
			this.Text = "Rooms List";
			this.Load += new System.EventHandler(this.RoomsList_Load);
			((System.ComponentModel.ISupportInitialize)(this.LogOutButton)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button CreateNewRoomButton;
		private System.Windows.Forms.ListView RoomsListView;
		private System.Windows.Forms.PictureBox LogOutButton;
        private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ListBox ConnectedUsersListBox;
	}
}