using System;
using System.Windows.Forms;

namespace SimpleClient.Dialogs
{
	public partial class DeclareDialg : Form
	{
		public bool AcceptToPlayAgain { get; set; }
		public bool IsWinner { get; set; }
		public DeclareDialg(bool isWinner)
		{
			InitializeComponent();
			this.IsWinner = isWinner;
			if (this.IsWinner)
			{
				label1.Text = "You Won This Round!";
			}
			else
			{
				label1.Text = "You Lose This Round!";
			}
		}

		private void YesButton_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			this.Close();
		}

		private void NoButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
