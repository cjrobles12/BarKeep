namespace BarKeep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSupplier : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bottles", "SupplierID", "dbo.Suppliers");
            DropIndex("dbo.Bottles", new[] { "SupplierID" });
            RenameColumn(table: "dbo.Bottles", name: "SupplierID", newName: "Supplier_SupplierID");
            AlterColumn("dbo.Bottles", "Supplier_SupplierID", c => c.Int());
            CreateIndex("dbo.Bottles", "Supplier_SupplierID");
            AddForeignKey("dbo.Bottles", "Supplier_SupplierID", "dbo.Suppliers", "SupplierID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bottles", "Supplier_SupplierID", "dbo.Suppliers");
            DropIndex("dbo.Bottles", new[] { "Supplier_SupplierID" });
            AlterColumn("dbo.Bottles", "Supplier_SupplierID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Bottles", name: "Supplier_SupplierID", newName: "SupplierID");
            CreateIndex("dbo.Bottles", "SupplierID");
            AddForeignKey("dbo.Bottles", "SupplierID", "dbo.Suppliers", "SupplierID", cascadeDelete: true);
        }
    }
}
