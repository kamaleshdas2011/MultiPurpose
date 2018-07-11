namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photo2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "Places_Id", "dbo.Places");
            DropIndex("dbo.Photos", new[] { "Places_Id" });
            RenameColumn(table: "dbo.Photos", name: "Places_Id", newName: "PlaceId");
            AlterColumn("dbo.Photos", "PlaceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Photos", "PlaceId");
            AddForeignKey("dbo.Photos", "PlaceId", "dbo.Places", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "PlaceId", "dbo.Places");
            DropIndex("dbo.Photos", new[] { "PlaceId" });
            AlterColumn("dbo.Photos", "PlaceId", c => c.Int());
            RenameColumn(table: "dbo.Photos", name: "PlaceId", newName: "Places_Id");
            CreateIndex("dbo.Photos", "Places_Id");
            AddForeignKey("dbo.Photos", "Places_Id", "dbo.Places", "Id");
        }
    }
}
