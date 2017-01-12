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
        public Product Product { get; private set; }
        public DateTime EntryDate { get; private set; }
        public int Quantity { get; private set; }

        public ProductInventory(int id, Product product, DateTime entryDate, int quantity) : base(id)
        {
            if (entryDate == null || entryDate.GetType() != typeof(DateTime)) throw new ArgumentException("Valid Date Time");
            if (product == null) throw new ArgumentNullException("Product");
            if (quantity < 0) throw new ArgumentNullException("Quantity");
            this.Product = product;
            this.EntryDate = entryDate;
            this.Quantity = quantity;
        }

        public void ModifyQuantity(int newQuantity)
        {
            if (newQuantity < 0) throw new ArgumentNullException("Quantity");
            this.Quantity = newQuantity;
        }
    }
}
