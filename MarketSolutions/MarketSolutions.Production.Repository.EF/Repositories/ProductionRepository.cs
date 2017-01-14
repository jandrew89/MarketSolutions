using MarketSolutions.Production.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.Repository.EF.Repositories
{
    public class ProductionRepository : IProductionRepository
    {
        public IList<Product> GetProductsFromCategory(ProductCategory productCategory)
        {
            ProductionContext context = new ProductionContext();
            IList<Product> productsWithCategory = context.Products.Where(p => p.ProductCategory.Id == productCategory.Id).ToList();
            return productsWithCategory;
        }

        public IList<ProductInventory> GetProductInventory()
        {
            ProductionContext context = new ProductionContext();
            IList<ProductInventory> products = context.ProductInventories.ToList();
            return products;
        }
    }
}
