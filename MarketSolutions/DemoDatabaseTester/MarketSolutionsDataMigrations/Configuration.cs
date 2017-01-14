namespace DemoDatabaseTester.MarketSolutionsDataMigrations
{
    using MarketSolutions.Production.Repository.EF;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductionContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"MarketSolutionsDataMigrations";
        }

        protected override void Seed(ProductionContext context)
        {
            

        }
    }
}
