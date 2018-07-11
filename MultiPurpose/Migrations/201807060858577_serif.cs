namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class serif : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FontFamilies", "Serif", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FontFamilies", "Serif");
        }
    }
}
