namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullplaceid : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Photos", "PlaceId", "dbo.Places");
            DropIndex("dbo.Photos", new[] { "PlaceId" });
            AlterColumn("dbo.Photos", "PlaceId", c => c.Int());
            CreateIndex("dbo.Photos", "PlaceId");
            AddForeignKey("dbo.Photos", "PlaceId", "dbo.Places", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "PlaceId", "dbo.Places");
            DropIndex("dbo.Photos", new[] { "PlaceId" });
            AlterColumn("dbo.Photos", "PlaceId", c => c.Int(nullable: false));
            CreateIndex("dbo.Photos", "PlaceId");
            AddForeignKey("dbo.Photos", "PlaceId", "dbo.Places", "Id", cascadeDelete: true);
        }
    }
}
