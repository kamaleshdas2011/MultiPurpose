namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class colors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "stateColor", c => c.String());
            DropColumn("dbo.FontFamilies", "Color");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FontFamilies", "Color", c => c.String());
            DropColumn("dbo.Places", "stateColor");
        }
    }
}
