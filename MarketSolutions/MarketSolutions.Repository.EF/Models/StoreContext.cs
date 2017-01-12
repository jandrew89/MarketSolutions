using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using MarketSolutions.Repository.EF.Models.Mapping;

namespace MarketSolutions.Repository.EF.Models
{
    public partial class StoreContext : DbContext
    {
        static StoreContext()
        {
            Database.SetInitializer<StoreContext>(null);
        }

        public StoreContext()
            : base("Name=StoreContext")
        {
        }

        public DbSet<EventLog> EventLogs { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductInventory> ProductInventories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<OrderSummary> OrderSummaries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new EventLogMap());
            modelBuilder.Configurations.Add(new EmployeeMap());
            modelBuilder.Configurations.Add(new ProductMap());
            modelBuilder.Configurations.Add(new ProductCategoryMap());
            modelBuilder.Configurations.Add(new ProductInventoryMap());
            modelBuilder.Configurations.Add(new CustomerMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new ShipperMap());
            modelBuilder.Configurations.Add(new OrderSummaryMap());
        }
    }
}
