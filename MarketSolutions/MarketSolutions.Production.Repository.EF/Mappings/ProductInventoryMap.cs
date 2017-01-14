using MarketSolutions.Production.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MarketSolutions.Production.Repository.EF.Models.Mappings
{
    public class ProductInventoryMap : EntityTypeConfiguration<ProductInventory>
    {
        public ProductInventoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            // Table & Column Mappings
            this.ToTable("ProductInventory", "Production");
            this.Property(t => t.Id).HasColumnName("ProductInventoryID");
            this.Property(t => t.ProductId).HasColumnName("ProductID");
            this.Property(t => t.EntryDate).HasColumnName("EntryDate");
            this.Property(t => t.Quantity).HasColumnName("Quantity");

            // Relationships
            this.HasRequired(t => t.Product)
                .WithMany(t => t.ProductInventories)
                .HasForeignKey(d => d.ProductId);

        }
    }
}
