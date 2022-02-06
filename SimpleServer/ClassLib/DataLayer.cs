﻿using ShardClassLibrary;
using System.Collections.Generic;

namespace SimpleServer.ClassLib
{
	/// <summary>
	/// This class will act as data layer
	/// </summary>
	public static class DataLayer
	{
		public static List<ClientHandler> Clients = new List<ClientHandler>();
		public static List<User> Users = new List<User>();
		public static List<Room> Rooms = new List<Room>();
		public static List<User> ConnectedUsers = new List<User>();

		public static void SeedUsers()
		{
			Users.Add(new User { UserName = "player1"});
			Users.Add(new User { UserName = "player2"});
			Users.Add(new User { UserName = "player3"});
			Users.Add(new User { UserName = "player4"});
			Users.Add(new User { UserName = "player5"});
			Users.Add(new User { UserName = "player6"});
		}
	}
}
