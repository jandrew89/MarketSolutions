namespace DemoDatabaseTester.MarketSolutionsDataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductInventory : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductInventories", "ProductID", "dbo.Products");
            DropIndex("dbo.ProductInventories", new[] { "ProductID" });
            RenameColumn(table: "dbo.ProductInventories", name: "ProductID", newName: "Product_Id");
            AlterColumn("dbo.ProductInventories", "Product_Id", c => c.Int());
            CreateIndex("dbo.ProductInventories", "Product_Id");
            AddForeignKey("dbo.ProductInventories", "Product_Id", "dbo.Products", "Id");
            DropColumn("dbo.ProductInventories", "ProductInventoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductInventories", "ProductInventoryID", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProductInventories", "Product_Id", "dbo.Products");
            DropIndex("dbo.ProductInventories", new[] { "Product_Id" });
            AlterColumn("dbo.ProductInventories", "Product_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ProductInventories", name: "Product_Id", newName: "ProductID");
            CreateIndex("dbo.ProductInventories", "ProductID");
            AddForeignKey("dbo.ProductInventories", "ProductID", "dbo.Products", "Id", cascadeDelete: true);
        }
    }
}
