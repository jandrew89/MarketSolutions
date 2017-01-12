using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MarketSolutions.Repository.EF.Models.Mapping
{
    public class OrderMap : EntityTypeConfiguration<Order>
    {
        public OrderMap()
        {
            // Primary Key
            this.HasKey(t => t.OrderID);

            // Properties
            this.Property(t => t.Comments)
                .HasMaxLength(255);

            this.Property(t => t.CreationUser)
                .IsRequired()
                .HasMaxLength(25);

            this.Property(t => t.LastUpdateUser)
                .HasMaxLength(25);

            // Table & Column Mappings
            this.ToTable("Order", "Sales");
            this.Property(t => t.OrderID).HasColumnName("OrderID");
            this.Property(t => t.OrderDate).HasColumnName("OrderDate");
            this.Property(t => t.CustomerID).HasColumnName("CustomerID");
            this.Property(t => t.EmployeeID).HasColumnName("EmployeeID");
            this.Property(t => t.ShipperID).HasColumnName("ShipperID");
            this.Property(t => t.Total).HasColumnName("Total");
            this.Property(t => t.Comments).HasColumnName("Comments");
            this.Property(t => t.CreationUser).HasColumnName("CreationUser");
            this.Property(t => t.CreationDateTime).HasColumnName("CreationDateTime");
            this.Property(t => t.LastUpdateUser).HasColumnName("LastUpdateUser");
            this.Property(t => t.LastUpdateDateTime).HasColumnName("LastUpdateDateTime");

            // Relationships
            this.HasRequired(t => t.Employee)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.EmployeeID);
            this.HasRequired(t => t.Customer)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.CustomerID);
            this.HasRequired(t => t.Shipper)
                .WithMany(t => t.Orders)
                .HasForeignKey(d => d.ShipperID);

        }
    }
}
