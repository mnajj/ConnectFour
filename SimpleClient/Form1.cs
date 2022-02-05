using SimpleClient.ClassLib;
using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace SimpleClient
{
	public partial class Form1 : Form
	{
		TcpClient client;
		NetworkStream networkStream;
		BinaryReader bReader;
		BinaryWriter bWriter;

		// Rooms
		RoomsList roomsListForm;
		public NetworkStream ClientNetworkStream { get => networkStream; set => networkStream = value; }

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
			bWriter = new BinaryWriter(networkStream);
			bWriter.Write($"0,username,{UserNameField.Text}");
			// RECEIVE
			bReader = new BinaryReader(networkStream);
			string responseRes = bReader.ReadString();
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

		public void SwitchResponseToForm(string view)
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
			roomsListForm = new RoomsList(this);
			roomsListForm.Show();
			this.Hide();
		}

		private void SwitchToWaitingRoom()
		{
			WaitingRoom waitingRoomForm = new WaitingRoom();
			waitingRoomForm.Show();
			roomsListForm.Hide();
		}

		private void SwitchToGameRoom()
		{
			// TO-DO
		}
	}
}
