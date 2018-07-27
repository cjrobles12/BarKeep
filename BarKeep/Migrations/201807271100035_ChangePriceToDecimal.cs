namespace BarKeep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangePriceToDecimal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Bottles", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Bottles", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Bottles", "Price", c => c.Int(nullable: false));
            AlterColumn("dbo.Bottles", "Cost", c => c.Int(nullable: false));
        }
    }
}
