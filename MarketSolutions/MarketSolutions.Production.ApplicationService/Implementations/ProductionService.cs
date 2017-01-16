﻿using MarketSolutions.Production.ApplicationService.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketSolutions.Production.ApplicationService.Messaging;
using MarketSolutions.Production.Domain;

namespace MarketSolutions.Production.ApplicationService.Implementations
{
    public class ProductionService : IProductionService
    {
        private readonly IProductionRepository _productionRepository;
        private readonly IProductionViewModelRepository _productionViewModelRepository;

        public ProductionService(IProductionRepository productionRepository, IProductionViewModelRepository productionViewModelRepository)
        {
            if (productionRepository == null) throw new ArgumentNullException("Production Repository");
            if (productionViewModelRepository == null) throw new ArgumentNullException("Production View Model Repository");
            this._productionRepository = productionRepository;
            this._productionViewModelRepository = productionViewModelRepository;
        }

        public async Task<ProductResponse> GetProductFromCategoryAsync(ProductRequest productRequest)
        {
            return await Task<ProductResponse>.Run(() => GetProductFromCategory(productRequest));
        }

        private ProductResponse GetProductFromCategory(ProductRequest productRequest)
        {
            ProductResponse resp = new ProductResponse();
            try
            {
                IList<Product> products = _productionRepository.GetProductsFromCategory(productRequest.ProductCategory);
                IEnumerable<ProductionViewModel> proViewModels = _productionViewModelRepository.ConvertToViewModels(products);
                resp.Product = proViewModels;
            }
            catch (Exception ex)
            {
                resp.Exception = ex;
            }
            return resp;
        }
    }
}