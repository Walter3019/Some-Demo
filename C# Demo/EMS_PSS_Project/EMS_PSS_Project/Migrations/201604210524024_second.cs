namespace EMS_PSS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EMS_FullTimeEmployee", "Date_Of_Hire", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EMS_FullTimeEmployee", "Date_Of_Hire", c => c.DateTime(nullable: false));
        }
    }
}
