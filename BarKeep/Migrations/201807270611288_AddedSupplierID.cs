namespace BarKeep.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSupplierID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bottles", "Supplier_SupplierID", "dbo.Suppliers");
            DropIndex("dbo.Bottles", new[] { "Supplier_SupplierID" });
            RenameColumn(table: "dbo.Bottles", name: "Supplier_SupplierID", newName: "SupplierID");
            AlterColumn("dbo.Bottles", "SupplierID", c => c.Int(nullable: false));
            CreateIndex("dbo.Bottles", "SupplierID");
            AddForeignKey("dbo.Bottles", "SupplierID", "dbo.Suppliers", "SupplierID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bottles", "SupplierID", "dbo.Suppliers");
            DropIndex("dbo.Bottles", new[] { "SupplierID" });
            AlterColumn("dbo.Bottles", "SupplierID", c => c.Int());
            RenameColumn(table: "dbo.Bottles", name: "SupplierID", newName: "Supplier_SupplierID");
            CreateIndex("dbo.Bottles", "Supplier_SupplierID");
            AddForeignKey("dbo.Bottles", "Supplier_SupplierID", "dbo.Suppliers", "SupplierID");
        }
    }
}
