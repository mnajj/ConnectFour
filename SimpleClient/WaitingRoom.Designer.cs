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
			this.StartGameButton = new System.Windows.Forms.Button();
			this.ChooseDiskColorComboBox = new System.Windows.Forms.ComboBox();
			this.RoomNameLabel = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.label1 = new System.Windows.Forms.Label();
			this.listBox2 = new System.Windows.Forms.ListBox();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// StartGameButton
			// 
			this.StartGameButton.Location = new System.Drawing.Point(314, 323);
			this.StartGameButton.Name = "StartGameButton";
			this.StartGameButton.Size = new System.Drawing.Size(161, 23);
			this.StartGameButton.TabIndex = 0;
			this.StartGameButton.Text = "Start Game";
			this.StartGameButton.UseVisualStyleBackColor = true;
			this.StartGameButton.Visible = false;
			// 
			// ChooseDiskColorComboBox
			// 
			this.ChooseDiskColorComboBox.FormattingEnabled = true;
			this.ChooseDiskColorComboBox.Items.AddRange(new object[] {
            "Red",
            "Yellow",
            "Blue"});
			this.ChooseDiskColorComboBox.Location = new System.Drawing.Point(314, 257);
			this.ChooseDiskColorComboBox.Name = "ChooseDiskColorComboBox";
			this.ChooseDiskColorComboBox.Size = new System.Drawing.Size(161, 21);
			this.ChooseDiskColorComboBox.TabIndex = 1;
			// 
			// RoomNameLabel
			// 
			this.RoomNameLabel.AutoSize = true;
			this.RoomNameLabel.Location = new System.Drawing.Point(12, 9);
			this.RoomNameLabel.Name = "RoomNameLabel";
			this.RoomNameLabel.Size = new System.Drawing.Size(40, 13);
			this.RoomNameLabel.TabIndex = 2;
			this.RoomNameLabel.Text = "           ";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(339, 9);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(105, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Wating Play To Start";
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(314, 90);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(161, 121);
			this.listBox1.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(353, 55);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(72, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Room Players";
			// 
			// listBox2
			// 
			this.listBox2.FormattingEnabled = true;
			this.listBox2.Location = new System.Drawing.Point(12, 90);
			this.listBox2.Name = "listBox2";
			this.listBox2.Size = new System.Drawing.Size(209, 199);
			this.listBox2.TabIndex = 6;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 70);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(77, 13);
			this.label3.TabIndex = 7;
			this.label3.Text = "Spectators List";
			// 
			// WaitingRoom
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.listBox2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.RoomNameLabel);
			this.Controls.Add(this.ChooseDiskColorComboBox);
			this.Controls.Add(this.StartGameButton);
			this.Name = "WaitingRoom";
			this.Text = "WaitingRoom";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.Button StartGameButton;
        private System.Windows.Forms.ComboBox ChooseDiskColorComboBox;
        private System.Windows.Forms.Label RoomNameLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Label label3;
    }
}