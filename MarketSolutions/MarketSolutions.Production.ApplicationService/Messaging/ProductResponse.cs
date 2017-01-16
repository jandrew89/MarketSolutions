using MarketSolutions.Production.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.ApplicationService.Messaging
{
    public class ProductResponse : ServiceResponseBase
    {
        public IEnumerable<ProductionViewModel> Product { get; set; }
    }
}
