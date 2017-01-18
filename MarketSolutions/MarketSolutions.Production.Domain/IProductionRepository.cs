using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.Domain
{
    public interface IProductionRepository
    {
        IList<Product> GetProductsFromCategory(ProductCategory productCategory);
        void AddOrModifyProduct(AddOrUpdateProductionValidation validation);
    }
}
