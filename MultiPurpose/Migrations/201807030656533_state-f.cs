namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class statef : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Places", "State_id", "dbo.States");
            DropIndex("dbo.Places", new[] { "State_id" });
            RenameColumn(table: "dbo.Places", name: "State_id", newName: "StateId");
            AlterColumn("dbo.Places", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Places", "StateId");
            AddForeignKey("dbo.Places", "StateId", "dbo.States", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "StateId", "dbo.States");
            DropIndex("dbo.Places", new[] { "StateId" });
            AlterColumn("dbo.Places", "StateId", c => c.Int());
            RenameColumn(table: "dbo.Places", name: "StateId", newName: "State_id");
            CreateIndex("dbo.Places", "State_id");
            AddForeignKey("dbo.Places", "State_id", "dbo.States", "id");
        }
    }
}
