using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Messaging;
using System.Threading;
namespace ASQL_Final_Yoyo
{

    public partial class frmMainMenu : Form
    {
        public DAL dataAccess;
        public frmUserPage userForm;
        public frmAdminPage adminForm;

        public string currentUser;

        public frmMainMenu()
        {
            InitializeComponent();
        }

        //Attempting to log into the server.
        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                dataAccess = new DAL();
                userForm = new frmUserPage();
                adminForm = new frmAdminPage();

                string connectedToServer = dataAccess.VerifyConnection();
                int validUser = 0;

                //Check if we're able to connect to the server.
                if (connectedToServer != "Success")
                {
                    lblUserFeedback.Text = connectedToServer;
                }
                else
                {
                    //Attempt to connect with the following information
                    //bool userFound = dataAccess.UserStatus("SELECT COUNT(*) FROM UsersTable WHERE Name = 'Admin' AND ThePassword = '1234' ");

                    validUser = dataAccess.AttemptLogin(txtboxUser.Text, txtboxPassword.Text);

                    //User is not found within the database
                    if (validUser == 0)
                    {
                        lblUserFeedback.Text = "Incorrect user information";
                    }
                    //User is found in the database.
                    else if (validUser >= 10)
                    {
                        lblUserFeedback.Text = "Logging as an Admin...";
                        currentUser = txtboxUser.Text;
                        adminForm.setUserName(currentUser);
                        this.Hide();
                        adminForm.ShowDialog();
                        this.Close();
                    }
                    else if (validUser <= 5)
                    {
                        lblUserFeedback.Text = "Logging as a User...";
                        currentUser = txtboxUser.Text;
                        this.Hide();
                        adminForm.setUserName(currentUser);
                        userForm.ShowDialog();
                        this.Close();
                    }
                }
            }
            catch (System.Data.SqlClient.SqlException sqlException)
            {
                MessageBox.Show("Please ensure the Database has all procedures and tables.\r\nError Message:\r\n" + sqlException.Message.ToString());
            }
            catch (Exception generalException)
            {
                MessageBox.Show("Error: \r\n" + generalException.Message.ToString());
            }
        }
    }
}
