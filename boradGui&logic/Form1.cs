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

        public void clearArray()//reset all data
        {
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    board[i][j] = 0;
                }
            }
             box1X = 210;
             box2X = 277;
             box3X = 344;
             box4X = 411;
             box5X = 478;
             box6X = 545;
             box7X = 612;
             box1Y = 355;
             box2Y = 355;
             box3Y = 355;
             box4Y = 355;
             box5Y = 355;
             box6Y = 355;
             box7Y = 355;


            //game board
          
             board1X = 5;
             board2X = 5;
             board3X = 5;
             board4X = 5;
             board5X = 5;
             board6X = 5;
             board7X = 5;
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
                         
                            MessageBox.Show("player 1 Win by  horizantal");
                            Invalidate();//to reload the game
                            clearArray();
                        }

                        //player 2
                        else if (board[i][j] == 2 && board[i][j + 1] == 2 && board[i][j + 2] == 2 && board[i][j + 3] == 2)
                        {
                            MessageBox.Show("player 2 Win by  horizantal");
                            Invalidate();
                            clearArray();
                        }


                    }
                    if (i == 0 || i == 1 || i == 2)//verticalll
                    {
                        if (board[i][j] == 1 && board[i + 1][j] == 1 && board[i + 2][j] == 1 && board[i + 3][j] == 1)//vertical side player1
                        {
                            MessageBox.Show("player 1 Win by  vertical");
                            Invalidate();
                            clearArray();
                        }
                        else if (board[i][j] == 2 && board[i + 1][j] == 2 && board[i + 2][j] == 2 && board[i + 3][j] == 2)//vertical side player1
                        {
                            MessageBox.Show("player 2 Win by  vertical");
                            Invalidate();
                            clearArray();
                        }


                    }
                    else
                    {


                        // ascendingDiagonalCheck 
                        if (i >= 3 && j <= 3)//in the upper half of thee board
                        {
                           

                            //player 1
                            if (board[i][j] == 1 && board[i - 1][j + 1] == 1 && board[i - 2][j + 2] == 1 && board[i - 3][j + 3] == 1)//digonal asc  player1
                            {
                                MessageBox.Show("player 1 Win by  Asc digonal");
                                Invalidate();
                                clearArray();
                            }
                            //player 2
                            else if (board[i][j] == 2 && board[i - 1][j + 1] == 2 && board[i - 2][j + 2] == 2 && board[i - 3][j + 3] == 2)//digonal asc  player2
                            {
                                MessageBox.Show("player 2 Win by  Asc digonal");
                                Invalidate();
                                clearArray();
                            }

                        }

                        // descendingDiagonalCheck 
                        if (i >= 3 && j >= 3 && j < 7)//in the lower half of thee board
                        {

                            //player 1
                            if (board[i][j] == 1 && board[i - 1][j - 1] == 1 && board[i - 2][j - 2] == 1 && board[i - 3][j - 3] == 1)//digonal desc  player1
                            {
                                MessageBox.Show("player 1 Win by  Desc digonal");
                                Invalidate();
                                clearArray();
                            }
                            //player 2
                            else if (board[i][j] == 2 && board[i - 1][j - 1] == 2 && board[i - 2][j - 2] == 2 && board[i - 3][j - 3] == 2)//digonal desc  player2
                            {
                                MessageBox.Show("player 2 Win by  Desc digonal");
                                Invalidate();
                                clearArray();
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
                playerColor = new SolidBrush(Color.Red);//change the color

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

                    if(box1Y!=55)//to mentain the circles inside the board
                    {
                        //draw the circle here
                        g.FillEllipse(playerColor, new Rectangle(box1X, box1Y, 40, 40));

                        box1Y -= 50;//increase the height of the circle

                        //Game logicccc
                        if (switchPlayer == true)
                        {
                            board[board1X][0] = 1;
                            board1X--;
                        }
                        else
                        {
                            board[board1X][0] = 2;
                            board1X--;
                        }

                        checkWinner();
                    }
                    
                }
                else if (e.Location.X >= 267 && e.Location.X <= 334)//2
                {
                    if (box2Y != 55)
                    {
                        g.FillEllipse(playerColor, new Rectangle(box2X, box2Y, 40, 40));
                        box2Y -= 50;

                        //Game logicccc
                        if (switchPlayer == true)
                        {
                            board[board2X][1] = 1;
                            board2X--;
                        }
                        else
                        {
                            board[board2X][1] = 2;
                            board2X--;
                        }

                        checkWinner();
                    }
                      

                }
                else if (e.Location.X >= 334 && e.Location.X <= 401)//3
                {
                    if (box3Y != 55)
                    {
                        g.FillEllipse(playerColor, new Rectangle(box3X, box3Y, 40, 40));
                        box3Y -= 50;

                        //Game logicccc
                        if (switchPlayer == true)
                        {
                            board[board3X][2] = 1;
                            board3X--;
                        }
                        else
                        {
                            board[board3X][2] = 2;
                            board3X--;
                        }

                        checkWinner();
                    }
                       

                }
                else if (e.Location.X >= 401 && e.Location.X <= 468)//4
                {
                    if (box4Y != 55)
                    {
                        g.FillEllipse(playerColor, new Rectangle(box4X, box4Y, 40, 40));
                        box4Y -= 50;

                        //Game logicccc
                        if (switchPlayer == true)
                        {
                            board[board4X][3] = 1;
                            board4X--;
                        }
                        else
                        {
                            board[board4X][3] = 2;
                            board4X--;
                        }

                        checkWinner();
                    }
                       

                }
                else if (e.Location.X >= 468 && e.Location.X <= 535)//5
                {
                    if (box5Y != 55)
                    {
                        g.FillEllipse(playerColor, new Rectangle(box5X, box5Y, 40, 40));
                        box5Y -= 50;

                        //Game logicccc
                        if (switchPlayer == true)
                        {
                            board[board5X][4] = 1;
                            board5X--;
                        }
                        else
                        {
                            board[board5X][4] = 2;
                            board5X--;
                        }

                        checkWinner();
                    }
                     

                }
                else if (e.Location.X >= 535 && e.Location.X <= 602)//6
                {
                    if (box6Y != 55)
                    {
                        g.FillEllipse(playerColor, new Rectangle(box6X, box6Y, 40, 40));
                        box6Y -= 50;

                        //Game logicccc
                        if (switchPlayer == true)
                        {
                            board[board6X][5] = 1;
                            board6X--;
                        }
                        else
                        {
                            board[board6X][5] = 2;
                            board6X--;
                        }

                        checkWinner();
                    }


                }
                else if (e.Location.X >= 602 && e.Location.X <= 669)//7
                {
                    if (box7Y != 55)
                    {
                        g.FillEllipse(playerColor, new Rectangle(box7X, box7Y, 40, 40));

                        box7Y -= 50;

                        //Game logicccc
                        if (switchPlayer == true)
                        {
                            board[board7X][6] = 1;
                            board7X--;
                        }
                        else
                        {
                            board[board7X][6] = 2;
                            board7X--;
                        }

                        checkWinner();
                    }
                     


                }
            }


        }
    }
    }

