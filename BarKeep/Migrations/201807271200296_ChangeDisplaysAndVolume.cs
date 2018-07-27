namespace BarKeep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDisplaysAndVolume : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bottles", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Bottles", "Notes", c => c.String(maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bottles", "Notes", c => c.String());
            AlterColumn("dbo.Bottles", "Name", c => c.String());
        }
    }
}
