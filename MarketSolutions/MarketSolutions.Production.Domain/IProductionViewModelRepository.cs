using MarketSolutions.Production.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.Domain
{
    public interface IProductionViewModelRepository
    {
        IList<ProductionViewModel> ConvertToViewModels(IEnumerable<Product> domains);
        IList<Product> ConvertToDomain(IEnumerable<ProductionViewModel> viewModels);
    }
}
