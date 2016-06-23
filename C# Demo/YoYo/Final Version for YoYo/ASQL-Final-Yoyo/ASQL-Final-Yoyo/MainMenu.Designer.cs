namespace ASQL_Final_Yoyo
{
    partial class frmMainMenu
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
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtboxUser = new System.Windows.Forms.TextBox();
            this.txtboxPassword = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUserFeedback = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(103, 211);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(129, 23);
            this.btnLogin.TabIndex = 0;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtboxUser
            // 
            this.txtboxUser.Location = new System.Drawing.Point(158, 80);
            this.txtboxUser.Name = "txtboxUser";
            this.txtboxUser.Size = new System.Drawing.Size(100, 20);
            this.txtboxUser.TabIndex = 1;
            // 
            // txtboxPassword
            // 
            this.txtboxPassword.Location = new System.Drawing.Point(158, 135);
            this.txtboxPassword.Name = "txtboxPassword";
            this.txtboxPassword.PasswordChar = '*';
            this.txtboxPassword.Size = new System.Drawing.Size(100, 20);
            this.txtboxPassword.TabIndex = 2;
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Location = new System.Drawing.Point(56, 83);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(63, 13);
            this.lblUserName.TabIndex = 3;
            this.lblUserName.Text = "User Name:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(59, 138);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(56, 13);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Password:";
            // 
            // lblUserFeedback
            // 
            this.lblUserFeedback.AutoSize = true;
            this.lblUserFeedback.Location = new System.Drawing.Point(12, 262);
            this.lblUserFeedback.Name = "lblUserFeedback";
            this.lblUserFeedback.Size = new System.Drawing.Size(51, 13);
            this.lblUserFeedback.TabIndex = 5;
            this.lblUserFeedback.Text = "No Errors";
            // 
            // frmMainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 302);
            this.Controls.Add(this.lblUserFeedback);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.Controls.Add(this.txtboxPassword);
            this.Controls.Add(this.txtboxUser);
            this.Controls.Add(this.btnLogin);
            this.Name = "frmMainMenu";
            this.Text = "Main Menu";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtboxUser;
        private System.Windows.Forms.TextBox txtboxPassword;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUserFeedback;
    }
}

