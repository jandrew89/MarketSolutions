using System;
using System.Collections.Generic;

namespace MarketSolutions.Repository.EF.Models
{
    public partial class ProductCategory
    {
        public ProductCategory()
        {
            this.Products = new List<Product>();
        }

        public int ProductCategoryID { get; set; }
        public string ProductCategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
