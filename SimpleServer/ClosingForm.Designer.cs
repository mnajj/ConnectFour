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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClosingForm));
			this.label1 = new System.Windows.Forms.Label();
			this.DestroyServer = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.Color.White;
			this.label1.Location = new System.Drawing.Point(12, 136);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(327, 21);
			this.label1.TabIndex = 7;
			this.label1.Text = "Press to Disconnect (Connect Four) Server";
			// 
			// DestroyServer
			// 
			this.DestroyServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(76)))), ((int)(((byte)(41)))));
			this.DestroyServer.FlatAppearance.BorderSize = 0;
			this.DestroyServer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.DestroyServer.ForeColor = System.Drawing.SystemColors.ControlLight;
			this.DestroyServer.Location = new System.Drawing.Point(100, 167);
			this.DestroyServer.Name = "DestroyServer";
			this.DestroyServer.Size = new System.Drawing.Size(135, 23);
			this.DestroyServer.TabIndex = 6;
			this.DestroyServer.Text = "Destroy Server";
			this.DestroyServer.UseVisualStyleBackColor = false;
			this.DestroyServer.Click += new System.EventHandler(this.DestroyServer_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(19, -4);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(302, 142);
			this.pictureBox1.TabIndex = 8;
			this.pictureBox1.TabStop = false;
			// 
			// ClosingForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(40)))), ((int)(((byte)(49)))));
			this.ClientSize = new System.Drawing.Size(346, 207);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.DestroyServer);
			this.Name = "ClosingForm";
			this.Text = "ClosingForm";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button DestroyServer;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}