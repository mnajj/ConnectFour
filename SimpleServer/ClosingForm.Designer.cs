namespace SimpleServer
{
	partial class ClosingForm
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
			this.DestroyServer = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(296, 199);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(209, 13);
			this.label1.TabIndex = 7;
			this.label1.Text = "Press to Disconnect (Connect Four) Server";
			// 
			// DestroyServer
			// 
			this.DestroyServer.Location = new System.Drawing.Point(331, 229);
			this.DestroyServer.Name = "DestroyServer";
			this.DestroyServer.Size = new System.Drawing.Size(135, 23);
			this.DestroyServer.TabIndex = 6;
			this.DestroyServer.Text = "Destroy Server";
			this.DestroyServer.UseVisualStyleBackColor = true;
			this.DestroyServer.Click += new System.EventHandler(this.DestroyServer_Click);
			// 
			// ClosingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(800, 450);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.DestroyServer);
			this.Name = "ClosingForm";
			this.Text = "ClosingForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button DestroyServer;
	}
}