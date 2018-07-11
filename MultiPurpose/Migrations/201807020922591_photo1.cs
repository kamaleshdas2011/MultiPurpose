namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photo1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "PlacesId", "dbo.Places");
            DropIndex("dbo.Photos", new[] { "PlacesId" });
            RenameColumn(table: "dbo.Photos", name: "PlacesId", newName: "Places_Id");
            AlterColumn("dbo.Photos", "Places_Id", c => c.Int());
            CreateIndex("dbo.Photos", "Places_Id");
            AddForeignKey("dbo.Photos", "Places_Id", "dbo.Places", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "Places_Id", "dbo.Places");
            DropIndex("dbo.Photos", new[] { "Places_Id" });
            AlterColumn("dbo.Photos", "Places_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Photos", name: "Places_Id", newName: "PlacesId");
            CreateIndex("dbo.Photos", "PlacesId");
            AddForeignKey("dbo.Photos", "PlacesId", "dbo.Places", "Id", cascadeDelete: true);
        }
    }
}
