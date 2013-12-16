namespace DYEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sessionstarttime : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sessions", "StartTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sessions", "StartTime");
        }
    }
}
