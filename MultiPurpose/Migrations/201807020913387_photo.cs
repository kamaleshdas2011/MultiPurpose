namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class photo : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Photos", "PlacesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Photos", "PlacesId");
            AddForeignKey("dbo.Photos", "PlacesId", "dbo.Places", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Photos", "PlacesId", "dbo.Places");
            DropIndex("dbo.Photos", new[] { "PlacesId" });
            DropColumn("dbo.Photos", "PlacesId");
        }
    }
}
