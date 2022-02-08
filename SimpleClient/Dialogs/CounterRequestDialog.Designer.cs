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
			this.MsgLable = new System.Windows.Forms.Label();
			this.AcceptRequestButton = new System.Windows.Forms.Button();
			this.DeclinesRequestButton = new System.Windows.Forms.Button();
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
			this.AcceptRequestButton.Location = new System.Drawing.Point(162, 151);
			this.AcceptRequestButton.Name = "AcceptRequestButton";
			this.AcceptRequestButton.Size = new System.Drawing.Size(75, 23);
			this.AcceptRequestButton.TabIndex = 1;
			this.AcceptRequestButton.Text = "Accept";
			this.AcceptRequestButton.UseVisualStyleBackColor = true;
			this.AcceptRequestButton.Click += new System.EventHandler(this.AcceptRequestButton_Click);
			// 
			// DeclinesRequestButton
			// 
			this.DeclinesRequestButton.Location = new System.Drawing.Point(243, 151);
			this.DeclinesRequestButton.Name = "DeclinesRequestButton";
			this.DeclinesRequestButton.Size = new System.Drawing.Size(75, 23);
			this.DeclinesRequestButton.TabIndex = 2;
			this.DeclinesRequestButton.Text = "Decline";
			this.DeclinesRequestButton.UseVisualStyleBackColor = true;
			this.DeclinesRequestButton.Click += new System.EventHandler(this.DeclinesRequestButton_Click);
			// 
			// CounterRequestDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(488, 276);
			this.Controls.Add(this.DeclinesRequestButton);
			this.Controls.Add(this.AcceptRequestButton);
			this.Controls.Add(this.MsgLable);
			this.Name = "CounterRequestDialog";
			this.Text = "CounterRequestDialog";
			this.Load += new System.EventHandler(this.CounterRequestDialog_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label MsgLable;
		private System.Windows.Forms.Button AcceptRequestButton;
		private System.Windows.Forms.Button DeclinesRequestButton;
	}
}