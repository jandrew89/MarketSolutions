using MarketSolutions.SharedKernal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.Domain
{
    public class ProductUnit : ValueObjectBase<ProductUnit>
    {
        public string ProductName { get; private set; }
        public string ProductDescription { get; private set; }

        public ProductUnit(string productName, string productDescription)
        {
            if (string.IsNullOrEmpty(productName)) throw new ArgumentNullException("Product Name");
            if (string.IsNullOrEmpty(productDescription)) throw new ArgumentNullException("Product Description");
            this.ProductName = productName;
            this.ProductDescription = productDescription;
        }

        public ProductUnit WithProductName(string productName) =>
                new ProductUnit(productName, this.ProductDescription);

        public ProductUnit WithProductDescription(string productDescription) =>
                new ProductUnit(this.ProductName, productDescription);


        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is ProductUnit)) return false;
            return this.Equals((ProductUnit)obj);
        }

        public override bool Equals(ProductUnit other)
        {
            return this.ProductName.Equals(other.ProductName, StringComparison.InvariantCultureIgnoreCase)
           && this.ProductDescription.Equals(other.ProductDescription, StringComparison.InvariantCultureIgnoreCase);
        }

        public override int GetHashCode()
        {
            return this.ProductName.GetHashCode() + this.ProductDescription.GetHashCode();
        }
    }
}
