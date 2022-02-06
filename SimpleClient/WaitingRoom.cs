using System;
using System.Windows.Forms;

namespace SimpleClient
{
	public partial class WaitingRoom : Form
	{
		RoomsList roomsListForm;

		public WaitingRoom(RoomsList roomsListForm)
		{
			InitializeComponent();
			this.roomsListForm = roomsListForm;
		}

		private void WaitingRoom_Load(object sender, EventArgs e)
		{
			PlayersListBox.Items.Add(roomsListForm.ClientForm.UserName);
			RoomNameLabel.Text = roomsListForm.CreatedRoomName;
		}
	}
}
