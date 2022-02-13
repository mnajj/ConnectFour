using ShardClassLibrary;
using System;
using System.Collections.Generic;
using System.Drawing;
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
		public string UserName { get; set; }
		public string Counter { get; set; }
		public int CurrentRoomNumber { get; set; }
		public bool IsOwner { get; set; }
		public bool IsPlayer { get; set; }
		public Color DiskColor { get; set; }
		public int PlayerNumber { get; set; }
		public int PlayAgain { get; set; }	

		NetworkStream networkStream;
		BinaryWriter bWriter;
		BinaryReader bReader;

		public ClientHandler(TcpClient soc)
		{
			Socket = soc;
			Thread clientThread = new Thread(this.AcceptRequests);
			clientThread.Start();
			PlayAgain = -1;
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
						case -1:
							LogClientOut();
							RemoveThisUserFromOnlineList();
							break;
						case 0:
							LogInUser(reqRes.Split(',')[2]);
							SendNewUserToConnected();
							break;
						case 2:
							RedirectToWaitingRoom();
							break;
						case 3:
							SaveNewRoomData(reqRes.Split(',')[2]);
							break;
						case 4:
							AddNewGuestToRoom(int.Parse(reqRes.Split(',')[2]));
							SendRoomData(int.Parse(reqRes.Split(',')[2]));
							UpdateOnlineMembersToOthers(int.Parse(reqRes.Split(',')[2]));
							break;
						case 45:
							AddNewSpectatorToRoom(int.Parse(reqRes.Split(',')[2]));
							SendRoomData(int.Parse(reqRes.Split(',')[2]));
							AddWatchOnlySpec(int.Parse(reqRes.Split(',')[2]));
							break;
						case 5:
							AddNewSpectatorToRoom(int.Parse(reqRes.Split(',')[2]));
							SendRoomDataToSpectator(int.Parse(reqRes.Split(',')[2]));
							UpdateOnlineSpectatorToOthers(int.Parse(reqRes.Split(',')[2]));
							break;
						case 6:
							SendGameStartRequestForCounter(
								reqRes.Split(',')[2],
								int.Parse(reqRes.Split(',')[3])
								);
							break;
						case 7:
						case -7:
							ReceiveCounterResponse(
								int.Parse(reqRes.Split(',')[0]),
								int.Parse(reqRes.Split(',')[2])
								);
							break;
						case 8:
							LogOutFrom(int.Parse(reqRes.Split(',')[2]));
							SendAvaliableRoomsData();
							UpdateAllMembersToOthers(int.Parse(reqRes.Split(',')[2]));
							break;
						case 9:
							SaveMoveData(int.Parse(reqRes.Split(',')[2]));
							CheckForWinner(int.Parse(reqRes.Split(',')[2]), reqRes.Split(',')[3]);
							break;
						case 12:
							SendConnectedUsersToNewLogin();
							break;
						case 919:
							AccepToPlayAgain();
							break;
						case 909:
							RefuseoPlayAgain();
							break;
					}
				}
			}
		}

		private void RefuseoPlayAgain()
		{
			this.PlayAgain = 0;
			ClientHandler counterCln = DataLayer.Clients
				.Where(c => c.UserName == this.Counter)
				.Where(c => c.CurrentRoomNumber == this.CurrentRoomNumber)
				.FirstOrDefault();
			counterCln.PlayAgain = 0;
			this.Counter = "";
			counterCln.Counter = "";
			bWriter = new BinaryWriter(counterCln.Socket.GetStream());
			bWriter.Write("9090,Other player refuse to play Again");
			DataLayer.Rooms[this.CurrentRoomNumber].Game.ResetTheBoard();
		}

		private void AccepToPlayAgain()
		{
			this.PlayAgain = 1;
			ClientHandler counterCln = DataLayer.Clients
				.Where(c => c.UserName == this.Counter)
				.Where(c => c.CurrentRoomNumber == this.CurrentRoomNumber)
				.FirstOrDefault();
			if (this.PlayAgain == 1 && counterCln.PlayAgain == 1)
			{
				DataLayer.Rooms[this.CurrentRoomNumber].Game.ResetTheBoard();
				bWriter = new BinaryWriter(counterCln.Socket.GetStream());
				bWriter.Write("9191,Other player want to play Again");
			}
		}

		private void AddWatchOnlySpec(int roomIdx)
		{
			foreach (var cln in DataLayer.Clients)
			{
				if (cln.CurrentRoomNumber == roomIdx)
				{
					if (cln.UserName != this.UserName)
					{
						bWriter = new BinaryWriter(cln.Socket.GetStream());
						bWriter.Write($"454,Append New watch Only Spec,{this.UserName}");
					}
				}
			}
		}

		private void RemoveThisUserFromOnlineList()
		{
			if (DataLayer.ConnectedUsers.Count > 0)
			{
				BinaryFormatter bf = new BinaryFormatter();
				foreach (var cln in DataLayer.Clients)
				{
					if (cln.UserName != this.UserName)
					{
						bWriter = new BinaryWriter(cln.Socket.GetStream());
						bWriter.Write($"1212,New User UnConnected,{this.UserName}");
					}
				}
			}
		}

		private void SendNewUserToConnected()
		{
			if (DataLayer.ConnectedUsers.Count > 1)
			{
				BinaryFormatter bf = new BinaryFormatter();
				foreach (var cln in DataLayer.Clients)
				{
					if (cln.UserName != this.UserName)
					{
						bWriter = new BinaryWriter(cln.Socket.GetStream());
						bWriter.Write($"121,New User Connected,{this.UserName}");
					}
				}
			}
		}

		private void SendNewConnectedToOthers()
		{
			BinaryFormatter bf = new BinaryFormatter();
			foreach (var cln in DataLayer.Clients)
			{
				bWriter = new BinaryWriter(cln.Socket.GetStream());
				bWriter.Write("-11,Client logout");
				bf.Serialize(networkStream, DataLayer.ConnectedUsers);
			}
		}

		private void SendConnectedUsersToNewLogin()
		{
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(networkStream, DataLayer.ConnectedUsers);
		}

		private void UpdateAllMembersToOthers(int roomIdx)
		{
			string players = String.Empty;
			string specs = String.Empty;
			foreach (ClientHandler cln in DataLayer.Clients)
			{
				if (cln.CurrentRoomNumber == roomIdx)
				{
					if (cln.IsPlayer)
					{
						players += cln.UserName + ";";
					}
					else
					{
						specs += cln.UserName + ";";
					}
				}
			}
			foreach (ClientHandler cln in DataLayer.Clients)
			{
				if (cln.CurrentRoomNumber == roomIdx)
				{
					bWriter = new BinaryWriter(cln.Socket.GetStream());
					bWriter.Write($"888,Update All Members,{players},{specs}");
				}
			}
		}

		private void CheckForWinner(int col, string counterClr)
		{
			Game game = DataLayer.Rooms[this.CurrentRoomNumber].Game;
			int winNum = -1;
			for (int i = 0; i < 6; i++)
			{
				for (int j = 0; j < 7; j++)
				{
					if (j <= 3)//for the horizantal either left or right from this point
					{

						//player 1
						if (game.BoardData[i][j] == 1 && game.BoardData[i][j + 1] == 1 && game.BoardData[i][j + 2] == 1 && game.BoardData[i][j + 3] == 1)
						{
							winNum = 1;
						}

						//player 2
						else if (game.BoardData[i][j] == 2 && game.BoardData[i][j + 1] == 2 && game.BoardData[i][j + 2] == 2 && game.BoardData[i][j + 3] == 2)
						{
							winNum = 2;
						}


					}
					if (i == 0 || i == 1 || i == 2)//verticalll
					{
						if (game.BoardData[i][j] == 1 && game.BoardData[i + 1][j] == 1 && game.BoardData[i + 2][j] == 1 && game.BoardData[i + 3][j] == 1)//vertical side player1
						{
							winNum = 1;
						}
						else if (game.BoardData[i][j] == 2 && game.BoardData[i + 1][j] == 2 && game.BoardData[i + 2][j] == 2 && game.BoardData[i + 3][j] == 2)//vertical side player1
						{
							winNum = 2;
						}
					}
					else
					{


						// ascendingDiagonalCheck 
						if (i >= 3 && j <= 3)//in the upper half of thee game.BoardData
						{
							//player 1
							if (game.BoardData[i][j] == 1 && game.BoardData[i - 1][j + 1] == 1 && game.BoardData[i - 2][j + 2] == 1 && game.BoardData[i - 3][j + 3] == 1)//digonal asc  player1
							{
								winNum = 1;
							}
							//player 2
							else if (game.BoardData[i][j] == 2 && game.BoardData[i - 1][j + 1] == 2 && game.BoardData[i - 2][j + 2] == 2 && game.BoardData[i - 3][j + 3] == 2)//digonal asc  player2
							{
								winNum = 2;
							}

						}

						// descendingDiagonalCheck 
						if (i >= 3 && j >= 3 && j < 7)//in the lower half of thee game.BoardData
						{

							//player 1
							if (game.BoardData[i][j] == 1 && game.BoardData[i - 1][j - 1] == 1 && game.BoardData[i - 2][j - 2] == 1 && game.BoardData[i - 3][j - 3] == 1)//digonal desc  player1
							{
								winNum = 1;
							}
							//player 2
							else if (game.BoardData[i][j] == 2 && game.BoardData[i - 1][j - 1] == 2 && game.BoardData[i - 2][j - 2] == 2 && game.BoardData[i - 3][j - 3] == 2)//digonal desc  player2
							{
								winNum = 2;
							}
						}
					}
				}
			}
			ClientHandler counterCln = null;
			foreach (var cln in DataLayer.Clients)
			{
				if (cln.UserName == this.Counter)
				{
					counterCln = cln;
				}
			}
			if (winNum != -1)
			{
				ClientHandler playerOne = DataLayer.Clients
					.Where(c => c.PlayerNumber == 1)
					.Where(c => c.CurrentRoomNumber == this.CurrentRoomNumber)
					.FirstOrDefault();
				ClientHandler playerTwo = DataLayer.Clients
					.Where(c => c.PlayerNumber == 2)
					.Where(c => c.CurrentRoomNumber == this.CurrentRoomNumber)
					.FirstOrDefault();
				if (winNum == 1)
				{
					bWriter = new BinaryWriter(playerOne.Socket.GetStream());
					bWriter.Write("991,YouWinTheGame");
					bWriter = new BinaryWriter(playerTwo.Socket.GetStream());
					bWriter.Write($"99,Send move to counter,{col},{counterClr}");
					bWriter.Write("990,YouLoseTheGame");
				}
				else if (winNum == 2)
				{
					bWriter = new BinaryWriter(playerTwo.Socket.GetStream());
					bWriter.Write("991,YouWinTheGame");
					bWriter = new BinaryWriter(playerOne.Socket.GetStream());
					bWriter.Write($"99,Send move to counter,{col},{counterClr}");
					bWriter.Write("990,YouLoseTheGame");
				}
			}
			else
			{
				bWriter = new BinaryWriter(counterCln.Socket.GetStream());
				bWriter.Write($"99,Send move to counter,{col},{counterClr}");
			}
		}

		private void SaveMoveData(int col)
		{
			int currRoomIdx = this.CurrentRoomNumber;
			Room currRoom = DataLayer.Rooms[currRoomIdx];
			Game currGame = currRoom.Game;

			if (col == 0)
			{
				if (this.PlayerNumber == 1)
				{
					currGame.BoardData[currGame.Board1X][0] = 1;
					currGame.Board1X--;
				}
				else
				{
					currGame.BoardData[currGame.Board1X][0] = 2;
					currGame.Board1X--;
				}
			}
			else if (col == 1)
			{
				if (this.PlayerNumber == 1)
				{
					currGame.BoardData[currGame.Board2X][1] = 1;
					currGame.Board2X--;
				}
				else
				{
					currGame.BoardData[currGame.Board2X][1] = 2;
					currGame.Board2X--;
				}
			}
			else if (col == 2)
			{
				if (this.PlayerNumber == 1)
				{
					currGame.BoardData[currGame.Board3X][2] = 1;
					currGame.Board3X--;
				}
				else
				{
					currGame.BoardData[currGame.Board3X][2] = 2;
					currGame.Board3X--;
				}
			}
			else if (col == 3)
			{
				if (this.PlayerNumber == 1)
				{
					currGame.BoardData[currGame.Board4X][3] = 1;
					currGame.Board4X--;
				}
				else
				{
					currGame.BoardData[currGame.Board4X][3] = 2;
					currGame.Board4X--;
				}
			}
			else if (col == 4)
			{
				if (this.PlayerNumber == 1)
				{
					currGame.BoardData[currGame.Board5X][4] = 1;
					currGame.Board5X--;
				}
				else
				{
					currGame.BoardData[currGame.Board5X][4] = 2;
					currGame.Board5X--;
				}
			}
			else if (col == 5)
			{
				if (this.PlayerNumber == 1)
				{
					currGame.BoardData[currGame.Board6X][5] = 1;
					currGame.Board6X--;
				}
				else
				{
					currGame.BoardData[currGame.Board6X][5] = 2;
					currGame.Board6X--;
				}
			}
			else if (col == 6)
			{
				if (this.PlayerNumber == 1)
				{
					currGame.BoardData[currGame.Board7X][6] = 1;
					currGame.Board7X--;
				}
				else
				{
					currGame.BoardData[currGame.Board7X][6] = 2;
					currGame.Board7X--;
				}
			}
		}

		private void LogOutFrom(int roomIdx)
		{
			Room currentRoom = DataLayer.Rooms[roomIdx];
			currentRoom.Players.RemoveAll(p => p.UserName == this.UserName);
			currentRoom.Spectators.RemoveAll(s => s.UserName == this.UserName);
			if (this.IsPlayer)
			{
				if (currentRoom.RoomOwner.UserName == this.UserName)
				{
					currentRoom.RoomOwner.UserName = null;
				}
			}
			this.CurrentRoomNumber = -1;
		}

		private void SendAvaliableRoomsData()
		{
			bWriter = new BinaryWriter(this.networkStream);
			bWriter.Write("88,send rooms data");

			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(networkStream, DataLayer.Rooms);
			bf.Serialize(networkStream, DataLayer.ConnectedUsers);
		}

		private void LogClientOut()
		{
			DataLayer.Clients.RemoveAll(c => c.UserName == this.UserName);
			int i = DataLayer.Clients.Count;
			DataLayer.ConnectedUsers.RemoveAll(u => u.UserName == this.UserName);
		}

		private void ReceiveCounterResponse(int header, int roomIdx)
		{
			var currRoom = DataLayer.Rooms[roomIdx];
			foreach (ClientHandler cln in DataLayer.Clients)
			{
				if (cln.IsPlayer == true && cln.CurrentRoomNumber == roomIdx)
				{
					if (cln.UserName != this.UserName)
					{
						this.PlayerNumber = 2;
						this.Counter = cln.UserName;
						cln.PlayerNumber = 1;
						cln.Counter = this.UserName;

						bWriter = new BinaryWriter(cln.Socket.GetStream());
						if (header == 7)
						{
							bWriter.Write($"77,Your request accepted,{this.UserName},{currRoom.RoomBoardSize}");
							CreateAndInitGame(roomIdx);
						}
						else
						{
							bWriter.Write($"-77,Your request refused,{this.UserName},{currRoom.RoomBoardSize}");
						}
					}
				}
			}
			//foreach (ClientHandler cln in DataLayer.Clients)
			//{
			//	if (cln.CurrentRoomNumber == roomIdx && (!IsPlayer))
			//	{
			//		bWriter = new BinaryWriter(cln.Socket.GetStream());
			//		bWriter.Write($"77,Your request accepted,{this.UserName}");
			//		BinaryFormatter clinetBF = new BinaryFormatter();
			//		clinetBF.Serialize(cln.Socket.GetStream(), DataLayer.Rooms);
			//	}
			//}
		}

		private void CreateAndInitGame(int roomIdx)
		{
			DataLayer.Rooms[roomIdx].Game = new Game();
			if (DataLayer.Rooms[this.CurrentRoomNumber].RoomBoardSize == "6×7")
			{
				DataLayer.Rooms[roomIdx].Game.Board1X = 5;
				DataLayer.Rooms[roomIdx].Game.Board2X = 5;
				DataLayer.Rooms[roomIdx].Game.Board3X = 5;
				DataLayer.Rooms[roomIdx].Game.Board4X = 5;
				DataLayer.Rooms[roomIdx].Game.Board5X = 5;
				DataLayer.Rooms[roomIdx].Game.Board6X = 5;
				DataLayer.Rooms[roomIdx].Game.Board7X = 5;
			}
			else if (DataLayer.Rooms[this.CurrentRoomNumber].RoomBoardSize == "4×5")
			{
				DataLayer.Rooms[roomIdx].Game.Board1X = 3;
				DataLayer.Rooms[roomIdx].Game.Board2X = 3;
				DataLayer.Rooms[roomIdx].Game.Board3X = 3;
				DataLayer.Rooms[roomIdx].Game.Board4X = 3;
				DataLayer.Rooms[roomIdx].Game.Board5X = 3;
				DataLayer.Rooms[roomIdx].Game.Board6X = 3;
				DataLayer.Rooms[roomIdx].Game.Board7X = 3;
			}
		}

		private void PickColor(string strColor)
		{
			switch (strColor)
			{
				case "Red":
					this.DiskColor = Color.Red;
					break;
				case "Yellow":
					this.DiskColor = Color.Yellow;
					break;
				case "Blue":
					this.DiskColor = Color.Blue;
					break;
			}
		}

		private void SendGameStartRequestForCounter(string strColor, int roomIdx)
		{
			PickColor(strColor);
			Room currRoom = DataLayer.Rooms[roomIdx];
			ClientHandler counterClient;
			foreach (ClientHandler cln in DataLayer.Clients)
			{
				if (cln.IsPlayer == true && cln.UserName != this.UserName && cln.CurrentRoomNumber == roomIdx)
				{
					bWriter = new BinaryWriter(cln.Socket.GetStream());
					bWriter.Write($"66,redirect counter start game request,{this.UserName},{currRoom.RoomBoardSize}");
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
					this.UserName = userName;
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
						BinaryFormatter bf = new BinaryFormatter();
						bf.Serialize(networkStream, DataLayer.ConnectedUsers);
					}
				}
			}
			else
			{
				bWriter.Write("-1,Can't find username.");
			}
		}

		private void SendNewConnectedUserToExistingUsers()
		{
			foreach (var cln in DataLayer.Clients)
			{
				if (cln.UserName != this.UserName)
				{
					bWriter = new BinaryWriter(cln.Socket.GetStream());
					BinaryFormatter bf = new BinaryFormatter();
					bf.Serialize(cln.Socket.GetStream(), DataLayer.ConnectedUsers);
				}
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
			this.CurrentRoomNumber = idx;
			User roomOwner = new User { UserName = splitedData[2] };
			DataLayer.Rooms.Add(
				new Room
				{
					Index = idx,
					RoomName = splitedData[1],
					RoomBoardSize = splitedData[3],
					RoomOwnerDiskColor = splitedData[4],
					Players = new List<User>(),
					Spectators = new List<User>(),
					RoomOwner = roomOwner
				});
			DataLayer.Rooms[idx].Players.Add(roomOwner);
			this.IsPlayer = true;
			this.IsOwner = true;
			PickColor(splitedData[4]);

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
					clinetBF.Serialize(clientNetWorkStream, DataLayer.ConnectedUsers);
				}
			}
		}

		private void SendRoomData(int roomIdx)
		{
			// Get Room
			Room matchRoom = DataLayer.Rooms[roomIdx];

			// SEND Msg Header
			bWriter = new BinaryWriter(networkStream);
			bWriter.Write("44,Accept");

			// SEND Room Object
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(networkStream, matchRoom);
		}

		private void SendRoomDataToSpectator(int roomIdx)
		{
			// Get Room
			Room matchRoom = DataLayer.Rooms[roomIdx];

			// SEND Msg Header
			bWriter = new BinaryWriter(networkStream);
			bWriter.Write("55,Accept");

			// SEND Room Object
			BinaryFormatter bf = new BinaryFormatter();
			bf.Serialize(networkStream, matchRoom);
		}

		private void AddNewGuestToRoom(int roomIdx)
		{
			this.CurrentRoomNumber = roomIdx;
			DataLayer.Rooms[roomIdx].Players.Add(
					new User { UserName = this.UserName }
				);
			this.IsPlayer = true;
		}

		private void AddNewSpectatorToRoom(int roomIdx)
		{
			this.CurrentRoomNumber = roomIdx;
			DataLayer.Rooms[roomIdx].Spectators.Add(
					new User { UserName = this.UserName }
				);
			this.IsPlayer = false;
		}

		private void UpdateOnlineMembersToOthers(int roomIdx)
		{
			List<ClientHandler> roomPlayers = DataLayer.Clients.Where(c => c.CurrentRoomNumber == roomIdx).ToList();
			List<string> sendPlayers = new List<string>();

			for (int i = 0; i < roomPlayers.Count; i++)
			{
				sendPlayers.Add(roomPlayers[i].UserName);
			}

			for (int i = 0; i < roomPlayers.Count; i++)
			{

				if (roomPlayers[i].UserName != this.UserName)
				{
					NetworkStream clientNetWorkStream = roomPlayers[i].Socket.GetStream();
					bWriter = new BinaryWriter(clientNetWorkStream);
					bWriter.Write($"444,update room members");

					BinaryFormatter clinetBF = new BinaryFormatter();
					clinetBF.Serialize(clientNetWorkStream, sendPlayers);
				}
			}
		}

		private void UpdateOnlineSpectatorToOthers(int roomIdx)
		{
			List<ClientHandler> roomPlayers = DataLayer.Clients.Where(c => c.CurrentRoomNumber == roomIdx).ToList();
			List<ClientHandler> filterdSpecs = new List<ClientHandler>();

			for (int i = 0; i < roomPlayers.Count; i++)
			{
				for (int j = 0; j < DataLayer.Rooms[roomIdx].Spectators.Count; j++)
				{
					if (DataLayer.Rooms[roomIdx].Spectators[j].UserName == roomPlayers[i].UserName)
					{
						filterdSpecs.Add(roomPlayers[i]);
					}
				}
			}
			List<string> sendSpectators = new List<string>();

			for (int i = 0; i < filterdSpecs.Count; i++)
			{
				sendSpectators.Add(filterdSpecs[i].UserName);
			}

			for (int i = 0; i < filterdSpecs.Count; i++)
			{
				for (int j = 0; j < roomPlayers.Count; j++)
				{
					if (filterdSpecs[i].UserName != roomPlayers[i].UserName)
					{
						NetworkStream clientNetWorkStream = roomPlayers[i].Socket.GetStream();
						bWriter = new BinaryWriter(clientNetWorkStream);
						bWriter.Write($"555,update room members");
						BinaryFormatter clinetBF = new BinaryFormatter();
						clinetBF.Serialize(clientNetWorkStream, sendSpectators);
					}
				}
			}
		}
	}
}
