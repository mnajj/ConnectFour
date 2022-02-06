using System;
using System.IO;
using System.Windows.Forms;

namespace SimpleClient
{
	public partial class WaitingRoom : Form
	{
		RoomsList roomsListForm;
		Form1 clientForm;
		BinaryWriter bWriter;
		BinaryReader bReader;

		public bool HasRoomList { get; set; }

		public WaitingRoom(Form1 clientForm)
		{
			InitializeComponent();
			this.clientForm = clientForm;
			this.HasRoomList = false;
		}

		public WaitingRoom(RoomsList roomsListForm)
		{
			InitializeComponent();
			this.roomsListForm = roomsListForm;
			this.HasRoomList = true;
		}

		private void WaitingRoom_Load(object sender, EventArgs e)
		{
			if (HasRoomList)
			{
				PlayersListBox.Items.Add(roomsListForm.ClientForm.UserName);
				RoomNameLabel.Text = roomsListForm.CreatedRoomName;
			}
			else
			{
				GetRoomData();
			}
		}

		private void GetRoomData()
		{
			// SEND
			bWriter = new BinaryWriter(clientForm.ClientNetworkStream);
			bWriter.Write("4,Get room data");

			// RECEIVE

		}
	}
}
