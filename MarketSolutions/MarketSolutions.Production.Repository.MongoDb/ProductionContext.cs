using MarketSolutions.Infrastructure.Common.ApplicationSettings;
using MarketSolutions.Production.Repository.MongoDb.DatabaseObjects;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.Repository.MongoDb
{
    public class ProductionContext
    {
        private IMongoClient Client { get; set; }
        private IMongoDatabase Database { get; set; }
        private const string _databaseName = "Production";
        private static ProductionContext _productionContext;

        private ProductionContext() { }

        public static ProductionContext Create(IConnectionStringRepository connectionStringRepository)
        {
            if (_productionContext == null)
            {
                _productionContext = new ProductionContext();
                string connectionString = connectionStringRepository.ReadConnectionString("MongoDbProductionContext");
                _productionContext.Client = new MongoClient(connectionString);
                _productionContext.Database = _productionContext.Client.GetDatabase("Production");
            }
            return _productionContext;
        }

        public IMongoCollection<ProductMongoDb> Products
        {
            get { return Database.GetCollection<ProductMongoDb>("Products"); }
        }

        public IMongoCollection<ProductCategoryMongoDb> ProductsCategory
        {
            get { return Database.GetCollection<ProductCategoryMongoDb>("ProductsCategory"); }
        }

        public IMongoCollection<ProductInventoryMongoDb> ProductInventory
        {
            get { return Database.GetCollection<ProductInventoryMongoDb>("ProductInventory"); }
        }
    }
}
