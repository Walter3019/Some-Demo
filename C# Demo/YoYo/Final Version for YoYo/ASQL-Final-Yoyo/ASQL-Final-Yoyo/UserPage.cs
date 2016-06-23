/*
 * Authors:          Lingchen Meng / Xuan Zhang
 * Date of creation: March 16, 2016
 * File Name:        frmUserPage.cs
 * Description:      This class handles the form for the user. IT will allow the user to
 *                   basically display different graphs and filter them as they see fit.
 * 
 * Last Modified:    April 14, 2016
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
using System.Windows.Forms.DataVisualization.Charting;

namespace ASQL_Final_Yoyo
{
    public partial class frmUserPage : Form
    {
        //Declaration
        public DAL dataAccess = new DAL();
        private string success;
        string theFilterParameters = "";

         /*
         * Function:    frmUserPage()
         * 
         * Description:	The constructor for the form User class.
         *              
         *              Initializes all the combo boxes and variables for the program.
         * 
         * Parameters:	void
         * 
         * Returns:		void
        */
        public frmUserPage()
        {
            InitializeComponent();
            success = dataAccess.VerifyConnection();
            
            //Populating the tables from the database
            DataTable coloursTable = dataAccess.populateSpecificTable("Colours");
            DataTable productsTable = dataAccess.populateSpecificTable("Products");
            DataTable defectsTable = dataAccess.populateSpecificTable("Defects");

            //Setting up all the combo boxes with the loaded in data.
            for (int i = 0; i < coloursTable.Rows.Count; i ++)
            {
                comboColours.Items.Insert(i, coloursTable.Rows[i].ItemArray[0]);
            }

            for (int i = 0; i < productsTable.Rows.Count; i++)
            {
                comboProducts.Items.Insert(i, productsTable.Rows[i].ItemArray[0]);
            }

            for (int i = 0; i < defectsTable.Rows.Count; i++)
            {
                comboDefects.Items.Insert(i, defectsTable.Rows[i].ItemArray[0]);
            }

            //Setting the selected indexes to being. 
            comboColours.SelectedIndex = 0;
            comboProducts.SelectedIndex = 0;
            comboDefects.SelectedIndex = 0;

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
                lblFeedBack.Text = "Unable to connect to server";
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
            for(int j = 0; j < tbl.Rows.Count; j++)
            {
             tempValue += (Convert.ToDouble(tbl.Rows[j][1])/ theValue * 100);
            chartResults.Series["Series2"].Points.AddY(Math.Round(tempValue, 2));
            }
            chartResults.ChartAreas[0].AxisY.Maximum = theValue;
            chartResults.ChartAreas[0].AxisY2.LabelStyle.Format = "{#'%'}";

            
            chartResults.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            chartResults.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
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
