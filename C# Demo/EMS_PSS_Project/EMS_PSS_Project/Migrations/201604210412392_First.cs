namespace EMS_PSS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EMS_Company",
                c => new
                    {
                        Company_ID = c.Int(nullable: false, identity: true),
                        CompanyDescription = c.String(),
                    })
                .PrimaryKey(t => t.Company_ID);
            
            CreateTable(
                "dbo.EMS_FullTimeEmployee",
                c => new
                    {
                        Fulltime_Employee_ID = c.Int(nullable: false, identity: true),
                        Person_ID = c.Int(nullable: false),
                        Company_ID = c.Int(nullable: false),
                        Date_Of_Hire = c.DateTime(nullable: false),
                        Date_Of_Termination = c.DateTime(nullable: false),
                        Reason_For_Leaving = c.String(),
                        Salary = c.Single(nullable: false),
                        Status = c.Boolean(nullable: false),
                        Completion = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Fulltime_Employee_ID)
                .ForeignKey("dbo.EMS_Company", t => t.Company_ID, cascadeDelete: true)
                .ForeignKey("dbo.EMS_Person", t => t.Person_ID, cascadeDelete: true)
                .Index(t => t.Person_ID)
                .Index(t => t.Company_ID);
            
            CreateTable(
                "dbo.EMS_Person",
                c => new
                    {
                        Person_ID = c.Int(nullable: false, identity: true),
                        First_Name = c.String(maxLength: 50),
                        Last_Name = c.String(maxLength: 50),
                        Date_Of_Birth = c.DateTime(nullable: false),
                        Social_Insurance_Number = c.String(),
                    })
                .PrimaryKey(t => t.Person_ID);
            
            CreateTable(
                "dbo.EMS_SecurityLevel",
                c => new
                    {
                        SecurityLevel_ID = c.Int(nullable: false, identity: true),
                        ScurityDescription = c.String(),
                    })
                .PrimaryKey(t => t.SecurityLevel_ID);
            
            CreateTable(
                "dbo.EMS_User",
                c => new
                    {
                        User_ID = c.Int(nullable: false, identity: true),
                        First_Name = c.String(),
                        Last_Name = c.String(),
                        SecurityLevel_ID = c.Int(nullable: false),
                        User_Name = c.String(nullable: false),
                        PassWord = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.User_ID)
                .ForeignKey("dbo.EMS_SecurityLevel", t => t.SecurityLevel_ID, cascadeDelete: true)
                .Index(t => t.SecurityLevel_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.EMS_User", "SecurityLevel_ID", "dbo.EMS_SecurityLevel");
            DropForeignKey("dbo.EMS_FullTimeEmployee", "Person_ID", "dbo.EMS_Person");
            DropForeignKey("dbo.EMS_FullTimeEmployee", "Company_ID", "dbo.EMS_Company");
            DropIndex("dbo.EMS_User", new[] { "SecurityLevel_ID" });
            DropIndex("dbo.EMS_FullTimeEmployee", new[] { "Company_ID" });
            DropIndex("dbo.EMS_FullTimeEmployee", new[] { "Person_ID" });
            DropTable("dbo.EMS_User");
            DropTable("dbo.EMS_SecurityLevel");
            DropTable("dbo.EMS_Person");
            DropTable("dbo.EMS_FullTimeEmployee");
            DropTable("dbo.EMS_Company");
        }
    }
}
