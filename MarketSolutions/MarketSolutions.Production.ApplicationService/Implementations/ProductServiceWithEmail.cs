using MarketSolutions.Production.ApplicationService.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketSolutions.Production.ApplicationService.Messaging;
using MarketSolutions.Infrastructure.Common.Emailing;
using MarketSolutions.Production.Domain;

namespace MarketSolutions.Production.ApplicationService.Implementations
{
    public class ProductServiceWithEmail : IProductionService
    {
        private readonly IProductionService _innerProductionService;
        private readonly IEmailService _emailService;

        public ProductServiceWithEmail(IProductionService innerProductionService, IEmailService emailService)
        {
            if (emailService == null) throw new ArgumentNullException("Email Service");
            if (innerProductionService == null) throw new ArgumentNullException("Production Service");
            this._emailService = emailService;
            this._innerProductionService = innerProductionService;
        }

        public async Task<AddOrUpdateProductResponse> AddOrUpdateProductAsync(AddOrUpdateProductRequest addOrUpdateProductRequest)
        {
            AddOrUpdateProductResponse resp = await _innerProductionService.AddOrUpdateProductAsync(addOrUpdateProductRequest);
            if (resp.Exception == null)
            {
                EmailArguments args = new EmailArguments("Product Added or Updated", "A Product has been add or updated", "Jason", "Developer", "123.456.789");
                _emailService.SendEmail(args);
            }
            return resp;
        }

        public async Task<ProductResponse> GetProductFromCategoryAsync(ProductRequest productRequest)
        {
            ProductResponse productResponse = await _innerProductionService.GetProductFromCategoryAsync(productRequest);
            return productResponse;
        }
    }
}
