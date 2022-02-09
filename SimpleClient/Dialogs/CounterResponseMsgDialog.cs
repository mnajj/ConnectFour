using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
			this.Close();
		}
	}
}
