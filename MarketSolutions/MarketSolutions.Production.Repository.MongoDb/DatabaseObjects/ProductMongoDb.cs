using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.Repository.MongoDb.DatabaseObjects
{
    public class ProductMongoDb : MongoDbDomainBase
    {
        [BsonRepresentation(BsonType.String)]
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductCategoryId { get; set; }
        public decimal UnitPrice { get; set; }
        public string Description { get; set; }
        public bool Discontinued { get; set; }
        public int ProductInventoryId { get; set; }
    }
}
