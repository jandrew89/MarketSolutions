using MarketSolutions.Production.ApplicationService.Abstractions;
using MarketSolutions.Production.ApplicationService.Messaging;
using MarketSolutions.Production.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace MarketSolutions.WebApi.Controllers
{
    public class ProductionController : ApiController
    {
        private readonly IProductionService _productionService;

        public ProductionController(IProductionService productionService)
        {
            if (productionService == null) throw new ArgumentNullException("Production Service");
            this._productionService = productionService;
        }

        public async Task<IHttpActionResult> Get()
        {
            ProductRequest productRequest = new ProductRequest(new ProductCategory(1, "PS4 Games"));
            ProductResponse productResponse = await _productionService.GetProductFromCategoryAsync(productRequest);
            if (productResponse.Exception == null)
            {
                return Ok<IEnumerable<ProductionViewModel>>(productResponse.Product);
            }

            return InternalServerError(productResponse.Exception);
        }

    }
}
