using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.Repository.MongoDb.DatabaseObjects
{
    public abstract class MongoDbDomainBase : MongoObjectBase
    {
        [BsonRepresentation(BsonType.String)]
        public Guid DomainId { get; set; }
    }
}
