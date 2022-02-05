using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleClient
{
	public partial class RoomsList : Form
	{
		public RoomsList()
		{
			InitializeComponent();
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
            var listViewItem = new ListViewItem();
            listViewItem.Text = "group One";
            listViewItem.SubItems.Add("Player One");
            listViewItem.ImageKey = "RoomIcon";
            RoomsListView.Items.Add(listViewItem);
            
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
