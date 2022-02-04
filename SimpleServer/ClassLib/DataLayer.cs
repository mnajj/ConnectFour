using System.Collections.Generic;

namespace SimpleServer.ClassLib
{
	/// <summary>
	/// This class will act as data layer
	/// </summary>
	public static class DataLayer
	{
		public static List<User> Users = new List<User>();
		public static List<Room> Rooms = new List<Room>();
	}
}
