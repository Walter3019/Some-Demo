/*
 * File Name : EMS_Person.cs
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
     * Class Name : EMS_Person.
     * Class Description : The Person Class keep track of and contains all person specific informatin including the person ID, First Name, Last Name,
     *                     Date of birth, and SIN.
     */
    public class EMS_Person
    {
        [Key]
        public int Person_ID { get; set; }
        [Required, StringLength(50)]
        public String First_Name { get; set; }
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public String Last_Name { get; set; }
        [Required, Display(Name = "Date of Birth"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public String Date_Of_Birth { get; set; }
        [Required, Display(Name = "SIN"), DisplayFormat(DataFormatString = "{0:DDD-DDD-DDD}")]
        public String Social_Insurance_Number { get; set; }
    }
}