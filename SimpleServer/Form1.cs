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
			server.Start();
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
				Thread clientThread = new Thread(newClient.AcceptRequests);
				clientThread.Start();
			}
		}

		private void AcceptClient(object clientObj)
		{
			TcpClient client = clientObj as TcpClient;
			networkStream = client.GetStream();
			if (networkStream.DataAvailable)
			{
				bReader = new BinaryReader(networkStream);
				string reqRes = bReader.ReadString();
				int status = int.Parse(reqRes.Split(',')[0]);
				switch (status)
				{
					// Login Status
					case 0:
						LogInUser(reqRes.Split(',')[2]);
						break;
					case 2:
						RedirectToWaitingRoom();
						break;
					case 3:
						SaveNewRoomData(reqRes.Split(',')[2]);
						break;
				}
			}
		}

		private void LogInUser(string userName)
		{
			var matches =	DataLayer.Users.Where(u => u.UserName == userName).ToList();
			bWriter = new BinaryWriter(networkStream);
			if (matches.Count > 0)
			{
				DataLayer.ConnectedUsers.AddRange(matches);
				if (DataLayer.Rooms.Count > 0)
				{
					bWriter.Write($"11,{Views.RoomsList}");

					BinaryFormatter bf = new BinaryFormatter();
					bf.Serialize(networkStream, DataLayer.Rooms);
				}
				else
				{
					bWriter.Write($"1,{Views.RoomsList}");
				}
			}
			else
			{
				bWriter.Write("-1,Can't find username.");
			}
		}

		private void RedirectToWaitingRoom()
		{
			bWriter = new BinaryWriter(networkStream);
			bWriter.Write($"1,{Views.WaitingRoom}");
		}

		private void SendSerializedData(byte [] data)
		{
			BinaryFormatter formatter = new BinaryFormatter();
			bWriter.Write(data);
		}

		private void SaveNewRoomData(string roomData)
		{
			string[] splitedData = roomData.Split(';');
			int idx = int.Parse(splitedData[0]);
			User roomOwner = new User { UserName = splitedData[2] };
			DataLayer.Rooms.Add(
				new Room {
					Index = idx,
					RoomName = splitedData[1],
					Players = new List<User>(),
					Spectators = new List<User>(),
					RoomOwner = roomOwner
				});
			DataLayer.Rooms[idx].Players.Add(roomOwner);
		}

		private byte[] SerializeToBytes<T>(T item)
		{
			var formatter = new BinaryFormatter();
			using (var stream = new MemoryStream())
			{
				formatter.Serialize(stream, item);
				stream.Seek(0, SeekOrigin.Begin);
				return stream.ToArray();
			}
		}

	}
}
