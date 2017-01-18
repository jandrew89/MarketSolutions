using MarketSolutions.Production.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketSolutions.Production.Repository.EF.Repositories
{
    public class ProductionViewModelRepository : IProductionViewModelRepository
    {

        public AddOrUpdateProductionValidation ConvertProductViewModelToDomain(ProductionViewModel viewModel)
        {
            ProductionContext context = new ProductionContext();
            AddOrUpdateProductionValidation validation = new AddOrUpdateProductionValidation();

            ProductCategory productCategory = ConvertToProductCategory(viewModel.ProductCategoryId, viewModel.ProductCategoryName);
            validation.ProductCategory = productCategory;

            Product newProduct = new Product(viewModel.ProductId, viewModel.ProductCategoryId, viewModel.ProductName, viewModel.UnitPrice,
              viewModel.ProductDescription, viewModel.Discontinued, productCategory);

            ProductInventory productInventory = ConvertToProductInventory(newProduct, viewModel.Quantity);
            validation.Product = newProduct;
            validation.ProductInventory = productInventory;
       
            return validation;            
        }

        private ProductCategory ConvertToProductCategory(int id, string productCategoryName)
        {
            ProductionContext context = new ProductionContext();

            ProductCategory prodCategory = (from c in context.ProductCategories
                                            where c.ProductCategoryName.Equals(productCategoryName, StringComparison.InvariantCultureIgnoreCase)
                                            || c.Id.Equals(id)
                                            select c).FirstOrDefault();

            if (prodCategory == null) throw new ArgumentException("There is no Product Category with the given name or id.");

            return prodCategory;
        }

        private ProductInventory ConvertToProductInventory(Product product, int quantity)
        {
            ProductionContext context = new ProductionContext();

            ProductInventory prodInventory = context.ProductInventories.Where(pi => pi.ProductId == product.Id).SingleOrDefault();

            if (prodInventory == null)
            {
                ProductInventory newProductInventory = new ProductInventory(0, product.Id, product, DateTime.Now, quantity);
                return newProductInventory;
            }

            prodInventory.ModifyQuantity(quantity);

            return prodInventory;
        }

        public IList<Product> ConvertToDomains(IEnumerable<ProductionViewModel> viewModels)
        {
            List<Product> products = new List<Product>();
            ProductionContext context = new ProductionContext();
            foreach (ProductionViewModel vm in viewModels)
            {
                ProductCategory productCategory = context.ProductCategories.Where(pc => pc.Id == vm.ProductCategoryId).SingleOrDefault();
                if (productCategory == null) throw new ArgumentNullException("Product Category");

                ProductInventory productInventory = context.ProductInventories.Where(pi => pi.ProductId == vm.ProductId).SingleOrDefault();
                if (productInventory == null) throw new ArgumentNullException("Product Inventory");


                Product product = new Product(vm.ProductId, vm.ProductCategoryId, vm.ProductName, vm.UnitPrice, vm.ProductDescription, vm.Discontinued, productCategory);
                products.Add(product);
            }
            return products;
        }

        public IList<ProductionViewModel> ConvertToViewModels(IEnumerable<Product> domains)
        {
            ProductionContext context = new ProductionContext();
            List<ProductionViewModel> viewModels = new List<ProductionViewModel>();
            foreach (Product product in domains)
            {
                ProductionViewModel vm = new ProductionViewModel();
                ProductInventory productInventory = context.ProductInventories.Where(pi => pi.ProductId == product.Id).SingleOrDefault();
                if (productInventory == null) throw new ArgumentNullException("No Product Inventory");
                vm.Quantity = productInventory.Quantity;

                ProductCategory productCategory = context.ProductCategories.Where(pc => pc.Id == product.ProductCategoryId).SingleOrDefault();
                if (productCategory == null) throw new ArgumentNullException("No Product Category");
                vm.ProductCategoryName = productCategory.ProductCategoryName;
                vm.ProductCategoryId = productCategory.Id;

                vm.Discontinued = product.Discontinued;
                vm.ProductDescription = product.Description;
                vm.UnitPrice = product.UnitPrice;
                vm.ProductId = product.Id;
                vm.ProductName = product.ProductName;

                viewModels.Add(vm);
            }

            return viewModels;
        }
    }
}
