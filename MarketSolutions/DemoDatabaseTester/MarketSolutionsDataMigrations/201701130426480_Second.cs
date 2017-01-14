namespace DemoDatabaseTester.MarketSolutionsDataMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProductCategories", "ProductCategoryID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProductCategories", "ProductCategoryID", c => c.Int(nullable: false));
        }
    }
}
