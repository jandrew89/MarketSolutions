using MarketSolutions.Infrastructure.Common.ApplicationSettings.Implementations;
using MarketSolutions.Production.Repository.MongoDb;
using MarketSolutions.Production.Repository.MongoDb.DatabaseObjects;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDbDatabaseTester
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductionContext context = ProductionContext.Create(new WebConfigConnectionStringRepository());
            ProductCategoryMongoDb productCategory = new ProductCategoryMongoDb();
            productCategory.DbOnjectId = ObjectId.GenerateNewId();
            productCategory.ProductCategoryId = 1;
            productCategory.ProductCategoryName = "PS4 Games";
            ProductMongoDb product = new ProductMongoDb();
            product.DbOnjectId = ObjectId.GenerateNewId();
            product.ProductCategoryId = 1;
            product.DomainId = Guid.NewGuid();
            product.Description = "KOF XIV";
            product.Discontinued = false;
            product.ProductName = "King Of Fighters";
            product.UnitPrice = 59.99m;
            ProductInventoryMongoDb productInventory = new ProductInventoryMongoDb();
            productInventory.DbOnjectId = ObjectId.GenerateNewId();
            productInventory.EntryDate = DateTime.Now;
            productInventory.Product = product;
            productInventory.ProductInventoryId = 1;
            productInventory.Quantity = 100000;

            Task productsCates = context.ProductsCategory.InsertOneAsync(productCategory);
            Task products = context.Products.InsertOneAsync(product);
            Task productsInventories = context.ProductInventory.InsertOneAsync(productInventory);

            Task.WaitAll(productsCates, products, productsInventories);
        }
    }
}
