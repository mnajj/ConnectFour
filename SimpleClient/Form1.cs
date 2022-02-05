using SimpleClient.ClassLib;
using SimpleServer;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace SimpleClient
{
	public partial class Form1 : Form
	{
		TcpClient client;
		NetworkStream networkStream;
		BinaryReader binaryReader;
		BinaryWriter binaryWriter;

		public Form1()
		{
			InitializeComponent();
		}

		private void ConnectToServer_Click(object sender, System.EventArgs e)
		{
			client = new TcpClient();
			try
			{
				client.Connect(IPAddress.Parse("127.0.0.1"), 13000);
				networkStream = client.GetStream();
				SendLoginRequestToServer();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void SendLoginRequestToServer()
		{
			// SEND
			binaryWriter = new BinaryWriter(networkStream);
			binaryWriter.Write($"0,username,{UserNameField.Text}");
			// RECEIVE
			binaryReader = new BinaryReader(networkStream);
			string responseRes = binaryReader.ReadString();
			int status = int.Parse(responseRes.Split(',')[0]);
			if (status == 1)
			{
				SwitchResponseToForm(responseRes.Split(',')[1]);
			}
			else
			{
				MessageBox.Show(responseRes.Split(',')[1]);
			}
		}

		private void SwitchResponseToForm(string view)
		{
			Views responseView = (Views)Enum.Parse(typeof(Views), view, true);
			switch (responseView)
			{
				case Views.RoomsList:
					SwitchToRoomsList();
					break;
				case Views.WaitingRoom:
					SwitchToWaitingRoom();
					break;
				case Views.GameRoom:
					SwitchToGameRoom();
					break;
			}
		}

		private void SwitchToRoomsList()
		{

		}

		private void SwitchToWaitingRoom()
		{

		}

		private void SwitchToGameRoom()
		{

		}
	}
}
