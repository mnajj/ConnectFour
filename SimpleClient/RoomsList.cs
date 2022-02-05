using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleClient
{
	public partial class RoomsList : Form
	{
		Form1 clientForm;
		BinaryReader bReader;
		BinaryWriter bWriter;

		public RoomsList(Form1 clinetForm)
		{
			InitializeComponent();
			this.clientForm = clinetForm;
		}

		private void RoomsList_Load(object sender, EventArgs e)
		{
      RoomsListView.View = View.Details;
      RoomsListView.Columns.Add("Group Name", 50);
      RoomsListView.Columns.Add("Status", 50);
      RoomsListView.Columns.Add("Players", 50);
      RoomsListView.Columns.Add("Spectators", 50);
      RoomsListView.Columns.Add("Details", 50);
      var imageList = new ImageList();
			imageList.Images.Add("RoomIcon", LoadImage(@"https://png.pngtree.com/png-vector/20191028/ourlarge/pngtree-game-console-glyph-icon-vector-png-image_1903964.jpg"));
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
			bWriter.Write("2,Rquest for Waiting room.");
			// RECEIVE
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
		}

        private void CreateNewRoomButton_Click(object sender, EventArgs e)
        {
            RoomDialog RoomDlg = new RoomDialog();
            DialogResult Dialog = RoomDlg.ShowDialog();
            if(Dialog==DialogResult.OK)
            {
                string roomName = RoomDlg.RoomName;
                CreateNewRoom(roomName);
            }
            else
            {
                //ToDO
            }
            
        }

        private void CreateNewRoom(string roomName)
        {
            var listViewItem = new ListViewItem();
            listViewItem.Text = roomName;
            listViewItem.SubItems.Add("Player One");
            listViewItem.ImageKey = "RoomIcon";
            RoomsListView.Items.Add(listViewItem);
        }


    }
}
