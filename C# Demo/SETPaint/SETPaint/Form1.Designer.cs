namespace SETPaint
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePic = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rightClick = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.chooseShapeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ellipsesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.rectangleToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.lineToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.status = new System.Windows.Forms.StatusStrip();
            this.mousePostionInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentDrawType = new System.Windows.Forms.ToolStripStatusLabel();
            this.currentColor = new System.Windows.Forms.ToolStripStatusLabel();
            this.ToolPanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PenThick = new System.Windows.Forms.RadioButton();
            this.PenMedium = new System.Windows.Forms.RadioButton();
            this.PenThin = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.DrawtoolStrip = new System.Windows.Forms.ToolStrip();
            this.Dot = new System.Windows.Forms.ToolStripButton();
            this.Eraser = new System.Windows.Forms.ToolStripButton();
            this.Line = new System.Windows.Forms.ToolStripButton();
            this.Rectangle = new System.Windows.Forms.ToolStripButton();
            this.Ellipse = new System.Windows.Forms.ToolStripButton();
            this.FillRect = new System.Windows.Forms.ToolStripButton();
            this.FillEllipse = new System.Windows.Forms.ToolStripButton();
            this.ColorBtn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Painter = new System.Windows.Forms.PictureBox();
            this.MainMenu.SuspendLayout();
            this.rightClick.SuspendLayout();
            this.status.SuspendLayout();
            this.ToolPanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.DrawtoolStrip.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Painter)).BeginInit();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(655, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.savePic,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openPic_Click);
            // 
            // savePic
            // 
            this.savePic.Name = "savePic";
            this.savePic.Size = new System.Drawing.Size(103, 22);
            this.savePic.Text = "Save";
            this.savePic.Click += new System.EventHandler(this.savePic_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.Quit_Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Clear});
            this.toolToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            this.toolToolStripMenuItem.Size = new System.Drawing.Size(42, 20);
            this.toolToolStripMenuItem.Text = "Tool";
            // 
            // Clear
            // 
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(101, 22);
            this.Clear.Text = "Clear";
            this.Clear.Click += new System.EventHandler(this.clearPic_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // rightClick
            // 
            this.rightClick.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chooseShapeToolStripMenuItem1,
            this.lineToolStripMenuItem});
            this.rightClick.Name = "rightClick";
            this.rightClick.Size = new System.Drawing.Size(153, 48);
            // 
            // chooseShapeToolStripMenuItem1
            // 
            this.chooseShapeToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lineToolStripMenuItem2,
            this.ellipsesToolStripMenuItem1,
            this.rectangleToolStripMenuItem1});
            this.chooseShapeToolStripMenuItem1.Name = "chooseShapeToolStripMenuItem1";
            this.chooseShapeToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.chooseShapeToolStripMenuItem1.Text = "Choose Shape:";
            // 
            // lineToolStripMenuItem2
            // 
            this.lineToolStripMenuItem2.Name = "lineToolStripMenuItem2";
            this.lineToolStripMenuItem2.Size = new System.Drawing.Size(126, 22);
            this.lineToolStripMenuItem2.Text = "Line";
            // 
            // ellipsesToolStripMenuItem1
            // 
            this.ellipsesToolStripMenuItem1.Name = "ellipsesToolStripMenuItem1";
            this.ellipsesToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.ellipsesToolStripMenuItem1.Text = "Ellipses";
            // 
            // rectangleToolStripMenuItem1
            // 
            this.rectangleToolStripMenuItem1.Name = "rectangleToolStripMenuItem1";
            this.rectangleToolStripMenuItem1.Size = new System.Drawing.Size(126, 22);
            this.rectangleToolStripMenuItem1.Text = "Rectangle";
            // 
            // lineToolStripMenuItem
            // 
            this.lineToolStripMenuItem.Name = "lineToolStripMenuItem";
            this.lineToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.lineToolStripMenuItem.Text = "Clear";
            // 
            // status
            // 
            this.status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mousePostionInfo,
            this.currentDrawType,
            this.currentColor});
            this.status.Location = new System.Drawing.Point(0, 380);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(655, 22);
            this.status.TabIndex = 3;
            this.status.Text = "statusStrip1";
            // 
            // mousePostionInfo
            // 
            this.mousePostionInfo.Name = "mousePostionInfo";
            this.mousePostionInfo.Size = new System.Drawing.Size(0, 17);
            // 
            // currentDrawType
            // 
            this.currentDrawType.Name = "currentDrawType";
            this.currentDrawType.Size = new System.Drawing.Size(0, 17);
            // 
            // currentColor
            // 
            this.currentColor.Name = "currentColor";
            this.currentColor.Size = new System.Drawing.Size(0, 17);
            // 
            // ToolPanel
            // 
            this.ToolPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ToolPanel.Controls.Add(this.groupBox1);
            this.ToolPanel.Controls.Add(this.panel1);
            this.ToolPanel.Controls.Add(this.DrawtoolStrip);
            this.ToolPanel.Controls.Add(this.ColorBtn);
            this.ToolPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.ToolPanel.Location = new System.Drawing.Point(0, 0);
            this.ToolPanel.Name = "ToolPanel";
            this.ToolPanel.Size = new System.Drawing.Size(81, 356);
            this.ToolPanel.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.groupBox1.Controls.Add(this.PenThick);
            this.groupBox1.Controls.Add(this.PenMedium);
            this.groupBox1.Controls.Add(this.PenThin);
            this.groupBox1.Location = new System.Drawing.Point(3, 125);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(75, 90);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Pen Width";
            // 
            // PenThick
            // 
            this.PenThick.AutoSize = true;
            this.PenThick.Location = new System.Drawing.Point(7, 68);
            this.PenThick.Name = "PenThick";
            this.PenThick.Size = new System.Drawing.Size(52, 17);
            this.PenThick.TabIndex = 2;
            this.PenThick.Text = "Thick";
            this.PenThick.UseVisualStyleBackColor = true;
            this.PenThick.CheckedChanged += new System.EventHandler(this.PenThick_CheckedChanged);
            // 
            // PenMedium
            // 
            this.PenMedium.AutoSize = true;
            this.PenMedium.Location = new System.Drawing.Point(7, 44);
            this.PenMedium.Name = "PenMedium";
            this.PenMedium.Size = new System.Drawing.Size(62, 17);
            this.PenMedium.TabIndex = 1;
            this.PenMedium.Text = "Medium";
            this.PenMedium.UseVisualStyleBackColor = true;
            this.PenMedium.CheckedChanged += new System.EventHandler(this.PenMedium_CheckedChanged);
            // 
            // PenThin
            // 
            this.PenThin.AutoSize = true;
            this.PenThin.Checked = true;
            this.PenThin.Location = new System.Drawing.Point(7, 21);
            this.PenThin.Name = "PenThin";
            this.PenThin.Size = new System.Drawing.Size(46, 17);
            this.PenThin.TabIndex = 0;
            this.PenThin.TabStop = true;
            this.PenThin.Text = "Thin";
            this.PenThin.UseVisualStyleBackColor = true;
            this.PenThin.CheckedChanged += new System.EventHandler(this.PenThin_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(108, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(546, 346);
            this.panel1.TabIndex = 5;
            // 
            // DrawtoolStrip
            // 
            this.DrawtoolStrip.AutoSize = false;
            this.DrawtoolStrip.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.DrawtoolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.DrawtoolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Dot,
            this.Eraser,
            this.Line,
            this.Rectangle,
            this.Ellipse,
            this.FillRect,
            this.FillEllipse});
            this.DrawtoolStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.DrawtoolStrip.Location = new System.Drawing.Point(6, 1);
            this.DrawtoolStrip.Name = "DrawtoolStrip";
            this.DrawtoolStrip.Size = new System.Drawing.Size(75, 109);
            this.DrawtoolStrip.TabIndex = 0;
            this.DrawtoolStrip.Text = "toolStrip1";
            // 
            // Dot
            // 
            this.Dot.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Dot.Image = global::SETPaint.Properties.Resources.Pencil1;
            this.Dot.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Dot.Name = "Dot";
            this.Dot.Size = new System.Drawing.Size(23, 20);
            this.Dot.Text = "Pen";
            this.Dot.ToolTipText = "Line";
            this.Dot.Click += new System.EventHandler(this.tool_Click);
            // 
            // Eraser
            // 
            this.Eraser.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Eraser.Image = global::SETPaint.Properties.Resources.eraser1;
            this.Eraser.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Eraser.Name = "Eraser";
            this.Eraser.Size = new System.Drawing.Size(23, 20);
            this.Eraser.Text = "Eraser";
            this.Eraser.Click += new System.EventHandler(this.tool_Click);
            // 
            // Line
            // 
            this.Line.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Line.Image = global::SETPaint.Properties.Resources.line;
            this.Line.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Line.Name = "Line";
            this.Line.Size = new System.Drawing.Size(23, 20);
            this.Line.Text = "Line";
            this.Line.Click += new System.EventHandler(this.tool_Click);
            // 
            // Rectangle
            // 
            this.Rectangle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Rectangle.Image = global::SETPaint.Properties.Resources.rect;
            this.Rectangle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Rectangle.Name = "Rectangle";
            this.Rectangle.Size = new System.Drawing.Size(23, 20);
            this.Rectangle.Text = "Rectangle";
            this.Rectangle.Click += new System.EventHandler(this.tool_Click);
            // 
            // Ellipse
            // 
            this.Ellipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Ellipse.Image = global::SETPaint.Properties.Resources.Circle;
            this.Ellipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Ellipse.Name = "Ellipse";
            this.Ellipse.Size = new System.Drawing.Size(23, 20);
            this.Ellipse.Text = "Ellipse";
            this.Ellipse.Click += new System.EventHandler(this.tool_Click);
            // 
            // FillRect
            // 
            this.FillRect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FillRect.Image = global::SETPaint.Properties.Resources.Fillrect;
            this.FillRect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FillRect.Name = "FillRect";
            this.FillRect.Size = new System.Drawing.Size(23, 20);
            this.FillRect.Text = "FillRect";
            this.FillRect.Click += new System.EventHandler(this.tool_Click);
            // 
            // FillEllipse
            // 
            this.FillEllipse.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.FillEllipse.Image = global::SETPaint.Properties.Resources.FillCircle;
            this.FillEllipse.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.FillEllipse.Name = "FillEllipse";
            this.FillEllipse.Size = new System.Drawing.Size(23, 20);
            this.FillEllipse.Text = "FillEllipse";
            this.FillEllipse.Click += new System.EventHandler(this.tool_Click);
            // 
            // ColorBtn
            // 
            this.ColorBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorBtn.Image = ((System.Drawing.Image)(resources.GetObject("ColorBtn.Image")));
            this.ColorBtn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.ColorBtn.Location = new System.Drawing.Point(3, 311);
            this.ColorBtn.Name = "ColorBtn";
            this.ColorBtn.Size = new System.Drawing.Size(73, 45);
            this.ColorBtn.TabIndex = 0;
            this.ColorBtn.Text = "More";
            this.ColorBtn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.ColorBtn.UseVisualStyleBackColor = true;
            this.ColorBtn.Click += new System.EventHandler(this.ColorBtn_Click);
            // 
            // panel2
            // 
            this.panel2.AllowDrop = true;
            this.panel2.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel2.Controls.Add(this.Painter);
            this.panel2.Controls.Add(this.ToolPanel);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 24);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(655, 356);
            this.panel2.TabIndex = 5;
            // 
            // Painter
            // 
            this.Painter.BackColor = System.Drawing.Color.White;
            this.Painter.Location = new System.Drawing.Point(79, 1);
            this.Painter.Name = "Painter";
            this.Painter.Size = new System.Drawing.Size(561, 347);
            this.Painter.TabIndex = 0;
            this.Painter.TabStop = false;
            this.Painter.Paint += new System.Windows.Forms.PaintEventHandler(this.Painter_Paint);
            this.Painter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Painter_MouseDown);
            this.Painter.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Painter_MouseMove);
            this.Painter.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Painter_MouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(655, 402);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.status);
            this.Controls.Add(this.MainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "SETPaint";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.rightClick.ResumeLayout(false);
            this.status.ResumeLayout(false);
            this.status.PerformLayout();
            this.ToolPanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.DrawtoolStrip.ResumeLayout(false);
            this.DrawtoolStrip.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Painter)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePic;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Button ColorBtn;
        private System.Windows.Forms.ContextMenuStrip rightClick;
        private System.Windows.Forms.ToolStripMenuItem chooseShapeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lineToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem ellipsesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem rectangleToolStripMenuItem1;
        private System.Windows.Forms.StatusStrip status;
        private System.Windows.Forms.ToolStrip DrawtoolStrip;
        private System.Windows.Forms.ToolStripButton Dot;
        private System.Windows.Forms.ToolStripButton Eraser;
        private System.Windows.Forms.ToolStripButton Line;
        private System.Windows.Forms.ToolStripButton Rectangle;
        private System.Windows.Forms.Panel ToolPanel;
        private System.Windows.Forms.ToolStripButton Ellipse;
        private System.Windows.Forms.ToolStripStatusLabel mousePostionInfo;
        private System.Windows.Forms.ToolStripStatusLabel currentDrawType;
        private System.Windows.Forms.ToolStripStatusLabel currentColor;
        private System.Windows.Forms.ToolStripButton FillRect;
        private System.Windows.Forms.ToolStripButton FillEllipse;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox Painter;
        private System.Windows.Forms.ToolStripMenuItem Clear;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton PenThick;
        private System.Windows.Forms.RadioButton PenMedium;
        private System.Windows.Forms.RadioButton PenThin;
    }
}

