using System;
using System.Collections.Generic;

namespace MarketSolutions.Repository.EF.Models
{
    public partial class OrderSummary
    {
        public int OrderID { get; set; }
        public System.DateTime OrderDate { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeName { get; set; }
        public string ShipperName { get; set; }
    }
}
