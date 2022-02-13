﻿namespace SimpleClient
{
	partial class WaitingRoom
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WaitingRoom));
			this.ChooseDiskColorComboBox = new System.Windows.Forms.ComboBox();
			this.RoomNameLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.PlayersListBox = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SpectatorsBox = new System.Windows.Forms.ListBox();
			this.SpectatorsListBox = new System.Windows.Forms.Label();
			this.AskCounterForGame = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.BackButton = new System.Windows.Forms.PictureBox();
			this.LiveGameButton = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.BackButton)).BeginInit();
			this.SuspendLayout();
			// 
			// ChooseDiskColorComboBox
			// 
			this.ChooseDiskColorComboBox.FormattingEnabled = true;
			this.ChooseDiskColorComboBox.Items.AddRange(new object[] {
            "Red",
            "Yellow",
            "Blue"});
			this.ChooseDiskColorComboBox.Location = new System.Drawing.Point(316, 312);
			this.ChooseDiskColorComboBox.Name = "ChooseDiskColorComboBox";
			this.ChooseDiskColorComboBox.Size = new System.Drawing.Size(161, 21);
			this.ChooseDiskColorComboBox.TabIndex = 1;
			// 
			// RoomNameLabel
			// 
			this.RoomNameLabel.AutoSize = true;
			this.RoomNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RoomNameLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.RoomNameLabel.Location = new System.Drawing.Point(385, 9);
			this.RoomNameLabel.Name = "RoomNameLabel";
			this.RoomNameLabel.Size = new System.Drawing.Size(0, 20);
			this.RoomNameLabel.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label2.Location = new System.Drawing.Point(340, 42);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Wating Play To Start";
			// 
			// PlayersListBox
			// 
			this.PlayersListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
			this.PlayersListBox.FormattingEnabled = true;
			this.PlayersListBox.Location = new System.Drawing.Point(316, 90);
			this.PlayersListBox.Name = "PlayersListBox";
			this.PlayersListBox.Size = new System.Drawing.Size(161, 199);
			this.PlayersListBox.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.label1.Location = new System.Drawing.Point(353, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Room Players";
			// 
			// SpectatorsBox
			// 
			this.SpectatorsBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(251)))), ((int)(((byte)(248)))), ((int)(((byte)(241)))));
			this.SpectatorsBox.FormattingEnabled = true;
			this.SpectatorsBox.Location = new System.Drawing.Point(661, 29);
			this.SpectatorsBox.Name = "SpectatorsBox";
			this.SpectatorsBox.Size = new System.Drawing.Size(127, 381);
			this.SpectatorsBox.TabIndex = 6;
			// 
			// SpectatorsListBox
			// 
			this.SpectatorsListBox.AutoSize = true;
			this.SpectatorsListBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.SpectatorsListBox.Location = new System.Drawing.Point(694, 13);
			this.SpectatorsListBox.Name = "SpectatorsListBox";
			this.SpectatorsListBox.Size = new System.Drawing.Size(77, 13);
			this.SpectatorsListBox.TabIndex = 7;
			this.SpectatorsListBox.Text = "Spectators List";
			// 
			// AskCounterForGame
			// 
			this.AskCounterForGame.BackColor = System.Drawing.Color.Red;
			this.AskCounterForGame.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.AskCounterForGame.Location = new System.Drawing.Point(316, 348);
			this.AskCounterForGame.Name = "AskCounterForGame";
			this.AskCounterForGame.Size = new System.Drawing.Size(161, 23);
			this.AskCounterForGame.TabIndex = 8;
			this.AskCounterForGame.Text = "Ask The Counter for Game";
			this.AskCounterForGame.UseVisualStyleBackColor = false;
			this.AskCounterForGame.Click += new System.EventHandler(this.AskCounterForGame_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = global::SimpleClient.Properties.Resources.DanYr4AVMAABJ_K;
			this.pictureBox1.Location = new System.Drawing.Point(1, 5);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(139, 63);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 10;
			this.pictureBox1.TabStop = false;
			// 
			// BackButton
			// 
			this.BackButton.Image = ((System.Drawing.Image)(resources.GetObject("BackButton.Image")));
			this.BackButton.Location = new System.Drawing.Point(12, 382);
			this.BackButton.Name = "BackButton";
			this.BackButton.Size = new System.Drawing.Size(47, 56);
			this.BackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.BackButton.TabIndex = 9;
			this.BackButton.TabStop = false;
			this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
			// 
			// LiveGameButton
			// 
			this.LiveGameButton.BackColor = System.Drawing.Color.ForestGreen;
			this.LiveGameButton.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.LiveGameButton.Location = new System.Drawing.Point(334, 387);
			this.LiveGameButton.Name = "LiveGameButton";
			this.LiveGameButton.Size = new System.Drawing.Size(121, 23);
			this.LiveGameButton.TabIndex = 11;
			this.LiveGameButton.Text = "Watch Live Game";
			this.LiveGameButton.UseVisualStyleBackColor = false;
			this.LiveGameButton.Visible = false;
			this.LiveGameButton.Click += new System.EventHandler(this.LiveGameButton_Click);
			// 
			// WaitingRoom
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(201)))), ((int)(((byte)(244)))));
			this.BackgroundImage = global::SimpleClient.Properties.Resources.Blue_Gradient_Blur_Background_For_Free;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.LiveGameButton);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.BackButton);
			this.Controls.Add(this.AskCounterForGame);
			this.Controls.Add(this.SpectatorsListBox);
			this.Controls.Add(this.SpectatorsBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.PlayersListBox);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.RoomNameLabel);
			this.Controls.Add(this.ChooseDiskColorComboBox);
			this.Name = "WaitingRoom";
			this.Text = "WaitingRoom";
			this.Load += new System.EventHandler(this.WaitingRoom_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.BackButton)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion
        private System.Windows.Forms.ComboBox ChooseDiskColorComboBox;
        private System.Windows.Forms.Label RoomNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox PlayersListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox SpectatorsBox;
        private System.Windows.Forms.Label SpectatorsListBox;
		private System.Windows.Forms.Button AskCounterForGame;
		private System.Windows.Forms.PictureBox BackButton;
        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Button LiveGameButton;
	}
}