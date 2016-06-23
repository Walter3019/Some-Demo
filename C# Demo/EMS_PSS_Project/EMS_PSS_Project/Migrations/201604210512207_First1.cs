namespace EMS_PSS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class First1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EMS_FullTimeEmployee", "Date_Of_Termination", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EMS_FullTimeEmployee", "Date_Of_Termination", c => c.DateTime(nullable: false));
        }
    }
}
