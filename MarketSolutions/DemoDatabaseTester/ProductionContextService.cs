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
            //ProductionContext context = new ProductionContext();
            //List<ProductInventory> products = context.ProductInventories.ToList();

            //foreach (ProductInventory pro in products)
            //{
            //    Debug.WriteLine($"{pro.EntryDate}{pro.Quantity}");
            //}
            IProductionRepository productionRepo = new ProductionRepository();
            ProductCategory productCategory = new ProductCategory(1, "PS4 Games");
            IList<Product> products = productionRepo.GetProductsFromCategory(productCategory);
            IList<ProductInventory> productIn = productionRepo.GetProductInventory();
            foreach (Product product in products)
            {
                Debug.WriteLine($"Poduct name {product.ProductName}");
            }
        }
    }
}
