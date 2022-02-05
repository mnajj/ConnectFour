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

        public Form1()
        {
            InitializeComponent();
            blackPen = new Pen(Color.Black, 1);
            //for the numbers
             drawFont = new Font("Arial", 12);
             drawBrush = new SolidBrush(Color.Black);
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
           

            if (e.Location.Y >= 100 && e.Location.Y <= 402)//inside the y of the board
            {
                if (e.Location.X >= 200 && e.Location.X <= 267)//1
                {
                    //draw the circle here
                    g.FillEllipse(drawBrush, new Rectangle(box1X, box1Y, 40, 40));
                    box1Y -= 50;
                }
                else if (e.Location.X >= 267 && e.Location.X <= 334)//2
                {
                    g.FillEllipse(drawBrush, new Rectangle(box2X, box2Y, 40, 40));
                    box2Y -= 50;

                }
                else if (e.Location.X >= 334 && e.Location.X <= 401)//3
                {
                    g.FillEllipse(drawBrush, new Rectangle(box3X, box3Y, 40, 40));
                    box3Y -= 50;

                }
                else if (e.Location.X >= 401 && e.Location.X <= 468)//4
                {
                    g.FillEllipse(drawBrush, new Rectangle(box4X, box4Y, 40, 40));
                    box4Y -= 50;

                }
                else if (e.Location.X >= 468 && e.Location.X <= 535)//5
                {
                    g.FillEllipse(drawBrush, new Rectangle(box5X, box5Y, 40, 40));
                    box5Y -= 50;

                }
                else if (e.Location.X >= 535 && e.Location.X <= 602)//6
                {
                    g.FillEllipse(drawBrush, new Rectangle(box6X, box6Y, 40, 40));
                    box6Y -= 50;

                }
                else if (e.Location.X >= 602 && e.Location.X <= 669)//7
                {
                    g.FillEllipse(drawBrush, new Rectangle(box7X, box7Y, 40, 40));
                    box7Y -= 50;


                }
            }


        }
    }
    }

