using MarketSolutions.Production.Domain;
using MarketSolutions.Production.Repository.EF;
using MarketSolutions.Production.Repository.EF.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDatabaseTester
{
    public class ProductionContextService
    {
        public void ProductionTestingContext()
        {

            IProductionRepository productionRepo = new ProductionRepository();
            ProductCategory productCategory = new ProductCategory(1, "PS4 Games");
            IList<Product> products = productionRepo.GetProductsFromCategory(productCategory);

            
            foreach (Product product in products)
            {
                product.Discontinued = true;
                productionRepo.ModifyProduct(product);
                Debug.WriteLine($"Poduct name {product.ProductName}{product.Discontinued}");
            }
        }
    }
}
