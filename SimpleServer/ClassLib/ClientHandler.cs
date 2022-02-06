using ShardClassLibrary;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace SimpleServer.ClassLib
{
	public class ClientHandler
	{
		public TcpClient Socket { get; set; }

		string userName;
		string counter;
		NetworkStream networkStream;
		BinaryWriter bWriter;
		BinaryReader bReader;

		public ClientHandler(TcpClient soc)
		{
			Socket = soc;
			Thread clientThread = new Thread(this.AcceptRequests);
			clientThread.Start();
		}

		public void AcceptRequests()
		{
			while (true)
			{
				networkStream = Socket.GetStream();
				if (networkStream.DataAvailable)
				{
					bReader = new BinaryReader(networkStream);
					string reqRes = bReader.ReadString();
					int status = int.Parse(reqRes.Split(',')[0]);
					switch (status)
					{
						// Login Status
						case 0:
							LogInUser(reqRes.Split(',')[2]);
							break;
						case 2:
							RedirectToWaitingRoom();
							break;
						case 3:
							SaveNewRoomData(reqRes.Split(',')[2]);
							break;
					}
				}
			}
		}

		private void LogInUser(string userName)
		{
			var matches = DataLayer.Users.Where(u => u.UserName == userName).ToList();
			bWriter = new BinaryWriter(networkStream);
			if (matches.Count > 0)
			{
				var conntectedMatches = DataLayer.ConnectedUsers.Where(u => u.UserName == userName).ToList();
				if (conntectedMatches.Count > 0)
				{
					bWriter.Write("-1,This User is already connected to server.");
				}
				else
				{
					this.userName = userName;
					DataLayer.ConnectedUsers.AddRange(matches);
					if (DataLayer.Rooms.Count > 0)
					{
						bWriter.Write($"11,{Views.RoomsList}");

						BinaryFormatter bf = new BinaryFormatter();
						bf.Serialize(networkStream, DataLayer.Rooms);
					}
					else
					{
						bWriter.Write($"1,{Views.RoomsList}");
					}
				}
			}
			else
			{
				bWriter.Write("-1,Can't find username.");
			}
		}

		private void RedirectToWaitingRoom()
		{
			bWriter = new BinaryWriter(networkStream);
			bWriter.Write($"1,{Views.WaitingRoom}");
		}

		private void SaveNewRoomData(string roomData)
		{
			string[] splitedData = roomData.Split(';');
			int idx = int.Parse(splitedData[0]);
			User roomOwner = new User { UserName = splitedData[2] };
			DataLayer.Rooms.Add(
				new Room
				{
					Index = idx,
					RoomName = splitedData[1],
					Players = new List<User>(),
					Spectators = new List<User>(),
					RoomOwner = roomOwner
				});
			DataLayer.Rooms[idx].Players.Add(roomOwner);

			/* Check if there are players connected to send new data to them */
			if (DataLayer.ConnectedUsers.Count > 1)
			{
				SendNewCreatedRoomsDataToClients();
			}
		}

		private void SendNewCreatedRoomsDataToClients()
		{
			for (int i = 0; i < DataLayer.Clients.Count; i++)
			{
				NetworkStream clientNetWorkStream = DataLayer.Clients[i].Socket.GetStream();
				if (clientNetWorkStream != networkStream)
				{
					bWriter = new BinaryWriter(clientNetWorkStream);
					bWriter.Write($"111,new rooms data");

					BinaryFormatter clinetBF = new BinaryFormatter();
					clinetBF.Serialize(clientNetWorkStream, DataLayer.Rooms);
				}
			}
		}
	}
}
