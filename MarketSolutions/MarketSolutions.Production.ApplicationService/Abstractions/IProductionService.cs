using MarketSolutions.Production.ApplicationService.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.ApplicationService.Abstractions
{
    public interface IProductionService
    {
        Task<ProductResponse> GetProductFromCategoryAsync(ProductRequest productRequest);
        Task<AddOrUpdateProductResponse> AddOrUpdateProductAsync(AddOrUpdateProductRequest addOrUpdateProductRequest);
    }
}
