using System;
using System.Drawing;
using System.IO;
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
		public string CreatedRoomName { get; set; }

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
			// SEND
			bWriter = new BinaryWriter(clientForm.ClientNetworkStream);
			bWriter.Write($"2,Rquest for Waiting room,{RoomsListView.SelectedIndices[0]}");
			// RECEIVE
			//
			//
			//  TODO
			//
			//
			//
			/*
			OLD
			bReader = new BinaryReader(clientForm.ClientNetworkStream);
			string reqRes = bReader.ReadString();
			int status = int.Parse(reqRes.Split(',')[0]);
			if (status == 1)
			{
				clientForm.SwitchResponseToForm(reqRes.Split(',')[1]);
			}
			else
			{
				//ToDo
			}
			*/
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
				WaitingRoom waitingRoom = new WaitingRoom(this);
				waitingRoom.Show();
				this.Hide();
			}
			else
      {
				//TODO
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
  }
}
