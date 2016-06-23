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
     * Class Name : EMS_SecurityLevel.
     * Class Description : The EMS_SecurityLevel class will Keep track of and containt
     *					   all level of security including General and Admin.
     */
    public class EMS_SecurityLevel
    {
        [Key]
        public int SecurityLevel_ID { get; set; }
        public String ScurityDescription { get; set; }
    }
}