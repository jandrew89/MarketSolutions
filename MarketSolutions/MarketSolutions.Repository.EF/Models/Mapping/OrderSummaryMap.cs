using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MarketSolutions.Repository.EF.Models.Mapping
{
    public class OrderSummaryMap : EntityTypeConfiguration<OrderSummary>
    {
        public OrderSummaryMap()
        {
            // Primary Key
            this.HasKey(t => new { t.OrderID, t.OrderDate, t.EmployeeName });

            // Properties
            this.Property(t => t.OrderID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.CustomerName)
                .HasMaxLength(100);

            this.Property(t => t.EmployeeName)
                .IsRequired()
                .HasMaxLength(77);

            this.Property(t => t.ShipperName)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("OrderSummary");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");
            this.Property(t => t.CustomerName).HasColumnName("CustomerName");
            this.Property(t => t.EmployeeName).HasColumnName("EmployeeName");
            this.Property(t => t.ShipperName).HasColumnName("ShipperName");
        }
    }
}
