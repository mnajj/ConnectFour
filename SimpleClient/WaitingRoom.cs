using ShardClassLibrary;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace SimpleClient
{
	public partial class WaitingRoom : Form
	{
		RoomsList roomsListForm;
		Form1 clientForm;
		BinaryWriter bWriter;
		BinaryReader bReader;

		public bool IsGuest { get; set; }
		public int RoomIdx { get; set; }

		public WaitingRoom(RoomsList roomsListForm, bool isGuest)
		{
			InitializeComponent();
			this.roomsListForm = roomsListForm;
			this.IsGuest = isGuest;
		}

		private void WaitingRoom_Load(object sender, EventArgs e)
		{
			if (!IsGuest)
			{
				PlayersListBox.Items.Add($"👑 {roomsListForm.ClientForm.UserName} (You)");
				RoomNameLabel.Text = roomsListForm.CreatedRoomName;
			}
			else
			{
				GetRoomData();
			}
		}

		public void GetRoomData()
		{
			// SEND
			bWriter = new BinaryWriter(roomsListForm.ClientForm.ClientNetworkStream);
			bWriter.Write($"4,Get room data,{RoomIdx}");

			// RECEIVE Room Data
			BinaryFormatter formatter = new BinaryFormatter();
			Room roomData = (Room) formatter.Deserialize(roomsListForm.ClientForm.ClientNetworkStream);
			AddRoomDataToGuestView(roomData);
		}

		public void AddRoomDataToGuestView(Room roomData)
		{
			RoomNameLabel.Text = roomData.RoomName;
			PlayersListBox.Items.Add($"👑 {roomData.RoomOwner.UserName}");
			PlayersListBox.Items.Add($"{clientForm.UserName} (You)");
		}
	}
}
