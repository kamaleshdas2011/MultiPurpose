namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class color : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FontFamilies", "Color", c => c.String());
            AddColumn("dbo.Places", "text", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Places", "text");
            DropColumn("dbo.FontFamilies", "Color");
        }
    }
}
