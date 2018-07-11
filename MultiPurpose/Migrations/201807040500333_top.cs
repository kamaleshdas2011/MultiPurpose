namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class top : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "TopPlace", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "TopPlace");
        }
    }
}
