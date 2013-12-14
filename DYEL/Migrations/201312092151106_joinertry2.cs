namespace DYEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class joinertry2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Joiners",
                c => new
                    {
                        PersonId = c.String(nullable: false, maxLength: 128),
                        WorkoutId = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonId, t.WorkoutId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Joiners");
        }
    }
}
