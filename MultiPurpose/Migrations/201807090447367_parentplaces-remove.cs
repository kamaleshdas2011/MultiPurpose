namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class parentplacesremove : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Places", name: "ParentPlaceId", newName: "ParentPlace_Id");
            RenameIndex(table: "dbo.Places", name: "IX_ParentPlaceId", newName: "IX_ParentPlace_Id");
            AddColumn("dbo.Places", "Sequence", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "Sequence");
            RenameIndex(table: "dbo.Places", name: "IX_ParentPlace_Id", newName: "IX_ParentPlaceId");
            RenameColumn(table: "dbo.Places", name: "ParentPlace_Id", newName: "ParentPlaceId");
        }
    }
}
