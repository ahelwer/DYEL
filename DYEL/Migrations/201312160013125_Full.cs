namespace DYEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Full : DbMigration
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
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Guid(nullable: false),
                        PostId = c.Guid(nullable: false),
                        PersonId = c.String(),
                        Time = c.DateTime(nullable: false),
                        Text = c.String(),
                    })
                .PrimaryKey(t => t.CommentId);
            
            CreateTable(
                "dbo.FitnessLocations",
                c => new
                    {
                        FitnessLocationId = c.Guid(nullable: false),
                        Name = c.String(),
                        Address = c.String(),
                        Focus = c.String(),
                    })
                .PrimaryKey(t => t.FitnessLocationId);
            
            CreateTable(
                "dbo.Foci",
                c => new
                    {
                        FocusId = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.FocusId);
            
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId });
            
            CreateTable(
                "dbo.Joiners",
                c => new
                    {
                        PersonId = c.String(nullable: false, maxLength: 128),
                        WorkoutId = c.Guid(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PersonId, t.WorkoutId });
            
            CreateTable(
                "dbo.People",
                c => new
                    {
                        PersonId = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                        Gender = c.Int(nullable: false),
                        Age = c.Int(nullable: false),
                        Focus = c.String(),
                    })
                .PrimaryKey(t => t.PersonId);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Guid(nullable: false),
                        PersonId = c.String(),
                        Time = c.DateTime(nullable: false),
                        Text = c.String(),
                        Focus = c.String(),
                    })
                .PrimaryKey(t => t.PostId);
            
            CreateTable(
                "dbo.Sessions",
                c => new
                    {
                        SessionId = c.Guid(nullable: false),
                        PersonId = c.String(),
                    })
                .PrimaryKey(t => t.SessionId);
            
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
            DropTable("dbo.Sessions");
            DropTable("dbo.Posts");
            DropTable("dbo.People");
            DropTable("dbo.Joiners");
            DropTable("dbo.Followers");
            DropTable("dbo.Foci");
            DropTable("dbo.FitnessLocations");
            DropTable("dbo.Comments");
            DropTable("dbo.Attends");
        }
    }
}
