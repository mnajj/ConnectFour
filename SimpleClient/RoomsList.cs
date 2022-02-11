using ShardClassLibrary;
using SimpleClient.Dialogs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace SimpleClient
{
	public partial class RoomsList : Form
	{
		Form1 clientForm;
		BinaryReader bReader;
		BinaryWriter bWriter;
		int roomIdx;

		public Room SpacRoomData { get; set; }
		public ListView RoomsListControl { get => RoomsListView; }
		public ListBox RoomsUsersListBoxControl { get => ConnectedUsersListBox; }
		public Form1 ClientForm { get => clientForm; }
		public WaitingRoom WaitingRoom { get; set; }
		public string CreatedWaitingdRoomName { get; set; }
		public string CreatedWaitingdRoomOwnerDiskColor { get; set; }
		public string CreatedWaitingdRoomBoardSize { get; set; }
		public Room GuestRoomData { get; set; }
		public bool IsRoomCreator { get; set; }

		public RoomsList(Form1 clinetForm)
		{
			InitializeComponent();
			this.clientForm = clinetForm;
		}

		private void RoomsList_Load(object sender, EventArgs e)
		{
			RoomsListView.View = View.Details;
			RoomsListView.Columns.Add("Group Name", 100);
			RoomsListView.Columns.Add("Status", 100);
			RoomsListView.Columns.Add("Players", 100);
			RoomsListView.Columns.Add("Spectators", 100);
			var imageList = new ImageList();
			try
			{
				//imageList.Images.Add("RoomIcon", LoadImage(@"https://www.ala.org/lita/sites/ala.org.lita/files/content/learning/webinars/gamelogo.png"));
				imageList.Images.Add("RoomIcon", LoadImage(@"https://imgur.com/EjX8Ulb.png"));
			}
			catch (Exception ex)
			{

			}
			RoomsListView.SmallImageList = imageList;
		}

		private Image LoadImage(string url)
		{
			System.Net.WebRequest request = System.Net.WebRequest.Create(url);
			System.Net.WebResponse response = request.GetResponse();
			Stream responseStream = response.GetResponseStream();
			Bitmap bmp = new Bitmap(responseStream);
			responseStream.Dispose();
			return bmp;
		}

		private void RoomsListView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			var splitedPlayers = RoomsListView
													.SelectedItems[0]
													.SubItems[2].Text
													.Split(',');
			if (splitedPlayers.Length < 3)
			{
				bWriter = new BinaryWriter(clientForm.ClientNetworkStream);
				bWriter.Write($"4,Get room data,{RoomsListView.SelectedIndices[0]}");
				while (GuestRoomData == null) Thread.Sleep(100);
				RedirectGuestToRoom(RoomsListView.SelectedIndices[0]);
			}
			else
			{
				ContinueAsSpec continueAsSpecDlg = new ContinueAsSpec();
				DialogResult dlgRes = continueAsSpecDlg.ShowDialog();
				if (dlgRes == DialogResult.OK)
				{
					bWriter = new BinaryWriter(clientForm.ClientNetworkStream);
					bWriter.Write($"45,Get room data and add me as spec,{RoomsListView.SelectedIndices[0]}");
					while (GuestRoomData == null) Thread.Sleep(100);
					//SendWatchRequest();
					RedirectWatchOnlySpec(RoomsListView.SelectedIndices[0]);
				}
			}
		}

		private void RedirectWatchOnlySpec(int v)
		{
			WaitingRoom = new WaitingRoom(this, true, GuestRoomData, false);
			WaitingRoom.RoomIdx = roomIdx;
			WaitingRoom.Show();
			this.Hide();
		}

		private void CreateNewRoomButton_Click(object sender, EventArgs e)
		{
			RoomDialog RoomDlg = new RoomDialog();
			DialogResult Dialog = RoomDlg.ShowDialog();
			if (Dialog == DialogResult.OK)
			{
				this.IsRoomCreator = true;

				CreatedWaitingdRoomName = RoomDlg.RoomName;
				CreatedWaitingdRoomOwnerDiskColor = RoomDlg.RoomOwnerDiskColor;
				CreatedWaitingdRoomBoardSize = RoomDlg.RoomBoardSize;
				CreateNewRoom(CreatedWaitingdRoomName);

				// SEND Room Data to Server
				bWriter = new BinaryWriter(clientForm.ClientNetworkStream);
				bWriter.Write("3,Rquest for creating new room," +
					$"{roomIdx};" +
					$"{CreatedWaitingdRoomName};" +
					$"{clientForm.UserName};" +
					$"{CreatedWaitingdRoomBoardSize};" +
					$"{CreatedWaitingdRoomOwnerDiskColor}"
					);

				// Recieve view
				WaitingRoom = new WaitingRoom(this, false);
				WaitingRoom.Show();
				this.Hide();
			}
		}

		private void CreateNewRoom(string roomName)
		{
			var listViewItem = new ListViewItem();
			listViewItem.Text = roomName;
			listViewItem.SubItems.Add("Available");
			listViewItem.SubItems.Add(clientForm.UserName);
			listViewItem.SubItems.Add("0");
			listViewItem.ImageKey = "RoomIcon";
			RoomsListView.Items.Add(listViewItem);
			roomIdx = listViewItem.Index;
		}

		private void RedirectGuestToRoom(int roomIdx, bool isSpac = false)
		{
			if (isSpac)
			{
				WaitingRoom = new WaitingRoom(this, true, SpacRoomData, false);
			}
			else
			{
				WaitingRoom = new WaitingRoom(this, true, GuestRoomData);
			}
			WaitingRoom.RoomIdx = roomIdx;
			WaitingRoom.Show();
			this.Hide();
		}

		private void RoomsListView_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				SendWatchRequest();
			}
		}

		private void SendWatchRequest()
		{
			bWriter = new BinaryWriter(clientForm.ClientNetworkStream);
			bWriter.Write($"5,Get room data as spectator,{RoomsListView.SelectedIndices[0]}");
			while (SpacRoomData == null) Thread.Sleep(100);
			RedirectGuestToRoom(RoomsListView.SelectedIndices[0], true);
		}

		private void LogOutButton_Click(object sender, EventArgs e)
		{
			bWriter = new BinaryWriter(clientForm.ClientNetworkStream);
			bWriter.Write("-1,Sign Me Out");
			clientForm.Show();
			this.Close();
		}

		public void GetConnectedUsers(List<User> conUS)
		{
			ConnectedUsersListBox.Items.Clear();
			foreach (var user in conUS)
			{
				ConnectedUsersListBox.Items.Add("🤵 " + user.UserName);
			}
		}

		public void GetAvaliableRoomsData(List<Room> roomsList)
		{
			RoomsListView.Items.Clear();
			var imageList = new ImageList();
			imageList.Images.Add("RoomIcon", LoadImage(@"https://www.ala.org/lita/sites/ala.org.lita/files/content/learning/webinars/gamelogo.png"));
			RoomsListView.SmallImageList = imageList;
			foreach (Room room in roomsList)
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
				item.SubItems.Add(players);
				string specs = String.Empty;
				for (int i = 0; i < room.Spectators.Count; i++)
				{
					specs += room.Spectators[i].UserName + ", ";
				}
				item.SubItems.Add(specs);
				RoomsListView.Items.Add(item);
			}
		}
	}
}
