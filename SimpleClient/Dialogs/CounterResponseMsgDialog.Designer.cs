﻿namespace SimpleClient.Dialogs
{
	partial class CounterResponseMsgDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CounterResponseMsgDialog));
			this.ResMsgLabel = new System.Windows.Forms.Label();
			this.CloseButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// ResMsgLabel
			// 
			this.ResMsgLabel.AutoSize = true;
			this.ResMsgLabel.Location = new System.Drawing.Point(121, 53);
			this.ResMsgLabel.Name = "ResMsgLabel";
			this.ResMsgLabel.Size = new System.Drawing.Size(0, 13);
			this.ResMsgLabel.TabIndex = 0;
			// 
			// CloseButton
			// 
			this.CloseButton.Location = new System.Drawing.Point(111, 96);
			this.CloseButton.Name = "CloseButton";
			this.CloseButton.Size = new System.Drawing.Size(75, 23);
			this.CloseButton.TabIndex = 1;
			this.CloseButton.UseVisualStyleBackColor = true;
			this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
			// 
			// CounterResponseMsgDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::SimpleClient.Properties.Resources.patterns_ornaments_art_deco_style_calligraphy_page__2_;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ClientSize = new System.Drawing.Size(306, 207);
			this.Controls.Add(this.CloseButton);
			this.Controls.Add(this.ResMsgLabel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "CounterResponseMsgDialog";
			this.Text = "CounterResponseMsgDialog";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label ResMsgLabel;
		private System.Windows.Forms.Button CloseButton;
	}
}