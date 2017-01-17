using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostDeleteActionTester
{
    public class ProductionViewModel
    {
        public int ProductId { get; set; }
        public int ProductCategoryId { get; set; }
        public string ProductName { get; set; }
        public string ProductCategoryName { get; set; }
        public decimal UnitPrice { get; set; }
        public string ProductDescription { get; set; }
        public bool Discontinued { get; set; }
        public int Quantity { get; set; }
    }
}
