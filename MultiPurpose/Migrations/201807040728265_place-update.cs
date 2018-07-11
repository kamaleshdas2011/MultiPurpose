namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class placeupdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Places", "title", c => c.String());
            AddColumn("dbo.Places", "titleColor", c => c.String());
            AddColumn("dbo.Places", "textColor", c => c.String());
            AddColumn("dbo.Places", "col4", c => c.Boolean(nullable: false));
            AddColumn("dbo.Places", "col6", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "col6");
            DropColumn("dbo.Places", "col4");
            DropColumn("dbo.Places", "textColor");
            DropColumn("dbo.Places", "titleColor");
            DropColumn("dbo.Places", "title");
        }
    }
}
