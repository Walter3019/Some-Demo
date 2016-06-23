/*
* FILE           : DrawTools.cs
*
* PROJECT        : PROG2120-1 - Assignment 03
*
* PROGRAMMER     : Lingchen Meng (Walter) / Xun Zhang
*
* FIRST VERSION  : 2015-09-23
*
* DESCRIPTION    : Drawing something on a screen is a very popular application for any device. The primitive operations
*                  include drawing lines and shapes (like an oval or rectangle) and being able to fill them in with a 
*                  specific colour or pattern. A mouse, styles or finger(on a touch screen) is used to do the drawing.
*/

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SETPaint
{
    class DrawTools
    {
        public Graphics DrawTools_Graphics; // Target draw canvas.
        private Graphics newgraphics; // Temporary draw canvas.
        private Graphics tempGraphics; // temporary draw canvas.
        private Image orginalImg; // orginal Image.
        private Image finishingImg; //Finishing Image, and use to save Temporary Image.
        private Image tempImg; // temparory Image, and use to save dash painting.
        private Pen dashPen; // using ro draw things.
        private Pen solidPen; // solid Pen.
        private int width; // width of pen.
        private Color drawColor = Color.Black; // color of pen.
        public bool ShouldDraw = false; // Whether should draw on canvas.
        public PointF startPointF; // start point of mouse.

        /// <summary>
        /// pen color
        /// </summary>
        public Color DrawColor
        {
            get { return drawColor; }
            set
            {
                drawColor = value;
                dashPen.Color = value;
                solidPen.Color = value;
            }
        }

        /// <summary>
        /// pen width
        /// </summary>
        public int Width
        {
            get { return width; }
            set 
            { 
                width = value;
                dashPen.Width = width;
                solidPen.Width = width;
            }
        }

        /// <summary>
        /// Orginal Image.
        /// </summary>
        public Image OrginalImg
        {
            get { return orginalImg; }
            set
            {
                tempImg = (Image)value.Clone();
                orginalImg = (Image)value.Clone();
            }
        }



        /// <summary>
        /// Constuctor to initiate DrawTool object.
        /// </summary>
        /// <param name="g">Canvas</param>
        /// <param name="c">Color of Pen</param>
        /// <param name="img">initial Image</param>
        public DrawTools(Graphics g, Color c, Image img)
        {
            DrawTools_Graphics = g; // get tartget canvas.
            drawColor = c; // get color of pen.
            dashPen = new Pen(c, 1); // instance a Pen Object.
            solidPen = new Pen(c, 1);
            finishingImg = (Image)img.Clone(); // copy Image to finishing Image.
            orginalImg = (Image)img.Clone(); // copy Image to orginal Image.
            tempImg = (Image)img.Clone();
        }

        /// <summary>
        /// This Function is used to draw different of shapes.
        /// </summary>
        /// <param name="e"> Mouse Event Arguments.</param>
        /// <param name="sType"> which type of shape.</param>
        public void Draw(MouseEventArgs e, string sType)
        {
            Image img = (Image)orginalImg.Clone(); // copy orginal Image to temporary Image.
            Image img1 = (Image)orginalImg.Clone();
            newgraphics = Graphics.FromImage(img); // put temporary Image into temporary canvas.
            tempGraphics = Graphics.FromImage(img1);
            dashPen.DashStyle = DashStyle.Dash;

            // which type.
            switch (sType)
            {
                case "Line":
                    {
                        // draw Line from e.X to e.Y
                        newgraphics.DrawLine(dashPen, startPointF, new PointF(e.X, e.Y));
                        tempGraphics.DrawLine(solidPen, startPointF, new PointF(e.X, e.Y));
                    }
                    break;
                case "Ellipse":
                    {
                        // drwa a ellipse from startPointF and width and height.
                        newgraphics.DrawRectangle(dashPen, startPointF.X, startPointF.Y, e.X - startPointF.X, e.Y - startPointF.Y);
                        tempGraphics.DrawEllipse(solidPen, startPointF.X, startPointF.Y, e.X - startPointF.X, e.Y - startPointF.Y);
                    }
                    break;
                case "Rectangle":
                    {
                        // calculate absolute width and height.
                        float width = Math.Abs(e.X - startPointF.X);
                        float height = Math.Abs(e.Y - startPointF.Y);

                        PointF rectStartPointF = startPointF;

                        // if convert rectangle.
                        if (e.X < startPointF.X)
                        {
                            rectStartPointF.X = e.X;
                        }
                        if (e.Y < startPointF.Y)
                        {
                            rectStartPointF.Y = e.Y;
                        }

                        // dashPen.DashStyle = DashStyle.Dash;

                        // draw rectangle.
                        newgraphics.DrawRectangle(dashPen, rectStartPointF.X, rectStartPointF.Y, width, height);
                        tempGraphics.DrawRectangle(solidPen, rectStartPointF.X, rectStartPointF.Y, width, height);
                    }
                    break;
                case "FillRect":
                    {
                        // calculate absolute width and height.
                        float width = Math.Abs(e.X - startPointF.X);
                        float heigth = Math.Abs(e.Y - startPointF.Y);

                        // temporarily store start points.
                        PointF rectStartPointF = startPointF;

                        // if convert fillrectangle.
                        if (e.X < startPointF.X)
                        {
                            rectStartPointF.X = e.X;
                        }
                        if (e.Y < startPointF.Y)
                        {
                            rectStartPointF.Y = e.Y;
                        }

                        // draw fillrectangle.
                        newgraphics.FillRectangle(new SolidBrush(drawColor), rectStartPointF.X, rectStartPointF.Y, width, heigth);
                        tempGraphics.FillRectangle(new SolidBrush(drawColor), rectStartPointF.X, rectStartPointF.Y, width, heigth);
                    }
                    break;
                case "FillEllipse":
                    {
                        // FillEllipse
                        newgraphics.FillEllipse(new SolidBrush(drawColor), startPointF.X, startPointF.Y, e.X - startPointF.X, e.Y - startPointF.Y);
                        tempGraphics.FillEllipse(new SolidBrush(drawColor), startPointF.X, startPointF.Y, e.X - startPointF.X, e.Y - startPointF.Y);
                    }
                    break;
            }

            // dispose temporary canvas.
            newgraphics.Dispose();
            //
            tempGraphics.Dispose();
            // put finishing Image into temporay canvas.
            newgraphics = Graphics.FromImage(finishingImg);
            //
            tempGraphics = Graphics.FromImage(tempImg);
            // temporary canvas display orginalImage.
            newgraphics.DrawImage(img, 0, 0);
            //
            tempGraphics.DrawImage(img1, 0, 0);
            // dispose temporary canvas.
            newgraphics.Dispose();
            //
            tempGraphics.Dispose();
            // display
            DrawTools_Graphics.DrawImage(img, 0 ,0); // dash or solid picture.
            //
            // dispose Image.
            img.Dispose();
            // dispose Image.
            img1.Dispose();
        }


        /// <summary>
        /// This function is used to save orginal Image into temporary canvas when user MouseUp.
        /// </summary>
        public void EndDraw()
        {
            // set shouldDraw to false.
            ShouldDraw = false;

            // save orginal Image into temporary  Canvas.
            newgraphics = Graphics.FromImage(orginalImg); // orginalImg
            // save new Image into finishing Image.
            newgraphics.DrawImage(tempImg, 0, 0);
            // dispose temporay Canvas.
            newgraphics.Dispose();
        }

        /// <summary>
        /// This function is used to erase something which user want to.
        /// </summary>
        /// <param name="e"> Mouse event arguments.</param>
        public void Eraser(MouseEventArgs e)
        {
            // if shouldDraw is true.
            if (ShouldDraw)
            {
                // get current canvas
                newgraphics = Graphics.FromImage(tempImg);
                // get mouse to brush with white color.
                newgraphics.FillRectangle(new SolidBrush(Color.White), e.X, e.Y, 20, 20);
                // dispose 
                newgraphics.Dispose();
                DrawTools_Graphics.DrawImage(tempImg, 0, 0);
            }
        }

        /// <summary>
        /// This function is used to like a default method when user do not choise a shape.
        /// </summary>
        /// <param name="e">Mouse event argument.</param>
        public void DrawDot(MouseEventArgs e)
        {
            if (ShouldDraw)
            {
                newgraphics = Graphics.FromImage(tempImg);
                // get current Point fo mouse.
                PointF currentPointF = new PointF(e.X, e.Y);
                // draw line from start point to current point.
                newgraphics.DrawLine(solidPen, startPointF, currentPointF);
                // get current point to new start.
                startPointF = currentPointF;
                // dispose the canvas.
                newgraphics.Dispose();
                DrawTools_Graphics.DrawImage(tempImg, 0, 0);
            }
        }

        /// <summary>
        /// this function is used to clear all resources.
        /// </summary>
        public void ClearVar()
        {
            // dispose some resource.
            DrawTools_Graphics.Dispose();
            finishingImg.Dispose();
            tempImg.Dispose();
            orginalImg.Dispose();
            dashPen.Dispose();
        }
        
    }
}
