using MarketSolutions.Production.Domain;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MarketSolutions.Production.Repository.EF.Models.Mappings
{
    public class ProductCategoryMap : EntityTypeConfiguration<ProductCategory>
    {
        public ProductCategoryMap()
        {
            // Primary Key
            this.HasKey(t => t.Id);

            // Properties
            this.Property(t => t.ProductCategoryName)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("ProductCategory", "Production");
            this.Property(t => t.Id).HasColumnName("ProductCategoryID");
            this.Property(t => t.ProductCategoryName).HasColumnName("ProductCategoryName");
        }
    }
}
