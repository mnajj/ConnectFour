namespace SimpleClient
{
	partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.ConnectToServer = new System.Windows.Forms.Button();
            this.UserNameField = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 7;
            // 
            // ConnectToServer
            // 
            this.ConnectToServer.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConnectToServer.BackColor = System.Drawing.Color.Red;
            this.ConnectToServer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.ConnectToServer.Location = new System.Drawing.Point(331, 415);
            this.ConnectToServer.Name = "ConnectToServer";
            this.ConnectToServer.Size = new System.Drawing.Size(135, 23);
            this.ConnectToServer.TabIndex = 6;
            this.ConnectToServer.Text = "Connect";
            this.ConnectToServer.UseVisualStyleBackColor = false;
            this.ConnectToServer.Click += new System.EventHandler(this.ConnectToServer_Click);
            // 
            // UserNameField
            // 
            this.UserNameField.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.UserNameField.Location = new System.Drawing.Point(308, 374);
            this.UserNameField.Name = "UserNameField";
            this.UserNameField.Size = new System.Drawing.Size(186, 20);
            this.UserNameField.TabIndex = 8;
            this.UserNameField.MouseClick += new System.Windows.Forms.MouseEventHandler(this.UserNameField_MouseClick);
            this.UserNameField.GotFocus += new System.EventHandler(this.RemoveText);
            this.UserNameField.LostFocus += new System.EventHandler(this.AddText);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(201)))), ((int)(((byte)(244)))));
            this.BackgroundImage = global::SimpleClient.Properties.Resources.DanYr4AVMAABJ_K;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.UserNameField);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ConnectToServer);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Connect4-Login";
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button ConnectToServer;
		private System.Windows.Forms.TextBox UserNameField;
	}
}

