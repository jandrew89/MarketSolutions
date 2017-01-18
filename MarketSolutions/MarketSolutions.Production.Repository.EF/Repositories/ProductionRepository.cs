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

        public void AddOrModifyProduct(AddOrUpdateProductionValidation validation)
        {
            ProductionContext context = new ProductionContext();

            if (validation.Product != null)
            {
                context.Entry(validation.Product).State = validation.Product.Id == 0 ? EntityState.Added : EntityState.Modified;
            }
            if (validation.ProductCategory != null)
            {
                context.Entry(validation.ProductCategory).State = validation.ProductCategory.Id == 0 ? EntityState.Added : EntityState.Modified;
            }
            if (validation.ProductInventory != null)
            {
                context.Entry(validation.ProductInventory).State = validation.ProductInventory.Id == 0 ? EntityState.Added : EntityState.Modified;
            }

            context.SaveChanges();
        }
    }
}
