using System;
using System.Collections.Generic;

namespace ShardClassLibrary
{
	[Serializable]
	public class Room
	{
		public int Index { get; set; }
		public string RoomName { get; set; }
		public User RoomOwner { get; set; }
		public string RoomOwnerDiskColor { get; set; }
		public string RoomBoardSize { get; set; }
		public List<User> Players { get; set; }
		public List<User> Spectators { get; set; }
	}
}
