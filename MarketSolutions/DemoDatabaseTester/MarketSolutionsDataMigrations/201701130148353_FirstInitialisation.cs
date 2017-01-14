namespace DemoDatabaseTester.MarketSolutionsDataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstInitialisation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductCategoryID = c.Int(nullable: false),
                        ProductCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ProductCategoryID = c.Int(nullable: false),
                        ProductName = c.String(),
                        Description = c.String(),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Discontinued = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryID, cascadeDelete: true)
                .Index(t => t.ProductCategoryID);
            
            CreateTable(
                "dbo.ProductInventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        ProductInventoryID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductInventories", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductCategoryID", "dbo.ProductCategories");
            DropIndex("dbo.ProductInventories", new[] { "ProductID" });
            DropIndex("dbo.Products", new[] { "ProductCategoryID" });
            DropTable("dbo.ProductInventories");
            DropTable("dbo.Products");
            DropTable("dbo.ProductCategories");
        }
    }
}
