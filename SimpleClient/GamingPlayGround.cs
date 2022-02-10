using System.Drawing;
using System.Windows.Forms;

namespace SimpleClient
{
	public partial class GamingPlayGround : Form
	{
		WaitingRoom waitingRoom;
		public bool IsSpectator { get; set; }
		public bool IsMyTurn { get; set; }

    //Member data
    Pen blackPen;//pen for lines
    //for the numbers
    Font drawFont;
    SolidBrush drawBrush;
    //To draw the circles
    int box1X = 210;
    int box2X = 277;
    int box3X = 344;
    int box4X = 411;
    int box5X = 478;
    int box6X = 545;
    int box7X = 612;
    int box1Y = 355;
    int box2Y = 355;
    int box3Y = 355;
    int box4Y = 355;
    int box5Y = 355;
    int box6Y = 355;
    int box7Y = 355;

    //game board
    int[][] board;
    int board1X = 5;
    int board2X = 5;
    int board3X = 5;
    int board4X = 5;
    int board5X = 5;
    int board6X = 5;
    int board7X = 5;

    //to switch between players
    bool switchPlayer = false;
    SolidBrush playerColor;

    public GamingPlayGround(WaitingRoom waitingRoom, bool isSpec = false)
		{
			InitializeComponent();
			this.waitingRoom = waitingRoom;
			this.IsSpectator = isSpec;
			if (isSpec) IsMyTurn = false;

      ///
      blackPen = new Pen(Color.Black, 1);
      //for the numbers
      drawFont = new Font("Arial", 12);
      drawBrush = new SolidBrush(Color.Black);
      board = new int[6][];
      board[0] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
      board[1] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
      board[2] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
      board[3] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
      board[4] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
      board[5] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
    }

		protected override void OnPaint(PaintEventArgs e)
		{
			horzLine();//horz lines of board
			vertLine();//vert lines of board
			drawString();//numbers
		}
    public void horzLine()//horzinatal line
    {
      Graphics g = CreateGraphics();
      int x1 = 200;
      int y1 = 100;
      int x2 = 667;
      int y2 = 100;
      int count = 0;//to increment the lines 
      for (int i = 0; i < 7; i++)
      {
        g.DrawLine(blackPen, x1, y1 + count, x2, y2 + count);
        count += 50;
      }
    }
    public void vertLine()//vertical lines
    {
      Graphics g = CreateGraphics();
      int x1 = 200;
      int y1 = 100;
      int x2 = 200;
      int y2 = 400;
      int count = 0;//to increment the lines 
      for (int i = 0; i < 8; i++)
      {
        g.DrawLine(blackPen, x1 + count, y1, x2 + count, y2);
        count += 67;
      }
    }

    public void drawString()
    {
      Graphics g = CreateGraphics();
      int x = 175;
      int y = 100;
      int count = 0;
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
  }
}
