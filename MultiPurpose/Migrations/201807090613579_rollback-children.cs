namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rollbackchildren : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ChildPlaces", "Id", "dbo.Places");
            DropForeignKey("dbo.ChildPlaces", "Places_Id", "dbo.Places");
            DropIndex("dbo.ChildPlaces", new[] { "Id" });
            DropIndex("dbo.ChildPlaces", new[] { "Places_Id" });
            AddColumn("dbo.Places", "ParentPlaceId", c => c.Int());
            CreateIndex("dbo.Places", "ParentPlaceId");
            AddForeignKey("dbo.Places", "ParentPlaceId", "dbo.Places", "Id");
            DropColumn("dbo.Places", "Sequence");
            DropTable("dbo.ChildPlaces");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ChildPlaces",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Places_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Id, t.Places_Id });
            
            AddColumn("dbo.Places", "Sequence", c => c.Int());
            DropForeignKey("dbo.Places", "ParentPlaceId", "dbo.Places");
            DropIndex("dbo.Places", new[] { "ParentPlaceId" });
            DropColumn("dbo.Places", "ParentPlaceId");
            CreateIndex("dbo.ChildPlaces", "Places_Id");
            CreateIndex("dbo.ChildPlaces", "Id");
            AddForeignKey("dbo.ChildPlaces", "Places_Id", "dbo.Places", "Id");
            AddForeignKey("dbo.ChildPlaces", "Id", "dbo.Places", "Id");
        }
    }
}
