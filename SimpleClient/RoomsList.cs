using ShardClassLibrary;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
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

		public ListView RoomsListControl { get => RoomsListView; }
		public Form1 ClientForm { get => clientForm; }
		public WaitingRoom WaitingRoom { get; set; }
		public string CreatedRoomName { get; set; }
		public Room GuestRoomData { get; set; }

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
      RoomsListView.Columns.Add("Details", 100);
      var imageList = new ImageList();
			//imageList.Images.Add("RoomIcon", LoadImage(@"https://www.ala.org/lita/sites/ala.org.lita/files/content/learning/webinars/gamelogo.png"));
			imageList.Images.Add("RoomIcon", LoadImage(@"https://imgur.com/EjX8Ulb.png"));
			RoomsListView.SmallImageList = imageList;
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

		private void RoomsListView_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			bWriter = new BinaryWriter(clientForm.ClientNetworkStream);
			bWriter.Write($"4,Get room data,{RoomsListView.SelectedIndices[0]}");
			while (GuestRoomData == null) Thread.Sleep(100);
			RedirectGuestToRoom(RoomsListView.SelectedIndices[0]);
		}

		private void CreateNewRoomButton_Click(object sender, EventArgs e)
    {
      RoomDialog RoomDlg = new RoomDialog();
      DialogResult Dialog = RoomDlg.ShowDialog();
      if (Dialog == DialogResult.OK)
      {
				CreatedRoomName = RoomDlg.RoomName;
				CreateNewRoom(CreatedRoomName);

				// SEND Room Data to Server
				bWriter = new BinaryWriter(clientForm.ClientNetworkStream);
				bWriter.Write("3,Rquest for creating new room," +
					$"{roomIdx};{CreatedRoomName};{clientForm.UserName}");

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
			listViewItem.SubItems.Add(clientForm.UserName);
			listViewItem.ImageKey = "RoomIcon";
			RoomsListView.Items.Add(listViewItem);
			roomIdx = listViewItem.Index;
		}

		private void RedirectGuestToRoom(int roomIdx)
		{
			WaitingRoom = new WaitingRoom(this, true, GuestRoomData);
			WaitingRoom.RoomIdx = roomIdx;
			WaitingRoom.Show();
			this.Hide();
		}
	}
}
