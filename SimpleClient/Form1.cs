using SimpleServer;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace SimpleClient
{
	public partial class Form1 : Form
	{
		TcpClient client;
		NetworkStream networkStream;
		BinaryReader binaryReader;
		BinaryWriter binaryWriter;

		public Form1()
		{
			InitializeComponent();
		}

		private void ConnectToServer_Click(object sender, System.EventArgs e)
		{
			client = new TcpClient();
			client.Connect(IPAddress.Parse("127.0.0.1"), 13000);
			networkStream = client.GetStream();

			binaryWriter = new BinaryWriter(networkStream);
			binaryWriter.Write($"0,username,{UserNameField.Text}");

			binaryReader = new BinaryReader(networkStream);
			string responseRes = binaryReader.ReadString();
			int status = int.Parse(responseRes.Split(',')[0]);
			if (status == 1)
			{

			}
			else
			{
				MessageBox.Show(responseRes.Split(',')[1]);
			}
		}
	}
}
