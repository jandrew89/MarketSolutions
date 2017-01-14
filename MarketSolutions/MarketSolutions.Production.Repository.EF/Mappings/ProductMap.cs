using MarketSolutions.Production.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MarketSolutions.Production.Repository.EF.Models.Mappings
{
    public class ProductMap : EntityTypeConfiguration<Product>
    {
        public ProductMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ProductName)
                .IsRequired()
                .HasMaxLength(100);

            this.Property(t => t.Description)
                .HasMaxLength(255);
                
            // Table & Column Mappings
            this.ToTable("Product", "Production");
            this.Property(t => t.Id).HasColumnName("ProductID");
            this.Property(t => t.ProductName).HasColumnName("ProductName");
            this.Property(t => t.ProductCategoryId).HasColumnName("ProductCategoryID");
            this.Property(t => t.UnitPrice).HasColumnName("UnitPrice");
            this.Property(t => t.Description).HasColumnName("Description");
            this.Property(t => t.Discontinued).HasColumnName("Discontinued");

            // Relationships
            this.HasRequired(t => t.ProductCategory)
                .WithMany(t => t.Products)
                .HasForeignKey(d => d.ProductCategoryId);


        }
    }
}
