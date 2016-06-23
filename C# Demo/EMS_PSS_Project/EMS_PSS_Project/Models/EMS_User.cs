/*
 * File Name : SecurityLevel.cs
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
using System.Linq;
using System.Web;

namespace EMS_PSS_Project.Models
{
    /*
     * Class Name : EMS_User.
     * Class Description : The EMS_Users class will keep track of and containt 
	 *				       all EMS-PSS General and Administrative users' information
     */
    public class EMS_User
    {
        [Key]
        public int User_ID { get; set; }
        public String First_Name { get; set; }
        public String Last_Name { get; set; }
        public int SecurityLevel_ID { get; set; }
        [Required]
        public String User_Name { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public String PassWord { get; set; }

        public virtual EMS_SecurityLevel SecurityLevel { get; set; }
    }
}