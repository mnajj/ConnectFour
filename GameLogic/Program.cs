using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalProject1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[][] board = new int[6][];
            board[0] = new int[7] { 2, 0, 0, 0, 0, 0, 0 };
            board[1] = new int[7] { 0, 2, 0, 0, 0, 0, 0 };
            board[2] = new int[7] { 0, 0, 2, 0, 0, 0, 0 };
            board[3] = new int[7] { 0, 0, 0, 2, 0, 0, 0 };
            board[4] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };
            board[5] = new int[7] { 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < 6; i++)
            {
                for(int j = 0; j < 7; j++)
                {
                    if(j==3)//for the horizantal either left or right from this point
                    {
                        //player 1
                        if (board[i][j] == 1 && board[i][j+1] == 1 && board[i][j+2] == 1 && board[i][j+3] == 1)//right side player1
                        {
                            Console.WriteLine("player 1 Win by right horizantal");
                        }
                        else if (board[i][j] == 1 && board[i][j-1] == 1 && board[i][j-2] == 1 && board[i][j-3] == 1)//left side player1
                        {
                            Console.WriteLine("player 1 Win by left horizantal");
                        }

                        else //player 2
                        {
                            if (board[i][j] == 2 && board[i][j + 1] == 2 && board[i][j + 2] == 2 && board[i][j + 3] == 2)//right side player2
                            {
                                Console.WriteLine("player 2 Win by right horizantal");
                            }
                            else if (board[i][j] == 2 && board[i][j - 1] == 2 && board[i][j - 2] == 2 && board[i][j - 3] == 2)//left side player2
                            {
                                Console.WriteLine("player 2 Win by left horizantal");
                            }
                        }

                    }    
                          if(i==0 ||i==1 ||i==2)//verticalll
                    {
                        if (board[i][j] == 1 && board[i+1][j] == 1 && board[i+2][j] == 1 && board[i+3][j] == 1)//vertical side player1
                        {
                            Console.WriteLine("player 1 Win by  vetical");
                        }
                        else if (board[i][j] == 2 && board[i + 1][j] == 2 && board[i + 2][j] == 2 && board[i + 3][j] == 2)//vertical side player1
                        {
                            Console.WriteLine("player 2 Win by  vetical");
                        }


                    }
                    else
                    {
                       

                        // ascendingDiagonalCheck 
                       if(i>=3 && j<=3)//in the upper half of thee board
                        {
                            // Console.WriteLine($"i :{i} j:{j}   ");

                            //player 1
                            if (board[i][j] == 1 && board[i -1][j+1] == 1 && board[i - 2][j+2] == 1 && board[i - 3][j+3] == 1)//digonal asc  player1
                            {
                                Console.WriteLine("player 1 Win by  Asc digonal");
                            }
                            //player 2
                            else if (board[i][j] == 2 && board[i - 1][j + 1] == 2 && board[i - 2][j + 2] == 2 && board[i - 3][j + 3] == 2)//digonal asc  player2
                            {
                                Console.WriteLine("player 2 Win by  Asc digonal");
                            }

                        }

                        // descendingDiagonalCheck 
                         if (i == 3 && j >=3 &&j<7)//in the lower half of thee board
                        {
                           //  Console.WriteLine($"i :{i} j:{j}   ");

                            //player 1
                            if (board[i][j] == 1 && board[i - 1][j - 1] == 1 && board[i - 2][j - 2] == 1 && board[i - 3][j - 3] == 1)//digonal desc  player1
                            {
                                Console.WriteLine("player 1 Win by  Desc digonal");
                            }
                            //player 2
                            else if (board[i][j] == 2 && board[i - 1][j - 1] == 2 && board[i - 2][j - 2] == 2 && board[i - 3][j - 3] == 2)//digonal desc  player2
                            {
                                Console.WriteLine("player 2 Win by  Desc digonal");
                            }

                        }


                    }
                    }
                   
                }
            }    
        }
    }

