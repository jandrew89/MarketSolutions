using System;
using System.Collections.Generic;

namespace MarketSolutions.Repository.EF.Models
{
    public partial class Shipper
    {
        public Shipper()
        {
            this.Orders = new List<Order>();
        }

        public int ShipperID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
