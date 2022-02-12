using System;
using System.Windows.Forms;

namespace SimpleClient.Dialogs
{
	public partial class CounterResponseMsgDialog : Form
	{
		public CounterResponseMsgDialog(string counterName, bool accept)
		{
			InitializeComponent();
			if(accept)
			{
				ResMsgLabel.Text = $"{counterName} accept your request";
				CloseButton.Text = "Start Game!";
			}
			else
			{
				ResMsgLabel.Text = $"{counterName} refuse your request";
				CloseButton.Text = "OK";
			}
		}

		private void CloseButton_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}
