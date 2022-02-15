using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using SimpleClient.Dialogs;

namespace SimpleClient
{
	public partial class GamingPlayGround : Form
	{
		WaitingRoom waitingRoom;
    BinaryWriter bWriter;
		public Color PlayerClr { get; set; }
		public Color CounterClr { get; set; }
		public bool IsSpectator { get; set; }
		public bool IsMyTurn { get; set; }
    public bool IsInvitationSender { get; set; }
		public bool IsGameOver { get; set; }
		public string BoardSize { get; set; }
		public bool IsWinner { get; set; }

		//
		public Color PlayerOneClr { get; set; }
		public Color PlayerTwoClr { get; set; }

		//Member data GFX
		Pen blackPen;//pen for lines
		Graphics g;
		Font drawFont;
		SolidBrush drawBrush;
		SolidBrush playerBrush;
		SolidBrush counterPlayerBrush;

		//4 X 5
		int[] boxX1 = new int[7];
		int[] boxY1 = new int[7];

		// 6 X 7
		int[] boxX3 = new int[7];
		int[] boxY3 = new int[7];

		public GamingPlayGround(string boardSize, WaitingRoom waitingRoom, bool isSpec = false, bool isInvitationSender = false)
		{
			InitializeComponent();
			this.waitingRoom = waitingRoom;
			this.IsSpectator = isSpec;
			if (isSpec) IsMyTurn = false;
      IsInvitationSender = isInvitationSender;
			this.BoardSize = boardSize;
      if (isInvitationSender)
			{
        IsMyTurn = true;
			}
			else
			{
        IsMyTurn = false;
			}
			IsGameOver = false;
      bWriter = new BinaryWriter(waitingRoom.RoomsListForm.ClientForm.ClientNetworkStream);
			if (waitingRoom.PlayerColor == null)
			{
				PickOwnerColor();
			}
			else
			{
				PickMyColor();
			}

			CheckIfThereIsLiveGame();

			// GFX
			blackPen = new Pen(Color.Black, 1);
			g = CreateGraphics();
			drawFont = new Font("Arial", 12);
			drawBrush = new SolidBrush(Color.Black);
			playerBrush = new SolidBrush(PlayerClr);
			counterPlayerBrush = new SolidBrush(CounterClr);
		}

		private void CheckIfThereIsLiveGame()
		{
			if (waitingRoom.RoomsListForm.IsGameLive)
			{
				ClearArray();
				bWriter.Write("8069, give me current game data");
			}
		}

		private void PickOwnerColor()
		{
			switch (waitingRoom.RoomsListForm.OwnerClr)
			{
				case "Red":
					this.PlayerClr = Color.Red;
					break;
				case "Blue":
					this.PlayerClr = Color.Blue;
					break;
				case "Yellow":
					this.PlayerClr = Color.Yellow;
					break;
			}
		}

		private void PickMyColor()
		{
			switch (waitingRoom.PlayerColor)
			{
				case "Red":
					this.PlayerClr = Color.Red;
					break;
				case "Blue":
					this.PlayerClr = Color.Blue;
					break;
				case "Yellow":
					this.PlayerClr = Color.Yellow;
					break;
			}
		}

		protected override void OnPaint(PaintEventArgs e)
		{
			if (BoardSize == "6×7")
			{
				DrawSixBySeven();
			}
			else if (BoardSize == "4×5")
			{
				DrawFourByFive();
			}
			if (!waitingRoom.RoomsListForm.IsGameLive)
			{
				ClearArray();
			}
		}

