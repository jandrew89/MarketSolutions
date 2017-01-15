using MarketSolutions.SharedKernal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.Domain
{
    public class Product : EntityBase<int>
    {
        public ProductUnit ProductUnit;
        public string ProductName { get; private set; }
        public string Description { get; private set; }
        public IList<ProductInventory> ProductInventories { get; set; }
        public int ProductCategoryId { get; private set; }
        private Product() : base(new int())
        {
            this.ProductInventories = new List<ProductInventory>();
        }

        public Product(int Id, int productCategoryId, string productName, decimal unitPrice, 
            string productDescription, bool discontinued, ProductCategory productCategory) : base(Id)
        {
            if (productCategory == null) throw new ArgumentNullException("Product Category");
            this.ProductCategory = productCategory;
            this.Discontinued = discontinued;
            this.UnitPrice = unitPrice;
            this.ProductCategoryId = productCategoryId;
            this.ProductName = productName;
            this.ProductUnit = new ProductUnit(productName, productDescription);
        }

        private decimal _unitPrice;
        public decimal UnitPrice
        {
            get { return _unitPrice; }
            set { if (value < 0) throw new ArgumentNullException("Unit Price"); _unitPrice = value; }
        }

        private bool _discontined;
        public bool Discontinued
        {
            get { return _discontined; }
            set { _discontined = value; }
        }

        public void UpdateAvailability(bool avaliable) =>
            this._discontined = avaliable;

        private ProductCategory _productCategory;
        public ProductCategory ProductCategory
        {
            get { return _productCategory; }
            set { if (value == null) throw new ArgumentNullException("Product Category"); _productCategory = value; }
        }
    }
}
