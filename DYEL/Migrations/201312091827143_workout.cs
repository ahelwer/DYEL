namespace DYEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workout : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Workouts",
                c => new
                    {
                        WorkoutId = c.Guid(nullable: false),
                        PersonId = c.String(),
                        LocationId = c.Guid(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Description = c.String(),
                        Focus = c.String(),
                    })
                .PrimaryKey(t => t.WorkoutId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Workouts");
        }
    }
}
