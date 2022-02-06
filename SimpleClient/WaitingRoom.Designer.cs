namespace SimpleClient
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
			this.ChooseDiskColorComboBox = new System.Windows.Forms.ComboBox();
			this.RoomNameLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.PlayersListBox = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SpectatorsBox = new System.Windows.Forms.ListBox();
			this.SpectatorsListBox = new System.Windows.Forms.Label();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ChooseDiskColorComboBox
			// 
			this.ChooseDiskColorComboBox.FormattingEnabled = true;
			this.ChooseDiskColorComboBox.Items.AddRange(new object[] {
            "Red",
            "Yellow",
            "Blue"});
			this.ChooseDiskColorComboBox.Location = new System.Drawing.Point(316, 257);
			this.ChooseDiskColorComboBox.Name = "ChooseDiskColorComboBox";
			this.ChooseDiskColorComboBox.Size = new System.Drawing.Size(161, 21);
			this.ChooseDiskColorComboBox.TabIndex = 1;
			// 
			// RoomNameLabel
			// 
			this.RoomNameLabel.AutoSize = true;
			this.RoomNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.RoomNameLabel.ForeColor = System.Drawing.SystemColors.Control;
			this.RoomNameLabel.Location = new System.Drawing.Point(12, 9);
			this.RoomNameLabel.Name = "RoomNameLabel";
			this.RoomNameLabel.Size = new System.Drawing.Size(0, 20);
			this.RoomNameLabel.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.label2.Location = new System.Drawing.Point(339, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Wating Play To Start";
			// 
			// PlayersListBox
			// 
			this.PlayersListBox.FormattingEnabled = true;
			this.PlayersListBox.Location = new System.Drawing.Point(316, 90);
			this.PlayersListBox.Name = "PlayersListBox";
			this.PlayersListBox.Size = new System.Drawing.Size(161, 160);
			this.PlayersListBox.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.SystemColors.Control;
			this.label1.Location = new System.Drawing.Point(353, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Room Players";
			// 
			// SpectatorsBox
			// 
			this.SpectatorsBox.FormattingEnabled = true;
			this.SpectatorsBox.Location = new System.Drawing.Point(12, 55);
			this.SpectatorsBox.Name = "SpectatorsBox";
			this.SpectatorsBox.Size = new System.Drawing.Size(127, 381);
			this.SpectatorsBox.TabIndex = 6;
			// 
			// SpectatorsListBox
			// 
			this.SpectatorsListBox.AutoSize = true;
			this.SpectatorsListBox.ForeColor = System.Drawing.SystemColors.ControlLightLight;
			this.SpectatorsListBox.Location = new System.Drawing.Point(9, 33);
			this.SpectatorsListBox.Name = "SpectatorsListBox";
			this.SpectatorsListBox.Size = new System.Drawing.Size(77, 13);
			this.SpectatorsListBox.TabIndex = 7;
			this.SpectatorsListBox.Text = "Spectators List";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(316, 284);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(161, 23);
			this.button1.TabIndex = 8;
			this.button1.Text = "Ask The Counter for Game";
			this.button1.UseVisualStyleBackColor = true;
			// 
			// WaitingRoom
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.button1);
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
		private System.Windows.Forms.Button button1;
	}
}