/*
 * Authors:          Lingchen Meng / Xuan Zhang
 * Date of creation: March 16, 2016
 * File Name:        mainForm.cs
 * Description:      This essentially launches a thread and reads data from the message queue in bulk.
 *                   HEAVILY inspired by Norbert Mika's application which was provided to us.
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
using System.Messaging;
using System.Threading;


namespace BulkReadMsgQ
{
    public partial class mainForm : Form
    {
        //Variable declaration
        MessageQueue msmq = new MessageQueue();
        volatile Boolean bBulkWrite = false;
        volatile Boolean bulkThreadRunning = true;
        String queueName = "\\private$\\yoyo";
        DAL dal = new DAL();
        string computerName;
        Thread bulkReadThread;

        string theErrorMessage = "";

        /*
         * Function:    mainForm
         * 
         * Description:	The constructor for the main form class.
         *              
         *              Initializes variables and sets things up for the thread for reading from the message queue
         * 
         * Parameters:	void
         * 
         * Returns:		void
        */
        public mainForm()
        {
            InitializeComponent();
            msmq.Formatter = new ActiveXMessageFormatter();
            msmq.MessageReadPropertyFilter.LookupId = true;
            msmq.SynchronizingObject = this;
        }


        /*
         * Function:    btnBulkBegin_Click
         * 
         * Description:	Once the button is clicked, the thread launches and begins reading from the message queue
         * 
         * Parameters:	object sender, eventArgs e
         * 
         * Returns:		void
        */
        private void btnBulkBegin_Click(object sender, EventArgs e)
        {
            bBulkWrite = false;
            bulkThreadRunning = true;

            //Create and launch thread
            bulkReadThread = new Thread(beginBulkRead);
            bulkReadThread.Start();

            //Disable the button
            btnBulkStop.Enabled = true;
            btnBulkBegin.Enabled = false;
        }

        /*
         * Function:    beginBulkRead
         * 
         * Description:	This is the threaded bulk reading method. This will constantly execute reading from the message queue and writing to the database at the appropriate time
         * 
         * Parameters:	void
         * 
         * Returns:		void
        */
        public void beginBulkRead()
        {
            if (bulkThreadRunning == true)
            {
                //Checking computer name / error checking
                if (computerName == "")
                {
                     MessageBox.Show("Unable to retrieve computer name for queue server");
                     killTheBulkRead();
                }
                else
                {
                    //Everything is good, lets begin. Set up a few variables.
                    msmq.Path = "Formatname:Direct=os:" + computerName + queueName;
                    int absoluteMax = 10000;
                    int max = 0;
                    int currentCount = 0;
                    int queueCount = 0;
                    List<YoYoEntity> yoyoDataList = new List<YoYoEntity>();
                    bBulkWrite = true;

                    //The thread heart 
                    while (bBulkWrite)
                    {
                        try
                        {
                            //Check how many items are in the queue
                            queueCount = GetMessageCount(msmq);

                            if (chkboxCount.Checked)
                            {
                                txtboxCountDisplay.Text = queueCount.ToString();
                                Application.DoEvents();
                            }

                            //If it's greater than the absolute max then we have to up our processing power
                            if (queueCount > absoluteMax)
                            {
                                max = absoluteMax;
                            }
                            //otherwise we're good to carry on as usual 
                            else
                            {
                                max = queueCount;
                            }

                            while (currentCount < max)
                            {
                                theErrorMessage = "Reading from queue...";

                                //Read from the queue
                                System.Messaging.Message msg = msmq.Receive(new TimeSpan(0));
                                if (msg != null)
                                {
                                    //Write to the datatable
                                    string[] yoyoData = msg.Body.ToString().Split(',');
                                    YoYoEntity yoyo = new YoYoEntity();
                                    yoyo.YoYoID = yoyoData[1];
                                    yoyo.WorkArea = yoyoData[0];
                                    yoyo.LineNumber = yoyoData[2];
                                    yoyo.ProdState = yoyoData[3];
                                    yoyo.InspectionDecision = yoyoData[4];
                                    yoyo.DateTimeOfCompletion = Convert.ToDateTime(yoyoData[5]);
                                    yoyoDataList.Add(yoyo);
                                    currentCount++;
                                }
                            }
                            //Write to the database
                            dal.BulkWriteYoYoData(yoyoDataList);
                            //Clear and begin again
                            yoyoDataList.Clear();
                            currentCount = 0;
                            Application.DoEvents();
                        }

                        catch (Exception ex)
                        {
                            theErrorMessage = "Error Message:\r\n" + ex.Message.ToString();
                        }
                    }
                }
            }
        }

        /*
         * Function:    GetMessageCount
         * 
         * Description:	Gets the amount of messages that are within the message queue 
         * 
         * Parameters:	MessageQueue m
         * 
         * Returns:		void
        */
        private int GetMessageCount(MessageQueue m)
        {
            Int32 count = 0;
            //Increments the counter based on the number of items
            MessageEnumerator msgEnum = m.GetMessageEnumerator2();
            while (msgEnum.MoveNext(new TimeSpan(0, 0, 0)))
            {
                count++;
            }
            return count;
        }

        /*
         * Function:    Form1_Load
         * 
         * Description:	When the form loads get the computer name
         * 
         * Parameters:	object sender, EventArgs e
         * 
         * Returns:		void
        */
        private void Form1_Load(object sender, EventArgs e)
        {
            computerName = System.Windows.Forms.SystemInformation.ComputerName;
        }

        /*
         * Function:    Form1_FormClosing
         * 
         * Description:	When the form closes kill the thread
         * 
         * Parameters:	object sender, FormClosingEventArgs e
         * 
         * Returns:		void
        */
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            killTheBulkRead();
        }

        /*
         * Function:    btnBulkStop_Click
         * 
         * Description: When the stop button is pressed kill the bulkRead thread.
         * 
         * Parameters:	object sender, EventArgs e
         * 
         * Returns:		void
        */
        private void btnBulkStop_Click(object sender, EventArgs e)
        {
            killTheBulkRead();
        }

        /*
         * Function:    killTheBulkRead
         * 
         * Description: Set the volatile bools for the thread to false so the thread dies.
         * 
         * Parameters:	void
         * 
         * Returns:		void
        */
        private void killTheBulkRead()
        {
            theErrorMessage = "Reading stopped...";
            bBulkWrite = false;
            bulkThreadRunning = false;
            btnBulkStop.Enabled = false;
            btnBulkBegin.Enabled = true;
        }


        /*
         * Function:    timerUserFeedback_Tick
         * 
         * Description: Every half a second the timer ticks to update the user with any error messages.
         * 
         * Parameters:	void
         * 
         * Returns:		void
        */
        private void timerUserFeedback_Tick(object sender, EventArgs e)
        {
            txtboxErrorMessage.Text = theErrorMessage;
        }
    }
}
