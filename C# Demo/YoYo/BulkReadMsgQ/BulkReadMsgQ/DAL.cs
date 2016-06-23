using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace BulkReadMsgQ
{
    public class DAL
    {
        private SqlConnection conn;
        private SqlCommand sqlCmd;
        private string connectionString;
        private ConnectionStringSettings mySettings;
        private DataTable yoyoData;


        /*
         * Function:    DAL
         * 
         * Description:	The constructor for the DAL class.
         *              
         *              Uses a default connection string to the yoyo table within a SQL Server database.
         * 
         * Parameters:	void
         * 
         * Returns:		void
        */
        public DAL()
        {
            mySettings = ConfigurationManager.ConnectionStrings["YoYoConn"];
            connectionString = mySettings.ConnectionString;
            CreateYoYoDataTable();
        }

        /*
         * Function:    BulkWriteYoYoData
         * 
         * Description:	Writes data in bulk to the SQL Server by popluating a list with yoyo entities from the message que
         * 
         * Parameters:	void
         * 
         * Returns:		void
        */
        public int BulkWriteYoYoData(List<YoYoEntity> yoyos)
        {
            int result = 0;
            conn = new SqlConnection(connectionString);
            SqlBulkCopy sbc = new SqlBulkCopy(conn);
            sbc.DestinationTableName = yoyoData.TableName;
            // Load the datatable with data
            foreach (YoYoEntity yoyo in yoyos)
            {
                DataRow dr = yoyoData.NewRow();
                dr[0] = yoyo.WorkArea;
                dr[1] = yoyo.YoYoID;
                dr[2] = yoyo.LineNumber;
                dr[3] = yoyo.ProdState;
                dr[4] = yoyo.InspectionDecision;
                dr[5] = yoyo.DateTimeOfCompletion;
                yoyoData.Rows.Add(dr);
            }
            // Map the table columns
            foreach (DataColumn dc in yoyoData.Columns)
            {
                sbc.ColumnMappings.Add(dc.ToString(), dc.ToString());
            }
            //Open connection and write
            conn.Open();
            sbc.WriteToServer(yoyoData);
            conn.Close();

            yoyoData.Rows.Clear();

            return result;
        }

        /*
         * Function:    CreateYoYoDataTable
         * 
         * Description:	Creates a data table that holds all the items for the yoyo and mimics the one inside the database
         * 
         * Parameters:	void
         * 
         * Returns:		void
        */
        private void CreateYoYoDataTable()
        {
            yoyoData = new DataTable("YoYoLog");
            DataColumn WorkArea = new DataColumn("WorkArea", Type.GetType("System.String"));
            DataColumn YoYoID = new DataColumn("YoYoID", Type.GetType("System.String"));
            DataColumn LineNumber = new DataColumn("LineNumber", Type.GetType("System.String"));
            DataColumn ProdState = new DataColumn("ProdState", Type.GetType("System.String"));
            DataColumn InspectionDecision = new DataColumn("InspectionDecision", Type.GetType("System.String"));
            DataColumn DateTimeOfCompletion = new DataColumn("DateTimeOfCompletion", Type.GetType("System.DateTime"));
            yoyoData.Columns.Add(WorkArea);
            yoyoData.Columns.Add(YoYoID);
            yoyoData.Columns.Add(LineNumber);
            yoyoData.Columns.Add(ProdState);
            yoyoData.Columns.Add(InspectionDecision);
            yoyoData.Columns.Add(DateTimeOfCompletion);
        }
    }
}

