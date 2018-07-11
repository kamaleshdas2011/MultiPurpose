namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class type : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FontFamilies", "Type", c => c.String());
            DropColumn("dbo.FontFamilies", "Serif");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FontFamilies", "Serif", c => c.Boolean(nullable: false));
            DropColumn("dbo.FontFamilies", "Type");
        }
    }
}
