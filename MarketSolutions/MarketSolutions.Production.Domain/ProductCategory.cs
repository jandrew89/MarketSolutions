using MarketSolutions.SharedKernal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.Domain
{
    public class ProductCategory : EntityBase<int>
    {
        public IList<Product> Products { get; set; }

        private ProductCategory() : base(new int())
        {
            this.Products = new List<Product>();
        }
        public ProductCategory(int Id, string productCategoryName) : base(Id)
        {
            if (string.IsNullOrEmpty(productCategoryName)) throw new ArgumentNullException("Product category name");
            this._productCategoryName = productCategoryName;
        }

        private string _productCategoryName;
        public string ProductCategoryName {
            get { return _productCategoryName; }
            set { if (string.IsNullOrEmpty(value)) throw new ArgumentNullException("Product Category Name"); _productCategoryName = value; } }

        public void ModifyProductCategoryName(string newProductCategoryName)
        {
            if (string.IsNullOrEmpty(newProductCategoryName)) throw new ArgumentNullException("Product category name");
            this.ProductCategoryName = newProductCategoryName;
        }
    }
}
