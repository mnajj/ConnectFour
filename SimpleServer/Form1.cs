using ShardClassLibrary;
using SimpleServer.ClassLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace SimpleServer
{
	public delegate void ThrDlg();

	public partial class Form1 : Form
	{
		TcpListener server;
		Socket connection;
		NetworkStream networkStream;
		int port;
		IPAddress localAddr;
		BinaryWriter bWriter;
		BinaryReader bReader;
		Thread clientThread;
		bool quit;	// Flag to indicate if the server stil running or not.

		// Threads
		Thread acceptSocketThread;
		ThrDlg acceptSocketDlg;

		public Form1()
		{
			InitializeComponent();
			port = 13000;
			localAddr = IPAddress.Parse("127.0.0.1");
			server = new TcpListener(localAddr, port);
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
			ClosingForm clsFrm = new ClosingForm();
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
				ClientHandler newClient = new ClientHandler(client);
				DataLayer.Clients.Add(newClient);
			}
		}
	}
}
