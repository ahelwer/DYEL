namespace DYEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wtf5 : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FitnessLocations");
        }
    }
}