		private void GamingPlayGround_MouseDown(object sender, MouseEventArgs e)
		{
			if (!IsGameOver)
			{
				if (IsMyTurn)
				{
					int col = -1;
					IsMyTurn = false;
					// Darw Disk Move
					if (BoardSize == "6×7")
					{
						if ((e.Location.Y >= 100 && e.Location.Y <= 402))//inside the y of the board
						{
							if (e.Location.X >= 200 && e.Location.X <= 267)//1
							{
								col = 0;
								if (boxY1[0] != 55)//to mentain the circles inside the board
								{
									//draw the circle here
									g.FillEllipse(playerBrush, new Rectangle(boxX1[0], boxY1[0], 40, 40));
									boxY1[0] -= 50;//increase the height of the circle
								}
							}
							else if (e.Location.X >= 267 && e.Location.X <= 334)//2
							{
								col = 1;
								if (boxY1[1] != 55)
								{
									g.FillEllipse(playerBrush, new Rectangle(boxX1[1], boxY1[1], 40, 40));
									boxY1[1] -= 50;
								}
							}
							else if (e.Location.X >= 334 && e.Location.X <= 401)//3
							{
								col = 2;
								if (boxY1[2] != 55)
								{
									g.FillEllipse(playerBrush, new Rectangle(boxX1[2], boxY1[2], 40, 40));
									boxY1[2] -= 50;
								}
							}
							else if (e.Location.X >= 401 && e.Location.X <= 468)//4
							{
								col = 3;
								if (boxY1[3] != 55)
								{
									g.FillEllipse(playerBrush, new Rectangle(boxX1[3], boxY1[3], 40, 40));
									boxY1[3] -= 50;
								}
							}
							else if (e.Location.X >= 468 && e.Location.X <= 535)//5
							{
								col = 4;
								if (boxY1[4] != 55)
								{
									g.FillEllipse(playerBrush, new Rectangle(boxX1[4], boxY1[4], 40, 40));
									boxY1[4] -= 50;
								}
							}
							else if (e.Location.X >= 535 && e.Location.X <= 602)//6
							{
								col = 5;
								if (boxY1[5] != 55)
								{
									g.FillEllipse(playerBrush, new Rectangle(boxX1[5], boxY1[5], 40, 40));
									boxY1[5] -= 50;
								}
							}
							else if (e.Location.X >= 602 && e.Location.X <= 669)//7
							{
								col = 6;
								if (boxY1[6] != 55)
								{
									g.FillEllipse(playerBrush, new Rectangle(boxX1[6], boxY1[6], 40, 40));
									boxY1[6] -= 50;
								}
							}
						}
					}
					else if (BoardSize == "4×5")
					{
						if (e.Location.Y >= 100 && e.Location.Y <= 380)
						{
							if (e.Location.X >= 100 && e.Location.X <= 195)//1
							{
								col = 0;
								if (boxY3[0] != 50)//to mentain the circles inside the board
								{
									//draw the circle here
									g.FillEllipse(playerBrush, new Rectangle(boxX3[0], boxY3[0], 40, 40));

									boxY3[0] -= 70;//increase the height of the circle
								}
							}
							else if (e.Location.X >= 195 && e.Location.X <= 290)//2
							{
								col = 1;
								if (boxY3[1] != 50)
								{
									g.FillEllipse(playerBrush, new Rectangle(boxX3[1], boxY3[1], 40, 40));
									boxY3[1] -= 70;
								}
							}
							else if (e.Location.X >= 290 && e.Location.X <= 385)//3
							{
								col = 2;
								if (boxY3[2] != 50)
								{
									g.FillEllipse(playerBrush, new Rectangle(boxX3[2], boxY3[2], 40, 40));
									boxY3[2] -= 70;
								}

							}
							else if (e.Location.X >= 385 && e.Location.X <= 480)//4
							{
								col = 3;
								if (boxY3[3] != 50)
								{
									g.FillEllipse(playerBrush, new Rectangle(boxX3[3], boxY3[3], 40, 40));
									boxY3[3] -= 70;
								}
							}
							else if (e.Location.X >= 480 && e.Location.X <= 575)//5
							{
								col = 4;
								if (boxY3[4] != 50)
								{
									g.FillEllipse(playerBrush, new Rectangle(boxX3[4], boxY3[4], 40, 40));
									boxY3[4] -= 70;
								}
							}
						}
					}
					// Send This Move to Server
					SendMyMoveToServer(col);
				}
			}
		}

