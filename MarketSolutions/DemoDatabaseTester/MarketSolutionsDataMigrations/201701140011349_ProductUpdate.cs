namespace DemoDatabaseTester.MarketSolutionsDataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductUpdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Products", "ProductCategoryID", "dbo.ProductCategories");
            DropForeignKey("dbo.ProductInventories", "Product_Id", "dbo.Products");
            DropIndex("dbo.Products", new[] { "ProductCategoryID" });
            DropIndex("dbo.ProductInventories", new[] { "Product_Id" });
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.ProductInventories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductInventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        Quantity = c.Int(nullable: false),
                        Product_Id = c.Int(),
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
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductCategoryName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ProductInventories", "Product_Id");
            CreateIndex("dbo.Products", "ProductCategoryID");
            AddForeignKey("dbo.ProductInventories", "Product_Id", "dbo.Products", "Id");
            AddForeignKey("dbo.Products", "ProductCategoryID", "dbo.ProductCategories", "Id", cascadeDelete: true);
        }
    }
}
