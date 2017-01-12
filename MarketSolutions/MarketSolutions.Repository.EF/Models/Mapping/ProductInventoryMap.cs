using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MarketSolutions.Repository.EF.Models.Mapping
{
    public class ProductInventoryMap : EntityTypeConfiguration<ProductInventory>
    {
        public ProductInventoryMap()
        {
            // Primary Key
            this.HasKey(t => t.ProductInventoryID);

            // Properties
            // Table & Column Mappings
            this.ToTable("ProductInventory", "Production");
            this.Property(t => t.ProductInventoryID).HasColumnName("ProductInventoryID");
            this.Property(t => t.ProductID).HasColumnName("ProductID");
            this.Property(t => t.EntryDate).HasColumnName("EntryDate");
            this.Property(t => t.Quantity).HasColumnName("Quantity");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.ProductInventories)
                .HasForeignKey(d => d.ProductID);

        }
    }
}