		private void SendMyMoveToServer(int col)
		{
			bWriter.Write($"9,Send Move to Server,{col},{PlayerClr.Name}");
			this.IsMyTurn = false;
		}

		private void DrawSixBySeven()
		{
			int x1;
			int y1;
			int x2;
			int y2;
			int count;

			x1 = 200;
			y1 = 100;
			x2 = 667;
			y2 = 100;
			count = 0;//to increment the lines 
			for (int i = 0; i < 7; i++)
			{
				g.DrawLine(blackPen, x1, y1 + count, x2, y2 + count);
				count += 50;
			}

			x1 = 200;
			y1 = 100;
			x2 = 200;
			y2 = 400;
			count = 0;//to increment the lines 
			for (int i = 0; i < 8; i++)
			{
				g.DrawLine(blackPen, x1 + count, y1, x2 + count, y2);
				count += 67;
			}

			int x = 175;
			int y = 100;

			count = 0;
			for (int i = 6; i > 0; i--)//numbers on vertical
			{
				g.DrawString(i.ToString(), drawFont, drawBrush, x, y + count);
				count += 55;
			}
			int count1 = 0;
			for (int i = 1; i < 8; i++)//numbers on horzinatal
			{
				count1 += 63;
				g.DrawString(i.ToString(), drawFont, drawBrush, x + count1, 415);
			}
		}

		private void DrawFourByFive()
		{
			int x1 = 100;//-100(from size=0)
			int y1 = 100;
			int x2 = 575;// -100(from size=0)
			int y2 = 100;
			int count = 0;//to increment the lines 
			for (int i = 0; i < 5; i++)
			{
				g.DrawLine(blackPen, x1, y1 + count, x2, y2 + count);
				count += 70;//+20(from size=0)
			}
			x1 = 100;
			y1 = 100;
			x2 = 100;
			y2 = 380;
			count = 0;//to increment the lines 
			for (int i = 0; i < 6; i++)
			{
				g.DrawLine(blackPen, x1 + count, y1, x2 + count, y2);
				count += 95;//+28(from size 0)
			}
			int x = 60;
			int y = 130;
			count = 0;
			for (int i = 4; i > 0; i--)//numbers on vertical
			{
				g.DrawString(i.ToString(), drawFont, drawBrush, x, y + count);
				count += 70;
			}
			int count1 = 0;
			x1 = 40;
			for (int i = 1; i < 6; i++)//numbers on horzinatal
			{
				count1 += 97;
				g.DrawString(i.ToString(), drawFont, drawBrush, x1 + count1, 400);
			}
		}

		public void OtherPlayerAcceptToPlayAgain()
		{
			this.IsGameOver = false;
			ClearArray();
			Invalidate();
			if (IsWinner)
			{
				IsMyTurn = true;
			}
			else
			{
				IsMyTurn = false;
			}
		}

		public void OtherPlayerRefuseToPlayAgain()
		{
			this.IsGameOver = true;
			waitingRoom.Show();
			this.Close();
		}

