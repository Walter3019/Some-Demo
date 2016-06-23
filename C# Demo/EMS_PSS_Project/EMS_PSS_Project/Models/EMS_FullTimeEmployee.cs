/*
 * File Name : EMS_FullTimeEmployee.cs
 * 
 * Project : INFO2030 - EMS PSS Project
 * 
 * Programmer : Lingchen Meng (Walter) / 6818678 
 *              Xuan Zhang / 5283460 
 *              Geun Young Gil / 6944920 
 *              Markus Rankin / 3379187
 *              
 * First Verson : 2016-04-21
 * 
 * Description : The heart of this project is the re-development of an Employee Management System (EMS). This system will be
 *               capable of keeping track of a number of different employees and employee-types for the huge multinational
 *               Omnicorp Corporation and as well, this time around – employees from other companies. 
 */

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EMS_PSS_Project.Models
{
    /*
     * Class Name : EMS_FullTimeEmployee.
     * Class Description : The Full-time Employee class keeps track of and contains 
	 *					   all Full-time Employees and their personal information, company of employment, 
     *                     SIN, date of hire, date of Termination, Reason_For_Leaving, Salary, status, and completion.
     */
    public class EMS_FullTimeEmployee
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Fulltime_Employee_ID { get; set; }
        public int Person_ID { get; set; }
        public int Company_ID { get; set; }
        [Required, Display(Name = "Date of Hire"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public String Date_Of_Hire { get; set; }
        [Display(Name = "Date of Termination"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public String Date_Of_Termination { get; set; }
        public String Reason_For_Leaving { get; set; }
        public float Salary { get; set; }
        public Boolean Status { get; set; } // inactive or active.
        public Boolean Completion { get; set; } // complete or not.

        public virtual EMS_Person Person { get; set; }
        public virtual EMS_Company Company { get; set; }
    }
}