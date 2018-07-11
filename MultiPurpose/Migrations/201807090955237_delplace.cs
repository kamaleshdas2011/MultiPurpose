namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class delplace : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Places", "StateId", "dbo.States");
            DropIndex("dbo.Places", new[] { "StateId" });
            AlterColumn("dbo.Places", "StateId", c => c.Int());
            CreateIndex("dbo.Places", "StateId");
            AddForeignKey("dbo.Places", "StateId", "dbo.States", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Places", "StateId", "dbo.States");
            DropIndex("dbo.Places", new[] { "StateId" });
            AlterColumn("dbo.Places", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Places", "StateId");
            AddForeignKey("dbo.Places", "StateId", "dbo.States", "id", cascadeDelete: true);
        }
    }
}