		public void RecieveCounterMoveAsSpec(int col, string clr)
		{
			switch (clr)
			{
				case "Red":
					this.CounterClr = Color.Red;
					break;
				case "Blue":
					this.CounterClr = Color.Blue;
					break;
				case "Yellow":
					this.CounterClr = Color.Yellow;
					break;
			}
			counterPlayerBrush.Color = CounterClr;
			if (BoardSize == "6×7")
			{
				if (col == 0)
				{
					if (boxY1[0] != 55)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX1[0], boxY1[0], 40, 40));
						boxY1[0] -= 50;//increase the height of the circle
					}
				}
				else if (col == 1)
				{
					if (boxY1[1] != 55)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX1[1], boxY1[1], 40, 40));
						boxY1[1] -= 50;//increase the height of the circle
					}
				}
				else if (col == 2)
				{
					if (boxY1[2] != 55)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX1[2], boxY1[2], 40, 40));
						boxY1[2] -= 50;//increase the height of the circle
					}
				}
				else if (col == 3)
				{
					if (boxY1[3] != 55)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX1[3], boxY1[3], 40, 40));
						boxY1[3] -= 50;//increase the height of the circle
					}
				}
				else if (col == 4)
				{
					if (boxY1[4] != 55)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX1[4], boxY1[4], 40, 40));
						boxY1[4] -= 50;//increase the height of the circle
					}
				}
				else if (col == 5)
				{
					if (boxY1[5] != 55)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX1[5], boxY1[5], 40, 40));
						boxY1[5] -= 50;//increase the height of the circle
					}
				}
				else if (col == 6)
				{
					if (boxY1[6] != 55)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX1[6], boxY1[6], 40, 40));
						boxY1[6] -= 50;//increase the height of the circle
					}
				}
			}
			else if (BoardSize == "4×5")
			{
				if (col == 0)
				{
					if (boxY3[0] != 50)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX3[0], boxY3[0], 40, 40));

						boxY3[0] -= 70;//increase the height of the circle
					}
				}
				else if (col == 1)
				{
					if (boxY3[1] != 50)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX3[1], boxY3[1], 40, 40));

						boxY3[1] -= 70;//increase the height of the circle
					}
				}
				else if (col == 2)
				{
					if (boxY3[2] != 50)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX3[2], boxY3[2], 40, 40));
						boxY3[2] -= 70;//increase the height of the circle
					}
				}
				else if (col == 3)
				{
					if (boxY3[3] != 50)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX3[3], boxY3[3], 40, 40));
						boxY3[3] -= 70;//increase the height of the circle
					}
				}
				else if (col == 4)
				{
					if (boxY3[4] != 50)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX3[4], boxY3[4], 40, 40));
						boxY3[4] -= 70;//increase the height of the circle
					}
				}
			}
		}

		public void DrawCurrentGameBoardData(int[][] gameBoardData, string plyOneClr, string plyTwoClr)
		{
			AssignColorsToPlayers(plyOneClr, plyTwoClr);
			Brush playerOneBrush = new SolidBrush(PlayerOneClr);
			Brush playerTwoBrush = new SolidBrush(PlayerTwoClr);
			//6*7
			for (int i = 0; i < 7; i++)//col 
			{
				for (int j = 5; j >= 0; j--)//row
				{
					//player 1
					if (gameBoardData[j][i] == 1)
					{
						g.FillEllipse(playerOneBrush, new Rectangle(boxX1[i], boxY1[i], 40, 40));
					}
					//player 2
					else if (gameBoardData[j][i] == 2)
					{
						g.FillEllipse(playerTwoBrush, new Rectangle(boxX1[i], boxY1[i], 40, 40));
					}
					boxY1[i] -= 50;//must dec always
				}
			}
		}

		private void AssignColorsToPlayers(string plyOneClr, string plyTwoClr)
		{
			switch (plyOneClr)
			{
				case "Red":
					this.PlayerOneClr = Color.Red;
					break;
				case "Blue":
					this.PlayerOneClr = Color.Blue;
					break;
				case "Yellow":
					this.PlayerOneClr = Color.Yellow;
					break;
			}
			switch (plyTwoClr)
			{
				case "Red":
					this.PlayerTwoClr = Color.Red;
					break;
				case "Blue":
					this.PlayerTwoClr = Color.Blue;
					break;
				case "Yellow":
					this.PlayerTwoClr = Color.Yellow;
					break;
			}
		}

		public void EndSession()
		{
			waitingRoom.RoomsListForm.IsGameLive = false;
			MessageBox.Show("This Session Ended, You Can Leave Now");
			waitingRoom.Show();
			this.Close();
		}

		public void ResumeSession()
		{
			MessageBox.Show("Players Will Play Game Again");
			if (waitingRoom.RoomsListForm.IsGameLive)
			ClearArray();
			Invalidate();
		}

		public void DeclareWinnerOrLoser(int status)
		{
			DeclareDialg declareDialg;
			if (status == 991)
			{
				declareDialg = new DeclareDialg(true);
				IsWinner = true;
			}
			else
			{
				declareDialg = new DeclareDialg(false);
				IsWinner = false;

			}
			DialogResult dlgRes = declareDialg.ShowDialog();
			if (dlgRes == DialogResult.OK)
			{
				bWriter.Write("919,Accept to play Again");
				IsGameOver = false;
			}
			else
			{
				bWriter.Write("909,Refuse to play Again");
				IsGameOver = true;
				this.waitingRoom.Show();
				this.Close();
			}
		}

		private void ClearArray()
		{
			int boxCountX1 = 0;
			for (int i = 0; i < 7; i++)
			{
				boxX1[i] = 210 + boxCountX1;
				boxCountX1 += 67;
			}

			for (int i = 0; i < 7; i++)
			{
				boxY1[i] = 355;
			}
			int boxCountX3 = 0;
			for (int i = 0; i < 7; i++)
			{
				boxX3[i] = 130 + boxCountX3;
				boxCountX3 += 95;
			}

			for (int i = 0; i < 7; i++)
			{
				boxY3[i] = 330;
			}
		}

		public void RecieveCounterMove(int col, string counterClr)
		{
			switch (counterClr)
			{
				case "Red":
					this.CounterClr = Color.Red;
					break;
				case "Blue":
					this.CounterClr = Color.Blue;
					break;
				case "Yellow":
					this.CounterClr = Color.Yellow;
					break;
			}
			counterPlayerBrush.Color = CounterClr;
			if (BoardSize == "6×7")
			{
				if (col == 0)
				{
					if (boxY1[0] != 55)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX1[0], boxY1[0], 40, 40));
						boxY1[0] -= 50;//increase the height of the circle
					}
				}
				else if (col == 1)
				{
					if (boxY1[1] != 55)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX1[1], boxY1[1], 40, 40));
						boxY1[1] -= 50;//increase the height of the circle
					}
				}
				else if (col == 2)
				{
					if (boxY1[2] != 55)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX1[2], boxY1[2], 40, 40));
						boxY1[2] -= 50;//increase the height of the circle
					}
				}
				else if (col == 3)
				{
					if (boxY1[3] != 55)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX1[3], boxY1[3], 40, 40));
						boxY1[3] -= 50;//increase the height of the circle
					}
				}
				else if (col == 4)
				{
					if (boxY1[4] != 55)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX1[4], boxY1[4], 40, 40));
						boxY1[4] -= 50;//increase the height of the circle
					}
				}
				else if (col == 5)
				{
					if (boxY1[5] != 55)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX1[5], boxY1[5], 40, 40));
						boxY1[5] -= 50;//increase the height of the circle
					}
				}
				else if (col == 6)
				{
					if (boxY1[6] != 55)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX1[6], boxY1[6], 40, 40));
						boxY1[6] -= 50;//increase the height of the circle
					}
				}
			}
			else if (BoardSize == "4×5")
			{
				if (col == 0)
				{
					if (boxY3[0] != 50)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX3[0], boxY3[0], 40, 40));

						boxY3[0] -= 70;//increase the height of the circle
					}
				}
				else if (col == 1)
				{
					if (boxY3[1] != 50)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX3[1], boxY3[1], 40, 40));

						boxY3[1] -= 70;//increase the height of the circle
					}
				}
				else if (col == 2)
				{
					if (boxY3[2] != 50)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX3[2], boxY3[2], 40, 40));
						boxY3[2] -= 70;//increase the height of the circle
					}
				}
				else if (col == 3)
				{
					if (boxY3[3] != 50)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX3[3], boxY3[3], 40, 40));
						boxY3[3] -= 70;//increase the height of the circle
					}
				}
				else if (col == 4)
				{
					if (boxY3[4] != 50)//to mentain the circles inside the board
					{
						//draw the circle here
						g.FillEllipse(counterPlayerBrush, new Rectangle(boxX3[4], boxY3[4], 40, 40));
						boxY3[4] -= 70;//increase the height of the circle
					}
				}
			}
			IsMyTurn = true;
		}
	}
}
