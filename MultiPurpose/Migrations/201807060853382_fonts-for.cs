namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fontsfor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "PlaceFontFamily_Id", c => c.Int());
            AddColumn("dbo.Places", "StateFontFamily_Id", c => c.Int());
            CreateIndex("dbo.Places", "PlaceFontFamily_Id");
            CreateIndex("dbo.Places", "StateFontFamily_Id");
            AddForeignKey("dbo.Places", "PlaceFontFamily_Id", "dbo.FontFamilies", "Id");
            AddForeignKey("dbo.Places", "StateFontFamily_Id", "dbo.FontFamilies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "StateFontFamily_Id", "dbo.FontFamilies");
            DropForeignKey("dbo.Places", "PlaceFontFamily_Id", "dbo.FontFamilies");
            DropIndex("dbo.Places", new[] { "StateFontFamily_Id" });
            DropIndex("dbo.Places", new[] { "PlaceFontFamily_Id" });
            DropColumn("dbo.Places", "StateFontFamily_Id");
            DropColumn("dbo.Places", "PlaceFontFamily_Id");
        }
    }
}
