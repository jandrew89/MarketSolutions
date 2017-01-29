using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.Repository.MongoDb.DatabaseObjects
{
    [BsonIgnoreExtraElements]
    public abstract class MongoObjectBase
    {
        [BsonId]
        public ObjectId DbOnjectId { get; set; }
    }
}
