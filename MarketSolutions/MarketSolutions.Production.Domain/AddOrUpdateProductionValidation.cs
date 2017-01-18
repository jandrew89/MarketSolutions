using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.Domain
{
    public class AddOrUpdateProductionValidation
    {
        public Product Product { get; private set; }
        public ProductCategory ProductCategory { get; private set; }
        public ProductInventory ProductInventory { get; private set; }
        public AddOrUpdateProductionValidation(Product product, ProductCategory productCategory, ProductInventory productInventory )
        {
            this.Product = product;
            this.ProductCategory = productCategory;
            this.ProductInventory = productInventory;
        }
    }
}
