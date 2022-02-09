using System;
using System.Windows.Forms;

namespace SimpleServer
{
	public partial class ClosingForm : Form
	{
		Form1 serverForm;
		public ClosingForm(Form1 server)
		{
			InitializeComponent();
			this.serverForm = server;
		}

		private void DestroyServer_Click(object sender, EventArgs e)
		{
			if (serverForm.Listener != null)
			{
				serverForm.Listener.Stop();
			}
			serverForm.IsClosed = true;
			serverForm.Close();
			this.Close();
		}
	}
}
