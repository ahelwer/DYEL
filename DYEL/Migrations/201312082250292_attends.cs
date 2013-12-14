namespace DYEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class attends : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attends",
                c => new
                    {
                        PersonId = c.String(nullable: false, maxLength: 128),
                        LocationId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonId, t.LocationId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Attends");
        }
    }
}
