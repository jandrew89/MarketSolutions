using MarketSolutions.Production.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.ApplicationService.Messaging
{
    public class AddOrUpdateProductRequest : ServiceRequestBase
    {
        private ProductionViewModel _productionViewModel;

        public AddOrUpdateProductRequest(ProductionViewModel productionViewModel)
        {
            if (productionViewModel == null) throw new ArgumentNullException("Production View Model");
            this._productionViewModel = productionViewModel;
        }

        public ProductionViewModel ProductionViewModel
        {
            get { return _productionViewModel; }
        }
    }
}
