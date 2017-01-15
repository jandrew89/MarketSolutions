using MarketSolutions.Production.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.ApplicationService.Messaging
{
    public class AddOrUpdateProductsRequest : ServiceRequestBase
    {
        private IEnumerable<ProductionViewModel> _productionViewModels;

        public AddOrUpdateProductsRequest(IEnumerable<ProductionViewModel> productionViewModels)
        {
            if (productionViewModels == null) throw new ArgumentNullException("Production View Models");
            this._productionViewModels = productionViewModels;
        }

        public IEnumerable<ProductionViewModel> ProductionViewModels
        {
            get { return _productionViewModels; }
        }
    }
}
