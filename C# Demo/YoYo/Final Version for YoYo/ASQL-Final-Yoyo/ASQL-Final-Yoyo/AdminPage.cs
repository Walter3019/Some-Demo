/*
 * Authors:          Tong Zhang, Bridget Kerr & Ibrahim Naamani
 * Date of creation: March 16, 2016
 * File Name:        frmAdminPage.cs
 * Description:      This class handles the form for the admin, the admin has a lot of capabilities including everthing that the main user is able to do.
 *                   These extra things that the admin can do include managing employees and creating a schedule.
 * 
 * Last Modified:    April 14, 2016
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Excel = Microsoft.Office.Interop.Excel;


namespace ASQL_Final_Yoyo
{
    public partial class frmAdminPage : Form
    {
        //Declaration
        DAL dataAccess = new DAL();
        string currentUser;
        string success;
        string theFilterParameters = "";

        /*
         * Function:    frmAdminPage()
         * 
         * Description:	The constructor for the form admin class.
         *              
         *              Initializes all the combo boxes and variables for the program.
         * 
         * Parameters:	void
         * 
         * Returns:		void
        */
        public frmAdminPage()
        {
            InitializeComponent();
            success = dataAccess.VerifyConnection();

            //Populating the tables from the database
            DataTable coloursTable = dataAccess.populateSpecificTable("Colours");
            DataTable productsTable = dataAccess.populateSpecificTable("Products");

            DataTable usersTable = dataAccess.populateSpecificTable("Users");

            DataTable defectsTable = dataAccess.populateSpecificTable("Defects");


            //Setting up all the combo boxes with the loaded in data.
            for (int i = 0; i < coloursTable.Rows.Count; i++)
            {
                comboColours.Items.Insert(i, coloursTable.Rows[i].ItemArray[0]);
            }

            for (int i = 0; i < productsTable.Rows.Count; i++)
            {
                comboProducts.Items.Insert(i, productsTable.Rows[i].ItemArray[0]);
                comboAdminProducts.Items.Insert(i, productsTable.Rows[i].ItemArray[0]);
            }

            for (int i = 0; i < usersTable.Rows.Count; i++)
            {
                comboUsers.Items.Insert(i, usersTable.Rows[i].ItemArray[0]);
            }

            for (int i = 0; i < defectsTable.Rows.Count; i++)
            {
                comboDefects.Items.Insert(i, defectsTable.Rows[i].ItemArray[0]);
            }

            //Setting the selected indexes to being. 
            comboUsers.SelectedIndex = 0;
            comboColours.SelectedIndex = 0;
            comboProducts.SelectedIndex = 0;
            comboDefects.SelectedIndex = 0;

            comboAdminProducts.SelectedIndex = 0;

            datetimeScheduleEnd.Value = datetimeScheduleStart.Value.AddHours(1);
            dateTimeEnd.Value = dateTimeStart.Value.AddHours(1);
        }

        /*
         * Function:    btnUpdate_Click()
         * 
         * Description:	 When the update button is clicked this code gets executed
         *              Basically it checks to make sure that the correct DAL method is called
         *              to populate the charts for the user.
         * 
         * Parameters:	object sender, EventArgs e
         * 
         * Returns:		void
        */
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Pressing the update button
            if (success != "Success")
            {
                MessageBox.Show("Unable to connect to server");
            }
            else
            {
                //IT checks which radio button is checked in order to call the right filter method
                if (radioFirstTimeYield.Checked)
                {
                    retrieveFirstTimeYield();
                }
                else if (radioFinalYield.Checked)
                {
                    retrieveFinalYield();
                }
                else if (radioPareto.Checked)
                {
                    retrievePraetoTable();
                }
            }
        }

        /*
         * Function:    retrieveFirstTimeYield()
         * 
         * Description:	Calls the procedure to retrieve the first time yield and then populates
         *              the chart with the two values. This also takes into account any filtering that needs to occur
         *              by formulating the string before passing it into the procedure
         * 
         * Parameters: void
         * 
         * Returns:		void
        */
        private void retrieveFirstTimeYield()
        {
            //Retrieve first time yield
            chartResults.DataSource = null;
            chartResults.Series.Clear();
            chartResults.Series.Add("Series");
            chartResults.Series[0].ChartType = SeriesChartType.Pie;
            theFilterParameters = "";

            //Parsing the filters accordingly adding them to a huge string
            if (chkboxProductsFilter.Checked)
            {
                theFilterParameters = theFilterParameters + "'" + comboProducts.SelectedItem.ToString() + "', ";
            }
            else
            {
                theFilterParameters = theFilterParameters + "'', ";
            }

            if (chkboxColoursFilter.Checked)
            {
                theFilterParameters = theFilterParameters + "'" + comboColours.SelectedItem.ToString() + "', ";
            }
            else
            {
                theFilterParameters = theFilterParameters + "'', ";
            }

            if (chkboxDefectsFilter.Checked)
            {
                theFilterParameters = theFilterParameters + "'" + comboDefects.SelectedItem.ToString() + "', ";
            }
            else
            {
                theFilterParameters = theFilterParameters + "'', ";
            }


            if (chkboxDateFilter.Checked)
            {
                theFilterParameters = theFilterParameters + "'" + dateTimeStart.Value.ToString() + "', '" + dateTimeEnd.Value.ToString() + "' ";
            }
            else
            {
                theFilterParameters = theFilterParameters + "'', " + "'' ";
            }

            //Creating the datatable that will recieve the information from the first time yield procedure
            DataTable tbl = dataAccess.RetrieveTable(theFilterParameters, "FirstTimeYield");

            //sourcing the data table
            datagridTable.DataSource = tbl;

            //Populating the rows & cols
            string[] x = new String[tbl.Rows.Count];
            int[] y = new int[tbl.Rows.Count];


            for (int i = 0; i < tbl.Rows.Count; i++)
            {

                x[i] = tbl.Rows[i][1].ToString();
                y[i] = Convert.ToInt32(tbl.Rows[i][1]);
            }

            //Setting the points and the legends
            chartResults.Series[0].Points.DataBindXY(x, y);
            chartResults.Legends[0].Enabled = true;

        }

        /*
         * Function:    retrieveFinalYield()
         * 
         * Description:	Calls the procedure to retrieve the final yield and then populates
         *              the chart with the two values. This also takes into account any filtering that needs to occur
         *              by formulating the string before passing it into the procedure
         * 
         * Parameters:  void
         * 
         * Returns:		void
        */
        private void retrieveFinalYield()
        {
            //Retrieving the final yield.
            chartResults.DataSource = null;
            chartResults.Series.Clear();
            chartResults.Series.Add("Series");
            chartResults.Series[0].ChartType = SeriesChartType.Pie;
            theFilterParameters = "";

            // Setting up the filter parameters for the final yield.
            if (chkboxProductsFilter.Checked)
            {
                theFilterParameters = theFilterParameters + "'" + comboProducts.SelectedItem.ToString() +"', ";
            }
            else
            {
                theFilterParameters = theFilterParameters + "'', ";
            }

            if (chkboxColoursFilter.Checked)
            {
                theFilterParameters = theFilterParameters + "'" + comboColours.SelectedItem.ToString() + "', ";
            }
            else
            {
                theFilterParameters = theFilterParameters + "'', ";
            }

            if (chkboxDefectsFilter.Checked)
            {
                theFilterParameters = theFilterParameters + "'" + comboDefects.SelectedItem.ToString() + "', ";
            }
            else
            {
                theFilterParameters = theFilterParameters + "'', ";
            }


            if (chkboxDateFilter.Checked)
            {
                theFilterParameters = theFilterParameters + "'" + dateTimeStart.Value.ToString() + "', '" + dateTimeEnd.Value.ToString() + "' ";
            }
            else
            {
                theFilterParameters = theFilterParameters + "'', " + "'' ";
            }

            //Creating the datatable that will recieve the datatable
            DataTable tbl = dataAccess.RetrieveTable(theFilterParameters, "FinalYield");

            datagridTable.DataSource = tbl;

            //Populating the chart accordingly
            string[] x = new String[tbl.Rows.Count];
            double[] y = new double[tbl.Rows.Count];

            x[0] = "Rejects";
            x[1] = "Final Yield";
            y[0] = Convert.ToDouble(tbl.Rows[1][0]) / (Convert.ToDouble(tbl.Rows[0][0]) + Convert.ToDouble(tbl.Rows[1][0])) * 100;
            y[1] = 100 - y[0];

            chartResults.Series[0].Points.DataBindXY(x, y);
            chartResults.Legends[0].Enabled = true;
         }

        /*
         * Function:    retrievePraetoTable()
         * 
         * Description:	Calls the procedure to retrieve the praeto table and then populates
         *              the chart with the two values. This also takes into account any filtering that needs to occur
         *              by formulating the string before passing it into the procedure
         * 
         * Parameters:  void
         * 
         * Returns:		void
        */
        private void retrievePraetoTable()
        {
            //Retrieving the praeto table
            chartResults.DataSource = null;
            chartResults.Series.Clear();
            chartResults.Series.Add("Series");
            chartResults.Series[0].ChartType = SeriesChartType.Column;
            chartResults.Series.Add("Series2");
            chartResults.Series[1].ChartType = SeriesChartType.Line;

            chartResults.Series[1].YAxisType = AxisType.Secondary;

            chartResults.ChartAreas[0].AxisY2.Maximum = 100;

            //creating the datatable to recieve praeto
            DataTable tbl = dataAccess.RetrieveTable("", "Praeto");

            datagridTable.DataSource = tbl;

            int theValue = 0;

            double tempValue = 0;

            //Cyling through the points for the chart
            for (int i = 0; i < tbl.Rows.Count; i++)
            {
                theValue += Convert.ToInt32(tbl.Rows[i][1]);
                chartResults.Series["Series"].Points.AddY(tbl.Rows[i][1]);
            }

            //Cycling through all the points on the table
            for (int j = 0; j < tbl.Rows.Count; j++)
            {
                tempValue += (Convert.ToDouble(tbl.Rows[j][1]) / theValue * 100);
                chartResults.Series["Series2"].Points.AddY(Math.Round(tempValue, 2));
            }
            chartResults.ChartAreas[0].AxisY.Maximum = theValue;
            chartResults.ChartAreas[0].AxisY2.LabelStyle.Format = "{#'%'}";


            chartResults.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chartResults.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
        }

        /*
         * Function:    comboUsers_Click()
         * 
         * Description: When the comboUsers is clicked, then the combobox is updated to retrieve the most recent list of users.
         * 
         * Parameters:  object sender, EventArgs e
         * 
         * Returns:		void
        */
        private void comboUsers_Click(object sender, EventArgs e)
        {
            //Creating the datatable
            DataTable usersTable = dataAccess.populateSpecificTable("Users");
            comboUsers.Items.Clear();
            //looping through and populating it
            for (int i = 0; i < usersTable.Rows.Count; i++)
            {
                comboUsers.Items.Insert(i, usersTable.Rows[i].ItemArray[0]);
            }
        }

        /*
         * Function:    btnAddUser_Click()
         * 
         * Description: When the add user button is clicked, the system checks to make sure that the user
         *              that is being added does not already exist. Then afterwards it calls the appropriate procedure
         *              from the dal adding in the new user.
         * 
         * Parameters:  object sender, EventArgs e
         * 
         * Returns:		void
        */
        private void btnAddUser_Click(object sender, EventArgs e)
        {
            //Declaration
            string userName = this.txtboxUsername.Text;
            string password = this.txtboxPassword.Text;
            int securityLevel;
            int returnValue = 0;

            //Error checking
            if (!this.radioAdministrator.Checked && !this.radioGeneral.Checked)
            {
                MessageBox.Show("Please select security level.");
            }
            else if (System.String.IsNullOrWhiteSpace(userName) == true)
            {
                MessageBox.Show("Please input in a name.");
            }
            else if (String.IsNullOrWhiteSpace(password) == true)
            {
                MessageBox.Show("Please input in a password.");
            }
            else
            {
                if (this.radioAdministrator.Checked)
                {
                    securityLevel = 10;
                }
                else
                {
                    securityLevel = 5;
                }

                //Calling the procedure
                returnValue = dataAccess.InsertUser(userName, password, securityLevel);

                //Letting the user know of the results
                if (returnValue == 1)
                {
                    MessageBox.Show("New user has save to DataBase.");
                }
                else
                {
                    MessageBox.Show("User already exists.");
                }
            }
        }

        /*
         * Function:    btnDeleteUser_Click()
         * 
         * Description: When the delete user button is clicked, the system checks to make sure that the user
         *              that is being delete is not currently active. Then afterwards it calls the appropriate procedure
         *              from the dal deleting the user.
         * 
         * Parameters:  object sender, EventArgs e
         * 
         * Returns:		void
        */
        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            //declaration
           string theUser =  comboUsers.SelectedItem.ToString();
           int returnValue = 0;

           theUser = theUser.ToUpper();

            //Error checking
            if (theUser != currentUser)
            {
                returnValue = dataAccess.DeleteUser(theUser);
                //Letting the user know of the result
                if (returnValue == 1)
                {
                    MessageBox.Show("User deleted successfully.");
                }
                else
                {
                    MessageBox.Show("Unable to delete user.");
                }
            }
            else
            {
                MessageBox.Show("You can not delete the current active user.");
            }

            comboUsers.SelectedIndex = 0;
        }


        /*
         * Function:    btnModifyUser_Click()
         * 
         * Description: When the modify user button is clicked, the system checks to make sure that the user
         *              that is being edited is not currently active. Then afterwards it calls the appropriate procedure
         *              from the dal passing in the new fields so that the employe may be modified appropriately
         * 
         * Parameters:  object sender, EventArgs e
         * 
         * Returns:		void
        */
        private void btnModifyUser_Click(object sender, EventArgs e)
        {
            //Declaration and initialization
            string theUser = comboUsers.SelectedItem.ToString();
            theUser = theUser.ToUpper();

            string password = this.txtboxModifyPassword.Text;
            int securityLevel;
            int returnValue = 0;
            
            //Error handling
            if (!this.radioModifyAdministrator.Checked && !this.radioModifyGeneral.Checked)
            {
                MessageBox.Show("Please select security level.");
            }
            else if (theUser == currentUser)
            {
                MessageBox.Show("You cannot modify the current user.");
            }
            else if (String.IsNullOrWhiteSpace(password) == true)
            {
                MessageBox.Show("Please input in a password.");
            }
            else
            {
                if (this.radioModifyAdministrator.Checked)
                {
                    securityLevel = 10;
                }
                else
                {
                    securityLevel = 5;
                }
                //Call the function to modify the user
                returnValue = dataAccess.ModifyUser(theUser, password, securityLevel);

                //Let the user know if success or failure.
                if (returnValue == 1)
                {
                    MessageBox.Show("User successfully modified.");
                }
                else
                {
                    MessageBox.Show("Cannot modify user.");
                }
            }
        }


        /*
         * Function:    setUserName()
         * 
         * Description: Sets the name of the current user so they may not delete or modify their account while logged in.
         * 
         * Parameters:  string theName
         * 
         * Returns:		void
        */
        public void setUserName(string theName)
        {
            currentUser = theName.ToUpper();
        }

        /*
         * Function:    datetimeScheduleStart_ValueChanged()
         * 
         * Description: basically anytime the value is changed inside the datetimepicker the other value is 
         *              adjusted so that the values do not overlap one another.
         * 
         * Parameters:  object sender, EventArgs e
         * 
         * Returns:		void
        */
        private void datetimeScheduleStart_ValueChanged(object sender, EventArgs e)
        {
          if (datetimeScheduleStart.Value > datetimeScheduleEnd.Value)
          {
              datetimeScheduleEnd.Value = datetimeScheduleStart.Value.AddHours(1);
          }
        }

        /*
         * Function:    datetimeScheduleEnd_ValueChanged()
         * 
         * Description: basically anytime the value is changed inside the datetimepicker the other value is 
         *              adjusted so that the values do not overlap one another.
         * 
         * Parameters:  object sender, EventArgs e
         * 
         * Returns:		void
        */
        private void datetimeScheduleEnd_ValueChanged(object sender, EventArgs e)
        {
            if (datetimeScheduleStart.Value > datetimeScheduleEnd.Value)
            {
                datetimeScheduleStart.Value = datetimeScheduleEnd.Value.AddHours(-1);
            }
        }

        /*
         * Function:    btnAddSchedule_Click()
         * 
         * Description: When the add schedule button is clicked, the fields are checked before the dal is called
         *              with the passed in parameters to insert the schedule into the database
         * 
         * Parameters:  object sender, EventArgs e
         * 
         * Returns:		void
        */
        private void btnAddSchedule_Click(object sender, EventArgs e)
        {
            int returnValue = 0;
            //Checking values
            if (System.String.IsNullOrWhiteSpace(txtboxWorkArea.Text))
            {
                //Error occured, let the user know.
                MessageBox.Show("Please type a work area.");
            }
            else
            {
                //Inserting into the schedule 
                returnValue = dataAccess.InsertIntoSchedule(datetimeScheduleStart.Value, datetimeScheduleEnd.Value, comboAdminProducts.SelectedItem.ToString(), txtboxWorkArea.Text);

                if (returnValue == 1)
                {
                    //Everythign good!
                    MessageBox.Show("Successfully added schedule.");
                }
                else
                {
                    //Everything bad :(
                    MessageBox.Show("Was unsuccessful in adding the schedule.");
                }
            }
            
        }

        /*
         * Function:    dateTimeStart_ValueChanged()
         * 
         * Description: basically anytime the value is changed inside the datetimepicker the other value is 
         *              adjusted so that the values do not overlap one another.
         * 
         * Parameters:  object sender, EventArgs e
         * 
         * Returns:		void
        */
        private void dateTimeStart_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimeStart.Value > dateTimeEnd.Value)
            {
                dateTimeEnd.Value = dateTimeStart.Value.AddHours(1);
            }
        }

        /*
         * Function:    dateTimeEnd_ValueChanged()
         * 
         * Description: basically anytime the value is changed inside the datetimepicker the other value is 
         *              adjusted so that the values do not overlap one another.
         * 
         * Parameters:  object sender, EventArgs e
         * 
         * Returns:		void
        */
        private void dateTimeEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dateTimeStart.Value > dateTimeEnd.Value)
            {
                dateTimeStart.Value = dateTimeEnd.Value.AddHours(-1);
            }
        }
    }
}
