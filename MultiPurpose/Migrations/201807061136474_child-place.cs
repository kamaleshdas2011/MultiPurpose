namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class childplace : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "ParentPlace_Id", c => c.Int());
            CreateIndex("dbo.Places", "ParentPlace_Id");
            AddForeignKey("dbo.Places", "ParentPlace_Id", "dbo.Places", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "ParentPlace_Id", "dbo.Places");
            DropIndex("dbo.Places", new[] { "ParentPlace_Id" });
            DropColumn("dbo.Places", "ParentPlace_Id");
        }
    }
}
