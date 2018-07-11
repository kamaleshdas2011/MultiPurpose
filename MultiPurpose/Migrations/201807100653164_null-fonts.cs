namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nullfonts : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Places", name: "StateFontFamily_Id", newName: "StateFontFamilyId");
            RenameColumn(table: "dbo.Places", name: "PlaceFontFamily_Id", newName: "TextFontFamilyId");
            RenameIndex(table: "dbo.Places", name: "IX_PlaceFontFamily_Id", newName: "IX_TextFontFamilyId");
            RenameIndex(table: "dbo.Places", name: "IX_StateFontFamily_Id", newName: "IX_StateFontFamilyId");
            AddColumn("dbo.Places", "TitleFontFamilyId", c => c.Int());
            CreateIndex("dbo.Places", "TitleFontFamilyId");
            AddForeignKey("dbo.Places", "TitleFontFamilyId", "dbo.FontFamilies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "TitleFontFamilyId", "dbo.FontFamilies");
            DropIndex("dbo.Places", new[] { "TitleFontFamilyId" });
            DropColumn("dbo.Places", "TitleFontFamilyId");
            RenameIndex(table: "dbo.Places", name: "IX_StateFontFamilyId", newName: "IX_StateFontFamily_Id");
            RenameIndex(table: "dbo.Places", name: "IX_TextFontFamilyId", newName: "IX_PlaceFontFamily_Id");
            RenameColumn(table: "dbo.Places", name: "TextFontFamilyId", newName: "PlaceFontFamily_Id");
            RenameColumn(table: "dbo.Places", name: "StateFontFamilyId", newName: "StateFontFamily_Id");
        }
    }
}
