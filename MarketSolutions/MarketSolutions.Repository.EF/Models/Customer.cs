using System;
using System.Collections.Generic;

namespace MarketSolutions.Repository.EF.Models
{
    public partial class Customer
    {
        public Customer()
        {
            this.Orders = new List<Order>();
        }

        public int CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
