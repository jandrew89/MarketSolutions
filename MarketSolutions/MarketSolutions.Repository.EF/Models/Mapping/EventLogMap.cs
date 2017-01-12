using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace MarketSolutions.Repository.EF.Models.Mapping
{
    public class EventLogMap : EntityTypeConfiguration<EventLog>
    {
        public EventLogMap()
        {
            // Primary Key
            this.HasKey(t => t.EventLogID);

            // Properties
            this.Property(t => t.Key)
                .IsRequired()
                .HasMaxLength(255);

            this.Property(t => t.Message)
                .IsRequired();

            // Table & Column Mappings
            this.ToTable("EventLog");
            this.Property(t => t.EventLogID).HasColumnName("EventLogID");
            this.Property(t => t.EventType).HasColumnName("EventType");
            this.Property(t => t.Key).HasColumnName("Key");
            this.Property(t => t.Message).HasColumnName("Message");
            this.Property(t => t.EntryDate).HasColumnName("EntryDate");
        }
    }
}
