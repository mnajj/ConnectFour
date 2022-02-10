using SimpleServer.ClassLib;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;

namespace SimpleServer
{
	public delegate void ThrDlg();

	public partial class Form1 : Form
	{
		TcpListener server;
		int port;
		bool quit;	// Flag to indicate if the server stil running or not.

		// Threads
		Thread acceptSocketThread;
		ThrDlg acceptSocketDlg;

		// Props
		public TcpListener Listener { get; set; }
		public bool IsClosed { get => quit; set => quit = value; }
		public Thread AcceptSocketThread { get => acceptSocketThread; }

		public Form1()
		{
			InitializeComponent();	
			port = 43659;
			server = new TcpListener(IPAddress.Any, port);
			DataLayer.SeedUsers();
			quit = false;

			// Threads
			acceptSocketDlg += AcceptSocket;
			acceptSocketThread = new Thread(new ThreadStart(acceptSocketDlg));
		}

		private void EstablishServer_Click(object sender, EventArgs e)
		{
			try
			{
				server.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Server is Already Established!");
				this.Close();
			}
			acceptSocketThread.Start();

			// Closing Form
			ClosingForm clsFrm = new ClosingForm(this);
			clsFrm.Show();
			this.Hide();
		}

		/// <summary>
		/// AcceptSocketThread thread method to prevent the system
		/// from being freeze while waiting for clients to connect
		/// to the server
		/// </summary>
		private void AcceptSocket()
		{
			while (!quit)
			{
				TcpClient client = server.AcceptTcpClient();
				if (!quit)
				{
					ClientHandler newClient = new ClientHandler(client);
					DataLayer.Clients.Add(newClient);
				}
			}
		}
	}
}
