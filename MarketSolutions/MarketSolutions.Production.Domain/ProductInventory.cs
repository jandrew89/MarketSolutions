using MarketSolutions.SharedKernal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.Domain
{
    public class ProductInventory : EntityBase<int>
    {

        public int ProductId { get; private set; }
        public DateTime EntryDate { get; private set; }
        public int Quantity { get; private set; }
        public Product Product { get; private set; }
        private ProductInventory() : base(new int())
        {

        }

        public ProductInventory(int Id, int productId, Product product, DateTime entryDate, int quantity) : base(Id)
        {
            if (entryDate == null || entryDate.GetType() != typeof(DateTime)) throw new ArgumentException("Valid Date Time");
            
            if (quantity < 0) throw new ArgumentNullException("Quantity");
            this.ProductId = productId;
            this.EntryDate = entryDate;
            this.Quantity = quantity;
            this.Product = product;
        }

        public void ModifyQuantity(int newQuantity)
        {
            if (newQuantity < 0) throw new ArgumentNullException("Quantity");
            this.Quantity = newQuantity;
        }
    }
}
