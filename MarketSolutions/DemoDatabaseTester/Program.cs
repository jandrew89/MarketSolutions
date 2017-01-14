using MarketSolutions.Production.Repository.EF;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoDatabaseTester
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductionContextService domainService = new ProductionContextService();

            domainService.ProductionTestingContext();

            //StoreContext context = new StoreContext();

            //List<Product> products = context.Products.ToList();
            //foreach (Product product in products)
            //{
            //    Debug.WriteLine($"Product ID: {product.ProductID}, Product name {product.ProductName}, Unit Price {product.UnitPrice}");
            //}
        }
    }
}
