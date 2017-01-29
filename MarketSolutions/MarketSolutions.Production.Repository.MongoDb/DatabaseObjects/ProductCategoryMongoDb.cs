using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.Repository.MongoDb.DatabaseObjects
{
    public class ProductCategoryMongoDb : MongoDbDomainBase
    {
        public int ProductCategoryId { get; set; }
        public string ProductCategoryName { get; set; }
    }
}
