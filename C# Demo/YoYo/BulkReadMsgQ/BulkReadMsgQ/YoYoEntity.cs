/*
 * Authors:          Lingchen Meng / Xuan Zhang
 * Date of creation: March 16, 2016
 * File Name:        yoyoEntity.cs
 * Description:      The yoyos being read from the message queue are all being proccessed as entities.
 * 
 * Last Modified:    April 14, 2016
*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkReadMsgQ
{
    public class YoYoEntity
    {
        //Getters and setters for all the yoyo entities.
        public string YoYoID { get; set; }
        public string WorkArea { get; set; }
        public string LineNumber { get; set; }
        public string ProdState { get; set; }
        public string InspectionDecision { get; set; }
        public DateTime DateTimeOfCompletion { get; set; }
    }
}
