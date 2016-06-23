namespace BulkReadMsgQ
{
    partial class mainForm
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
            this.btnBulkBegin = new System.Windows.Forms.Button();
            this.btnBulkStop = new System.Windows.Forms.Button();
            this.txtboxErrorMessage = new System.Windows.Forms.TextBox();
            this.chkboxCount = new System.Windows.Forms.CheckBox();
            this.txtboxCountDisplay = new System.Windows.Forms.TextBox();
            this.timerUserFeedback = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnBulkBegin
            // 
            this.btnBulkBegin.Location = new System.Drawing.Point(12, 12);
            this.btnBulkBegin.Name = "btnBulkBegin";
            this.btnBulkBegin.Size = new System.Drawing.Size(109, 32);
            this.btnBulkBegin.TabIndex = 0;
            this.btnBulkBegin.Text = "Bulk Begin";
            this.btnBulkBegin.UseVisualStyleBackColor = true;
            this.btnBulkBegin.Click += new System.EventHandler(this.btnBulkBegin_Click);
            // 
            // btnBulkStop
            // 
            this.btnBulkStop.Enabled = false;
            this.btnBulkStop.Location = new System.Drawing.Point(12, 71);
            this.btnBulkStop.Name = "btnBulkStop";
            this.btnBulkStop.Size = new System.Drawing.Size(109, 32);
            this.btnBulkStop.TabIndex = 1;
            this.btnBulkStop.Text = "Bulk Stop";
            this.btnBulkStop.UseVisualStyleBackColor = true;
            this.btnBulkStop.Click += new System.EventHandler(this.btnBulkStop_Click);
            // 
            // txtboxErrorMessage
            // 
            this.txtboxErrorMessage.Enabled = false;
            this.txtboxErrorMessage.Location = new System.Drawing.Point(155, 12);
            this.txtboxErrorMessage.Multiline = true;
            this.txtboxErrorMessage.Name = "txtboxErrorMessage";
            this.txtboxErrorMessage.ReadOnly = true;
            this.txtboxErrorMessage.Size = new System.Drawing.Size(162, 91);
            this.txtboxErrorMessage.TabIndex = 2;
            // 
            // chkboxCount
            // 
            this.chkboxCount.AutoSize = true;
            this.chkboxCount.Location = new System.Drawing.Point(12, 128);
            this.chkboxCount.Name = "chkboxCount";
            this.chkboxCount.Size = new System.Drawing.Size(89, 17);
            this.chkboxCount.TabIndex = 3;
            this.chkboxCount.Text = "Count Queue";
            this.chkboxCount.UseVisualStyleBackColor = true;
            // 
            // txtboxCountDisplay
            // 
            this.txtboxCountDisplay.Enabled = false;
            this.txtboxCountDisplay.Location = new System.Drawing.Point(155, 125);
            this.txtboxCountDisplay.Name = "txtboxCountDisplay";
            this.txtboxCountDisplay.ReadOnly = true;
            this.txtboxCountDisplay.Size = new System.Drawing.Size(162, 20);
            this.txtboxCountDisplay.TabIndex = 4;
            this.txtboxCountDisplay.Text = "0";
            // 
            // timerUserFeedback
            // 
            this.timerUserFeedback.Enabled = true;
            this.timerUserFeedback.Interval = 500;
            this.timerUserFeedback.Tick += new System.EventHandler(this.timerUserFeedback_Tick);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 157);
            this.Controls.Add(this.txtboxCountDisplay);
            this.Controls.Add(this.chkboxCount);
            this.Controls.Add(this.txtboxErrorMessage);
            this.Controls.Add(this.btnBulkStop);
            this.Controls.Add(this.btnBulkBegin);
            this.Name = "mainForm";
            this.Text = "Bulk Reading - MsgQ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBulkBegin;
        private System.Windows.Forms.Button btnBulkStop;
        private System.Windows.Forms.TextBox txtboxErrorMessage;
        private System.Windows.Forms.CheckBox chkboxCount;
        private System.Windows.Forms.TextBox txtboxCountDisplay;
        private System.Windows.Forms.Timer timerUserFeedback;
    }
}

