namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class childplace1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Places", name: "ParentPlace_Id", newName: "ParentPlaceId");
            RenameIndex(table: "dbo.Places", name: "IX_ParentPlace_Id", newName: "IX_ParentPlaceId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Places", name: "IX_ParentPlaceId", newName: "IX_ParentPlace_Id");
            RenameColumn(table: "dbo.Places", name: "ParentPlaceId", newName: "ParentPlace_Id");
        }
    }
}
