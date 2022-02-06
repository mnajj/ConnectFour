using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace boradGui
{
    public partial class Form1 : Form
    {
        //Member data
        Pen blackPen;//pen for lines
        //for the numbers
        Font drawFont;
        SolidBrush drawBrush;
        //To draw the circles
        int box1X=210;
        int box2X=277;
        int box3X=344;
        int box4X=411;
        int box5X=478;
        int box6X=545;
        int box7X=612;
        int box1Y = 355;
        int box2Y = 355;
        int box3Y = 355;
        int box4Y = 355;
        int box5Y = 355;
        int box6Y = 355;
        int box7Y = 355;


        //game board
        int[][] board;
        int board1X = 0;
        int board2X = 0;
        int board3X = 0;
        int board4X = 0;
        int board5X = 0;
        int board6X = 0;
        int board7X = 0;



        //to switch between players
        bool switchPlayer=false;
        SolidBrush playerColor;



        public Form1()
        {
            InitializeComponent();
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



        public void checkWinner()
        {
            
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (j <= 3)//for the horizantal either left or right from this point
                    {
                       
                        //player 1
                        if (board[i][j] == 1 && board[i][j + 1] == 1 && board[i][j + 2] == 1 && board[i][j + 3] == 1)
                        {
                         
                            MessageBox.Show("player 1 Win by  vertical");
                        }

                        //player 2
                        else if (board[i][j] == 2 && board[i][j + 1] == 2 && board[i][j + 2] == 2 && board[i][j + 3] == 2)
                        {
                            MessageBox.Show("player 2 Win by  vertical");
                        }


                    }
                    if (i == 0 || i == 1 || i == 2)//verticalll
                    {
                        if (board[i][j] == 1 && board[i + 1][j] == 1 && board[i + 2][j] == 1 && board[i + 3][j] == 1)//vertical side player1
                        {
                            MessageBox.Show("player 1 Win by  horizantal");
                        }
                        else if (board[i][j] == 2 && board[i + 1][j] == 2 && board[i + 2][j] == 2 && board[i + 3][j] == 2)//vertical side player1
                        {
                            MessageBox.Show("player 2 Win by  horizantal");
                        }


                    }
                    else
                    {


                        // ascendingDiagonalCheck 
                        if (i >= 3 && j <= 3)//in the upper half of thee board
                        {
                            // Console.WriteLine($"i :{i} j:{j}   ");

                            //player 1
                            if (board[i][j] == 1 && board[i - 1][j + 1] == 1 && board[i - 2][j + 2] == 1 && board[i - 3][j + 3] == 1)//digonal asc  player1
                            {
                                MessageBox.Show("player 1 Win by  Asc digonal");
                            }
                            //player 2
                            else if (board[i][j] == 2 && board[i - 1][j + 1] == 2 && board[i - 2][j + 2] == 2 && board[i - 3][j + 3] == 2)//digonal asc  player2
                            {
                                MessageBox.Show("player 2 Win by  Asc digonal");
                            }

                        }

                        // descendingDiagonalCheck 
                        if (i >= 3 && j >= 3 && j < 7)//in the lower half of thee board
                        {

                            //player 1
                            if (board[i][j] == 1 && board[i - 1][j - 1] == 1 && board[i - 2][j - 2] == 1 && board[i - 3][j - 3] == 1)//digonal desc  player1
                            {
                                MessageBox.Show("player 1 Win by  Desc digonal");
                            }
                            //player 2
                            else if (board[i][j] == 2 && board[i - 1][j - 1] == 2 && board[i - 2][j - 2] == 2 && board[i - 3][j - 3] == 2)//digonal desc  player2
                            {
                                MessageBox.Show("player 2 Win by  Desc digonal");
                            }

                        }


                    }
                }

            }
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
            for(int i = 0; i < 7; i++)
            {
                g.DrawLine(blackPen, x1, y1+count, x2, y2+count);
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
                g.DrawLine(blackPen, x1 + count, y1 , x2 + count, y2 );
                count += 67;
            }
        }

        public void drawString()
        {
            Graphics g = CreateGraphics();
            int x= 175;
            int y = 100;

            int count = 0;
            for (int i=6;i>0;i--)//numbers on vertical
            {
                g.DrawString(i.ToString(), drawFont, drawBrush, x, y+ count);
                count += 55;
            }
            int count1 = 0;
            for (int i = 1; i < 8; i++)//numbers on horzinatal
            {
                count1 += 63;
                g.DrawString(i.ToString(), drawFont, drawBrush, x + count1, 415);
                
            }
        }

       


        private void Form1_Load(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)//for the event if i clicked 
        {
            Graphics g = CreateGraphics();

            //to swich between playersss

            if (switchPlayer==true)//player2
            {
                switchPlayer = false;
                playerColor = new SolidBrush(Color.Red);

            }
            else//player 1
            {
                switchPlayer = true;
                playerColor = new SolidBrush(Color.Black);
            }
           





            if (e.Location.Y >= 100 && e.Location.Y <= 402)//inside the y of the board
            {
                if (e.Location.X >= 200 && e.Location.X <= 267)//1
                {
                    //draw the circle here
                    g.FillEllipse(playerColor, new Rectangle(box1X, box1Y, 40, 40));
                    box1Y -= 50;

                    //Game logicccc
                    if(switchPlayer==true)
                    {
                        board[0][board1X] = 1;
                        board1X++;
                    }
                    else
                    {
                        board[0][board1X] = 2;
                        board1X++;
                    }

                    checkWinner();
                }
                else if (e.Location.X >= 267 && e.Location.X <= 334)//2
                {
                    g.FillEllipse(playerColor, new Rectangle(box2X, box2Y, 40, 40));
                    box2Y -= 50;

                    //Game logicccc
                    if (switchPlayer == true)
                    {
                        board[1][board2X] = 1;
                        board2X++;
                    }
                    else
                    {
                        board[1][board2X] = 2;
                        board2X++;
                    }

                    checkWinner();

                }
                else if (e.Location.X >= 334 && e.Location.X <= 401)//3
                {
                    g.FillEllipse(playerColor, new Rectangle(box3X, box3Y, 40, 40));
                    box3Y -= 50;

                    //Game logicccc
                    if (switchPlayer == true)
                    {
                        board[2][board3X] = 1;
                        board3X++;
                    }
                    else
                    {
                        board[2][board3X] = 2;
                        board3X++;
                    }

                    checkWinner();

                }
                else if (e.Location.X >= 401 && e.Location.X <= 468)//4
                {
                    g.FillEllipse(playerColor, new Rectangle(box4X, box4Y, 40, 40));
                    box4Y -= 50;

                    //Game logicccc
                    if (switchPlayer == true)
                    {
                        board[3][board4X] = 1;
                        board4X++;
                    }
                    else
                    {
                        board[3][board4X] = 2;
                        board4X++;
                    }

                    checkWinner();

                }
                else if (e.Location.X >= 468 && e.Location.X <= 535)//5
                {
                    g.FillEllipse(playerColor, new Rectangle(box5X, box5Y, 40, 40));
                    box5Y -= 50;

                    //Game logicccc
                    if (switchPlayer == true)
                    {
                        board[4][board5X] = 1;
                        board5X++;
                    }
                    else
                    {
                        board[4][board5X] = 2;
                        board5X++;
                    }

                    checkWinner();

                }
                else if (e.Location.X >= 535 && e.Location.X <= 602)//6
                {
                    g.FillEllipse(playerColor, new Rectangle(box6X, box6Y, 40, 40));
                    box6Y -= 50;

                    //Game logicccc
                    if (switchPlayer == true)
                    {
                        board[5][board6X] = 1;
                        board6X++;
                    }
                    else
                    {
                        board[5][board6X] = 2;
                        board6X++;
                    }

                    checkWinner();

                }
                else if (e.Location.X >= 602 && e.Location.X <= 669)//7
                {
                    g.FillEllipse(playerColor, new Rectangle(box7X, box7Y, 40, 40));
                    box7Y -= 50;

                    //Game logicccc
                    if (switchPlayer == true)
                    {
                        board[6][board7X] = 1;
                        board7X++;
                    }
                    else
                    {
                        board[6][board7X] = 2;
                        board7X++;
                    }

                    checkWinner();


                }
            }


        }
    }
    }

