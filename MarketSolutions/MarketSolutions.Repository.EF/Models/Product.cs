using System;
using System.Collections.Generic;

namespace MarketSolutions.Repository.EF.Models
{
    public partial class Product
    {
        public Product()
        {
            this.ProductInventories = new List<ProductInventory>();
            this.OrderDetails = new List<OrderDetail>();
        }

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductCategoryID { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public bool Discontinued { get; set; }
        public virtual ProductCategory ProductCategory { get; set; }
        public virtual ICollection<ProductInventory> ProductInventories { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
