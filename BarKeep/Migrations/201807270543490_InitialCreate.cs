namespace BarKeep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bottles",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BottleType = c.Int(nullable: false),
                        Volume = c.Int(nullable: false),
                        Cost = c.Int(nullable: false),
                        Price = c.Int(nullable: false),
                        Par = c.Int(nullable: false),
                        OnHand = c.Int(nullable: false),
                        Supplier_SupplierID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Suppliers", t => t.Supplier_SupplierID)
                .Index(t => t.Supplier_SupplierID);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false, identity: true),
                        BottleID = c.Int(nullable: false),
                        SupplierName = c.String(),
                        SupplierPhone = c.String(),
                        SupplierAddress = c.String(),
                        Notes = c.String(),
                    })
                .PrimaryKey(t => t.SupplierID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bottles", "Supplier_SupplierID", "dbo.Suppliers");
            DropIndex("dbo.Bottles", new[] { "Supplier_SupplierID" });
            DropTable("dbo.Suppliers");
            DropTable("dbo.Bottles");
        }
    }
}
