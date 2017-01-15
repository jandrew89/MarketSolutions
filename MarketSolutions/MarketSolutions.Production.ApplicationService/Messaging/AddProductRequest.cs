using MarketSolutions.Production.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.ApplicationService.Messaging
{
    public class AddProductRequest : ServiceRequestBase
    {
        private Product _product;
        public AddProductRequest(Product product)
        {
            if (product == null) throw new ArgumentNullException("Product");
            this._product = product;
        }

        public Product Product
        {
            get
            {
                return _product;
            }
        }
    }
}
