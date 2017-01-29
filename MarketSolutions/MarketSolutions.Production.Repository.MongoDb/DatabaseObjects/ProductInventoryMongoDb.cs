using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.Repository.MongoDb.DatabaseObjects
{
    public class ProductInventoryMongoDb : MongoDbDomainBase
    {
        public int ProductInventoryId { get; set; }
        public DateTime EntryDate { get; set; }
        public ProductMongoDb Product { get; set; }
        public int Quantity { get; set; }
    }
}
