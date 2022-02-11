namespace SimpleClient
{
    partial class RoomDialog
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomDialog));
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.CreateButton = new System.Windows.Forms.Button();
			this.CancelButton = new System.Windows.Forms.Button();
			this.DiskColorComboBox = new System.Windows.Forms.ComboBox();
			this.BoardSizeComboBox = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(100, 72);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(181, 20);
			this.textBox1.TabIndex = 0;
			// 
			// CreateButton
			// 
			this.CreateButton.BackColor = System.Drawing.Color.White;
			this.CreateButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.CreateButton.Location = new System.Drawing.Point(75, 167);
			this.CreateButton.Name = "CreateButton";
			this.CreateButton.Size = new System.Drawing.Size(75, 23);
			this.CreateButton.TabIndex = 1;
			this.CreateButton.Text = "Create";
			this.CreateButton.UseVisualStyleBackColor = false;
			this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
			// 
			// CancelButton
			// 
			this.CancelButton.BackColor = System.Drawing.Color.White;
			this.CancelButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.CancelButton.Location = new System.Drawing.Point(220, 167);
			this.CancelButton.Name = "CancelButton";
			this.CancelButton.Size = new System.Drawing.Size(75, 23);
			this.CancelButton.TabIndex = 2;
			this.CancelButton.Text = "Cancel";
			this.CancelButton.UseVisualStyleBackColor = false;
			this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// DiskColorComboBox
			// 
			this.DiskColorComboBox.FormattingEnabled = true;
			this.DiskColorComboBox.Items.AddRange(new object[] {
            "Red",
            "Yellow",
            "Blue"});
			this.DiskColorComboBox.Location = new System.Drawing.Point(100, 98);
			this.DiskColorComboBox.Name = "DiskColorComboBox";
			this.DiskColorComboBox.Size = new System.Drawing.Size(181, 21);
			this.DiskColorComboBox.TabIndex = 3;
			// 
			// BoardSizeComboBox
			// 
			this.BoardSizeComboBox.FormattingEnabled = true;
			this.BoardSizeComboBox.Items.AddRange(new object[] {
            "4×5",
            "6×7",
            "7×9"});
			this.BoardSizeComboBox.Location = new System.Drawing.Point(100, 125);
			this.BoardSizeComboBox.Name = "BoardSizeComboBox";
			this.BoardSizeComboBox.Size = new System.Drawing.Size(181, 21);
			this.BoardSizeComboBox.TabIndex = 4;
			// 
			// RoomDialog
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::SimpleClient.Properties.Resources.patterns_ornaments_art_deco_style_calligraphy_page__2_;
			this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
			this.ClientSize = new System.Drawing.Size(388, 259);
			this.Controls.Add(this.BoardSizeComboBox);
			this.Controls.Add(this.DiskColorComboBox);
			this.Controls.Add(this.CancelButton);
			this.Controls.Add(this.CreateButton);
			this.Controls.Add(this.textBox1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "RoomDialog";
			this.Text = "Form2";
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Button CancelButton;
		private System.Windows.Forms.ComboBox DiskColorComboBox;
		private System.Windows.Forms.ComboBox BoardSizeComboBox;
	}
}