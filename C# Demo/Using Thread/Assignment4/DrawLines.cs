/*
* FILE           : DrawLines.cs
*
* PROJECT        : PROG2120-1 - Assignment 04 
*
* PROGRAMMER     : Lingchen Meng (Walter)
*
* FIRST VERSION  : 2015-10-20
*
* DESCRIPTION    : this file is used to manage draw line class.
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment4
{
    class DrawLines
    {
        public static volatile bool Run = true; // using to kill the threads.
        public Color BackgroundColor { get; set; } // the background color.

        private Pen p = null; // the pen to draw the shape.
        private Pen backgroundPen = null; // use to erase the shape.

        public Graphics DrawLine_Graphics; // Painter Canvas.

        public int start_x, start_y; // start point x and y.
        public int end_x, end_y; // end point x and y.

        public int reStart_x, reStart_y; // using to erase the line in canvas.
        public int reEnd_x, reEnd_y; // using to erase the line in canvas.

        public int angle_Line = 0; // the angle of line.
        public int length_line = 0; // the length of line.
        public int Increment = 0; // how length need to increment.
        public int how_Many_Lines = 0; // how many lines.

        public int newAngle = 0; // temporary to store the orginal angle of line.
        public int newLength = 0; // temporaty to store the orginal length of line.

        /// <summary>
        /// the Method is a constructor.
        /// </summary>
        /// <param name="g"> Orginal Canvs</param>
        /// <param name="bgColor"> Backgroung Color</param>
        public DrawLines(Graphics g, Color bgColor)
        {
            // initiate values.
            DrawLine_Graphics = g;
            p = new Pen(Color.Black);
            backgroundPen = new Pen(bgColor);
        }

        /// <summary>
        /// this Method is used to draw lines.
        /// </summary>
        private void DesignLine()
        {
            // get new length of line.
            length_line = newLength;

            // how many lines need to draw.
            for (int i = 0; i < how_Many_Lines; i++)
            {
                // if shut down button is pressed.
                if (!Run) break;

                // get random Color for lines.
                Random randomColor = new Random();
                p.Color = Color.FromArgb(randomColor.Next(255), randomColor.Next(255), randomColor.Next(255));

                // angle of next line.
                angle_Line = angle_Line + newAngle;
                // increase length of line.
                length_line += Increment;

                // calculate next point for end of Point.
                end_x = (int)(start_x + Math.Cos(angle_Line * .2) * length_line);
                end_y = (int)(start_y + Math.Sin(angle_Line * .2) * length_line);

                // collect points.
                Point[] start_End = {
                                        new Point(start_x, start_y),
                                        new Point(end_x, end_y)
                                    };

                // set end point to start point.
                start_x = end_x;
                start_y = end_y;

                // draw line.
                DrawLine_Graphics.DrawLines(p, start_End);
                // sleep 70 ms.
                Thread.Sleep(70);

            }
        }

        /// <summary>
        /// this Method is used to erase the orgianl line.
        /// </summary>
        private void ReDesignLine()
        {
            // reset angle of line.
            angle_Line = 0;
            // set new length of line.
            length_line = newLength;

            // // how many lines need to erase.
            for (int i = 0; i < how_Many_Lines; i++)
            {
                // when user press shut down button.
                if (!Run) break;

                // set angle of line.
                angle_Line = angle_Line + newAngle;
                length_line += Increment;

                // calculate next point for end of Point. .014159265358
                reEnd_x = (int)(reStart_x + Math.Cos(angle_Line * .2) * length_line);
                reEnd_y = (int)(reStart_y + Math.Sin(angle_Line * .2) * length_line);

                Point[] start_End = {
                                        new Point(reStart_x, reStart_y),
                                        new Point(reEnd_x, reEnd_y)
                                    };

                // collect points.
                reStart_x = reEnd_x;
                reStart_y = reEnd_y;

                // using background Color to redraw the line.
                DrawLine_Graphics.DrawLines(backgroundPen, start_End);
                // sleep 50 ms
                Thread.Sleep(50);             
            }
           
        }

        /// <summary>
        /// this Method is used to call DesignLine() and ReDesignLine().
        /// </summary>
        public void Running()
        {
            if (Run)
            {
                DesignLine();

                ReDesignLine(); 
            }
          
        }
    }
}
