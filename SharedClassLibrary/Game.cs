using System;

namespace SimpleServer.ClassLib
{
	[Serializable]
	public class Game
	{
		public int[][] BoardData { get; set; }
		public int Board1X { get; set; }
		public int Board2X { get; set; }
		public int Board3X { get; set; }
		public int Board4X { get; set; }
		public int Board5X { get; set; }
		public int Board6X { get; set; }
		public int Board7X { get; set; }

		public Game()
		{
			BoardData = new int[6][];//for 6*7 and 4*5
			BoardData[0] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
			BoardData[1] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
			BoardData[2] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
			BoardData[3] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
			BoardData[4] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
			BoardData[5] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
		}
	}
}
