namespace DYEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wtf : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Posts");
            DropTable("dbo.Comments");
        }
    }
}
