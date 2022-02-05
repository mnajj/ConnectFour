namespace SimpleServer
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
			this.label1 = new System.Windows.Forms.Label();
			this.EstablishServer = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label1.Location = new System.Drawing.Point(21, 70);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(310, 21);
			this.label1.TabIndex = 5;
			this.label1.Text = "Press to Establish (Connect Four) Server";
			// 
			// EstablishServer
			// 
			this.EstablishServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(203)))), ((int)(((byte)(99)))));
			this.EstablishServer.FlatAppearance.BorderSize = 0;
			this.EstablishServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.EstablishServer.Location = new System.Drawing.Point(98, 110);
			this.EstablishServer.Name = "EstablishServer";
			this.EstablishServer.Size = new System.Drawing.Size(135, 23);
			this.EstablishServer.TabIndex = 4;
			this.EstablishServer.Text = "Establish Server";
			this.EstablishServer.UseVisualStyleBackColor = false;
			this.EstablishServer.Click += new System.EventHandler(this.EstablishServer_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
			this.ClientSize = new System.Drawing.Size(346, 207);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.EstablishServer);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button EstablishServer;
	}
}

