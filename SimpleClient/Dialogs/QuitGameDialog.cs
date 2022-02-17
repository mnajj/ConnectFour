using System;
using System.Windows.Forms;

namespace SimpleClient.Dialogs
{
	public partial class QuitGameDialog : Form
	{
		public QuitGameDialog()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void button2_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
