using MarketSolutions.Production.Domain;
using MarketSolutions.Production.Repository.EF.Models.Mappings;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.Repository.EF
{
    public class ProductionContext : DbContext
    {
        public ProductionContext() : base("Name=StoreContext")
        { }

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductInventory> ProductInventories { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ProductionContext>(null);

            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductCategoryMap());
            modelBuilder.Configurations.Add(new ProductInventoryMap());

        }
    }
}
