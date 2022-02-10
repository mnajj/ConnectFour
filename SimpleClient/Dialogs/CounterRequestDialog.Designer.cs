namespace SimpleClient.Dialogs
{
	partial class CounterRequestDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CounterRequestDialog));
            this.MsgLable = new System.Windows.Forms.Label();
            this.AcceptRequestButton = new System.Windows.Forms.Button();
            this.DeclinesRequestButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MsgLable
            // 
            this.MsgLable.AutoSize = true;
            this.MsgLable.Location = new System.Drawing.Point(220, 118);
            this.MsgLable.Name = "MsgLable";
            this.MsgLable.Size = new System.Drawing.Size(35, 13);
            this.MsgLable.TabIndex = 0;
            this.MsgLable.Text = "label1";
            // 
            // AcceptRequestButton
            // 
            this.AcceptRequestButton.BackColor = System.Drawing.Color.White;
            this.AcceptRequestButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AcceptRequestButton.Location = new System.Drawing.Point(162, 151);
            this.AcceptRequestButton.Name = "AcceptRequestButton";
            this.AcceptRequestButton.Size = new System.Drawing.Size(75, 23);
            this.AcceptRequestButton.TabIndex = 1;
            this.AcceptRequestButton.Text = "Accept";
            this.AcceptRequestButton.UseVisualStyleBackColor = false;
            this.AcceptRequestButton.Click += new System.EventHandler(this.AcceptRequestButton_Click);
            // 
            // DeclinesRequestButton
            // 
            this.DeclinesRequestButton.BackColor = System.Drawing.Color.White;
            this.DeclinesRequestButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.DeclinesRequestButton.Location = new System.Drawing.Point(243, 151);
            this.DeclinesRequestButton.Name = "DeclinesRequestButton";
            this.DeclinesRequestButton.Size = new System.Drawing.Size(75, 23);
            this.DeclinesRequestButton.TabIndex = 2;
            this.DeclinesRequestButton.Text = "Decline";
            this.DeclinesRequestButton.UseVisualStyleBackColor = false;
            this.DeclinesRequestButton.Click += new System.EventHandler(this.DeclinesRequestButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(84, 201);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "If the invitation is not accepted after five seconds, the invitation will be reje" +
    "cted";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(27, 173);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // CounterRequestDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::SimpleClient.Properties.Resources.islamic_arabic_arabesque_ornament_border_luxury_ab;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(488, 276);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeclinesRequestButton);
            this.Controls.Add(this.AcceptRequestButton);
            this.Controls.Add(this.MsgLable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CounterRequestDialog";
            this.Text = "CounterRequestDialog";
            this.Load += new System.EventHandler(this.CounterRequestDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label MsgLable;
		private System.Windows.Forms.Button AcceptRequestButton;
		private System.Windows.Forms.Button DeclinesRequestButton;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}