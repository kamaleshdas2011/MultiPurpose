namespace MultiPurpose.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seq1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Places", "Sequence", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Places", "Sequence", c => c.Int(nullable: false));
        }
    }
}
