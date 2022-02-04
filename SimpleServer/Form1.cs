using System;
using System.IO;
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
			quit = false;

			// Threads
			acceptSocketDlg += AcceptSocket;
			acceptSocketThread = new Thread(new ThreadStart(acceptSocketDlg));
		}

		private void EstablishServer_Click(object sender, EventArgs e)
		{
			server.Start();
			acceptSocketThread.Start();
			ClosingForm clsFrm = new ClosingForm();
			clsFrm.Show();
			this.Hide();
		}

		/// <summary>
		/// AcceptSocketThread thread method to prevent the system
		/// from being freezenwhile waiting for clients to connect to the server
		/// </summary>
		private void AcceptSocket()
		{
			while (!quit)
			{
				connection = server.AcceptSocket();
				networkStream = new NetworkStream(connection);
				bReader = new BinaryReader(networkStream);
				string req = bReader.ReadString();
				if (req[0] == '0')
				{
					bWriter.Write(SerializeToBytes<ClosingForm>(new ClosingForm()));
				}
			}
		}

		/// <summary>
		/// function to convert by object to byte
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="obj"></param>
		/// <returns>byte[]</returns>
		private byte[] SerializeToBytes<T>(T obj)
		{
			var formatter = new BinaryFormatter();
			using (var stream = new MemoryStream())
			{
				formatter.Serialize(stream, obj);
				stream.Seek(0, SeekOrigin.Begin);
				return stream.ToArray();
			}
		}
	}
}
