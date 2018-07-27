namespace BarKeep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotesToBottle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bottles", "Notes", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bottles", "Notes");
        }
    }
}
