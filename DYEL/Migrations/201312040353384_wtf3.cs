namespace DYEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wtf3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foci",
                c => new
                    {
                        FocusId = c.String(nullable: false, maxLength: 128),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.FocusId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Foci");
        }
    }
}
