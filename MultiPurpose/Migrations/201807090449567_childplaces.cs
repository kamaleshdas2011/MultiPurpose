namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class childplaces : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChildPlaces",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Places_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.Places_Id })
                .ForeignKey("dbo.Places", t => t.Id)
                .ForeignKey("dbo.Places", t => t.Places_Id)
                .Index(t => t.Id)
                .Index(t => t.Places_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ChildPlaces", "Places_Id", "dbo.Places");
            DropForeignKey("dbo.ChildPlaces", "Id", "dbo.Places");
            DropIndex("dbo.ChildPlaces", new[] { "Places_Id" });
            DropIndex("dbo.ChildPlaces", new[] { "Id" });
            DropTable("dbo.ChildPlaces");
        }
    }
}
