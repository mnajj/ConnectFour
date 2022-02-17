namespace SimpleClient
{
	partial class GamingPlayGround
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
			this.QuitGameButton = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.QuitGameButton)).BeginInit();
			this.SuspendLayout();
			// 
			// QuitGameButton
			// 
			this.QuitGameButton.Image = global::SimpleClient.Properties.Resources.ss_1;
			this.QuitGameButton.Location = new System.Drawing.Point(722, 8);
			this.QuitGameButton.Name = "QuitGameButton";
			this.QuitGameButton.Size = new System.Drawing.Size(78, 55);
			this.QuitGameButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.QuitGameButton.TabIndex = 0;
			this.QuitGameButton.TabStop = false;
			this.QuitGameButton.Click += new System.EventHandler(this.QuitGameButton_Click);
			// 
			// GamingPlayGround
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.QuitGameButton);
			this.Name = "GamingPlayGround";
			this.Text = "GamingPlayGround";
			this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GamingPlayGround_MouseDown);
			((System.ComponentModel.ISupportInitialize)(this.QuitGameButton)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox QuitGameButton;
	}
}