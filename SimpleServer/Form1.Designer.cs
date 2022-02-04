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
			this.label1.Location = new System.Drawing.Point(302, 199);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(197, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Press to Establish (Connect Four) Server";
			// 
			// EstablishServer
			// 
			this.EstablishServer.Location = new System.Drawing.Point(327, 229);
			this.EstablishServer.Name = "EstablishServer";
			this.EstablishServer.Size = new System.Drawing.Size(135, 23);
			this.EstablishServer.TabIndex = 4;
			this.EstablishServer.Text = "Establish Server";
			this.EstablishServer.UseVisualStyleBackColor = true;
			this.EstablishServer.Click += new System.EventHandler(this.EstablishServer_Click);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
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

