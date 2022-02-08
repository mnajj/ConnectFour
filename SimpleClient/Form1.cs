using ShardClassLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;

namespace SimpleClient
{
	public delegate void ThrDlg();

	public partial class Form1 : Form
	{
		public string UserName { get; private set; }
		TcpClient client;
		NetworkStream networkStream;
		BinaryReader bReader;
		BinaryWriter bWriter;
		List<Room> roomsList;
		int WaitingRoomIdex;
		bool quit;
		

		// Rooms
		RoomsList roomsListForm;
		public NetworkStream ClientNetworkStream { get => networkStream; set => networkStream = value; }
		//

		// Threads
		Thread recieveReqsThread;
		ThrDlg recieveReqsDlg;

		public Form1()
		{
			InitializeComponent();
			recieveReqsDlg += ListenForMsgs;
			recieveReqsThread = new Thread(new ThreadStart(recieveReqsDlg));
			quit = false;
			Control.CheckForIllegalCrossThreadCalls = false;
		}

		private void ConnectToServer_Click(object sender, System.EventArgs e)
		{
			client = new TcpClient();
			try
			{
				client.Connect(IPAddress.Parse("127.0.0.1"), 13000);
				networkStream = client.GetStream();
				SendLoginRequestToServer();
				recieveReqsThread.Start();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		private void SendLoginRequestToServer()
		{
			// SEND
			if (UserNameField.Text == String.Empty)
			{
				MessageBox.Show("Please, enter a user name");
			}
			else
			{
				bWriter = new BinaryWriter(networkStream);
				bWriter.Write($"0,username,{UserNameField.Text}");
				// RECEIVE
				bReader = new BinaryReader(networkStream);
				string responseRes = bReader.ReadString();
				int status = int.Parse(responseRes.Split(',')[0]);
				if (status == 1)
				{
					SwitchResponseToForm(responseRes.Split(',')[1]);
					this.UserName = UserNameField.Text;
				}
				else if (status == 11)
				{
					this.UserName = UserNameField.Text;
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
		}

		public void SwitchResponseToForm(string view)
		{
			Views responseView = (Views)Enum.Parse(typeof(Views), view, true);
			switch (responseView)
			{
				case Views.RoomsList:
					SwitchToRoomsList();
					break;
				case Views.GameRoom:
					SwitchToGameRoom();
					break;
				//case Views.WaitingRoom:
				//	SwitchToWaitingRoom();
				//	break;
			}
		}

		private void ListenForMsgs()
		{
			while(!quit)
			{
				if (networkStream.DataAvailable)
				{
					bReader = new BinaryReader(networkStream);
					string msg = bReader.ReadString();
					if (msg != String.Empty)
					{
						int status = int.Parse(msg.Split(',')[0]);
						if (status == 111)
						{
							BinaryFormatter formatter = new BinaryFormatter();
							roomsList = (List<Room>)formatter.Deserialize(networkStream);
							AddRoomsToRoomsListView(roomsList);
						}
						else if (status == 44)
						{
							BinaryFormatter formatter = new BinaryFormatter();
							Room roomData = (Room)formatter.Deserialize(networkStream);
							roomsListForm.GuestRoomData = roomData;
						}
						else if (status == 444)
						{
							BinaryFormatter formatter = new BinaryFormatter();
							var newPlayers = (List<string>)formatter.Deserialize(networkStream);
							roomsListForm.WaitingRoom.GetMemberChanges(newPlayers);
						}
						else if (status == 55)
						{
							BinaryFormatter formatter = new BinaryFormatter();
							Room spacData = (Room)formatter.Deserialize(networkStream);
							roomsListForm.SpacRoomData = spacData;
						}
						else if (status == 555)
						{
							BinaryFormatter formatter = new BinaryFormatter();
							var newPlayers = (List<string>)formatter.Deserialize(networkStream);
							roomsListForm.WaitingRoom.GetSpacMemberChanges(newPlayers);
						}
						else if (status == 66)
						{
							roomsListForm.WaitingRoom.ShowCounterDialogForm(msg.Split(',')[2]);
						}
					}
				}
			}
		}

		private void SwitchToRoomsList()
		{
			roomsListForm = new RoomsList(this);
			roomsListForm.Show();
			this.Hide();
		}

		//private void SwitchToWaitingRoom()
		//{
		//	WaitingRoom waitingRoom = new WaitingRoom(this);
		//	waitingRoom.Show();
		//	roomsListForm.Hide();
		//}

		private void SwitchToGameRoom()
		{
			// TO-DO
		}

		private void AddRoomsToRoomsListView(List<Room> list)
		{
			roomsListForm.RoomsListControl.Items.Clear();
			var imageList = new ImageList();
			imageList.Images.Add("RoomIcon", LoadImage(@"https://www.ala.org/lita/sites/ala.org.lita/files/content/learning/webinars/gamelogo.png"));
			roomsListForm.RoomsListControl.SmallImageList = imageList;
			foreach (Room room in list)
			{
				ListViewItem item = new ListViewItem();
				item.Text = room.RoomName;
				if (room.Players.Count == 2)
				{
					item.SubItems.Add("Watch Only");
				}
				else
				{
					item.SubItems.Add("Available");
				}
				string players = String.Empty;
				for (int i = 0; i < room.Players.Count; i++)
				{
					players += room.Players[i].UserName + ", ";
				}
				string specs = String.Empty;
				for (int i = 0; i < room.Spectators.Count; i++)
				{
					specs += room.Spectators[i].UserName + ", ";
				}
				item.SubItems.Add(specs);
				roomsListForm.RoomsListControl.Items.Add(item);
			}
		}

		private Image LoadImage(string url)
		{
			WebRequest request = WebRequest.Create(url);
			WebResponse response = request.GetResponse();
			Stream responseStream = response.GetResponseStream();
			Bitmap bmp = new Bitmap(responseStream);
			responseStream.Dispose();
			return bmp;
		}
	}
}
