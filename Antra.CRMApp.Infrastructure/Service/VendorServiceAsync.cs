using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Infrastructure.Service
{
    public class VendorServiceAsync : IVendorServiceAsync
    {
        private readonly IVendorRepositoryAsync vendorRepositoryAsync;
        public VendorServiceAsync(IVendorRepositoryAsync repo)
        {
            vendorRepositoryAsync = repo;
        }
        public async Task<int> AddVendorAsync(VendorModel model)
        {
            Vendor vendor = new Vendor();
            vendor.Name = model.Name;
            vendor.City = model.City;
            vendor.Country = model.Country;
            vendor.Mobile = model.Mobile;
            vendor.EmailId = model.EmailId;
            vendor.IsActive = model.IsActive;
            return await vendorRepositoryAsync.InsertAsync(vendor);
        }

        public async Task<int> DeleteVendorAsync(int id)
        {
            return await vendorRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<VendorModel>> GetAllAsync()
        {
            var collection = await vendorRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<VendorModel> VendorModels = new List<VendorModel>();
                foreach (var item in collection)
                {
                    VendorModel model = new VendorModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.City = item.City;
                    model.Country = item.Country;
                    model.Mobile = item.Mobile;
                    model.EmailId = item.EmailId;
                    model.IsActive = item.IsActive;
                    VendorModels.Add(model);
                }
                return VendorModels;
            }
            return null;
        }

        public async Task<int> UpdateVendorAsync(VendorModel model)
        {
            Vendor vendor = new Vendor();
            vendor.Id = model.Id;
            vendor.Name = model.Name;
            vendor.City = model.City;
            vendor.Country = model.Country;
            vendor.Mobile = model.Mobile;
            vendor.EmailId = model.EmailId;
            vendor.IsActive = model.IsActive;
            return await vendorRepositoryAsync.UpdateAsync(vendor);
        }

        public async Task<VendorModel> GetVendorForEditAsync(int id)
        {
            var item = await vendorRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                VendorModel model = new VendorModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.City = item.City;
                model.Country = item.Country;
                model.Mobile = item.Mobile;
                model.EmailId = item.EmailId;
                model.IsActive = item.IsActive;
                return model;
            }
            return null;
        }
    }
}
