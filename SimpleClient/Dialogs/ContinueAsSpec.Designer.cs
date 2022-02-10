namespace SimpleClient.Dialogs
{
	partial class ContinueAsSpec
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContinueAsSpec));
			this.label1 = new System.Windows.Forms.Label();
			this.OKButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(140, 70);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(97, 26);
			this.label1.TabIndex = 0;
			this.label1.Text = "This Room is Full.\r\nContinue as Spec?";
			// 
			// OKButton
			// 
			this.OKButton.Location = new System.Drawing.Point(78, 144);
			this.OKButton.Name = "OKButton";
			this.OKButton.Size = new System.Drawing.Size(75, 23);
			this.OKButton.TabIndex = 1;
			this.OKButton.Text = "OK ✔️";
			this.OKButton.UseVisualStyleBackColor = true;
			this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.ForeColor = System.Drawing.Color.Coral;
			this.CancelButton.Location = new System.Drawing.Point(173, 144);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(75, 23);
			this.CancelButton.TabIndex = 2;
			this.CancelButton.Text = "Cancel ❌";
			this.CancelButton.UseVisualStyleBackColor = true;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// pictureBox1
			// 
			this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
			this.pictureBox1.Location = new System.Drawing.Point(88, 57);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(46, 50);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			// 
			// ContinueAsSpec
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.Linen;
			this.ClientSize = new System.Drawing.Size(358, 211);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.OKButton);
			this.Controls.Add(this.label1);
			this.Name = "ContinueAsSpec";
			this.Text = "ContinueAsSpec";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button OKButton;
		private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.PictureBox pictureBox1;
	}
}