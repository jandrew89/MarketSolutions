using MarketSolutions.Production.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void ModifyProduct(Product product)
        {
            ProductionContext context = new ProductionContext();
            context.Entry<Product>(product).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
