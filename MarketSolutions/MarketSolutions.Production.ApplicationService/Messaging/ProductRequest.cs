using MarketSolutions.Production.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.ApplicationService.Messaging
{
    public class ProductRequest : ServiceRequestBase
    {
        private ProductCategory _productCategory;
        public ProductRequest(ProductCategory productCategory)
        {
            if (productCategory == null) throw new ArgumentNullException("Product Category");
            this._productCategory = productCategory;
        }

        public ProductCategory ProductCategory
        {
            get
            {
                return _productCategory;
            }
        }
    }
}
