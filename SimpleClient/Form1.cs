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

		private object DeserializeFromBytes(byte[] bytes)
		{
			var formatter = new BinaryFormatter();
			using (var stream = new MemoryStream(bytes))
			{
				return formatter.Deserialize(stream);
			}
		}

		private void ConnectToServer_Click(object sender, System.EventArgs e)
		{
			client = new TcpClient();
			client.Connect(IPAddress.Parse("127.0.0.1"), 13000);
			networkStream = client.GetStream();

			binaryWriter = new BinaryWriter(networkStream);
			binaryWriter.Write("0, Asking for Login Form.");

			binaryReader = new BinaryReader(networkStream);
			while (true)
			{
				byte[] bytes = binaryReader.ReadBytes(120);
				ClosingForm temp = DeserializeFromBytes(bytes) as ClosingForm;
			}
		}
	}
}
