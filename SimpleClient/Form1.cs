using ShardClassLibrary;
using SimpleServer.ClassLib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace SimpleClient
{
	public partial class Form1 : Form
	{
		public string UserName { get; private set; }
		TcpClient client;
		NetworkStream networkStream;
		BinaryReader bReader;
		BinaryWriter bWriter;
		List<User> clientList;
		List<Room> roomsList;

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
				UserName = UserNameField.Text;
			}
			else if (status == 11)
			{
				SwitchResponseToForm(responseRes.Split(',')[1]);
				BinaryFormatter formatter = new BinaryFormatter();
				roomsList = (List<Room>)formatter.Deserialize(networkStream);
				AddRoomsToRoomsListView(roomsList);
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

		private void AddRoomsToRoomsListView(List<Room> list)
		{
			var imageList = new ImageList();
			imageList.Images.Add("RoomIcon", LoadImage(@"https://www.ala.org/lita/sites/ala.org.lita/files/content/learning/webinars/gamelogo.png"));
			roomsListForm.RoomsListControl.SmallImageList = imageList;
			foreach (Room room in list)
			{
				ListViewItem item = new ListViewItem();
				item.Text = room.RoomName;
				for (int i = 0; i < room.Players.Count; i++)
				{
					item.SubItems.Add(room.Players[i].UserName);
				}
				roomsListForm.RoomsListControl.Items.Add(item);
			}
		}

		private Image LoadImage(string url)
		{
			System.Net.WebRequest request = System.Net.WebRequest.Create(url);
			System.Net.WebResponse response = request.GetResponse();
			System.IO.Stream responseStream = response.GetResponseStream();
			Bitmap bmp = new Bitmap(responseStream);
			responseStream.Dispose();
			return bmp;
		}
	}
}
