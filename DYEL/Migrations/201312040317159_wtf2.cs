namespace DYEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wtf2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Followers",
                c => new
                    {
                        FollowerId = c.String(nullable: false, maxLength: 128),
                        FolloweeId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.FollowerId, t.FolloweeId });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Followers");
        }
    }
}
