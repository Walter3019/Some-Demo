using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Messaging;
using System.Data.SqlClient;

namespace SampleQueueReader
{
    public partial class frmMain : Form
    {
        MessageQueue msmq = new MessageQueue();
        Boolean bRead = false;
        String queueName = "\\private$\\yoyo";
        public frmMain()
        {
            InitializeComponent();
            msmq.Formatter = new ActiveXMessageFormatter();
            msmq.MessageReadPropertyFilter.LookupId = true;
            msmq.SynchronizingObject = this;
            msmq.ReceiveCompleted += new ReceiveCompletedEventHandler(msmq_ReceiveCompleted);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            lstQueueData.Items.Clear();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtQueueServer.Text = System.Windows.Forms.SystemInformation.ComputerName;
            IsRunning(false);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (txtQueueServer.Text == "")
            {
                MessageBox.Show("Message Queue Server required");
            }
            else
            {
                msmq.Path = "Formatname:Direct=os:" + txtQueueServer.Text + queueName;
                bRead = true;
                msmq.BeginReceive();
                IsRunning(true);
            }

        }

        void msmq_ReceiveCompleted(object sender, ReceiveCompletedEventArgs e)
        {
            try
            {
                //lstQueueData.Items.Insert(0,e.Message.Body.ToString());
                msmq.EndReceive(e.AsyncResult);
                if (chkCount.Checked)
                {
                    txtRemaining.Text = GetMessageCount(msmq).ToString();

                    string theItem = e.Message.Body.ToString();

                    string[] arrayOfStrings = theItem.Split(',');

                    string workStation = arrayOfStrings[0];
                    string yoYoID = arrayOfStrings[1];
                    string lineNumber = arrayOfStrings[2];
                    string inspectionType = arrayOfStrings[3];
                    string issue = arrayOfStrings[4];
                    DateTime timeProcessed = Convert.ToDateTime(arrayOfStrings[5]);

                    string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=yoyo;Persist Security Info=True;User ID=sa;Password=Conestoga1";
                    SqlConnection conn;

                    conn = new SqlConnection(connectionString);
                    SqlCommand sqlCmd = new SqlCommand(
                        "INSERT INTO yoyoLog "
                        + "(WorkArea, YoYoID, LineNumber, ProdState, InspectionDecision, DateTimeOfCompletion) "
                        + "VALUES("
                        + "'" + workStation + "', "
                        + "'" + yoYoID + "', "
                        + "'" + lineNumber + "', "
                        + "'" + inspectionType + "', "
                        + "'" + issue + "', "
                        + "'" + timeProcessed + "')"
                        , conn);

                    try
                    {
                        conn.Open();
                        sqlCmd.ExecuteNonQuery();
                        conn.Close();
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show(exception.Message);
                    }

                    Application.DoEvents();
                }
                System.Threading.Thread.Sleep(1);
                if (bRead)
                {
                    msmq.BeginReceive();
                }
            }
            catch
            {
                MessageBox.Show("Unhandled Exception");
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            bRead = false;
            IsRunning(false);
        }

        private void btnClear_Click_1(object sender, EventArgs e)
        {
            lstQueueData.Items.Clear();
        }

        private int GetMessageCount(MessageQueue m)
        {
            Int32 count = 0;
            MessageEnumerator msgEnum = m.GetMessageEnumerator2();
            while (msgEnum.MoveNext(new TimeSpan(0, 0, 0)))
            {
                count++;
            }
            return count;
        }

        private void IsRunning(Boolean state)
        {
            if (state == true)
            {
                btnStart.Enabled = false;
                btnStop.Enabled = true;
                btnSingleRead.Enabled = false;
            }
            else
            {
                btnStart.Enabled = true;
                btnStop.Enabled = false ;
                btnSingleRead.Enabled = true;
            }
        }

        private void btnSingleRead_Click(object sender, EventArgs e)
        {
            string theItem;

            string workStation;
            string yoYoID;
            string lineNumber;
            string inspectionType;
            string issue;
            DateTime timeProcessed;

            if (txtQueueServer.Text == "")
            {
                MessageBox.Show("Message Queue Server required");
            }
            else
            {
                msmq.Path = "Formatname:Direct=os:" + txtQueueServer.Text + queueName;
                try
                {
                    System.Messaging.Message msg = msmq.Receive(new TimeSpan(0));
                    if (msg != null)
                    {
                        theItem = msg.Body.ToString();

                        string[] arrayOfStrings = theItem.Split(',');

                        workStation = arrayOfStrings[0];
                        yoYoID = arrayOfStrings[1];
                        lineNumber = arrayOfStrings[2];
                        inspectionType = arrayOfStrings[3];
                        issue = arrayOfStrings[4];
                        timeProcessed =  Convert.ToDateTime(arrayOfStrings[5]);

                        string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=yoyo;Persist Security Info=True;User ID=sa;Password=Conestoga1";
                        SqlConnection conn;

                        conn = new SqlConnection(connectionString);
                        SqlCommand sqlCmd = new SqlCommand(
                            "INSERT INTO yoyoLog " 
                            + "(WorkArea, YoYoID, LineNumber, ProdState, InspectionDecision, DateTimeOfCompletion) "
                            + "VALUES("
                            + "'" + workStation + "', "
                            + "'" + yoYoID + "', "
                            + "'" + lineNumber + "', "
                            + "'" + inspectionType + "', "
                            + "'" + issue + "', "
                            + "'" + timeProcessed + "')"
                            ,conn);

                        try
                        {
                            conn.Open();
                            sqlCmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        catch(Exception exception)
                        {
                            MessageBox.Show(exception.Message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Cannot read - probably empty queue or queue non existent");
                }
            }

        }

        private void btnPurgeQ_Click(object sender, EventArgs e)
        {
            msmq.Purge();
        }

    }
}
