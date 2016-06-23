namespace EMS_PSS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class five : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EMS_Person", "First_Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.EMS_Person", "Date_Of_Birth", c => c.String(nullable: false));
            AlterColumn("dbo.EMS_Person", "Social_Insurance_Number", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EMS_Person", "Social_Insurance_Number", c => c.String());
            AlterColumn("dbo.EMS_Person", "Date_Of_Birth", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EMS_Person", "First_Name", c => c.String(maxLength: 50));
        }
    }
}
