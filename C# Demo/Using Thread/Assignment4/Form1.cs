/*
* FILE           : Mystify.cs
*
* PROJECT        : PROG2120-1 - Assignment 04 
*
* PROGRAMMER     : Lingchen Meng (Walter)
*
* FIRST VERSION  : 2015-10-20
*
* DESCRIPTION    : Examine the behavior of the Windows screen saver called Mystify.
*                  You will be implementing a simplified version of the graohic effect,
*                  using only straight lines instead of curves.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment4
{
    public partial class Mystify : Form
    {
        static int partName = 0; // part of thread name.
        ThreadRepo tRepo = new ThreadRepo(); // the container of thread.
        Bitmap bmp; // bitmap used to draw thing.
        System.Threading.Timer tmr; // timer

        public Mystify()
        {
            InitializeComponent();

            // initiate the bitmap and timer.
            bmp = new Bitmap(Painter.Width, Painter.Height);
            tmr = new System.Threading.Timer(new System.Threading.TimerCallback(timer_tick));
            tmr.Change(1,1);

            PauseButt.Enabled = false;
            ResumeButt.Enabled = false;
            restart.Enabled = false;
        }

        private void Mystify_Load(object sender, EventArgs e)
        {
            // set double buffer.
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();
        }

        private void Paint_Paint(object sender, PaintEventArgs e)
        {
            // redraw the Graphics.
            e.Graphics.DrawImage(bmp, 0, 0);           
        }

        /// <summary>
        /// this function is used to call when evey one secound.
        /// </summary>
        /// <param name="state"></param>
        private void timer_tick(object state)
        {
            Painter.Invalidate();
        }

        private void Paint_MouseDown(object sender, MouseEventArgs e)
        {
            // if user left click mouse.
            if (e.Button == MouseButtons.Left)
            {
                // draw line.
                DrawWiththThread(e);
                PauseButt.Enabled = true;
            }
        }

        private void DrawWiththThread(MouseEventArgs eArgs)
        {
            // random class.
            Random r = new Random();
            // instance of drawLines class.
            DrawLines d = new DrawLines(Graphics.FromImage(bmp), Painter.BackColor);

            // set random number to each fields.
            d.newAngle = 110;
            d.newLength = r.Next(5, 10);
            d.Increment = r.Next(1, 5);
            d.how_Many_Lines = r.Next(100, 150);

            // get start point.
            d.start_x= eArgs.X;
            d.start_y = eArgs.Y;
            d.reStart_x = eArgs.X;
            d.reStart_y = eArgs.Y;

            // inset new thread into container.
            tRepo.Add("T" + partName.ToString(), new ThreadStart(d.Running));
            // increase the partName.
            partName++;
        }

        private void PauseButt_Click(object sender, EventArgs e)
        {
            // call pauseAll() to pause all threads.
            tRepo.PauseAll();

            // set resume button to enabled
            ResumeButt.Enabled = true;
            // kill thread.
            DrawLines.Run = false;
        }

        private void ResumeButt_Click(object sender, EventArgs e)
        {
            // call Resume() to restart all threads.
            tRepo.Resume();
            // kill thread.
            DrawLines.Run = true;
            // set resume button to disenabled.
            ResumeButt.Enabled = false;
        }

        private void Shut_DownButt_Click(object sender, EventArgs e)
        {
            // set Run falg to false.
            DrawLines.Run = false;
            // Kill all threads.
            tRepo.KillAll();

            // reset canvas to orginal form.
            Bitmap newpic = new Bitmap(Painter.Width, Painter.Height);
            Graphics g = Graphics.FromImage(newpic);
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, Painter.Width, Painter.Height);
            g.Dispose();
            g = Painter.CreateGraphics();
            g.DrawImage(newpic,0,0);
            g.Dispose();
            bmp = newpic;

            // set three button.
            PauseButt.Enabled = false;
            ResumeButt.Enabled = false;
            restart.Enabled = true;
        }

        private void restart_Click(object sender, EventArgs e)
        {
            // set Run falg to true.
            DrawLines.Run = true;
            // kill all threads.
            tRepo.KillAll();
            restart.Enabled = false;
        }
    }
}
