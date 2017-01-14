namespace DemoDatabaseTester.MarketSolutionsDataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductUpdate2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Production.ProductCategory",
                c => new
                    {
                        ProductCategoryID = c.Int(nullable: false, identity: true),
                        ProductCategoryName = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ProductCategoryID);
            
            CreateTable(
                "Production.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        ProductName = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 255),
                        ProductCategoryID = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discontinued = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID)
                .ForeignKey("Production.ProductCategory", t => t.ProductCategoryID, cascadeDelete: true)
                .Index(t => t.ProductCategoryID);
            
            CreateTable(
                "Production.ProductInventory",
                c => new
                    {
                        ProductInventoryID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        EntryDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductInventoryID)
                .ForeignKey("Production.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Production.ProductInventory", "ProductID", "Production.Product");
            DropForeignKey("Production.Product", "ProductCategoryID", "Production.ProductCategory");
            DropIndex("Production.ProductInventory", new[] { "ProductID" });
            DropIndex("Production.Product", new[] { "ProductCategoryID" });
            DropTable("Production.ProductInventory");
            DropTable("Production.Product");
            DropTable("Production.ProductCategory");
        }
    }
}
