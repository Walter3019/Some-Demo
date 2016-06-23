namespace Assignment4
{
    partial class Mystify
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.restart = new System.Windows.Forms.Button();
            this.Shut_DownButt = new System.Windows.Forms.Button();
            this.ResumeButt = new System.Windows.Forms.Button();
            this.PauseButt = new System.Windows.Forms.Button();
            this.Painter = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Painter)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.restart);
            this.panel1.Controls.Add(this.Shut_DownButt);
            this.panel1.Controls.Add(this.ResumeButt);
            this.panel1.Controls.Add(this.PauseButt);
            this.panel1.Location = new System.Drawing.Point(528, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(83, 407);
            this.panel1.TabIndex = 0;
            // 
            // restart
            // 
            this.restart.Location = new System.Drawing.Point(5, 156);
            this.restart.Name = "restart";
            this.restart.Size = new System.Drawing.Size(75, 23);
            this.restart.TabIndex = 4;
            this.restart.Text = "ReStart";
            this.restart.UseVisualStyleBackColor = true;
            this.restart.Click += new System.EventHandler(this.restart_Click);
            // 
            // Shut_DownButt
            // 
            this.Shut_DownButt.Location = new System.Drawing.Point(5, 109);
            this.Shut_DownButt.Name = "Shut_DownButt";
            this.Shut_DownButt.Size = new System.Drawing.Size(75, 23);
            this.Shut_DownButt.TabIndex = 2;
            this.Shut_DownButt.Text = "Shut Down";
            this.Shut_DownButt.UseVisualStyleBackColor = true;
            this.Shut_DownButt.Click += new System.EventHandler(this.Shut_DownButt_Click);
            // 
            // ResumeButt
            // 
            this.ResumeButt.Location = new System.Drawing.Point(5, 63);
            this.ResumeButt.Name = "ResumeButt";
            this.ResumeButt.Size = new System.Drawing.Size(75, 23);
            this.ResumeButt.TabIndex = 1;
            this.ResumeButt.Text = "Resume";
            this.ResumeButt.UseVisualStyleBackColor = true;
            this.ResumeButt.Click += new System.EventHandler(this.ResumeButt_Click);
            // 
            // PauseButt
            // 
            this.PauseButt.Location = new System.Drawing.Point(5, 21);
            this.PauseButt.Name = "PauseButt";
            this.PauseButt.Size = new System.Drawing.Size(75, 23);
            this.PauseButt.TabIndex = 0;
            this.PauseButt.Text = "Pause All";
            this.PauseButt.UseVisualStyleBackColor = true;
            this.PauseButt.Click += new System.EventHandler(this.PauseButt_Click);
            // 
            // Painter
            // 
            this.Painter.BackColor = System.Drawing.Color.White;
            this.Painter.Location = new System.Drawing.Point(-4, 0);
            this.Painter.Name = "Painter";
            this.Painter.Size = new System.Drawing.Size(531, 407);
            this.Painter.TabIndex = 1;
            this.Painter.TabStop = false;
            this.Painter.Paint += new System.Windows.Forms.PaintEventHandler(this.Paint_Paint);
            this.Painter.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Paint_MouseDown);
            // 
            // Mystify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 404);
            this.Controls.Add(this.Painter);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Mystify";
            this.Text = "Mystify";
            this.Load += new System.EventHandler(this.Mystify_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Painter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Shut_DownButt;
        private System.Windows.Forms.Button ResumeButt;
        private System.Windows.Forms.Button PauseButt;
        private System.Windows.Forms.PictureBox Painter;
        private System.Windows.Forms.Button restart;
    }
}

