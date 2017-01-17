using MarketSolutions.Production.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.ApplicationService.Messaging
{
    public class AddOrUpdateProductResponse : ServiceResponseBase
    {
        public Product Product { get; set; }
        public ProductCategory ProductCategory { get; set; }
        public ProductInventory ProductInventory { get; set; }
    }
}
