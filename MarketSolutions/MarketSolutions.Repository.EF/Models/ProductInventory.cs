using System;
using System.Collections.Generic;

namespace MarketSolutions.Repository.EF.Models
{
    public partial class ProductInventory
    {
        public int ProductInventoryID { get; set; }
        public int ProductID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
    }
}
