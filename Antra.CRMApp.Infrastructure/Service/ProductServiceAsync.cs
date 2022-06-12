using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using Antra.CRMApp.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Infrastructure.Service
{
    public class ProductServiceAsync : IProductServiceAsync
    {
        private readonly IProductRepositoryAsync productRepositoryAsync;
        public ProductServiceAsync(IProductRepositoryAsync _productRepositoryAsync)
        {
           productRepositoryAsync = _productRepositoryAsync;
        }

        public async Task<int> AddProductAsync(ProductRequestModel model)
        {
            Product product = new Product();
            product.Name = model.Name;
            product.SupplierId = model.SupplierId;
            product.CategoryId = model.CategoryId;
            product.QuantityPerUnit = model.QuantityPerUnit;
            product.UnitPrice = model.UnitPrice;
            product.UnitsInStock = model.UnitsInStock;
            product.UnitsOnOrder = model.UnitsOnOrder;
            product.ReorderLevel = model.ReorderLevel;
            product.Discontinued = model.Discontinued;
            product.VendorId = model.VendorId;
            return await productRepositoryAsync.InsertAsync(product);
        }

        public async Task<int> DeleteProductAsync(int id)
        {
            return await productRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<ProductResponseModel>> GetAllAsync()
        {
            var collection = await productRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<ProductResponseModel> productModels = new List<ProductResponseModel>();
                foreach (var item in collection)
                {
                    ProductResponseModel model = new ProductResponseModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.SupplierId = item.SupplierId;
                    model.CategoryId = item.CategoryId;
                    model.QuantityPerUnit = item.QuantityPerUnit;
                    model.UnitPrice = item.UnitPrice;
                    model.UnitsInStock = item.UnitsInStock;
                    model.UnitsOnOrder = item.UnitsOnOrder;
                    model.ReorderLevel = item.ReorderLevel;
                    model.Discontinued = item.Discontinued;
                    model.VendorId = item.VendorId;
                    productModels.Add(model);
                }
                return productModels;
            }
            return null;
        }

        public async Task<int> UpdateProductAsync(ProductRequestModel model)
        {
            Product product = new Product();
            product.Id = model.Id;
            product.Name = model.Name;
            product.SupplierId = model.SupplierId;
            product.CategoryId = model.CategoryId;
            product.QuantityPerUnit = model.QuantityPerUnit;
            product.UnitPrice = model.UnitPrice;
            product.UnitsInStock = model.UnitsInStock;
            product.UnitsOnOrder = model.UnitsOnOrder;
            product.ReorderLevel = model.ReorderLevel;
            product.Discontinued = model.Discontinued;
            product.VendorId = model.VendorId;
            return await productRepositoryAsync.UpdateAsync(product);
        }

        public async Task<ProductRequestModel> GetProductForEditAsync(int id)
        {
            var item = await productRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                ProductRequestModel model = new ProductRequestModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.SupplierId = item.SupplierId;
                model.CategoryId = item.CategoryId;
                model.QuantityPerUnit = item.QuantityPerUnit;
                model.UnitPrice = item.UnitPrice;
                model.UnitsInStock = item.UnitsInStock;
                model.UnitsOnOrder = item.UnitsOnOrder;
                model.ReorderLevel = item.ReorderLevel;
                model.Discontinued = item.Discontinued;
                model.VendorId = item.VendorId;
                return model;
            }
            return null;
        }
    }
}
