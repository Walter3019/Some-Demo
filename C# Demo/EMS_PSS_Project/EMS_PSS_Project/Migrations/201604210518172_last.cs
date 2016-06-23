namespace EMS_PSS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class last : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EMS_FullTimeEmployee", "Date_Of_Termination", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EMS_FullTimeEmployee", "Date_Of_Termination", c => c.String(nullable: false));
        }
    }
}
