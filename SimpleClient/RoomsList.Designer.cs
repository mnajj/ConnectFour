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
			this.label1 = new System.Windows.Forms.Label();
			this.LogOutButton = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.LogOutButton)).BeginInit();
			this.SuspendLayout();
			// 
			// CreateNewRoomButton
			// 
			this.CreateNewRoomButton.Location = new System.Drawing.Point(19, 66);
			this.CreateNewRoomButton.Name = "CreateNewRoomButton";
			this.CreateNewRoomButton.Size = new System.Drawing.Size(128, 23);
			this.CreateNewRoomButton.TabIndex = 7;
			this.CreateNewRoomButton.Text = "Create New Room";
			this.CreateNewRoomButton.UseVisualStyleBackColor = true;
			this.CreateNewRoomButton.Click += new System.EventHandler(this.CreateNewRoomButton_Click);
			// 
			// RoomsListView
			// 
			this.RoomsListView.HideSelection = false;
			this.RoomsListView.Location = new System.Drawing.Point(19, 116);
			this.RoomsListView.Name = "RoomsListView";
			this.RoomsListView.Size = new System.Drawing.Size(769, 257);
			this.RoomsListView.TabIndex = 6;
			this.RoomsListView.UseCompatibleStateImageBehavior = false;
			this.RoomsListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.RoomsListView_MouseClick);
			this.RoomsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.RoomsListView_MouseDoubleClick);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(12, 13);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 39);
			this.label1.TabIndex = 4;
			this.label1.Text = "Rooms\' list";
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
			// RoomsList
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.LogOutButton);
			this.Controls.Add(this.CreateNewRoomButton);
			this.Controls.Add(this.RoomsListView);
			this.Controls.Add(this.label1);
			this.Name = "RoomsList";
			this.Text = "RoomsList";
			this.Load += new System.EventHandler(this.RoomsList_Load);
			((System.ComponentModel.ISupportInitialize)(this.LogOutButton)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button CreateNewRoomButton;
		private System.Windows.Forms.ListView RoomsListView;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox LogOutButton;
	}
}