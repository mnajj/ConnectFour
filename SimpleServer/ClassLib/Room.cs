using System.Collections.Generic;

namespace SimpleServer.ClassLib
{
	public class Room
	{
		public string RoomName { get; set; }
		public User RoomOwner { get; set; }
		public List<User> Players { get; set; }
		public List<User> Spectators { get; set; }
	}
}
