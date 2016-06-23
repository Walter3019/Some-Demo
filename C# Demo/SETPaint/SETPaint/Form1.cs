/*
* FILE           : Form1.cs
*
* PROJECT        : PROG2120-1 - Assignment 03 GDI
*
* PROGRAMMER     : Lingchen Meng (Walter) / Xun Zhang
*
* FIRST VERSION  : 2015-10-06
*
* DESCRIPTION    : This file include all Events in this program.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.Threading;

namespace SETPaint
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private DrawTools dt; // Draw Tools
        private string choise; // which shape.
        private string sFileName; // open file name.
        //private bool resetSize = false; // if reset size of Graphic
        private Size defaultPicSize; // save , and creat new file;


        /*
         * Function : Painter_MouseDown()
         * Description : this function is called when user click the mouse and do not leave the key.
         * Parameters : sender, is the control that the action is for MouseDown.
         *              e, is the mouse event argument.
         * Return : Nothing.
         */
        private void Painter_MouseDown(object sender, MouseEventArgs e)
        {
            // if user left click mouse.
            if (e.Button == MouseButtons.Left)
            {
                // if draw tool object is instance.
                if (dt != null)
                {
                    mousePostionInfo.Text = e.Location.ToString();
                    // set should Draw to true.
                    dt.ShouldDraw = true;
                    // get start point.
                    dt.startPointF = new PointF(e.X, e.Y);
                }
            }
        }

        /*
         * Function : Painter_MouseMove()
         * Description : this function is called when user move the mouse and do not leave the key.
         * Parameters : sender, is the control that the action is for MouseMove.
         *              e, is the mouse event argument.
         * Return : Nothing.
         */
        private void Painter_MouseMove(object sender, MouseEventArgs e)
        {
            // let system get some sleep, and reduce system bear.
            Thread.Sleep(6);

            // if should draw is true.
            if (dt.ShouldDraw)
            {
                // show mouse position in status bar.
                mousePostionInfo.Text = e.Location.ToString();

                // get user choise about which type of shape or pen.
                switch (choise)
                {
                    case "Dot": dt.DrawDot(e); break;
                    case "Eraser": dt.Eraser(e); break;
                    default: dt.Draw(e, choise); break;
                }
            }
        }

        /*
         * Function : Painter_MouseUp()
         * Description : this function is called when user release the mouse.
         * Parameters : sender, is the control that the action is for MouseUp.
         *              e, is the mouse event argument.
         * Return : Nothing.
         */
        private void Painter_MouseUp(object sender, MouseEventArgs e)
        {
            // if drawTool is instance.
            if(dt != null)
            {
                // clear Mouse Location Message.
                mousePostionInfo.Text = "";
                // call EndDraw 
                dt.EndDraw();
                Painter.Invalidate();
            }
        }

        /*
         * Function : MainForm_Load()
         * Description : this function is called when system load main window, and initiate main window.
         * Parameters : sender, is the control that the action is for Load.
         *              e, is the event argument.
         * Return : Nothing.
         */
        private void MainForm_Load(object sender, EventArgs e)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);
            this.UpdateStyles();

            // 
            Bitmap bmp = new Bitmap(Painter.Width, Painter.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.FillRectangle(new SolidBrush(Painter.BackColor), new Rectangle(0, 0, Painter.Width, Painter.Height));
            g.Dispose();

            // instance drawTool, and initiate the drawTool.
            dt = new DrawTools(this.Painter.CreateGraphics(), Color.Black, bmp);//实例化工具类
            defaultPicSize = Painter.Size;
        }

        /*
         * Function : Painter_Paint()
         * Description : this function is called when
         * Parameters : sender, is the control that the action is for Paint.
         *              e, is the Paint event argument.
         * Return : Nothing.
         */
        private void Painter_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(dt.OrginalImg, 0, 0);
            // g.Dispose(); can not use this method because Graphics is argument of system, and it is not created by yourself. if you use it, it will wrong.
        }

        /*
         * Function : Painter_Paint()
         * Description : this function is called when user choose one of shape in draw tool.
         * Parameters : sender, is the control that the action is for Click.
         *              e, is the event argument.
         * Return : Nothing.
         */
        private void tool_Click(object sender, EventArgs e)
        {
            // get sender.
            ToolStripButton tsb = sender  as ToolStripButton;

            // if sender is not null.
            if (tsb != null)
            {
                // get which choise when user click tool bar.
                choise = tsb.Name;
                currentDrawType.Text = tsb.Text;

                // if choise is Eraser.
                if (choise == "Eraser")
                {
                    // set new cursor type to current cursor from img file.
                    Painter.Cursor = new Cursor(Application.StartupPath + @"\img\pb.cur");
                }
                else // otherwise.
                {
                    // set cross cursor type
                    Painter.Cursor = Cursors.Cross;
                }
            }
        }

        /*
         * Function : ColorBtn_Click()
         * Description : this function is called when user choose one of color from choose color button.
         * Parameters : sender, is the control that the action is for Click.
         *              e, is the event argument.
         * Return : Nothing.
         */
        private void ColorBtn_Click(object sender, EventArgs e)
        {
            // instance color dialog.
            ColorDialog cDialog = new ColorDialog();
            // set current color to color dialog.
            cDialog.Color = dt.DrawColor;
            // get result of user choose.
            DialogResult result = cDialog.ShowDialog();
            // if user press ok.
            if (result == DialogResult.OK)
            {
                // set color in color dialog to pen.
                dt.DrawColor = cDialog.Color;
                // reset current color to new one.
                currentDrawType.Text = cDialog.Color.ToString();
            }
        }

        /*
         * Function : openPic_Click()
         * Description : this function is called when user click file menu and choose open menu.
         * Parameters : sender, is the control that the action is for Click.
         *              e, is the event argument.
         * Return : Nothing.
         */
        private void openPic_Click(object sender, EventArgs e)
        {
            // instance open file dialog.
            OpenFileDialog ofd = new OpenFileDialog();
            // set can open file extension.
            ofd.Filter = "JPG|*.jpg|Bmp|*.bmp|All Files|*.*";
            // when user click ok 
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                // get open file.
                Bitmap bmpformfile = new Bitmap(ofd.FileName);
                // reset rollbar.
                panel2.AutoScrollPosition = new Point(0, 0);
                // reset size of canvas for size of Image.
                Painter.Size = bmpformfile.Size;

                // reSize.Location = new Point(bmpformfile.Width, bmpformfile.Height);//reSize为我用来实现手动调节画布大小用的
                // bacuase we orginal size of canvas is limited, so the canvas have to reset size. therefore recall createGraphics. 
                dt.DrawTools_Graphics = Painter.CreateGraphics();

                Bitmap bmp = new Bitmap(Painter.Width, Painter.Height);
                Graphics g = Graphics.FromImage(bmp);
                // if we do not use FillRectangle method, the bmp is lucency. 
                g.FillRectangle(new SolidBrush(Painter.BackColor), new Rectangle(0, 0, Painter.Width, Painter.Height));
                // draw Image file put on canvas.
                g.DrawImage(bmpformfile, 0, 0, bmpformfile.Width, bmpformfile.Height);
                // dispose resource.
                g.Dispose();
                // http://www.wanxin.org/redirect.php?tid=3&goto=lastpost
                // dispose open file resource.
                bmpformfile.Dispose();
                g = Painter.CreateGraphics();
                g.DrawImage(bmp, 0, 0);
                g.Dispose();
                dt.OrginalImg = bmp;
                bmp.Dispose();
                // save path of open file.
                sFileName = ofd.FileName;
                ofd.Dispose();
            }
        }

        /*
         * Function : savePic_Click()
         * Description : this function is called when user click file menu and choose save menu.
         * Parameters : sender, is the control that the action is for Click.
         *              e, is the event argument.
         * Return : Nothing.
         */
        private void savePic_Click(object sender, EventArgs e)
        {
            // if save file does not have name.
            if (sFileName != null)
            {
                if(MessageBox.Show("Do you want to save Picture?", "System Message", MessageBoxButtons.YesNo) == DialogResult.OK)
                {
                    dt.OrginalImg.Save(sFileName);
                }
            }
            else // otherwise
            {
                // instance save file dialog.
                SaveFileDialog sfd = new SaveFileDialog();
                // can save file extension.
                sfd.Filter = "JPG(*.jpg)|*.jpg|BMP(*.bmp)|*.bmp";
                // if user click OK.
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    dt.OrginalImg.Save(sfd.FileName);
                    sFileName = sfd.FileName;
                }
            }
        }

        /*
         * Function : clearPic_Click()
         * Description : this function is called when user click tool menu and choose clear menu.
         * Parameters : sender, is the control that the action is for Click.
         *              e, is the event argument.
         * Return : Nothing.
         */
        private void clearPic_Click(object sender, EventArgs e)
        {

            DialogResult confirm = MessageBox.Show("Do You want to clear all ?","Message", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                Bitmap newpic = new Bitmap(Painter.Width, Painter.Height);
                Graphics g = Graphics.FromImage(newpic);
                g.FillRectangle(new SolidBrush(Color.White), 0, 0, Painter.Width, Painter.Height);
                g.Dispose();
                g = Painter.CreateGraphics();
                g.DrawImage(newpic, 0, 0);
                g.Dispose();
                dt.OrginalImg = newpic;
            }
        }

        /// <summary>
        /// This function is used to quit this program.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Quit_Click(object sender, EventArgs e)
        {
            dt.ClearVar();
            Application.Exit();
        }

        /// <summary>
        /// this fnuction is used to change width of pen to thin.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PenThin_CheckedChanged(object sender, EventArgs e)
        {
            dt.Width = 1;
            Painter.Invalidate();
        }

        /// <summary>
        /// this fnuction is used to change width of pen to Medium.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PenMedium_CheckedChanged(object sender, EventArgs e)
        {
            dt.Width = 5;
            Painter.Invalidate();
        }

        /// <summary>
        /// this fnuction is used to change width of pen to thick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PenThick_CheckedChanged(object sender, EventArgs e)
        {
            dt.Width = 10;
            Painter.Invalidate();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ProgramAbout company = new ProgramAbout();
            company.Show();
        }
    }

}
