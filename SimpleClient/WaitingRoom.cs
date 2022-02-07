using ShardClassLibrary;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace SimpleClient
{
	public partial class WaitingRoom : Form
	{
		Room roomData;
		RoomsList roomsListForm;

		public bool IsGuest { get; set; }
		public int RoomIdx { get; set; }

		public WaitingRoom(RoomsList roomsListForm, bool isGuest, Room roomData = null)
		{
			InitializeComponent();
			this.roomsListForm = roomsListForm;
			this.IsGuest = isGuest;
			this.roomData = roomData;
		}

		private void WaitingRoom_Load(object sender, EventArgs e)
		{
			if (!IsGuest)
			{
				PlayersListBox.Items.Add($"👑 {roomsListForm.ClientForm.UserName}");
				RoomNameLabel.Text = roomsListForm.CreatedRoomName;
			}
			else
			{
				AddRoomDataToGuestView(roomData);
			}
		}

		public void AddRoomDataToGuestView(Room roomData)
		{
			RoomNameLabel.Text = roomData.RoomName;
			PlayersListBox.Items.Add($"👑 {roomData.RoomOwner.UserName}");
			PlayersListBox.Items.Add($"{roomsListForm.ClientForm.UserName}");
		}

		public void GetMemberChanges(List<string> newPlayers)
		{
			PlayersListBox.Items.Clear();
			PlayersListBox.Items.Add($"👑 {roomsListForm.ClientForm.UserName}");
			for (int i = 0; i < newPlayers.Count; i++)
			{
				if (newPlayers[i] != roomsListForm.ClientForm.UserName)
				{
					PlayersListBox.Items.Add($"{newPlayers[i]}");
				}
			}
		}
	}
}
