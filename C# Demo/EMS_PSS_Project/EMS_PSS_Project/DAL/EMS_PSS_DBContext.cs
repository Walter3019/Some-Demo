using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using EMS_PSS_Project.Models;

namespace EMS_PSS_Project.DAL
{
    public class EMS_PSS_DBContext : DbContext
    {
        public EMS_PSS_DBContext()
            : base("EMSPSSContext")
        {
        }

        public DbSet<EMS_SecurityLevel> EMS_SecurityLevel { get; set; }
        public DbSet<EMS_Company> EMS_Company { get; set; }
        public DbSet<EMS_User> EMS_Users { get; set; }      
        public DbSet<EMS_Person> EMS_Person { get; set; }
        public DbSet<EMS_FullTimeEmployee> EMS_Fulltime { get; set; }       
    }
}