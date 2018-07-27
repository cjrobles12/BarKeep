namespace BarKeep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FinalChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bottles", "Supplier_SupplierID", "dbo.Suppliers");
            DropIndex("dbo.Bottles", new[] { "Supplier_SupplierID" });
            DropColumn("dbo.Bottles", "Supplier_SupplierID");
            DropTable("dbo.Suppliers");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.Bottles", "Supplier_SupplierID", c => c.Int());
            CreateIndex("dbo.Bottles", "Supplier_SupplierID");
            AddForeignKey("dbo.Bottles", "Supplier_SupplierID", "dbo.Suppliers", "SupplierID");
        }
    }
}
