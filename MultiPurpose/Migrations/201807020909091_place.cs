namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class place : DbMigration
    {
        public override void Up()
        {
            
            CreateTable(
                "dbo.Photos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Photo = c.Binary(),
                        Name = c.String(),
                        Primary = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Places",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        State_id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.States", t => t.State_id)
                .Index(t => t.State_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "State_id", "dbo.States");
            DropIndex("dbo.Places", new[] { "State_id" });
            DropTable("dbo.Places");
            DropTable("dbo.Photos");
        }
    }
}
